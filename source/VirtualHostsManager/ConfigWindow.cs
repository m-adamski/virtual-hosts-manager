using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class ConfigWindow : Form
    {

        private List<ConfigItem> configCollection;

        private List<ConfigItem> certificateConfigCollection;

        public ConfigWindow()
        {
            InitializeComponent();

            // Init config collection
            this.configCollection = this.PrepareConfigData();
            this.certificateConfigCollection = this.PrepareCertificateConfigData();

            // Set data to the list view
            this.configListView.SetObjects(this.configCollection);
            this.certificateListView.SetObjects(this.certificateConfigCollection);
        }

        // Prepare list with config items to the list view
        private List<ConfigItem> PrepareConfigData()
        {
            string subdomainRootDirectory = Config.Default.SubdomainRootDirectory;
            string hostConfigDirectory = Config.Default.HostConfigDirectory;
            string certificateDirectory = Config.Default.CertificateDirectory;
            string openSSLPath = Config.Default.OpenSSLPath;

            // Prepare collection
            List<ConfigItem> configCollection = new List<ConfigItem>
            {
                new ConfigItem { Name = "SubdomainRootDirectory", Description = "Subdomains directory", Value = subdomainRootDirectory },
                new ConfigItem { Name = "HostConfigDirectory", Description = "Hosts configuration files", Value = hostConfigDirectory },
                new ConfigItem { Name = "CertificateDirectory", Description = "Certificates directory", Value = certificateDirectory },
                new ConfigItem { Name = "OpenSSLPath", Description = "OpenSSL", Value = openSSLPath }
            };

            return configCollection;
        }

        // Prepare list with certificate config items to the list view
        private List<ConfigItem> PrepareCertificateConfigData()
        {
            string countryName = Config.Default.CertificateCountryName;
            string stateName = Config.Default.CertificateStateName;
            string localityName = Config.Default.CertificateLocalityName;
            string organizationName = Config.Default.CertificateOrganizationName;
            string unitName = Config.Default.CertificateUnitName;
            string emailAddress = Config.Default.CertificateEmailAddress;

            // Prepare collection
            List<ConfigItem> configCollection = new List<ConfigItem>
            {
                new ConfigItem { Name = "CertificateCountryName", Description = "Country Name (2 letter code)", Value = countryName },
                new ConfigItem { Name = "CertificateStateName", Description = "State or Province Name", Value = stateName },
                new ConfigItem { Name = "CertificateLocalityName", Description = "Locality Name (eg, city)", Value = localityName },
                new ConfigItem { Name = "CertificateOrganizationName", Description = "Organization Name (eg, company)", Value = organizationName },
                new ConfigItem { Name = "CertificateUnitName", Description = "Organizational Unit Name (eg, section)", Value = unitName },
                new ConfigItem { Name = "CertificateEmailAddress", Description = "Email Address", Value = emailAddress }
            };

            return configCollection;
        }

        // Save changes to the Config and close window
        private void saveButton_Click(object sender, EventArgs e)
        {

            // Update config values
            foreach (ConfigItem configItem in this.configCollection)
            {
                Config.Default[configItem.Name] = configItem.Value;
            }

            // Update certificate config values
            foreach (ConfigItem configItem in this.certificateConfigCollection)
            {
                Config.Default[configItem.Name] = configItem.Value;
            }

            // Save changes
            Config.Default.Save();

            // Close window
            this.Close();
        }
    }
}
