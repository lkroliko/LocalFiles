using LocalFiles.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
            
            if(_permissions.CanRun(path))
                Process.Start(path);
        }
    }
}
