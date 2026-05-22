using BDDWebShopApp.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDDWebShopApp.Drivers
{
    public class BaseDriver
    {
        protected IWebDriver driver;
        

        public BaseDriver()
        {
            driver = DriverFactory.GetDriver();
           
        }
    }
}