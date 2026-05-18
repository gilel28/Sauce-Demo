using Sauce_Demo.Pages;

namespace Sauce_Demo.Tests
{
    public class SauceDemoTests : TestBase
    {

        private LoginPage loginPage;
        private ProductsPage productsPage;

        [SetUp]
        public void InitPages()
        {
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
        }


        [TestCase("standard_user", "not_secret_sauce", "Epic sadface: Username and password do not match any user in this service")]
        [TestCase("locked_out_user", "secret_sauce", "Epic sadface: Sorry, this user has been locked out.")]
        public void Login_Unsuccessful_ShowsExpectedErrorMessage(string username, string password, string expectedError)
        {
            loginPage.Login(username, password);
            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo(expectedError));
        }

        [Test]
        public void LoginAndSortProducts()
        {
            TestContext.Progress.WriteLine("Starting Test 3: Successful Login & Sorting");
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            productsPage.SortFromLowToHigh();
            Assert.That(productsPage.ArePricesSortedLowToHigh(), Is.True);
        }
    }
}