using AngloSDET.TestAutomation.UI.Interfaces;
using AngloSDET.TestAutomation.UI.Models;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AngloSDET.TestAutomation.UI.Pages
{
    public class HomePage : BasePage, IHomePage
    {
        private readonly IWebDriver _webDriver;
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Elements
        private IWebElement ProductBlock(string name) => _webDriver.FindElement(By.CssSelector($"a[title='{name}']"));
        private IWebElement AddToCartButton => _webDriver.FindElement(By.CssSelector("li a.cart"));
        private ReadOnlyCollection<IWebElement> ProductRows => _webDriver.FindElements(By.CssSelector("div.product-list tr:nth-child(n+2)"));
        private ReadOnlyCollection<IWebElement> TotalRows => _webDriver.FindElements(By.CssSelector("table#totals_table tr td:nth-child(n+2)"));
        private ReadOnlyCollection<IWebElement> EmptyCartLabel => _webDriver.FindElements(By.XPath("//div[contains(.,'Your shopping cart is empty!')]"));        
        #endregion

        #region Methods
        public void AddProduct(string name)
        {
            ProductBlock(name).Click();
            AddToCartButton.Click();
        }

        public Cart GetShoppingCart()
        {
            var cart = new Cart();
            if (EmptyCartLabel.Count != 0)
            {
                return cart;
            }
            
            foreach (var productRow in ProductRows)
            {
                var colums = productRow.FindElements(By.CssSelector("td"));
                cart.Products.Add(new Product()
                {
                    Name = colums[1].FindElement(By.CssSelector("a")).Text,
                    Model = colums[2].Text,
                    UnitPrice = Convert.ToDecimal(colums[3].Text[1..]),
                    Quantity = Convert.ToInt32(colums[4].FindElement(By.CssSelector("input")).GetAttribute("value")),
                    Total = Convert.ToDecimal(colums[5].Text[1..])
                });
            }

            cart.SubTotal = Convert.ToDecimal(TotalRows[0].Text[1..]);
            cart.FlatShippingRate = Convert.ToDecimal(TotalRows[1].Text[1..]);
            cart.Total = Convert.ToDecimal(TotalRows[2].Text[1..]);

            return cart;
        }

        #endregion
    }
}