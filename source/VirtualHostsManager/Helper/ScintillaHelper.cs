using ScintillaNET;
using System;
using System.Drawing;

namespace VirtualHostsManager.Helper
{
    class ScintillaHelper
    {

        // Style Scintilla Editor
        // https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Syntax-Highlighting
        public void ConfigureLexer(ref Scintilla scintillaEditor)
        {
            scintillaEditor.StyleResetDefault();
            scintillaEditor.Styles[Style.Default].Font = "Consolas";
            scintillaEditor.Styles[Style.Default].Size = 8;
            scintillaEditor.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            scintillaEditor.Styles[Style.Cpp.Word].ForeColor = Color.Purple;
            scintillaEditor.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(128, 128, 128);
            scintillaEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21);
            scintillaEditor.Styles[Style.Cpp.Comment].ForeColor = Color.Red;
            scintillaEditor.Styles[Style.Cpp.CommentDocKeyword].ForeColor = Color.Red;

            scintillaEditor.Lexer = Lexer.Cpp;

            scintillaEditor.SetKeywords(0, "@Name @DocumentRootPath @CertificatePath @CertificateKeyPath");
            scintillaEditor.SetKeywords(1, "ServerName ServerAlias DocumentRoot Options AllowOverride Require SSLEngine SSLCertificateFile SSLCertificateKeyFile listen server_name return server_tokens root index add_header ssl_protocols ssl_ciphers ssl_prefer_server_ciphers ssl_certificate ssl_certificate_key location include internalerror_log access_log");
        }
    }
}
