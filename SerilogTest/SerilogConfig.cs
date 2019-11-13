using Microsoft.Extensions.Configuration;

namespace SerilogTest
{
    public class SerilogConfig
    {
        public IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("serilog_cfg.json").Build();
            return configuration;
        }
    }
}