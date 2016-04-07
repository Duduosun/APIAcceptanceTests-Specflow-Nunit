using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace APITests.SpecflowTests.Steps
{
    [Binding]
    public class ProductPageSteps
    {
        private HttpResponseMessage _response;

        [Given(@"I have a (.*)")]
        public void GivenIHaveA(string product)
        {
            ScenarioContext.Current["productName"] = product;
        }
        
        [When(@"I retrieve the product")]
        public void WhenIRetrieveTheProduct()
        {
          _response= GetProduct((string)ScenarioContext.Current["productName"]);

        }

        [Then(@"the response should be as (.*)")]
        public void ThenTheResponseShouldBeAs(HttpStatusCode expectedStatusCode)
        {
            Utils.Utils.AssertTheResponse(_response,expectedStatusCode);
        }
        
        private HttpResponseMessage GetProduct(string product)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
                response = client.GetAsync(string.Format("products/{0}", product)).Result;
            }
            return response;
        }

    }
}
