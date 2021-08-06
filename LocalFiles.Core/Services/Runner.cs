using LocalFiles.Core.Interfaces;
using System.Diagnostics;
using System.IO;

namespace LocalFiles.Core.Services
{
    public class Runner
    {
        private readonly IPermissions _permissions;

        public Runner(IPermissions permissions)
        {
            _permissions = permissions;
        }

        public void Run(string path)
        {
            if (_permissions.CanRun(path) && File.Exists(path))
                Process.Start(path);
        }
    }
}
