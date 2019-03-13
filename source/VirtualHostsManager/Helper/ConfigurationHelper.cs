using System;
using System.Diagnostics;
using System.IO;

namespace VirtualHostsManager.Helper
{
    class ConfigurationHelper
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
    }
}
