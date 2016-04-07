using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using UITests.Helpers;
using UITests.PageObjects;

namespace UITests.NunitTests
{
    [TestFixture]
    public class ProductPageTests
    {
        private BrowserAccess _browserAccess;
        private HomePage _homePage;
        private CameraPage _cameraPage;
        private IWebDriver _driver;
        private string _baseUrl;
        private StringBuilder VerificationErrors { get; set; }

        [SetUp]
        public void Setup()
        {
            _browserAccess = new BrowserAccess();
            _driver = _browserAccess.Driver;
            _baseUrl = _browserAccess.BaseUrl;

            _homePage = new HomePage(_driver);
            _cameraPage = new CameraPage(_driver);
        }

        /// <summary>
        /// This test opens the Camera product page and Validates the product title
        /// </summary>
        [TestCase("nikon-d3200", "Nikon D3200")]
        [TestCase("olympus-pen-f", "Olympus PEN-F")]
        public void CameraPageTests(string productName , string productTitle )
        {
            string productPageUrl = _baseUrl + "/#/camera/" + productName;
            NavigateToCameraProductPage(productPageUrl);
            _cameraPage.DriverWait.Until(x => _cameraPage.CameraNameId.Displayed);
            string actualProductTitle = _cameraPage.CameraNameId.Text;
            Assert.AreEqual(productTitle, actualProductTitle);
        }
        
        [TearDown]
        public void TearDownTest()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                Assert.AreEqual(string.Empty, VerificationErrors.ToString());
            }
        }

        private void NavigateToCameraProductPage(string productPageUrl)
        {
            _driver.Navigate().GoToUrl(productPageUrl);
        }
    }
}
