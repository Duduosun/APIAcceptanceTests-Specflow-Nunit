using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;

namespace APITests.Utils
{
    public static class Utils
    {
        public static void AssertTheResponse(HttpResponseMessage response, HttpStatusCode expectedCode)
        {
            if (response.StatusCode != expectedCode)
            {
                var rawResponse = response.Content.ReadAsStringAsync();

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    Error = (sender, args) => { args.ErrorContext.Handled = true; }
                };
                Console.WriteLine(JsonConvert.DeserializeObject<dynamic>(rawResponse.Result, jsonSerializerSettings));
            }

            Assert.That(response.StatusCode, Is.EqualTo(expectedCode));
        }
    }
}
