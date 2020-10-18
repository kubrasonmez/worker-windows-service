using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WorkerWS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);
            host = OperatingSystem.IsWindows() ? host.UseWindowsService() : host.UseSystemd();
            host = host.ConfigureAppConfiguration((builderContext, config) =>
            {
                //var str = builderContext.HostingEnvironment.EnvironmentName;
                config.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            });
            host = host.ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;

                services.AddSingleton(configuration);

                services.AddHostedService<Worker>();
                //
            });
            return host;
        }

        public static void WriteLog(string msg)
        {
            var _currentPath = System.AppDomain.CurrentDomain.BaseDirectory;

            var _dt = DateTime.Now;
            var LogPath = Path.Combine(_currentPath, "logs");

            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            var _file = Path.Combine(LogPath, DateTime.Now.ToString("yyyyMMdd") + ".txt");
            using (var sw = new StreamWriter(_file, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(_dt.ToString("yyyy.MM.dd HH:mm.ss"));
                sw.WriteLine(msg);
                sw.WriteLine("****************************************************");
                sw.Close();
            }
        }
    }
}
