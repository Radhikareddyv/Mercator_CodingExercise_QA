using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Mercator_CodingExercise_QA.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private IList<IWebElement> ProductPrices => _driver.FindElements(By.XPath("//div[@data-test='inventory-item-price']"));
        private IWebElement CartBadge => _wait.Until(d => d.FindElement(By.XPath("//span[@data-test='shopping-cart-badge']")));


        // Actions
        public void WaitForProductPageToLoad()
        {
            _wait.Until(d => d.Url.Contains("/inventory.html"));
        }

        public string SelectAndAddHighestPricedItem()
        {
            string expectedPrice = string.Empty;
            if (ProductPrices.Count == 0)
            {
                throw new Exception("No prices found on the page.");
            }

            double maxPrice = 0;
            IWebElement highestPriceElement = null;

            foreach (var priceElement in ProductPrices)
            {
                string priceText = priceElement.Text.Replace("$", "").Trim();
                if (double.TryParse(priceText, out double price) && price > maxPrice)
                {
                    maxPrice = price;
                    highestPriceElement = priceElement;
                    expectedPrice = priceText; // Store highest price
                }
            }
            
            if (highestPriceElement == null)
            {
                throw new Exception("Unable to determine the highest-priced item.");
            }
            
            var addToCartButton = highestPriceElement.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-fleece-jacket']"));
            addToCartButton.Click();
            return expectedPrice;
        }
        

        public bool IsItemAddedToCart()
        {
            return CartBadge.Displayed;
        }

        public void ClickAddToCart()
        {
            CartBadge.Click();


        }
    }
}
