using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium.Internal;

namespace Mercator_CodingExercise_QA.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement CartItemPrices => _driver.FindElement(By.XPath("//div[@data-test='inventory-item-price']"));
        public void WaitForProductPageToLoad()
        {
            _wait.Until(d => d.Url.Contains("/cart.html"));
        }

        public string VerifyHighestPricedItemInCart()
        {

                string cartPriceText = CartItemPrices.Text.Replace("$", "").Replace(",", "").Trim();
                return cartPriceText;
        }
    }
}
