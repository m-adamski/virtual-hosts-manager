using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class CreateWindow : Form
    {

        private List<HostItem> hostCollection;
        private HostItem selectedHostItem;

        public CreateWindow()
        {
            InitializeComponent();

            // Style editor
            this.PrepareContentEditor();

            // Init hosts collection
            this.hostCollection = this.PrepareHostData();

            // Set data to the list view
            this.hostListView.SetObjects(this.hostCollection);
        }

        // Style Scintilla editor
        // https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Syntax-Highlighting
        private void PrepareContentEditor()
        {
            this.contentEditor.StyleResetDefault();
            this.contentEditor.Styles[Style.Default].Font = "Consolas";
            this.contentEditor.Styles[Style.Default].Size = 8;
            this.contentEditor.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            this.contentEditor.Styles[Style.Cpp.Word].ForeColor = Color.Purple;
            this.contentEditor.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(128, 128, 128);
            this.contentEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21);
            this.contentEditor.Lexer = Lexer.Cpp;

            this.contentEditor.SetKeywords(0, "@Name @DocumentRootPath @CertificatePath @CertificateKeyPath");
            this.contentEditor.SetKeywords(1, "ServerName ServerAlias DocumentRoot Options AllowOverride Require SSLEngine SSLCertificateFile SSLCertificateKeyFile");
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

                // Add created item to the collection
                hostCollection.Add(hostItem);
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

        // Show error box with specified message
        private void ShowErrorBox(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RunCommand(string fileName, string arguments)
        {
            Process commandProcess = new Process();
            commandProcess.StartInfo.UseShellExecute = false;
            commandProcess.StartInfo.RedirectStandardOutput = true;
            commandProcess.StartInfo.FileName = fileName;
            commandProcess.StartInfo.Arguments = arguments;
            commandProcess.Start();

            string output = commandProcess.StandardOutput.ReadToEnd();

            commandProcess.WaitForExit();

            System.Diagnostics.Debug.WriteLine(arguments);
            System.Diagnostics.Debug.WriteLine(output);

            //Process commandProcess = new Process();
            //ProcessStartInfo commandProcessStartInfo = new ProcessStartInfo();

            //commandProcessStartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //commandProcessStartInfo.FileName = "cmd.exe";
            //commandProcessStartInfo.Arguments = command;

            //commandProcess.StartInfo = commandProcessStartInfo;
            //commandProcess.Start();
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset configurations of virtual hosts?", "Are you sure?", MessageBoxButtons.OKCancel);

            // Reset only when confirmed
            if (dialogResult == DialogResult.OK)
            {

                // Reload list view
                this.hostListView.SelectedIndex = -1;
                this.hostListView.Update();

                // Refresh collection
                this.hostCollection = this.PrepareHostData();
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

                // Get config certificate parameters
                string countryName = Config.Default.CertificateCountryName;
                string stateName = Config.Default.CertificateStateName;
                string localityName = Config.Default.CertificateLocalityName;
                string organizationName = Config.Default.CertificateOrganizationName;
                string unitName = Config.Default.CertificateUnitName;
                string emailAddress = Config.Default.CertificateEmailAddress;

                // Get OpenSSL path
                string openSSLPath = Config.Default.OpenSSLPath;

                // Check if creation is allowed
                if (Directory.Exists(directoryPath))
                {
                    if (!File.Exists(configurationPath))
                    {
                        if (!File.Exists(certificatePath) && !File.Exists(certificateKeyPath))
                        {

                            // Generate OpenSSL command
                            string certificateGenerateCommand = $"req -x509 -nodes -newkey rsa:4096 -keyout \"{certificateKeyPath}\" -out \"{certificatePath}\" -days 365 -subj \"//C={countryName}/ST={stateName}/L={localityName}/O={organizationName}/OU={unitName}/CN={domainName}\"";

                            // Run command
                            this.RunCommand(openSSLPath, certificateGenerateCommand);
                        }
                        else
                        {
                            this.ShowErrorBox("One of the certificate files already exists");
                        }
                    }
                    else
                    {
                        this.ShowErrorBox("The virtual host configuration file already exists");
                    }
                }
                else
                {
                    this.ShowErrorBox("The main subdomain directory was not found");
                }
            }
        }
    }
}
