using PSHostsFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VirtualHostsManager.Helper;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class CreateWindow : Form
    {

        private ConfigurationHelper configurationHelper;
        private ScintillaHelper scintillaHelper;
        private List<HostItem> hostCollection;
        private HostItem selectedHostItem;

        public CreateWindow()
        {
            InitializeComponent();

            // Init dependencies
            this.configurationHelper = new ConfigurationHelper();
            this.scintillaHelper = new ScintillaHelper();

            // Style editor
            this.scintillaHelper.ConfigureLexer(ref this.contentEditor);

            // Init hosts collection
            this.hostCollection = this.PrepareHostData();

            // Set data to the list view
            this.hostListView.SetObjects(this.hostCollection);
        }

        // Prepare list with hosts items to the list view
        private List<HostItem> PrepareHostData()
        {
            string subdomainRootDirectory = Config.Default.SubdomainRootDirectory;
            string hostConfigDirectory = Config.Default.HostConfigDirectory;
            string certificateDirectory = Config.Default.CertificateDirectory;

            // Prepare collection
            List<HostItem> hostCollection = new List<HostItem>();

            // Get collection of the directories
            string[] directoriesCollection = this.GetDirectories(subdomainRootDirectory);

            // Prepare items
            foreach (string directoryPath in directoriesCollection)
            {
                string directoryName = new DirectoryInfo(directoryPath).Name;
                string configurationPath = Path.Combine(new string[] { hostConfigDirectory, directoryName + ".conf" });
                string certificatePath = Path.Combine(new string[] { certificateDirectory, directoryName + ".cert" });
                string certificateKeyPath = Path.Combine(new string[] { certificateDirectory, directoryName + ".key" });
                string configurationContent = this.PrepareConfigContent(directoryName, directoryPath, certificatePath, certificateKeyPath);

                // Create instance of the Host Item
                HostItem hostItem = new HostItem
                {
                    Domain = directoryName,
                    DirectoryPath = directoryPath,
                    ConfigurationPath = configurationPath,
                    CertificatePath = certificatePath,
                    CertificateKeyPath = certificateKeyPath,
                    ConfigurationContent = configurationContent
                };

                // Add created item to the collection when configuration file does not exist
                if (!File.Exists(configurationPath))
                {
                    hostCollection.Add(hostItem);
                }
            }

            return hostCollection;
        }

        // Prepare content of the host configuration
        private string PrepareConfigContent(string domainName, string directoryPath, string certificatePath, string certificateKeyPath)
        {
            string configTemplate = Config.Default.HostConfigTemplate;

            // Replace parameters
            configTemplate = configTemplate.Replace("@Name", domainName);
            configTemplate = configTemplate.Replace("@DocumentRootPath", directoryPath);
            configTemplate = configTemplate.Replace("@CertificatePath", certificatePath);
            configTemplate = configTemplate.Replace("@CertificateKeyPath", certificateKeyPath);

            return configTemplate;
        }

        // Get collection of the directories paths from specified root path
        private string[] GetDirectories(string rootPath)
        {
            try
            {
                return Directory.GetDirectories(rootPath);
            }
            catch (SystemException)
            {
                return new string[] { };
            }
        }

        // Find instance of the Host Item with specified domain
        private HostItem GetByDomain(string domainName)
        {
            try
            {
                return this.hostCollection.Find(x => x.Domain.Equals(domainName));
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        // Reset collection
        private void ResetCollection()
        {

            // Reload list view
            this.hostListView.Items.Clear();
            this.hostListView.Update();

            // Reset content editor
            this.contentEditor.Text = "Select the domain to create the virtual host configuration";

            // Refresh collection
            this.hostCollection = this.PrepareHostData();
            this.hostListView.SetObjects(this.hostCollection);
        }

        // Print host configuration content on domain selection changed
        private void hostListView_SelectionChanged(object sender, EventArgs e)
        {

            // Get selected item
            ListViewItem selectedItem = this.hostListView.SelectedItem;

            if (null != selectedItem)
            {

                // Find instance of the Host Item based on selected domain
                string domainName = selectedItem.Text;
                HostItem hostItem = this.GetByDomain(domainName);

                if (null != hostItem)
                {
                    this.selectedHostItem = hostItem;
                    this.contentEditor.Text = hostItem.ConfigurationContent;

                    // Enable Create button
                    this.createButton.Enabled = true;
                }
            }
            else
            {
                this.selectedHostItem = null;
                this.contentEditor.Text = "Select the domain to create the virtual host configuration";

                // Disable Create button
                this.createButton.Enabled = false;
            }
        }

        // Change content of the selected host item
        private void contentEditor_TextChanged(object sender, EventArgs e)
        {
            string currentContent = this.contentEditor.Text;

            // Overwrite content of the selected host item
            if (null != this.selectedHostItem)
            {
                this.selectedHostItem.ConfigurationContent = currentContent;
            }
        }

        // Reset changes
        private void resetButton_Click(object sender, EventArgs e)
        {

            // Display confirm box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset configuration?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Reset only when confirmed
            if (dialogResult == DialogResult.Yes)
            {
                this.ResetCollection();
            }
        }

        // Create configuration
        private void createButton_Click(object sender, EventArgs e)
        {

            // Check if selected host item is not null
            // This should never happened but better check
            if (null != this.selectedHostItem)
            {
                string domainName = this.selectedHostItem.Domain;
                string directoryPath = this.selectedHostItem.DirectoryPath;
                string configurationPath = this.selectedHostItem.ConfigurationPath;
                string certificatePath = this.selectedHostItem.CertificatePath;
                string certificateKeyPath = this.selectedHostItem.CertificateKeyPath;
                string configurationContent = this.selectedHostItem.ConfigurationContent;

                // Create and show Progress Window
                ProgressWindow progressWindow = new ProgressWindow();
                progressWindow.Show();

                // Check if creation is allowed
                if (Directory.Exists(directoryPath))
                {
                    if (!File.Exists(configurationPath))
                    {
                        if (!File.Exists(certificatePath) && !File.Exists(certificateKeyPath))
                        {

                            // Generate certificate
                            bool certificateStatus = this.configurationHelper.GenerateCertificate(domainName, certificatePath, certificateKeyPath);

                            // Check generation status
                            if (true == certificateStatus)
                            {

                                // Save virtual host configuration
                                bool configurationStatus = this.configurationHelper.WriteConfiguration(configurationPath, configurationContent);

                                // Check write status
                                if (true == configurationStatus)
                                {

                                    // Display confirm box
                                    DialogResult dialogResult = MessageBox.Show("The configuration has been completed successfully.\nDo you want to add an entry in the system hosts file?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    // Add entry to hosts file when confirmed
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        try
                                        {

                                            // Try to add new host into hosts configuration file
                                            HostsFile.Set(domainName, "127.0.0.1");

                                            // Show success message
                                            MessageBox.Show("The entry has been successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (SystemException)
                                        {
                                            MessageBox.Show("There was a problem while trying to add an entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                    // Reset collection
                                    this.ResetCollection();
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem while trying to write the configuration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("There was a problem creating the certificate. Make sure the configuration is correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("One of the certificate files already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The virtual host configuration file already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The main subdomain directory was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Close Progress Window
                progressWindow.Close();
            }
        }
    }
}
