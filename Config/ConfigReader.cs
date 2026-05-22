using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BDDWebShopApp.Config
{
    public class ConfigReader
    {
        private static IConfigurationRoot config;

        static ConfigReader()
        {
            try
            {
                var configPath = GetConfigDataPath();

                if (configPath == null)
                {
                    throw new FileNotFoundException("config.json not found in project root or Config directory");
                }

                config = new ConfigurationBuilder()
                    .SetBasePath(Path.GetDirectoryName(configPath))
                    .AddJsonFile(Path.GetFileName(configPath), optional: false, reloadOnChange: true)
                    .Build();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load configuration", ex);
            }
        }

        /// <summary>
        /// Gets the Config folder path relative to the project root
        /// </summary>
        private static string GetConfigDataPath()
        {
            // Get the project root by finding the solution directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = currentDirectory;

            // Navigate up from bin\Debug\net8.0 to project root
            while (!File.Exists(Path.Combine(projectRoot, "BDDWebShopApp.csproj")))
            {
                projectRoot = Directory.GetParent(projectRoot)?.FullName;
                if (projectRoot == null)
                {
                    throw new DirectoryNotFoundException("Could not find project root. Ensure BDDWebShopApp.csproj exists.");
                }
            }

            return Path.Combine(projectRoot, "Config","config.json");
        }

        public static string BaseUrl => config["BaseUrl"] ?? string.Empty;
    }
}