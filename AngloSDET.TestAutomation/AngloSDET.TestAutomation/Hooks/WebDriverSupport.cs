using AngloSDET.TestAutomation.UI.Infrastructure;
using AngloSDET.TestAutomation.UI.Interfaces;
using AngloSDET.TestAutomation.UI.Pages;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AngloSDET.TestAutomation.UI.Hooks
{
    [Binding]
    public sealed class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;
        private static IWebDriver webDriver;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            webDriver = new ChromeDriver(CreateChromeOptions)
            {
                Url = ConfigurationReader.BaseUrl
            };
            webDriver.Manage().Timeouts().ImplicitWait = ConfigurationReader.ImplicitWaitSec;
            _objectContainer.RegisterInstanceAs(webDriver);
            _objectContainer.RegisterTypeAs<HeaderPanel, IHeaderPanel>();
            _objectContainer.RegisterTypeAs<CategoryMenu, ICategoryMenu>();
            _objectContainer.RegisterTypeAs<HomePage, IHomePage>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Close();
            webDriver.Dispose();
        }

        private static ChromeOptions CreateChromeOptions
        {
            get
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("test-type");
                chromeOptions.AddArgument("start-maximized");
                chromeOptions.AddArgument("--disable-extensions");

                return chromeOptions;
            }
        }
    }
}