
namespace Selenium.Errors {

    /// <summary>
    /// このフォークでは Chrome（chromedriver）と Edge（msedgedriver）のみをサポートする。
    /// </summary>
    public class ChromeOnlyBrowserError : SeleniumError {

        internal ChromeOnlyBrowserError(string attemptedBrowser)
            : base(
                "このフォークは Google Chrome（chromedriver）と Microsoft Edge（Edge WebDriver）のみをサポートします。次のブラウザ指定はメンテナンス対象外です: {0}\n" +
                "This fork supports only Chrome (chromedriver) and Microsoft Edge (Edge WebDriver). Unsupported browser: {0}",
                attemptedBrowser ?? "(null)") {
        }
    }
}
