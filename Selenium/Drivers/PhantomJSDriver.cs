using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Web driver for PhantomJS（COM 互換のため型のみ保持。本フォークでは未サポート）
    /// </summary>
    [ProgId("Selenium.PhantomJSDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-0809389E78C4")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class PhantomJSDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "phantomjs";

        public PhantomJSDriver()
            : base(BROWSER_NAME) { }
    }
}
