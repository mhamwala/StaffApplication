using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace UnitTests
{
    public class ProductsViewTest
    {

        private ChromeDriver _driver;

        public ProductsViewTest()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void CreateNew_ClickOnLink_PageLoaded()
        {
            _driver.Navigate().GoToUrl(@"http://localhost:5100/Product");
            var link = _driver.FindElement(By.PartialLinkText("Add New Product"));
            var jsToBeExecuted = $"window.scroll(0, {link.Location.Y})";
            ((IJavaScriptExecutor)_driver).ExecuteScript(jsToBeExecuted);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Add New Product")));
            clickableElement.Click();
        }

        [Fact]
        public void CreateNewStaffAcc_ClickOnLink_PageLoaded()
        {
            _driver.Navigate().GoToUrl(@"http://localhost:5100/Staff");
            var link = _driver.FindElement(By.PartialLinkText("Edit"));
            var jsToBeExecuted = $"window.scroll(0, {link.Location.Y})";
            ((IJavaScriptExecutor)_driver).ExecuteScript(jsToBeExecuted);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Edit")));
            clickableElement.Click();
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
