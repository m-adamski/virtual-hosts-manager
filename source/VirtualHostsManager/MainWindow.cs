using System;
using System.IO;
using System.Windows.Forms;

namespace VirtualHostsManager
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
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
            }
            else
            {
                this.configInfoPictureBox.Visible = false;
                this.createButton.Enabled = true;
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
    }
}
