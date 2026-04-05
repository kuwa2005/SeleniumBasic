using NUnit.Framework;
using System;

namespace Selenium.Tests.Internals {

    /// <summary>このフォークの正式対応ブラウザは Chrome / Edge。現状の NUnit フィクスチャは Chrome のみ。</summary>
    public enum Browser {
        Chrome
    }

    abstract class BaseBrowsers {

        public readonly object Fixture;

        protected WebDriver driver;
        protected Keys Keys = new Keys();
        protected By By = new By();

        public BaseBrowsers(Browser browser) {
            WebServer.StartServer(@"..\..\Pages");
            this.driver = GetBrowserInstance(browser);
            this.driver.BaseUrl = WebServer.BaseUri;
            this.Fixture = browser;
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown() {
            driver.Quit();
        }

        private WebDriver GetBrowserInstance(Browser browser) {
            switch (browser) {
                case Browser.Chrome:
                    return new Selenium.ChromeDriver();
            }
            throw new Exception("Browser not supported: " + browser.ToString());
        }

    }

}
