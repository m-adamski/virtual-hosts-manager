using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            //this.contentEditor.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            //this.contentEditor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            //this.contentEditor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            //this.contentEditor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            //this.contentEditor.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            //this.contentEditor.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            //this.contentEditor.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            //this.contentEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //this.contentEditor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //this.contentEditor.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //this.contentEditor.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            //this.contentEditor.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            //this.contentEditor.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
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
                string certificatePath = Path.Combine(new string[] { certificateDirectory, directoryName + ".cert" });
                string certificateKeyPath = Path.Combine(new string[] { certificateDirectory, directoryName + ".key" });

                // Create instance of the Host Item
                HostItem hostItem = new HostItem
                {
                    Domain = directoryName,
                    DirectoryPath = directoryPath,
                    CertificatePath = certificatePath,
                    CertificateKeyPath = certificateKeyPath
                };

                // Add created item to the collection
                hostCollection.Add(hostItem);
            }

            return hostCollection;
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
                    System.Diagnostics.Debug.WriteLine(hostItem.DirectoryPath);
                }
            }
        }
    }
}
