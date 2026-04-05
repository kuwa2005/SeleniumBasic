using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Web driver for Firefox（COM 互換のため型のみ保持。起動ロジックは未サポート）
    /// </summary>
    [ProgId("Selenium.FirefoxDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-14DB1E4916D4")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class FirefoxDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "firefox";

        public FirefoxDriver()
            : base(BROWSER_NAME) { }
    }
}
