using LocalFiles.Core.Interfaces;
using LocalFiles.Core.Services;

namespace LocalFiles.Core.Builders
{
    public class RunnerBuilder
    {
        IConfiguration _configuration;

        public static RunnerBuilder New { get { return new RunnerBuilder(); } }

        public RunnerBuilder UseRegistryConfiguration()
        {
            _configuration = new RegistryConfiguration();
            return this;
        }

        public Runner Build()
        {
            IPermissions permissions = new Permissions(_configuration);
            return new Runner(permissions);
        }
    }
}
