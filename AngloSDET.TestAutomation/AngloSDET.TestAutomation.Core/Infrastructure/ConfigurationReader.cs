using AngloSDET.TestAutomation.Core.Helpers;
using Microsoft.Extensions.Configuration;

namespace AngloSDET.TestAutomation.Core.Infrastructure
{
    public static class ConfigurationReader
    {
        private static readonly IConfiguration Config = ConfigurationHelper.GetConfig();
        public static string Url => Config["url"];
        public static TimeSpan ImplicitWaitSec =>
            TimeSpan.FromSeconds(Convert.ToInt32(Config["implicitWaitSec"]));
    }
}
