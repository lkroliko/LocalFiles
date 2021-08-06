using LocalFiles.Core.Enums;
using LocalFiles.Core.Interfaces;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

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
        public List<string> AclPaths { get; }

        public RegistryConfiguration()
        {
            AclExtensions = GetAcl(_aclExtensionKey);
            AclExtensionsType = GetAclType();
            AclPaths = GetAcl(_aclPaths);
        }


        private List<string> GetAcl(string keyName)
        {
            try
            {
                var regKey = Registry.LocalMachine.OpenSubKey(_rootKey);
                object value = regKey.GetValue(keyName);
                return (value as string).Split(';').ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        private AclType GetAclType()
        {
            try
            {
                var key = Registry.LocalMachine.OpenSubKey(_rootKey);
                object value = key.GetValue(_aclTypeKey);
                return (AclType)int.Parse((value as string));
            }
            catch
            {
                return AclType.Permit;
            }
        }
    }
}
