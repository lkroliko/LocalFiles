using LocalFiles.Core.Builders;
using LocalFiles.Core.Extensions;

namespace LocalFiles.App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                return;

            var path = args[0].ToPath();

            RunnerBuilder.New.UseRegistryConfiguration().Build().Run(path);
        }
    }
}
