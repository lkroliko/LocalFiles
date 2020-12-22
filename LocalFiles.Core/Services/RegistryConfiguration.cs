using LocalFiles.Core.Enums;
using LocalFiles.Core.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFiles.Core.Services
{
    public class RegistryConfiguration : IConfiguration
    {
        private const string _rootKey = "Software\\LocalFiles";
        private const string _aclExtensionKey = "AclExtensions";
        private const string _aclTypeKey = "AclExtensionsType";
        private const string _aclPaths = "AclPaths";

        public List<string> AclExtensions { get; }
        public AclType AclExtensionsType { get; }
        public List<string> AclPaths {get;}

        public RegistryConfiguration()
        {
            AclExtensions = GetAcl(_aclExtensionKey);
            AclExtensionsType = GetAclType();
            AclPaths = GetAcl(_aclPaths);
        }


        private List<string> GetAcl(string keyName)
        {
            var regKey = Registry.LocalMachine.OpenSubKey(_rootKey);
            object value = regKey.GetValue(keyName);
            if (value == null)
                return new List<string>();
            return (value as string).Split(';').ToList();
        }

        private AclType GetAclType()
        {
            var key = Registry.LocalMachine.OpenSubKey(_rootKey);
            object value = key.GetValue(_aclTypeKey);
            if (value != null)
                return (AclType)int.Parse((value as string));
            return AclType.Permit;
        }
    }
}
