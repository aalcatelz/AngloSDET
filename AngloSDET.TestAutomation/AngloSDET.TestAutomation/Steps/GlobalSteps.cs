using AngloSDET.TestAutomation.UI.Interfaces;
using AngloSDET.TestAutomation.UI.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AngloSDET.TestAutomation.UI.Steps
{
    [Binding]
    public class GlobalSteps
    {
        IHeaderPanel _headerPanel;
        ICategoryMenu _categoryMenu;
        IHomePage _homePage;
        private readonly Cart _cart;

        public GlobalSteps(ICategoryMenu categoryMenu, IHomePage homePage, IHeaderPanel headerPanel, Cart cart)
        {
            _categoryMenu = categoryMenu;
            _homePage = homePage;
            _cart = cart;
            _headerPanel = headerPanel;
        }

        [Given(@"I have completed preconditions for navigating to automationteststore page")]
        public void GivenIHaveCompletedPreconditionsForNavigatingToAutomationteststorePage()
        {
        }

        [When(@"I select category '(.*)' with subcategory '(.*)'")]
        public void WhenISelectCategoryWithSubcategory(string category, string subcategory)
        {
            _categoryMenu.SelectProducts(category, subcategory);
        }

        [When(@"I add product '(.*)' to cart")]
        public void WhenIAddProductToCart(string product)
        {
            _homePage.AddProduct(product);
            _cart.Products.Add(new Product()
            {
                Name = product
            });
        }

        [When(@"I open Cart from header panel")]
        public void WhenIOpenCartFromHeaderPanel()
        {
            _headerPanel.OpenCart();
        }

        [Then(@"Shopping cart should be empty")]
        public void ThenShoppingCartShouldBeEmpty()
        {
            var actualCart = _homePage.GetShoppingCart();
            actualCart.Products.Should().BeEmpty();            
        }

        [Then(@"Shopping cart contains added products")]
        public void ThenShoppingCartContainsAddedProducts()
        {
            var actualCart = _homePage.GetShoppingCart();
            actualCart.Products.Should().HaveCount(_cart.Products.Count, "Verification products count failed");
            actualCart.Products.Select(x => x.Name).Should().Equal(_cart.Products.Select(x => x.Name), "Verification products failed");
        }
    }
}