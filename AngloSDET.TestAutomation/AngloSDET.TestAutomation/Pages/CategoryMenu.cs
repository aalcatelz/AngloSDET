using AngloSDET.TestAutomation.UI.Interfaces;
using OpenQA.Selenium;

namespace AngloSDET.TestAutomation.UI.Pages
{
    public class CategoryMenu : BasePage, ICategoryMenu
    {

        private readonly IWebDriver _webDriver;
        public CategoryMenu(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Elements
        private IWebElement Category(string category) => _webDriver.FindElement(By.XPath($"//section[@id='categorymenu']//a[contains(.,'{category}')]"));
        private IWebElement SubCategory(string subCategory) => _webDriver.FindElement(By.XPath($"//ul[@class='thumbnails row']//a[contains(.,'{subCategory}')]"));

        #endregion

        #region Methods
        public void SelectProducts(string category, string subcategory)
        {
            Category(category).Click();
            SubCategory(subcategory).Click();
        }
        #endregion
    }
}