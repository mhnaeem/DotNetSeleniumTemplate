using DotNetSeleniumTemplate.Helpers.Model;
using Microsoft.Extensions.Configuration;

namespace DotNetSeleniumTemplate.Helpers
{
	public class ConfigurationRoot
	{
        private static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("envsettings.json")
                .Build();
        }

        public static AppSettings GetApplicationConfiguration()
        {
            var configuration = new AppSettings();

            var iConfig = GetIConfigurationRoot(AppContext.BaseDirectory);

            iConfig.GetSection("EnvSettings").Bind(configuration);

            return configuration;
        }
    }
}
