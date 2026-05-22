using BDDWebShopApp.Drivers;
using BDDWebShopApp.WebPages;
using BDDWebShopApp.Config;
using BDDWebShopApp.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Collections.Generic;

namespace BDDWebShopApp.StepDefinitions
{
    [Binding]
    public class UserLoginStepDefinitions : BaseDriver
    {
            //private readonly ScenarioContext _scenarioContext;
        private Dictionary<string, string> _loginDetails;
    
            //Login page object create
            LoginPage loginPage; 
        public UserLoginStepDefinitions(ScenarioContext scenarioContext)
        {
           
            loginPage = new LoginPage(driver);
        }
        [Given("I navigate to the Demo Web Shop login page")]
        public void GivenINavigateToTheDemoWebShopLoginPage()
        {
            //throw new PendingStepException();
        }

        [When("I enter username {string} and password {string}")]
        public void WhenIEnterUsernameAndPassword(string p0, string p1)
        {
            loginPage.EnterUsername(p0, p1);
        }

        [When("I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then("I should be navigated to the valid account page")]
        public void ThenIShouldBeNavigatedToTheValidAccountPage()
        {
            // User Navidate to Account page and verify the account details
            loginPage.IsLoginSuccessful();

        }
        [When("I navigate to the Electronics category page")]
        public void WhenINavigateToTheElectronicsCategoryPage()
        {
            loginPage.NavigateToCellPhones();
        }

        [When("I select a product from the Electronics category")]
        public void WhenISelectAProductFromTheElectronicsCategory()
        {
            loginPage.SearchForProduct("Smartphone");
        }

        [When("Click on Add to Cart button")]
        public void WhenClickOnAddToCartButton()
        {
           loginPage.AddProductToCart();           
          
        }

        [Then("I should see the product should be listed in my shopping cart")]
        public void ThenIShouldSeeTheProductShouldBeListedInMyShoppingCart()
        {
           bool flag = loginPage.IsProductInCart("Smartphone");
            Assert.IsTrue(flag, "Product is not listed in the shopping cart.");
        }

        // Additional step definitions for other scenarios  can be added here
        [When("I navigate to my shopping cart")]
        public void WhenINavigateToMyShoppingCart()
        {
            loginPage.NavigateToShoppingCart();
        }

        [When("I navigate to the Computers Manu and Click on Desktop Submenu")]
        public void WhenINavigateToTheComputersManuAndClickOnDesktopSubmenu()
        {
            loginPage.NavigateToDesktops();
        }

        [When("I search for Simple Computer product and Click on Search button")]
        public void WhenISearchForSimpleComputerProductAndClickOnSearchButton()
        {
            loginPage.SearchForProduct("Simple Computer");
        }

        [When("I Select Processor radio button")]
        public void WhenISelectProcessorRadioButton()
        {
            if (loginPage.SelectProcessor())
            {
                loginPage.NavigateToShoppingCart();
            }
            else
            {
                Console.WriteLine("Failed to select the processor option.Which is Not Showing");


            }
        }

        [When("Click on Confirmation Check box and Click on Checkout button")]
        public void WhenClickOnConfirmationCheckBoxAndClickOnCheckoutButton()
        {
            loginPage.AgreeToTermsAndCheckout();
        }

        [When("I enter billing address details and click on continue button")]
        public void WhenIEnterBillingAddressDetailsAndClickOnContinueButton()
        {
            loginPage.CompleteCheckoutProcess("Billing");
        }

        [When("Click on shipping address continue button")]
        public void WhenClickOnShippingAddressContinueButton()
        {
            loginPage.CompleteCheckoutProcess("Shipping");
        }

        [When("Click on shipping method continue button")]
        public void WhenClickOnShippingMethodContinueButton()
        {
            loginPage.CompleteCheckoutProcess("Shipping Method");
        }

        [When("Click on payment method continue button")]
        public void WhenClickOnPaymentMethodContinueButton()
        {
            loginPage.CompleteCheckoutProcess("Payment Method");
        }

        [When("Click on payment information continue button")]
        public void WhenClickOnPaymentInformationContinueButton()
        {
            loginPage.CompleteCheckoutProcess("Payment Information");
        }

        [When("Click on Confirm button")]
        public void WhenClickOnConfirmButton()
        {
            loginPage.CompleteCheckoutProcess("Confirm Order");
        }       

        [Then("I should see order placed successfully message")]
        public void ThenIShouldSeeOrderPlacedSuccessfullyMessage()
        {
           //place order and verify the order confirmation message
            bool isOrderPlaced = loginPage.IsOrderPlacedSuccessfully();
            Assert.IsTrue(isOrderPlaced, "Order was not placed successfully.");

        }




    }
}
