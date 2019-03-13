using ScintillaNET;
using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualHostsManager.Helper;
using VirtualHostsManager.Model;

namespace VirtualHostsManager
{
    public partial class PreviewWindow : Form
    {
        private ConfigurationHelper configurationHelper;
        private HostItem currentHostItem;
        private string originalConfigurationContent;

        public PreviewWindow(HostItem hostItem)
        {
            InitializeComponent();

            // Assign Host Item
            this.currentHostItem = hostItem;
            this.originalConfigurationContent = hostItem.ConfigurationContent;

            // Init dependencies
            this.configurationHelper = new ConfigurationHelper();

            // Style editor
            this.PrepareContentEditor();

            // Set content of the editor
            this.contentEditor.Text = hostItem.ConfigurationContent;
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

        // Reset content of the configuration file
        private void resetButton_Click(object sender, EventArgs e)
        {

            // Display confirm box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to restore the contents of the configuration file?", "Are you sure?", MessageBoxButtons.OKCancel);

            // Reset only when confirmed
            if (dialogResult == DialogResult.OK)
            {
                this.contentEditor.Text = this.originalConfigurationContent;
            }
        }

        // Save changes
        private void saveButton_Click(object sender, EventArgs e)
        {

            // Display confirm box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes to the configuration file?", "Are you sure?", MessageBoxButtons.OKCancel);

            // Reset only when confirmed
            if (dialogResult == DialogResult.OK)
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
