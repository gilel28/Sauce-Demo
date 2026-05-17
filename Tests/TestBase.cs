using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Sauce_Demo.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;


        [SetUp]
        public void BaseSetUp()
        {
            TestContext.Progress.WriteLine("Initializing ChromeDriver and opening browser");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            TestContext.Progress.WriteLine("Navigating to https://www.saucedemo.com/");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [TearDown]
        public void BaseTearDown()
        {
            TestContext.Progress.WriteLine("Closing browser and cleaning up driver");
            if (driver != null)
            {
                driver.Quit();
            }
        }

    }
}
