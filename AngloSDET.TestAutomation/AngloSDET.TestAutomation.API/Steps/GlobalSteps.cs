using AngloSDET.TestAutomation.API.Models;
using AngloSDET.TestAutomation.API.Resources;
using AngloSDET.TestAutomation.Core.Extensions;
using AngloSDET.TestAutomation.Core.Wrappers;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace AngloSDET.TestAutomation.API.Steps
{
    [Binding]
    public class GlobalSteps
    {
        private readonly ScenarioContext _context;

        public GlobalSteps(ScenarioContext scenarioContext)
        {
            _context = scenarioContext;
        }

        [Given(@"request to the resource - (.*)")]
        public void GivenUserWantsToSendARequestToTheResource(string resource)
        {
            _context.SaveValue("request", new HttpRequestWrapper().SetResourse(ResourcesApi.EndPoints[resource]));
        }

        [When(@"user adds car type - (.*)")]
        public void WhenUserAddsCarType(string type)
        {
            var request = _context.Get<HttpRequestWrapper>("request");
            request.AddUrlSegment("type", type);
        }


        [When(@"execute (.*) request")]
        public void WhenUserExecuteRequest(Method method)
        {
            var request = _context.Get<HttpRequestWrapper>("request");
            var response = request.SetMethod(method).Execute();
            _context.SaveValue("response", response);
        }

        [Then(@"response status code - (.*)")]
        public void ThenResponseStatusCode(HttpStatusCode statusCode)
        {
            var response = _context.Get<IRestResponse>("response");

            Assert.AreEqual(statusCode, response.StatusCode, "Verification status code failed");
        }

        [Then(@"all cars have type - (.*)")]
        public void ThenAllCarsHaveType(string type)
        {
            var response = _context.Get<IRestResponse>("response");
            var cars = JsonConvert.DeserializeObject<List<Car>>(response.Content);
            cars.Select(x => x.Type).Should().AllBe(type, "Verification car types failed");
        }
    }
}