using AngloSDET.TestAutomation.UI.Interfaces;
using OpenQA.Selenium;

namespace AngloSDET.TestAutomation.UI.Pages
{
    public class HeaderPanel : BasePage, IHeaderPanel
    {

        private readonly IWebDriver _webDriver;
        public HeaderPanel(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Elements
        private IWebElement CartLink => _webDriver.FindElement(By.CssSelector("ul#main_menu_top li[data-id='menu_cart']"));
        #endregion

        #region Methods
        public void OpenCart()
        {
            CartLink.Click();
        }
        #endregion
    }
}