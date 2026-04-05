using Selenium.Core;
using Selenium.Internal;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Microsoft Edge（Chromium）用 WebDriver。ローカルは msedgedriver.exe（または edgedriver.exe）。
    /// </summary>
    [ProgId("Selenium.EdgeDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-3C406728F1A2")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class EdgeDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "MicrosoftEdge";

        public EdgeDriver()
            : base(BROWSER_NAME) { }

        internal static IDriverService StartService(WebDriver wd) {
            ExtendCapabilities(wd, false);

            var svc = new DriverService();
            svc.AddArgument("--host=localhost");
            svc.AddArgument("--port=" + svc.IPEndPoint.Port.ToString());
            svc.Start(ResolveEdgeDriverPath(wd), true);
            return svc;
        }

        /// <summary>
        /// msedgedriver の実体を解決。優先: edge.serverBinary → 環境変数 → dll 同梱フォルダ → PATH。
        /// </summary>
        static string ResolveEdgeDriverPath(WebDriver wd) {
            Capabilities capa = wd.Capabilities;
            object o;
            if (capa.TryGetValue<object>("edge.serverBinary", out o)) {
                capa.Remove("edge.serverBinary");
                string p = Convert.ToString(o);
                if (!string.IsNullOrEmpty(p) && File.Exists(p))
                    return Path.GetFullPath(p);
            }

            foreach (string envName in new[] { "EDGEWEBDRIVER_PATH", "webdriver.edge.driver", "EDGEDRIVER", "MSEDGEDRIVER" }) {
                string ev = Environment.GetEnvironmentVariable(envName);
                if (!string.IsNullOrEmpty(ev) && File.Exists(ev))
                    return Path.GetFullPath(ev);
            }

            string lib = IOExt.GetAssemblyDirectory();
            foreach (string candidate in GetBundledStyleEdgeDriverPaths(lib)) {
                if (File.Exists(candidate))
                    return Path.GetFullPath(candidate);
            }

            string fromPath = FindEdgeDriverInPath();
            if (!string.IsNullOrEmpty(fromPath))
                return fromPath;

            string fallback = Path.Combine(lib, "msedgedriver.exe");
            throw new Errors.FileNotFoundError(fallback);
        }

        static string[] GetBundledStyleEdgeDriverPaths(string libraryDir) {
            return new[] {
                Path.Combine(libraryDir, "msedgedriver.exe"),
                Path.Combine(libraryDir, "edgedriver.exe"),
                Path.Combine(libraryDir, "edgedriver-win64", "msedgedriver.exe"),
                Path.Combine(libraryDir, "edgedriver-win64", "edgedriver.exe")
            };
        }

        static string FindEdgeDriverInPath() {
            string path = Environment.GetEnvironmentVariable("PATH");
            if (string.IsNullOrEmpty(path))
                return null;
            foreach (string exe in new[] { "msedgedriver.exe", "edgedriver.exe" }) {
                foreach (string dir in path.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)) {
                    try {
                        string trimmed = dir.Trim().Trim('"');
                        if (trimmed.Length == 0)
                            continue;
                        string full = Path.Combine(trimmed, exe);
                        if (File.Exists(full))
                            return Path.GetFullPath(full);
                    } catch {
                    }
                }
            }
            return null;
        }

        internal static void ExtendCapabilities(WebDriver wd, bool remote) {
            Capabilities capa = wd.Capabilities;

            if (remote)
                capa.Remove("edge.serverBinary");

            Dictionary opts;
            if (!capa.TryGetValue("edgeOptions", out opts))
                capa["edgeOptions"] = opts = new Dictionary();

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

            wd.MergeExcludeEnableAutomationIntoOptions(opts);

            capa.SetDefault("download.directory_upgrade", true);
            capa.SetDefault("download.prompt_for_download", false);
        }

        static string ExpandProfile(string profile, bool remote) {
            if (!remote) {
                if (IOExt.IsPath(profile)) {
                    profile = IOExt.ExpandPath(profile);
                } else {
                    string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    profile = Path.Combine(local, "Microsoft", "Edge", "User Data", profile);
                }
                Directory.CreateDirectory(profile);
            }
            return profile;
        }

    }

}
