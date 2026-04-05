using System.Runtime.InteropServices;

namespace Selenium {

    /// <summary>
    /// Web driver for Microsoft Edge（COM 互換のため型のみ保持。起動ロジックは未サポート）
    /// </summary>
    [ProgId("Selenium.EdgeDriver")]
    [Guid("0277FC34-FD1B-4616-BB19-3C406728F1A2")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class EdgeDriver : WebDriver, ComInterfaces._WebDriver {

        const string BROWSER_NAME = "MicrosoftEdge";

        public EdgeDriver()
            : base(BROWSER_NAME) { }
    }
}
