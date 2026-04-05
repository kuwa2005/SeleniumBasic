
namespace Selenium.Errors {

    /// <summary>
    /// 正式対応は Chrome / Edge のみ。それ以外のブラウザ指定時に送出する。クラス名は下位互換のため従来のまま。
    /// </summary>
    public class ChromeOnlyBrowserError : SeleniumError {

        internal ChromeOnlyBrowserError(string attemptedBrowser)
            : base(
                "このフォークで正式対応しているのは Google Chrome（chromedriver）と Microsoft Edge（Edge WebDriver）のみです。次のブラウザ指定は対象外です: {0}\n" +
                "Only Chrome (chromedriver) and Microsoft Edge (Edge WebDriver) are officially supported in this fork. Unsupported browser: {0}",
                attemptedBrowser ?? "(null)") {
        }
    }
}
