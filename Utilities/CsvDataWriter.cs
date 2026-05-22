using System;
using System.IO;
using System.Text;

namespace BDDWebShopApp.Utilities
{
    public static class CsvDataWriter
    {
        private static readonly string TestDataPath = GetTestDataPath();
        private static readonly string CsvFilePath = Path.Combine(TestDataPath, "UserCredentials.csv");

        /// <summary>
        /// Gets the TestData folder path relative to the project root
        /// </summary>
        private static string GetTestDataPath()
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

            return Path.Combine(projectRoot, "TestData");
        }

        /// <summary>
        /// Writes username and password to CSV file. Appends if file exists, creates if not.
        /// </summary>
        /// <param name="username">Username/Email to save</param>
        /// <param name="password">Password to save</param>
        public static void WriteUserCredentialsToCsv(string username, string password)
        {
            try
            {
                // Create TestData directory if it doesn't exist
                if (!Directory.Exists(TestDataPath))
                {
                    Directory.CreateDirectory(TestDataPath);
                }

                // Check if file exists to determine if we need to write headers
                bool fileExists = File.Exists(CsvFilePath);

                using (StreamWriter writer = new StreamWriter(CsvFilePath, append: true, encoding: Encoding.UTF8))
                {
                    // Write headers if file is new
                    if (!fileExists)
                    {
                        writer.WriteLine("Username,Password");
                    }

                    // Write the data row
                    string escapedUsername = EscapeCsvField(username);
                    string escapedPassword = EscapeCsvField(password);
                    writer.WriteLine($"{escapedUsername},{escapedPassword}");
                    writer.Flush();
                }

                Console.WriteLine($"Credentials saved to: {CsvFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Escapes CSV field values that contain commas or quotes
        /// </summary>
        private static string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return string.Empty;
            }

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }

            return field;
        }
    }
}