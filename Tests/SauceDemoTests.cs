using OpenQA.Selenium.Support.UI;
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

        [Test]
        public void Test1_LoginWithInvalidPassword()
        {
            TestContext.Progress.WriteLine("Starting Test 1: Invalid Password");
            loginPage.Login("standard_user", "not_secret_sauce");

            string expectedError = "Epic sadface: Username and password do not match any user in this service";
            Assert.That(loginPage.GetTextError(), Is.EqualTo(expectedError));
        }

        [Test]
        public void Test2_LoginWithLockedOutUser()
        {
            TestContext.Progress.WriteLine("Starting Test 2: Locked Out User");
            loginPage.Login("locked_out_user", "secret_sauce");

            string expectedError = "Epic sadface: Sorry, this user has been locked out.";
            Assert.That(loginPage.GetTextError(), Is.EqualTo(expectedError));
        }

        [Test]
        public void Test3_LoginAndSortProducts()
        {
            TestContext.Progress.WriteLine("Starting Test 3: Successful Login & Sorting");
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            productsPage.SortFromLowToHigh();
            Assert.That(productsPage.ArePricesSortedLowToHigh(), Is.True);
        }
    }
}