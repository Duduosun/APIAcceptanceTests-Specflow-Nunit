using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UITests.PageObjects.Base;

namespace UITests.PageObjects
{
    public class HomePage : BaseClass
    {
        public WebDriverWait DriverWait { get; private set; }

        public HomePage(IWebDriver driver) : base(driver)
        {
            DriverWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(60000));
        }
        public void NavigateToHomePage(IWebDriver driver, string baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl);
            Console.WriteLine(baseUrl);
        }
    }
}
