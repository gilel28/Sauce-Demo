using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Sauce_Demo.Pages
{
    public class ProductsPage:BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }


        private IWebElement productSortContainer=> wait.Until(d=>d.FindElement(By.ClassName("product_sort_container")));
        private ReadOnlyCollection<IWebElement> pricesElements =>wait.Until(d =>
            {
              var elements = d.FindElements(By.ClassName("inventory_item_price"));
              return elements.Count > 0 ? elements : null;
            });



        public void SortFromLowToHigh()
        {
            TestContext.Progress.WriteLine("Selecting 'Price (low to high)' from the sort dropdown");
            SelectElement sortProducts = new SelectElement(productSortContainer);
            sortProducts.SelectByValue("lohi");
        }

        public bool ArePricesSortedLowToHigh()
        {
            var prices = new List<double>();
            foreach (IWebElement e in pricesElements)
            {
                prices.Add(double.Parse((e.Text).Trim('$')));
            }

            List<double> sortedList = new List<double>(prices);
            sortedList.Sort();
            return sortedList.SequenceEqual(prices);           

        }
    }
}
