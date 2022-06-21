using AngloSDET.TestAutomation.UI.Interfaces;
using OpenQA.Selenium;

namespace AngloSDET.TestAutomation.UI.Pages
{
    public class BasePage : IBasePage
    {
        private readonly IWebDriver _webDriver;
        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        #region Elements
        protected IWebElement BaseLink(string text) => _webDriver.FindElement(By.XPath($"//a[contains(.,'{text}')]"));
        #endregion
    }
}