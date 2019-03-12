using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualHostsManager.Model
{
    class HostItem
    {
        public string Domain { get; set; }
        public string DirectoryPath { get; set; }
        public string CertificatePath { get; set; }
        public string CertificateKeyPath { get; set; }
        public string ConfigurationContent { get; set; }
    }
}
