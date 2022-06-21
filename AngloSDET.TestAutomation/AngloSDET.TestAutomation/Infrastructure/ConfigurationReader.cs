using AngloSDET.TestAutomation.UI.Helpers;
using Microsoft.Extensions.Configuration;

namespace AngloSDET.TestAutomation.UI.Infrastructure
{
    public static class ConfigurationReader
    {
        private static readonly IConfiguration Config = ConfigurationHelper.GetConfig();
        public static string BaseUrl => Config["url"];
        public static TimeSpan ImplicitWaitSec =>
            TimeSpan.FromSeconds(Convert.ToInt32(Config["implicitWaitSec"]));        
    }
}
