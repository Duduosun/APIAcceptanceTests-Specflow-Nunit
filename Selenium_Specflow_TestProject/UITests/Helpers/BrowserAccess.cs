using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace UITests.Helpers
{
    public class BrowserAccess
    {
        public readonly IWebDriver Driver;
        public readonly string BaseUrl;
        private readonly string _selectedBrowser = ConfigurationManager.AppSettings["Browser"];
        private readonly string _hub;
        private readonly DesiredCapabilities _capabilities = null;

        public BrowserAccess()
        {
            _hub = ConfigurationManager.AppSettings["hub"];
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

            switch (_selectedBrowser)
            {
                case "chrome":
                    _capabilities = DesiredCapabilities.Chrome();
                    break;
                case "phantomjs":
                    _capabilities = DesiredCapabilities.PhantomJS();
                    break;
                case "firefox":
                    _capabilities = DesiredCapabilities.Firefox();
                    break;
            }

            Driver = new RemoteWebDriver(new Uri(_hub), _capabilities, new TimeSpan(0, 30, 0));
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
