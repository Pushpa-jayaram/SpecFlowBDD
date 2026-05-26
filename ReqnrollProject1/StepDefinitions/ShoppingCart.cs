using NUnit.Framework;
using ReqnrollProject1.Drivers;
using ReqnrollProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions
{

    [Binding]
    public class ShoppingCartSteps
    {
        HomePage homePage;
        SearchPage searchPage;
        CartPage cartPage;

        public ShoppingCartSteps(DriverContext driverContext)
        {
            homePage = new HomePage(driverContext.driver);
            searchPage = new SearchPage(driverContext.driver);
            cartPage = new CartPage(driverContext.driver);
        }

        [Given(@"user launches application")]
        public void GivenUserLaunchesApplication()
        {

        }

        [When(@"user searches for ""([^""]*)""")]
        public void WhenUserSearchesFor(string product)
        {
            homePage.SearchProduct(product);
        }

        [When(@"user opens the product")]
        public void WhenUserOpensTheProduct()
        {
            searchPage.OpenProduct();
        }

        [When(@"user adds product to cart")]
        public void WhenUserAddsProductToCart()
        {
            searchPage.AddProductToCart();
        }

        [When(@"user opens shopping cart")]
        public void WhenUserOpensShoppingCart()
        {
            cartPage.OpenCart();
        }

        [Then(@"product should be displayed in cart")]
        public void ThenProductShouldBeDisplayedInCart()
        {
            Assert.That(cartPage.VerifyProduct(), Is.True);
        }
    }
}
