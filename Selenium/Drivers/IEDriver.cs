using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Web driver for Internet Explorer（COM 互換のため型のみ保持。起動ロジックは未サポート）
    /// </summary>
    [ProgId("Selenium.IEDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-EED04A1E4CD1")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class IEDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "internet explorer";

        public IEDriver()
            : base(BROWSER_NAME) { }
    }
}
