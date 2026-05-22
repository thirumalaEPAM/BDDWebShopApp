using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BDDWebShopApp.WebPages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions actions;

        private IWebElement UsernameField => _driver.FindElement(By.Id("Email"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("Password"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("//input[@value='Log in']"));

        //Electronics locators
        private IWebElement ElectronicsCategory => _driver.FindElement(By.XPath("//ul[@class='top-menu']//a[contains(text(), 'Electronics')]"));

        //Computers locators
        private IWebElement ComputersCategory => _driver.FindElement(By.XPath("//ul[@class='top-menu']//a[contains(text(), 'Computers')]"));

        //Desktops menu locator
        private IWebElement DesktopsMenu => _driver.FindElement(By.XPath("//ul[@class='top-menu']//a[contains(text(), 'Desktops')]"));

        //cellphones menu locator
        private IWebElement CellPhonesMenu => _driver.FindElement(By.XPath("//ul[@class='top-menu']//a[contains(text(), 'Cell phones')]"));

        //search locator
        private IWebElement SearchBox => _driver.FindElement(By.Id("small-searchterms"));
        //Search button locator
        private IWebElement SearchButton => _driver.FindElement(By.XPath("//input[@value='Search']"));

        //Add to cart button locator
        private IWebElement AddToCartButton => _driver.FindElement(By.XPath("//input[@value='Add to cart']"));

        //Shopping cart link locator
        private IWebElement ShoppingCartLink => _driver.FindElement(By.XPath("//span[contains(text(), 'Shopping cart')]"));
        //Shopping Cart header locator
        private IWebElement ShoppingCartHeader => _driver.FindElement(By.XPath("//h1[contains(text(), 'Shopping cart')]"));

        // Smartphone product link locator
        private IWebElement SmartphoneProductLink => _driver.FindElement(By.XPath("//a[contains(text(), 'Smartphone')]"));

        //Terms and Conditions checkbox locator
        private IWebElement TermsAndConditionsCheckbox => _driver.FindElement(By.Id("termsofservice"));
        //Checkout button locator
        private IWebElement CheckoutButton => _driver.FindElement(By.Id("checkout"));

        //processor radio button locator
        private IWebElement Processor => _driver.FindElement(By.XPath("//input[@value=96]"));

        //Billing Save
        private IWebElement BillingSave => _driver.FindElement(By.XPath("//input[@onClick='Billing.save()']"));

        //Shipping Save
        private IWebElement ShippingSave => _driver.FindElement(By.XPath("//input[@onClick='Shipping.save()']"));
        //Shipping Method Save
        private IWebElement ShippingMethodSave => _driver.FindElement(By.XPath("//input[@onClick='ShippingMethod.save()']"));
        //Payment Method Save
        private IWebElement PaymentMethodSave => _driver.FindElement(By.XPath("//input[@onClick='PaymentMethod.save()']"));
        //Payment Information Save
        private IWebElement PaymentInfoSave => _driver.FindElement(By.XPath("//input[@onClick='PaymentInfo.save()']"));
        //Confirm Order Save
        private IWebElement ConfirmOrderSave => _driver.FindElement(By.XPath("//input[@onclick='ConfirmOrder.save()']"));
        //Order Confirmation header locator
        private IWebElement OrderConfirmationHeader => _driver.FindElement(By.XPath("//strong[text()='Your order has been successfully processed!']"));


        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            actions = new Actions(driver);
        }

        //Enter username and Password
        public void EnterUsername(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
        }

        //Click on Login Button
        public void ClickLoginButton()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LoginButton)).Click();
        }

        // validate the login success by checking the presence of welcome message or account page
        public bool IsLoginSuccessful()
        {
            try
            {
                var accountLink = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), 'Log out')]")));
                return accountLink.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // Navigate to Cell Phones page under Electronics category
        public void NavigateToCellPhones()
        {
            // Hover over Electronics category
            actions.MoveToElement(ElectronicsCategory).Perform();
            // Click on Cell Phones menu item
            _wait.Until(ExpectedConditions.ElementToBeClickable(CellPhonesMenu)).Click();
        }

        // Navigate to Desktops page under Computers category
        public void NavigateToDesktops()
        {
            // Hover over Electronics category
            actions.MoveToElement(ComputersCategory).Perform();
            // Click on Cell Phones menu item
            _wait.Until(ExpectedConditions.ElementToBeClickable(DesktopsMenu)).Click();
        }


        // Search f or a product using the search box
        public void SearchForProduct(string productName)
        {
            SearchBox.SendKeys(productName);
            _wait.Until(ExpectedConditions.ElementToBeClickable(SearchButton)).Click();
        }

        // Add a product to the cart from the search results or product page
        public void AddProductToCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(AddToCartButton)).Click();
        }

        // Navigate to the shopping cart page
        // Navigate to the shopping cart page
        public void NavigateToShoppingCart()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(), 'Shopping cart')]"))).Click();

           
        }

        // Verify that the product is listed in the shopping cart
        public bool IsProductInCart(string productName)
        {
            try
            {
                //string productLinkXPath = $"//a[contains(text(), '{productName}')]";
                string productimg = $"//img[@alt='Picture of Smartphone']";
                var cartHeader = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(), 'Shopping cart')]")));
                var productLink = _driver.FindElement(By.XPath(productimg));
                Console.WriteLine($"Cart Header Displayed: {cartHeader.Displayed}, Product Link Displayed: {productLink.Displayed}");
                return cartHeader.Displayed && productLink.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }



        }
        // Click on terms and Conditiones Check box and Click on Continue button
        public void AgreeToTermsAndCheckout()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(TermsAndConditionsCheckbox)).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(CheckoutButton)).Click();
        }

        // Complete the checkout process by filling in necessary details and confirming the order
        public void CompleteCheckoutProcess(string phase)
        {
            if (phase == "Billing")
            {
                // Click on Billing Save button
                _wait.Until(ExpectedConditions.ElementToBeClickable(BillingSave)).Click();
            }
            else if (phase == "Shipping")
            {
                // Click on Shipping Save button
                _wait.Until(ExpectedConditions.ElementToBeClickable(ShippingSave)).Click();
            }

            else if (phase == "Shipping Method")
            {
                // Click on Shipping Method Save button
                _wait.Until(ExpectedConditions.ElementToBeClickable(ShippingMethodSave)).Click();
            }
            else if (phase == "Payment Method")
            {
                // Click on Payment Method Save button
                _wait.Until(ExpectedConditions.ElementToBeClickable(PaymentMethodSave)).Click();
            }
            else if (phase == "Payment Information")
            {
                // Click on Payment Information Save button
                _wait.Until(ExpectedConditions.ElementToBeClickable(PaymentInfoSave)).Click();
            }
            else if (phase == "Confirm Order")
            {
                // Click on Confirm Order Save button
                _wait.Until(ExpectedConditions.ElementToBeClickable(ConfirmOrderSave)).Click();
            }


        }
        
        // Select the Processor
        public bool SelectProcessor()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(Processor)).Click();
            return Processor.Displayed;
        }

        // Verify that the order confirmation message is displayed after completing the checkout process
        public bool IsOrderPlacedSuccessfully()
        {
            try
            {
                var confirmationHeader = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='Your order has been successfully processed!']")));
                return confirmationHeader.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }

}
