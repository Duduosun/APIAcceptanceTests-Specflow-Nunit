using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace UITests.PageObjects.Base
{
    public abstract class BaseClass
    {
        public const int DefaultActionTimeWait = 30000;
        private IWebDriver _driver;
        public BaseClass(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            DriverWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(DefaultActionTimeWait));
        }
        private WebDriverWait DriverWait { get; set; }
    }
}
