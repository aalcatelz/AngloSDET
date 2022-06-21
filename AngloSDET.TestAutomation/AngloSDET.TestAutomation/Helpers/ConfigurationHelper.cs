using Microsoft.Extensions.Configuration;

namespace AngloSDET.TestAutomation.UI.Helpers
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

        public static string GetOutputDirectory()
        {
            try
            {
                var outputDirectoryPath = Path.Combine(Directory.GetCurrentDirectory().Replace("file:\\", string.Empty));
                Directory.CreateDirectory(outputDirectoryPath);

                return outputDirectoryPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to create the output directory. {ex.Message}");
            }
        }
        public static string GetTestDataDirectory()
        {
            return Path.Combine(GetOutputDirectory(), "TestData");
        }
    }
}