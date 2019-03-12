﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualHostsManager {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Config : global::System.Configuration.ApplicationSettingsBase {
        
        private static Config defaultInstance = ((Config)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Config())));
        
        public static Config Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SubdomainRootDirectory {
            get {
                return ((string)(this["SubdomainRootDirectory"]));
            }
            set {
                this["SubdomainRootDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string HostConfigDirectory {
            get {
                return ((string)(this["HostConfigDirectory"]));
            }
            set {
                this["HostConfigDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateDirectory {
            get {
                return ((string)(this["CertificateDirectory"]));
            }
            set {
                this["CertificateDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<VirtualHost *:80>
    ServerName @Name
    ServerAlias www.@Name
    DocumentRoot @DocumentRootPath

    <Directory ""@DocumentRootPath"">
        Options +Indexes +Includes +FollowSymLinks +MultiViews
        AllowOverride All
        Require local
    </Directory>
</VirtualHost>

<VirtualHost *:443>
    ServerName @Name
    ServerAlias www.@Name
    DocumentRoot @DocumentRootPath

    SSLEngine On
    SSLCertificateFile @CertificatePath
    SSLCertificateKeyFile @CertificateKeyPath

    <Directory ""@DocumentRootPath"">
        Options +Indexes +Includes +FollowSymLinks +MultiViews
        AllowOverride All
        Require local
    </Directory>
</VirtualHost>")]
        public string HostConfigTemplate {
            get {
                return ((string)(this["HostConfigTemplate"]));
            }
            set {
                this["HostConfigTemplate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateCountryName {
            get {
                return ((string)(this["CertificateCountryName"]));
            }
            set {
                this["CertificateCountryName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateStateName {
            get {
                return ((string)(this["CertificateStateName"]));
            }
            set {
                this["CertificateStateName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateLocalityName {
            get {
                return ((string)(this["CertificateLocalityName"]));
            }
            set {
                this["CertificateLocalityName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateOrganizationName {
            get {
                return ((string)(this["CertificateOrganizationName"]));
            }
            set {
                this["CertificateOrganizationName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateUnitName {
            get {
                return ((string)(this["CertificateUnitName"]));
            }
            set {
                this["CertificateUnitName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CertificateEmailAddress {
            get {
                return ((string)(this["CertificateEmailAddress"]));
            }
            set {
                this["CertificateEmailAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OpenSSLPath {
            get {
                return ((string)(this["OpenSSLPath"]));
            }
            set {
                this["OpenSSLPath"] = value;
            }
        }
    }
}