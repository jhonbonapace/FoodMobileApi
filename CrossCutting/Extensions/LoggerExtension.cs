using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace CrossCutting.Extensions
{
    public class LoggerExtension
    {
        public Serilog.Core.Logger CreateLogger()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            return new LoggerConfiguration()
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.MongoDB(config.GetConnectionString("MongoDatabase"), collectionName: "logs")
           .CreateLogger();
        }
    }
}
