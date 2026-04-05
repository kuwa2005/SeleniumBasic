using NUnit.Framework;
using System;

namespace Selenium.Tests.Internals {

    /// <summary>このフォークでは Chrome のみテストする。</summary>
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
