using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using VirtualHostsManager.Model;

namespace VirtualHostsManager.Helper
{
    public class ConfigurationHelper
    {

        // Generate certificate for specified domain
        public bool GenerateCertificate(string domainName, string certificatePath, string certificateKeyPath)
        {

            // Get config certificate parameters
            string countryName = Config.Default.CertificateCountryName;
            string stateName = Config.Default.CertificateStateName;
            string localityName = Config.Default.CertificateLocalityName;
            string organizationName = Config.Default.CertificateOrganizationName;
            string unitName = Config.Default.CertificateUnitName;

            // Get OpenSSL path
            string openSSLPath = Config.Default.OpenSSLPath;

            // Define OpenSSL command
            string certificateGenerateCommand = $"req -x509 -nodes -newkey rsa:4096 -keyout \"{certificateKeyPath}\" -out \"{certificatePath}\" -days 365 -subj \"/C={countryName}/ST={stateName}/L={localityName}/O={organizationName}/OU={unitName}/CN={domainName}\"";

            // Run command
            int generateCode = this.RunCommand(openSSLPath, certificateGenerateCommand);

            // Return status
            return 0 == generateCode;
        }

        // Write configuration content
        public bool WriteConfiguration(string configurationPath, string configurationContent)
        {
            try
            {
                using (StreamWriter streamWriter = File.CreateText(configurationPath))
                {
                    streamWriter.Write(configurationContent);
                }

                return true;
            }
            catch (SystemException)
            {
                return false;
            }
        }

        // Get collection of paths of the configuration files
        public string[] GetConfigurationsCollection(string configurationDirectory)
        {
            try
            {
                return Directory.GetFiles(configurationDirectory, "*.conf");
            }
            catch (SystemException)
            {
                return new string[] { };
            }
        }

        // Read content of the specified file
        public string ReadConfigurationFile(string configurationPath)
        {
            try
            {
                return File.ReadAllText(configurationPath);
            }
            catch (SystemException)
            {
                return null;
            }
        }

        // Parse specified content of the configuration file
        public HostItem ParseConfiguration(string configurationPath, string configurationContent)
        {

            string subdomainRootDirectory = Config.Default.SubdomainRootDirectory;
            string hostConfigDirectory = Config.Default.HostConfigDirectory;
            string certificateDirectory = Config.Default.CertificateDirectory;

            // Define Apache Regex Match
            Match domainNameMatch = Regex.Match(configurationContent, "(servername|server_name)(.*)", RegexOptions.IgnoreCase);
            Match directoryPathMatch = Regex.Match(configurationContent, "(documentroot|root)(.*)", RegexOptions.IgnoreCase);
            Match certificatePathMatch = Regex.Match(configurationContent, "(sslcertificatefile|ssl_certificate)(.*)", RegexOptions.IgnoreCase);
            Match certificateKeyPathMatch = Regex.Match(configurationContent, "(sslcertificatekeyfile|ssl_certificate_key)(.*)", RegexOptions.IgnoreCase);

            // Get matching values
            string domainName = this.RegexValue(domainNameMatch, 2);
            string directoryPath = this.RegexValue(directoryPathMatch, 2);
            string certificatePath = this.RegexValue(certificatePathMatch, 2);
            string certificateKeyPath = this.RegexValue(certificateKeyPathMatch, 2);

            // Trim values to remove whitespaces
            domainName = this.ClearString(domainName, new string[] { "'", "\"", ";" })?.Trim();
            directoryPath = this.ClearString(directoryPath, new string[] { "'", "\"", ";" })?.Trim();
            certificatePath = this.ClearString(certificatePath, new string[] { "'", "\"", ";" })?.Trim();
            certificateKeyPath = this.ClearString(certificateKeyPath, new string[] { "'", "\"", ";" })?.Trim();

            if (null != domainName && null != directoryPath)
            {

                // Split directory path into parts
                string[] directoryPathParts = directoryPath.Replace(subdomainRootDirectory, "").Trim('\\').Split('\\');

                if (directoryPathParts.Length > 0 && directoryPathParts[0] == domainName)
                {

                    // Create instance of the Host Item
                    return new HostItem
                    {
                        Domain = domainName,
                        DirectoryPath = Path.Combine(subdomainRootDirectory, domainName),
                        ConfigurationPath = configurationPath,
                        CertificatePath = certificatePath,
                        CertificateKeyPath = certificateKeyPath,
                        ConfigurationContent = configurationContent
                    };
                }
            }

            return null;
        }

        // Run specified command with provided arguments
        private int RunCommand(string fileName, string arguments)
        {
            Process commandProcess = new Process();
            commandProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            commandProcess.StartInfo.FileName = fileName;
            commandProcess.StartInfo.Arguments = arguments;
            commandProcess.Start();

            // Wait for process exit
            commandProcess.WaitForExit();

            // Return exit code
            return commandProcess.ExitCode;
        }

        // Get value of the group with specified index
        private string RegexValue(Match match, int groupNumber = 1)
        {
            if (match.Success)
            {

                // Get value of the group with specified index
                string matchValue = match.Groups[groupNumber].Value;

                return null != matchValue && "" != matchValue ? matchValue : null;
            }

            return null;
        }

        // Remove specified characters from provided string
        private string ClearString(string value, string[] items)
        {
            string returnValue = value;

            if (null != returnValue && items.Length > 0)
            {
                foreach (string item in items)
                {
                    returnValue = returnValue.Replace(item, "");
                }
            }

            return returnValue;
        }
    }
}
