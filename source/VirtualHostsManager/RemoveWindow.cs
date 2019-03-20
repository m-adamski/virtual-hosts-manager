using PSHostsFile;
using System;
using System.IO;
using System.Windows.Forms;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class RemoveWindow : Form
    {

        private HostItem currentHostItem;

        public RemoveWindow(HostItem hostItem)
        {
            InitializeComponent();

            // Assign specified instance of the Host Item
            this.currentHostItem = hostItem;
        }

        // Try to remove file with specified path
        private bool RemoveFile(string path)
        {
            try
            {
                File.Delete(path);

                return true;
            }
            catch (SystemException)
            {

                // Display error box
                DialogResult dialogResult = MessageBox.Show($"There was a problem while trying to delete the file ({path})", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Retry)
                {
                    return this.RemoveFile(path);
                }
                else
                {
                    return false;
                }
            }
        }

        // Try to remove directory with specified path
        private bool RemoveDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);

                return true;
            }
            catch (SystemException)
            {

                // Display error box
                DialogResult dialogResult = MessageBox.Show($"There was a problem while trying to delete the directory ({path})", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Retry)
                {
                    return this.RemoveDirectory(path);
                }
                else
                {
                    return false;
                }
            }
        }

        // Try to remove specified domain from Windows Hosts file
        private bool RemoveEntry(string domainName)
        {
            try
            {
                HostsFile.Remove(domainName);

                return true;
            }
            catch (SystemException)
            {
                return false;
            }
        }

        // Remove selected elements
        private void confirmButton_Click(object sender, EventArgs e)
        {

            // The final confirmation
            DialogResult dialogResult = MessageBox.Show("Removed items can not be restored. Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {

                string domainName = this.currentHostItem.Domain;
                string certificatePath = this.currentHostItem.CertificatePath;
                string certificateKeyPath = this.currentHostItem.CertificateKeyPath;
                string configurationPath = this.currentHostItem.ConfigurationPath;
                string directoryPath = this.currentHostItem.DirectoryPath;

                // Remove files
                bool certificateStatus = this.RemoveFile(certificatePath);
                bool certificateKeyStatus = this.RemoveFile(certificateKeyPath);
                bool configurationStatus = this.RemoveFile(configurationPath);

                // Prepare statuses
                bool directoryStatus = true;
                bool entryStatus = true;

                // Remove subdomain directory
                if (true == this.directoryCheckBox.Checked)
                {
                    directoryStatus = this.RemoveDirectory(directoryPath);
                }

                // Remove entry from Windows Hosts file
                if (true == this.entryCheckBox.Checked)
                {
                    entryStatus = this.RemoveEntry(domainName);
                }

                // Display status information
                if (certificateStatus && certificateKeyStatus && configurationStatus && directoryStatus && entryStatus)
                {
                    MessageBox.Show("The configuration has been successfully removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    string configurationStatusMessage = configurationStatus ? "Ok" : "Fail";
                    string certificateStatusMessage = certificateStatus ? "Ok" : "Fail";
                    string certificateKeyStatusMessage = certificateKeyStatus ? "Ok" : "Fail";
                    string directoryStatusMessage = directoryStatus ? "Ok" : "Fail";
                    string entryStatusMessage = entryStatus ? "Ok" : "Fail";

                    // Prepare message content
                    string errorMessage = "There was a problem while trying to remove the configuration. Below are the statuses of the activities performed:\n\n" +
                        $"     Configuration file: {configurationStatusMessage}\n" +
                        $"     Certificate file: {certificateStatusMessage}\n" +
                        $"     Certificate key file: {certificateKeyStatusMessage}\n" +
                        $"     Subdomain directory: {directoryStatusMessage}\n" +
                        $"     Entry in system hosts file: {entryStatusMessage}";

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Close window
                this.Close();
            }
        }
    }
}
