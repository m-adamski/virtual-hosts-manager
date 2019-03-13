using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VirtualHostsManager.Helper;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class MainWindow : Form
    {

        private ConfigurationHelper configurationHelper;
        private HostItem selectedHostItem;

        public MainWindow()
        {
            InitializeComponent();

            // Init dependencies
            this.configurationHelper = new ConfigurationHelper();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {

            // Get config variables
            string subdomainRootDirectory = Config.Default.SubdomainRootDirectory;
            string hostConfigDirectory = Config.Default.HostConfigDirectory;
            string certificateDirectory = Config.Default.CertificateDirectory;
            string openSSLPath = Config.Default.OpenSSLPath;

            // Check if directories exist
            if (!Directory.Exists(subdomainRootDirectory) || !Directory.Exists(hostConfigDirectory) || !Directory.Exists(certificateDirectory) || !File.Exists(openSSLPath))
            {
                this.configInfoPictureBox.Visible = true;
                this.createButton.Enabled = false;
                this.scanButton.Enabled = false;
            }
            else
            {
                this.configInfoPictureBox.Visible = false;
                this.createButton.Enabled = true;
                this.scanButton.Enabled = true;
            }
        }

        // Show Config Window
        private void configButton_Click(object sender, EventArgs e)
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }

        // Show Template Window
        private void templateButton_Click(object sender, EventArgs e)
        {
            TemplateWindow templateWindow = new TemplateWindow();
            templateWindow.ShowDialog();
        }

        // Show Create Window
        private void createButton_Click(object sender, EventArgs e)
        {
            CreateWindow createWindow = new CreateWindow();
            createWindow.ShowDialog();
        }

        // Scan for existing configurations
        private void scanButton_Click(object sender, EventArgs e)
        {

            string subdomainRootDirectory = Config.Default.SubdomainRootDirectory;
            string hostConfigDirectory = Config.Default.HostConfigDirectory;
            string certificateDirectory = Config.Default.CertificateDirectory;

            // Define collection of the host items
            List<HostItem> hostCollection = new List<HostItem>();

            // Get collection with paths of the configurations files
            string[] configurationsCollection = this.configurationHelper.GetConfigurationsCollection(hostConfigDirectory);

            foreach (string configurationPath in configurationsCollection)
            {

                // Read content of the configuration file
                string configurationContent = this.configurationHelper.ReadConfigurationFile(configurationPath);

                // Parse configuration content
                HostItem hostItem = this.configurationHelper.ParseConfiguration(configurationPath, configurationContent);

                if (null != hostItem)
                {
                    hostCollection.Add(hostItem);
                }
            }

            // Clear list view
            this.hostListView.Items.Clear();
            this.hostListView.SetObjects(hostCollection);
        }

        // Show Context Menu Strip
        private void hostListView_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {

            // Get selected Host Item
            HostItem selectedItem = (HostItem)e.Model;

            if (null != selectedItem)
            {
                this.selectedHostItem = selectedItem;

                // Set Context Menu Strip to show
                e.MenuStrip = this.contextMenuStrip;
            }
        }

        // Preview details of the selected item
        private void previewStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != this.selectedHostItem)
            {
                PreviewWindow previewWindow = new PreviewWindow(this.selectedHostItem);
                previewWindow.ShowDialog();
            }
        }

        // Change stored selected item
        private void hostListView_SelectionChanged(object sender, EventArgs e)
        {

            // Get selected Host Item
            HostItem selectedItem = (HostItem)this.hostListView.SelectedObject;

            // Set selected item
            this.selectedHostItem = selectedItem;
        }

        // Remove stored selected item
        private void removeStripMenuItem_Click(object sender, EventArgs e)
        {

            // Display confirm box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this configuration?", "Are you sure?", MessageBoxButtons.OKCancel);

            // Reset only when confirmed
            if (dialogResult == DialogResult.OK)
            {

                // Display additional confirm box
                dialogResult = MessageBox.Show($"Do you also want to delete the entire subdomain directory ({this.selectedHostItem.DirectoryPath})?", "Are you sure?", MessageBoxButtons.YesNoCancel);

                if (dialogResult != DialogResult.Cancel)
                {

                    // TODO: Remove certificate and configuration files

                    if (dialogResult == DialogResult.Yes)
                    {

                        // TODO: Remove subdomain directory
                    }
                }
            }
        }
    }
}
