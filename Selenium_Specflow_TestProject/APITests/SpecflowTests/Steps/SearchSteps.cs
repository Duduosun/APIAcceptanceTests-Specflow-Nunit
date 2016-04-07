using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using APITests.NunitTests;
using APITests.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APITests.SpecflowTests.Steps
{
    [Binding]
    public class SearchSteps
    {
        private HttpResponseMessage response;
        private string _minPrice, _maxPrice, _minMp, _maxMp = null;

        [Given(@"I want to search for (.*)")]
        public void GivenIWantToSearchForSearchItem(string searchItem)
        {
            ScenarioContext.Current["SearchItem"] = searchItem;
        }
  
        [When(@"I search for it")]
        public void WhenISearchForIt()
        {
            string searchItem = Convert.ToString(ScenarioContext.Current["SearchItem"]);
            response = RetrieveSearchItemsFromSearchPage(searchItem);
        }

        [When(@"I search for it with advanced parameters")]
        public void WhenISearchForItWithAdvancedParameters(Table table)
        {

            string brand = Convert.ToString(ScenarioContext.Current["SearchItem"]);
          
            foreach (var row in table.Rows)
            {
                 _minPrice = Convert.ToString(row["minPrice"]);
                 _maxPrice = Convert.ToString(row["maxPrice"]);
                 _minMp = Convert.ToString(row["minMp"]);
                 _maxMp = Convert.ToString(row["maxMp"]);
            }
            response = RetreiveSearchItemsFromAdvancedSearchPage(brand, _minPrice, _maxPrice, _minMp, _maxMp);
        }

        [Then(@"the response to be as (.*)")]
        public void ThenTheResponseToBeAs(HttpStatusCode expectedStatusCode)
        {
            Utils.Utils.AssertTheResponse(response, expectedStatusCode);
        }

        private HttpResponseMessage RetreiveSearchItemsFromAdvancedSearchPage(string brand, string minPrice, string maxPrice, string minMp, string maxMp)
        {
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

                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                var jsonCommand = JsonConvert.SerializeObject(command, settings);
                response = client.PostAsync("advanced-search", new StringContent(jsonCommand, Encoding.UTF8, "application/json")).Result;
            }

            return response;
        }
        private HttpResponseMessage RetrieveSearchItemsFromSearchPage(string searchItem)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
                response = client.GetAsync(string.Format("search/{0}", searchItem)).Result;
            }
            return response;
        }
    }
}
