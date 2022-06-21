using Microsoft.Extensions.Configuration;

namespace AngloSDET.TestAutomation.Core.Helpers
{
    public class ConfigurationHelper
    {
        public static IConfiguration GetConfig(string file = "appsettings.json")
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(file, true, true);

            return builder.Build();
        }
    }
}