using BDDWebShopApp.Config;
using BDDWebShopApp.Drivers;
using OpenQA.Selenium.Support.UI;
using Reqnroll;

namespace BDDWebShopApp.Hooks
{
    [Binding]
    public class TestHook
    {
        private readonly ScenarioContext _scenarioContext;

        public TestHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = DriverFactory.GetDriver();
            var url = GetUrlForScenario(_scenarioContext.ScenarioInfo.Title);
            Console.WriteLine($"Navigating to URL: {url}");
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverFactory.QuitDriver();
        }

        private string GetUrlForScenario(string scenarioName)
        {
            return scenarioName.ToLower() switch
            {
                _ when scenarioName.ToLower().Contains("register") => $"{ConfigReader.BaseUrl}/register",
                _ when scenarioName.ToLower().Contains("login") => $"{ConfigReader.BaseUrl}/login",
                _ when scenarioName.ToLower().Contains("order") => $"{ConfigReader.BaseUrl}/login",
                _ when scenarioName.ToLower().Contains("cart") => $"{ConfigReader.BaseUrl}/login",
                _ => ConfigReader.BaseUrl
            };
        }
    }
}