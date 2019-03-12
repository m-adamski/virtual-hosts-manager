﻿using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualHostsManager
{
    public partial class TemplateWindow : Form
    {
        public TemplateWindow()
        {
            InitializeComponent();

            // Style editor
            this.PrepareTemplateEditor();

            // Set content of the editor
            this.templateEditor.Text = Config.Default.HostConfigTemplate;
        }

        // Style Scintilla editor
        // https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Syntax-Highlighting
        private void PrepareTemplateEditor()
        {
            this.templateEditor.StyleResetDefault();
            this.templateEditor.Styles[Style.Default].Font = "Consolas";
            this.templateEditor.Styles[Style.Default].Size = 8;
            this.templateEditor.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            this.templateEditor.Styles[Style.Cpp.Word].ForeColor = Color.Purple;
            this.templateEditor.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(128, 128, 128);
            this.templateEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21);

            //this.templateEditor.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            //this.templateEditor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            //this.templateEditor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            //this.templateEditor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            //this.templateEditor.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            //this.templateEditor.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            //this.templateEditor.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            //this.templateEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //this.templateEditor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //this.templateEditor.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //this.templateEditor.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            //this.templateEditor.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            //this.templateEditor.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            this.templateEditor.Lexer = Lexer.Cpp;

            this.templateEditor.SetKeywords(0, "@Name @DocumentRootPath @CertificatePath @CertificateKeyPath");
            this.templateEditor.SetKeywords(1, "ServerName ServerAlias DocumentRoot Options AllowOverride Require SSLEngine SSLCertificateFile SSLCertificateKeyFile");
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
