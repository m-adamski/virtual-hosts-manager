using System;
using System.Windows.Forms;
using VirtualHostsManager.Helper;

namespace VirtualHostsManager
{
    public partial class TemplateWindow : Form
    {

        private ScintillaHelper scintillaHelper;

        public TemplateWindow()
        {
            InitializeComponent();

            // Init dependencies
            this.scintillaHelper = new ScintillaHelper();

            // Style editor
            this.scintillaHelper.ConfigureLexer(ref this.templateEditor);

            // Set content of the editor
            this.templateEditor.Text = Config.Default.HostConfigTemplate;
        }

        // Save changes in config and close window
        private void saveButton_Click(object sender, EventArgs e)
        {

            // Change config value
            Config.Default.HostConfigTemplate = this.templateEditor.Text;
            Config.Default.Save();

            // Close window
            this.Close();
        }
    }
}
