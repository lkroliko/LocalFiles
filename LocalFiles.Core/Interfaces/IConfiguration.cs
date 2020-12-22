using LocalFiles.Core.Enums;
using System.Collections.Generic;

namespace LocalFiles.Core.Interfaces
{
    public interface IConfiguration
    {
        List<string> AclExtensions { get; }
        AclType AclExtensionsType { get; }
        List<string> AclPaths { get; }
    }
}