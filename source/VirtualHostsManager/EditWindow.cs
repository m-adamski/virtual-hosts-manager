using ScintillaNET;
using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualHostsManager.Helper;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class EditWindow : Form
    {
        private ConfigurationHelper configurationHelper;
        private ScintillaHelper scintillaHelper;
        private HostItem currentHostItem;
        private string originalConfigurationContent;

        public EditWindow(HostItem hostItem)
        {
            InitializeComponent();

            // Assign Host Item
            this.currentHostItem = hostItem;
            this.originalConfigurationContent = hostItem.ConfigurationContent;

            // Init dependencies
            this.configurationHelper = new ConfigurationHelper();
            this.scintillaHelper = new ScintillaHelper();

            // Style Scintilla editor
            this.scintillaHelper.ConfigureLexer(ref this.contentEditor);

            // Set content of the editor
            this.contentEditor.Text = hostItem.ConfigurationContent;
        }

        // Reset content of the configuration file
        private void resetButton_Click(object sender, EventArgs e)
        {

            // Display confirm box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to restore the contents of the configuration file?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Reset only when confirmed
            if (dialogResult == DialogResult.Yes)
            {
                this.contentEditor.Text = this.originalConfigurationContent;
            }
        }

        // Save changes
        private void saveButton_Click(object sender, EventArgs e)
        {

            // Display confirm box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes to the configuration file?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Reset only when confirmed
            if (dialogResult == DialogResult.Yes)
            {

                string configurationPath = this.currentHostItem.ConfigurationPath;
                string configurationContent = this.contentEditor.Text;

                // Write changes to the file
                bool writeStatus = this.configurationHelper.WriteConfiguration(configurationPath, configurationContent);

                if (true == writeStatus)
                {
                    MessageBox.Show("The changes have been saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There was a problem while trying to write the configuration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
