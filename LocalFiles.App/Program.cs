using LocalFiles.Core.Builders;
using LocalFiles.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFiles.App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                return;

            var path = Uri.UnescapeDataString(args[0].Replace("localfile://", ""));

            RunnerBuilder.New.UseRegistryConfiguration().Build().Run(path);
        }
    }
}
