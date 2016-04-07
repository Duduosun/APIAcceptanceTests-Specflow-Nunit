using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using UITests.PageObjects.Base;

namespace UITests.PageObjects
{
    public class CameraPage :  BaseClass
    {
        public WebDriverWait DriverWait { get; private set; }

        public CameraPage(IWebDriver driver) : base(driver)
        {
            DriverWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(DefaultActionTimeWait));
        }

        [FindsBy(How = How.CssSelector, Using = "div.one.column.row.ng-scope div.column div.ui.segment.blue h1.ng-binding")]
        public IWebElement CameraNameId { get; set; }
        
    }
}
