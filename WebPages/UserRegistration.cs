
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BDDWebShopApp.Pages
{
    public class UserRegistration
    {
        private IWebDriver driver;
        private WebDriverWait _wait;

        public UserRegistration(IWebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        string genderXPath = "//*[@id=/'gender-xxxx/']";
        private IWebElement Gender;
        private IWebElement FirstName => driver.FindElement(By.Id("FirstName"));
        private IWebElement LastName => driver.FindElement(By.Id("LastName"));
        private IWebElement Email => driver.FindElement(By.Id("Email"));
        private IWebElement Password => driver.FindElement(By.Name("Password"));
        private IWebElement ConfirmPassword => driver.FindElement(By.Name("ConfirmPassword"));
        private IWebElement RegisterButton => driver.FindElement(By.Id("register-button"));

        // Actions
        public void Select_Gender(string gender)
        {
            var genderLower = gender.ToLower().Trim();
            Gender = driver.FindElement(By.XPath($"//*[@id='gender-{genderLower}']"));
            Gender.Click();
        }

        public void EnterTextfield(IWebElement elt, string data)
        {
            elt.SendKeys(data);
        }

        public void BtnClick(IWebElement elt)
        {            
            _wait.Until(ExpectedConditions.ElementToBeClickable(elt)).Click();

        }

        // Method to perform user registran with _registrationDetails Dictionary as Parameter
        //firstname,lastname,email,password,confirmPassword and registtion button click can be performed in this method 
        public void RegisterUser(Dictionary<string, string> registrationDetails)
        {
            //Select Gender
            Select_Gender(registrationDetails["Gender"]);
            //Enter First Name
            EnterTextfield(FirstName, registrationDetails["FirstName"]);
            //Enter Last Name
            EnterTextfield(LastName, registrationDetails["LastName"]);
            //Enter Email
            EnterTextfield(Email, registrationDetails["Email"]);
            //Enter Password
            EnterTextfield(Password, registrationDetails["Password"]);
            //Enter Confirm Password
            EnterTextfield(ConfirmPassword, registrationDetails["ConfirmPassword"]);           


        }

        public void ClickRegisterButton()
        {
            BtnClick(RegisterButton);
        }

        // method to perform user registration success returns true or false based on the presence of success message
        public bool IsRegistrationSuccessful()
        {
            try
            {
                var successMessage = _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("result")));
                return successMessage.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        // method to perform account creation success returns true or false based on the presence of account link
        public bool IsAccountCreatedSuccessfully()
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
    }
}
