using BDDWebShopApp.Drivers;
using BDDWebShopApp.Pages;
using BDDWebShopApp.Config;
using BDDWebShopApp.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Collections.Generic;

namespace BDDWebShopApp.Features.Steps
{
    [Binding]
    public class WebShopUserRegStepDefinitions : BaseDriver
    {
        //private readonly IWebDriver driver;
        //private readonly WebDriverWait _wait;
        private readonly ScenarioContext _scenarioContext;
        private Dictionary<string, string> _registrationDetails;

        //registration page object create
            UserRegistration userRegistration;
        public WebShopUserRegStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            userRegistration = new UserRegistration(driver);
        }
       

        [Given(@"I navigate to the Demo Web Shop registration page")]
        public void GivenINavigateToTheDemoWebShopRegistrationPage()
        {
            //driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/register");
        }

        [When(@"I enter valid registration details")]
        public void WhenIEnterValidRegistrationDetails(Table table)
        {
            _registrationDetails = new Dictionary<string, string>();
            var row = table.Rows[0];

            foreach (var key in table.Header)
            {
                _registrationDetails[key] = row[key];
            }

            // Store Email and Password in ScenarioContext
            if (_registrationDetails.ContainsKey("Email"))
            {
                _scenarioContext["Email"] = _registrationDetails["Email"];
            }

            if (_registrationDetails.ContainsKey("Password"))
            {
                _scenarioContext["Password"] = _registrationDetails["Password"];
            }
            // Fill registration form
            userRegistration.RegisterUser(_registrationDetails);


        }

        [When(@"I click on the register button")]
        public void WhenIClickOnTheRegisterButton()
        {
           userRegistration.ClickRegisterButton();
        }

        [Then(@"I should see the registration success message")]
        public void ThenIShouldSeeTheRegistrationSuccessMessage()
        {            
            Assert.IsTrue(userRegistration.IsRegistrationSuccessful());
        }

        [Then(@"my account should be created successfully")]
        public void ThenMyAccountShouldBeCreatedSuccessfully()
        {
            if (_scenarioContext.ContainsKey("Email") && _scenarioContext.ContainsKey("Password") && userRegistration.IsAccountCreatedSuccessfully())
            {
                string email = _scenarioContext["Email"].ToString();
                string password = _scenarioContext["Password"].ToString();
                CsvDataWriter.WriteUserCredentialsToCsv(email, password);
            }
            Assert.IsTrue(userRegistration.IsAccountCreatedSuccessfully());
        }
    }
}