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

        public ConfigWindow()
        {
            InitializeComponent();

            // Init config collection
            this.configCollection = this.PrepareConfigData();

            // Set data to the list view
            this.configListView.SetObjects(this.configCollection);
        }

        // Prepare list with config items to the list view
        private List<ConfigItem> PrepareConfigData()
        {
            string subdomainRootDirectory = Config.Default.SubdomainRootDirectory;
            string hostConfigDirectory = Config.Default.HostConfigDirectory;
            string certificateDirectory = Config.Default.CertificateDirectory;

            // Prepare collection
            List<ConfigItem> configCollection = new List<ConfigItem>
            {
                new ConfigItem { Name = "SubdomainRootDirectory", Description = "Subdomains directory", Value = subdomainRootDirectory },
                new ConfigItem { Name = "HostConfigDirectory", Description = "Hosts configuration files", Value = hostConfigDirectory },
                new ConfigItem { Name = "CertificateDirectory", Description = "Certificates directory", Value = certificateDirectory }
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

            // Save changes
            Config.Default.Save();

            // Close window
            this.Close();
        }
    }
}
