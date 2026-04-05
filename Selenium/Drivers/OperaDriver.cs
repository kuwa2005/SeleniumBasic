using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Web driver for Opera（COM 互換のため型のみ保持。起動ロジックは未サポート）
    /// </summary>
    [ProgId("Selenium.OperaDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-9E7F9EF1D002")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class OperaDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "opera";

        public OperaDriver()
            : base(BROWSER_NAME) { }
    }
}
