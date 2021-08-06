using LocalFiles.Core.Enums;
using LocalFiles.Core.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace LocalFiles.Core.Services
{
    public class Permissions : IPermissions
    {
        private readonly IConfiguration _configuration;

        public Permissions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CanRun(string path)
        {
            var extension = Path.GetExtension(path);
            return IsExtensionAllow(extension) && IsPathAllow(path);
        }

        private bool IsExtensionAllow(string extension)
        {
            switch (_configuration.AclExtensionsType)
            {
                case AclType.Permit:
                    return _configuration.AclExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
                case AclType.Deny:
                    return !_configuration.AclExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }

        private bool IsPathAllow(string path)
        {
            return _configuration.AclPaths.Where(p => path.StartsWith(p, StringComparison.InvariantCultureIgnoreCase)).Count() > 0;
        }
    }
}
