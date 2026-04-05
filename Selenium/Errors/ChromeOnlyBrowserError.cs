
namespace Selenium.Errors {

    /// <summary>
    /// このフォークではローカル／リモートとも Google Chrome（chromedriver）のみをサポートする。
    /// </summary>
    public class ChromeOnlyBrowserError : SeleniumError {

        internal ChromeOnlyBrowserError(string attemptedBrowser)
            : base(
                "このフォークは Google Chrome（chromedriver）のみをサポートします。次のブラウザ指定はメンテナンス対象外です: {0}\n" +
                "This fork supports only Google Chrome (chromedriver). Unsupported browser: {0}",
                attemptedBrowser ?? "(null)") {
        }
    }
}
