using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Sauce_Demo.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement productSortContainer=> wait.Until(d=>d.FindElement(By.ClassName("product_sort_container")));
        private ReadOnlyCollection<IWebElement> pricesTxt => driver.FindElements(By.ClassName("inventory_item_price"));



        public void SortFromLowToHigh()
        {
            TestContext.Progress.WriteLine("Selecting 'Price (low to high)' from the sort dropdown");
            SelectElement sortProducts = new SelectElement(productSortContainer);
            sortProducts.SelectByValue("lohi");
        }

        public bool ArePricesSortedLowToHigh()
        {
            var prices = new List<double>();
            foreach (IWebElement e in pricesTxt)
            {
                prices.Add(double.Parse((e.Text).Trim('$')));
            }

            List<double> sortedList = new List<double>(prices);
            sortedList.Sort();
            return sortedList.SequenceEqual(prices);           

        }
    }
}
