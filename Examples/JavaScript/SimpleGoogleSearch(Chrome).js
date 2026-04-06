
/*
 * JScript example — Google Chrome（このフォークの正式対応ブラウザ）
 */

var Waiter = new ActiveXObject("Selenium.Waiter");
var Assert = new ActiveXObject("Selenium.Assert");
var driver = new ActiveXObject("Selenium.ChromeDriver");

driver.Get("https://www.google.co.uk");

var ele = driver.FindElementByName("q");
ele.SendKeys("Eiffel tower" + driver.Keys.Return);

Waiter.Until(function(){return /^Eiffel tower/.test(driver.Title);});

WScript.Echo("Click OK to quit the browser");
