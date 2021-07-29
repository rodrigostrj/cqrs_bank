using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaltpayBank.Infrastructure.Data;
using System;
using System.IO;
using System.Reflection;

namespace SaltpayBank.Migrations
{
    public class Program
    {
        private static IConfigurationRoot Configuration;

        private static void Main(string[] args)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var contentRoot = Path.GetDirectoryName(path);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var tokensBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = tokensBuilder.Build();
            var config = new ConfigurationBuilder();

            var configuration = config.Build();

        }
    }
}
