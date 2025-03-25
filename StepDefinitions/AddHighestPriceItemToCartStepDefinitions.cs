using Mercator_CodingExercise_QA.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Mercator_CodingExercise_QA.StepDefinitions
{
    [Binding]
    public class AddHighestPriceItemToCartStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productPage;
        private readonly CartPage _cartPage;
        private readonly ScenarioContext _scenarioContext;


        public AddHighestPriceItemToCartStepDefinitions(ScenarioContext scenarioContext)
        {
            _driver = Hooks.Hooks.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductsPage(_driver);
            _cartPage = new CartPage(_driver);
            _scenarioContext = scenarioContext;
        }

        [Given("I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            _loginPage.NavigateToLoginPage();
        }

        [When("I enter username (.*) and password (.*)")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then("I should be redirected to the product listing page")]
        public void ThenIShouldBeRedirectedToTheProductListingPage()
        {
            _productPage.WaitForProductPageToLoad(); // Wait for the product page to load
            Assert.IsTrue(_driver.Url.Contains("/inventory.html"), "Login was unsuccessful or redirection failed.");
        }

        [When("I select the highest-priced item")]
        public void WhenISelectTheHighest_PricedItem()
        {
            var actualPrice = _productPage.SelectAndAddHighestPricedItem();
            _scenarioContext["ActualPrice"] = actualPrice;
        }

        [Then("The item should be added to the cart successfully")]
        public void ThenTheItemShouldBeAddedToTheCartSuccessfully()
        {
            Assert.IsTrue(_productPage.IsItemAddedToCart(), "Item was not added to the cart.");
        }

        [When("I click shopping cart badge")]
        public void WhenIClickShoppingCartBadge()
        {
            _productPage.ClickAddToCart();
        }

        [When("I should be redirected to the cart page")]
        public void WhenIShouldBeRedirectedToTheCartPage()
        {
            _cartPage.WaitForProductPageToLoad(); // Wait for the product page to load
            Assert.IsTrue(_driver.Url.Contains("/cart.html"), "Login was unsuccessful or redirection failed.");
        }


        [Then("I verify the highest-priced item added to the cart")]
        public void ThenIVerifyTheHighest_PricedItemAddedToTheCart()
        {
            var actualPrice = _scenarioContext["ActualPrice"];
            var expectedPrice = _cartPage.VerifyHighestPricedItemInCart();
            Assert.AreEqual(actualPrice, expectedPrice, "The highest-priced item was not added to the cart correctly.");
        }


    }
}
