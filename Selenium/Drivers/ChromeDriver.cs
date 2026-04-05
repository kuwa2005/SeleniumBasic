using Selenium.Core;
using Selenium.Internal;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Web driver for Chrome
    /// </summary>
    /// 
    /// <example>
    /// 
    /// VBScript:
    /// <code lang="vbs">	
    /// Class Script
    ///     Dim driver
    ///     
    ///     Sub Class_Initialize
    ///         Set driver = CreateObject("Selenium.ChromeDriver")
    ///         driver.Get "http://www.google.com"
    ///     End Sub
    /// 
    ///     Sub Class_Terminate
    ///         driver.Quit
    ///     End Sub
    /// End Class
    /// 
    /// Set s = New Script
    /// </code>
    /// 
    /// VBA:
    /// <code lang="vbs">	
    /// Public Sub Script()
    ///   Dim driver As New ChromeDriver
    ///   driver.Get "http://www.google.com"
    ///   ...
    ///   driver.Quit
    /// End Sub
    /// </code>
    /// 
    /// </example>
    [ProgId("Selenium.ChromeDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-5D556733E8C9")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class ChromeDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "chrome";

        public ChromeDriver()
            : base(BROWSER_NAME) { }

        internal static IDriverService StartService(WebDriver wd) {
            ExtendCapabilities(wd, false);

            var svc = new DriverService();
            svc.AddArgument("--port=" + svc.IPEndPoint.Port.ToString());
            svc.AddArgument("--silent");
            svc.Start(ResolveChromeDriverPath(wd));
            return svc;
        }

        /// <summary>
        /// chromedriver の実体を解決する。優先順: chrome.serverBinary → 環境変数 → Selenium.dll と同じフォルダ配下 → PATH。
        /// </summary>
        static string ResolveChromeDriverPath(WebDriver wd) {
            Capabilities capa = wd.Capabilities;
            object o;
            if (capa.TryGetValue<object>("chrome.serverBinary", out o)) {
                capa.Remove("chrome.serverBinary");
                string p = Convert.ToString(o);
                if (!string.IsNullOrEmpty(p) && File.Exists(p))
                    return Path.GetFullPath(p);
            }

            foreach (string envName in new[] { "CHROMEDRIVER_PATH", "webdriver.chrome.driver", "CHROMEDRIVER" }) {
                string ev = Environment.GetEnvironmentVariable(envName);
                if (!string.IsNullOrEmpty(ev) && File.Exists(ev))
                    return Path.GetFullPath(ev);
            }

            string lib = IOExt.GetAssemblyDirectory();
            foreach (string candidate in GetBundledStyleChromeDriverPaths(lib)) {
                if (File.Exists(candidate))
                    return Path.GetFullPath(candidate);
            }

            string fromPath = FindChromeDriverInPath();
            if (!string.IsNullOrEmpty(fromPath))
                return fromPath;

            string fallback = Path.Combine(lib, "chromedriver.exe");
            throw new Errors.FileNotFoundError(fallback);
        }

        static string[] GetBundledStyleChromeDriverPaths(string libraryDir) {
            return new[] {
                Path.Combine(libraryDir, "chromedriver.exe"),
                Path.Combine(libraryDir, "chromedriver-win64", "chromedriver.exe"),
                Path.Combine(libraryDir, "chromedriver-win32", "chromedriver.exe"),
                Path.Combine(libraryDir, "chromedriver", "chromedriver.exe")
            };
        }

        static string FindChromeDriverInPath() {
            string path = Environment.GetEnvironmentVariable("PATH");
            if (string.IsNullOrEmpty(path))
                return null;
            foreach (string dir in path.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)) {
                try {
                    string trimmed = dir.Trim().Trim('"');
                    if (trimmed.Length == 0)
                        continue;
                    string full = Path.Combine(trimmed, "chromedriver.exe");
                    if (File.Exists(full))
                        return Path.GetFullPath(full);
                } catch {
                }
            }
            return null;
        }

        internal static void ExtendCapabilities(WebDriver wd, bool remote) {
            Capabilities capa = wd.Capabilities;

            if (remote)
                capa.Remove("chrome.serverBinary");

            Dictionary opts;
            if (!capa.TryGetValue("chromeOptions", out opts))
                capa["chromeOptions"] = opts = new Dictionary();

            capa.TryMove("debuggerAddress", opts);

            if (wd.Profile != null)
                wd.Arguments.Add("user-data-dir=" + ExpandProfile(wd.Profile, remote));

            if (wd.Arguments.Count != 0)
                opts["args"] = wd.Arguments;

            if (wd.Extensions.Count != 0)
                opts["extensions"] = wd.Extensions;

            if (wd.Preferences.Count != 0)
                opts["prefs"] = wd.Preferences;

            if (wd.Binary != null)
                opts["binary"] = wd.Binary;

            capa.SetDefault("download.directory_upgrade", true);
            capa.SetDefault("download.prompt_for_download", false);
        }

        private static string ExpandProfile(string profile, bool remote) {
            if (!remote) {
                if (IOExt.IsPath(profile)) {
                    profile = IOExt.ExpandPath(profile);
                } else {
                    profile = IOExt.AppDataFolder + @"\Google\Chrome\Profiles\" + profile;
                }
                Directory.CreateDirectory(profile);
            }
            return profile;
        }

    }

}
