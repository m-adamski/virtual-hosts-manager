namespace VirtualHostsManager.Model
{
    public class HostItem
    {
        public string Domain { get; set; }
        public string DirectoryPath { get; set; }
        public string ConfigurationPath { get; set; }
        public string CertificatePath { get; set; }
        public string CertificateKeyPath { get; set; }
        public string ConfigurationContent { get; set; }
    }
}
