using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDDWebShopApp.Drivers
{
    public class DriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}