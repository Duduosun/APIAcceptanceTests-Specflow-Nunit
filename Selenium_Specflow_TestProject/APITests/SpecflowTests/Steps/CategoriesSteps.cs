using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace APITests.SpecflowTests.Steps
{
    [Binding]
    public class CategoriesSteps
    {
        private HttpResponseMessage response;

        [Given(@"I want to filter items based on (.*) and (.*)")]
        public void GivenIWantToFilterItemsBasedOnSubcategory(string subCategory, string productItem)
        {
            ScenarioContext.Current["SubCategory"] = subCategory;
            ScenarioContext.Current["ProductItem"] = productItem;
        }

        [When(@"I filter and search for it")]
        public void WhenIFilterAndSearchForIt()
        {
            string subCategory = Convert.ToString(ScenarioContext.Current["SubCategory"]);
            string searchItem = Convert.ToString(ScenarioContext.Current["ProductItem"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
                response = client.GetAsync(string.Format("categories/{0}/{1}", subCategory, searchItem)).Result;
            }
        }

        [Then(@"the response should be with (.*)")]
        public void ThenTheResponseShouldBeWith(HttpStatusCode statusCode)
        {
            Utils.Utils.AssertTheResponse(response, statusCode);
        }



    }
}