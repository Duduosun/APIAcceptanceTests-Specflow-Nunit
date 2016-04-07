using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using APITests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;

namespace APITests.NunitTests
{
    [TestFixture]
    public class APITests
    {
        /// <summary>
        /// This Test checks Product Page functionality through the API Layer by Sending GET request
        /// Test contains both positive and negative test cases
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="statusCode"></param>
        [TestCase("olympus-pen-f", 200)]
        [TestCase("fujifilm-x-pro2", 200)]
        [TestCase("nonexistingitem", 500)]
        public void ProductPageTests(string productName, int statusCode)
        {
            // Arrange
            HttpStatusCode expectedStatusCode = (HttpStatusCode) statusCode;

            // Act
            var response = RetrieveTheProductFromProductPage(productName);

            // Assert
            Utils.Utils.AssertTheResponse(response, expectedStatusCode);
        }

        /// <summary>
        /// This test verifies the categories menu through the API layer by Sending GET request
        /// Test contains subcategories and their corresponding product item parameters
        /// </summary>
        /// <param name="subCategory"></param>
        /// <param name="productItem"></param>
        /// <param name="statusCode"></param>
        [TestCase("brand", "Canon", 200)]
        [TestCase("type", "UltraCompact", 200)]
        [TestCase("price", "2000", 200)]
        [TestCase("sensor", "Full-Frame", 200)]
        [TestCase("color", "Black", 200)]
        [TestCase("feature", "GPS", 200)]
        [TestCase("unknown", "SONY", 404)]
        public void CategoryPageTests(string subCategory, string productItem, int statusCode)
        {
            // Arrange
            HttpStatusCode expectedStatusCode = (HttpStatusCode) statusCode;
            
            // Act
            var response = RetrieveProductsFromCategoriesPage(subCategory,productItem);

            // Assert
            Utils.Utils.AssertTheResponse(response,expectedStatusCode);
        }

        /// <summary>
        /// This test verifies the search functionality  by Sending GET request
        /// </summary>
        /// <param name="searchItem"></param>
        /// <param name="statusCode"></param>
        [TestCase("Nikon", 200)]
        [TestCase("Pentax", 200)]
        public void SearchPageTests(string searchItem, int statusCode)
        {
            // Arrange
            HttpStatusCode expectedStatusCode = (HttpStatusCode)statusCode;

            // Act
            var response = RetrieveSearchItemsFromSearchPage(searchItem);

            // Assert
            Utils.Utils.AssertTheResponse(response, expectedStatusCode);
        }

        /// <summary>
        /// This test verifies the advanced search functionality- by Sending POST request
        /// Advanced search is done by sending Post request 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <param name="minMP"></param>
        /// <param name="maxMp"></param>
        /// <param name="statusCode"></param>
        [TestCase("Nikon","300","500","12","18",200)]
        [TestCase("Leica", "300", "500", "12", "18",200)]
        public void AdvancedSearchPageTests(string brand, string minPrice, string maxPrice, string minMP, string maxMp, int statusCode)
        {
            // Arrange
            HttpStatusCode expectedStatusCode = (HttpStatusCode)statusCode;

            // Act
            var response = RetreiveSearchItemsFromAdvancedSearchPage(brand, minPrice, maxPrice, minMP, maxMp);

            // Assert
            Utils.Utils.AssertTheResponse(response, expectedStatusCode);
        }

        private HttpResponseMessage RetreiveSearchItemsFromAdvancedSearchPage(string brand, string minPrice, string maxPrice, string minMp, string maxMp)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);

                var command = new AdvancedSearchParameters
                {
                    Brand = brand,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinMp = minMp,
                    MaxMp = maxMp
                };

                var settings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto};
                var jsonCommand = JsonConvert.SerializeObject(command, settings);
                response = client.PostAsync("advanced-search", new StringContent(jsonCommand,Encoding.UTF8,"application/json")).Result;
            }

            return response;
        }

        private HttpResponseMessage RetrieveSearchItemsFromSearchPage(string searchItem)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
                response = client.GetAsync(string.Format("search/{0}", searchItem)).Result;
            }
            return response;
        }
        
        private HttpResponseMessage RetrieveProductsFromCategoriesPage(string subCategory, string searchItem)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
                response = client.GetAsync(string.Format("categories/{0}/{1}", subCategory, searchItem)).Result;
            }
            return response;
        }

        private HttpResponseMessage RetrieveTheProductFromProductPage(string productName)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
                response = client.GetAsync(string.Format("products/{0}", productName)).Result;
            }
            return response;
        }
    }
}

    
