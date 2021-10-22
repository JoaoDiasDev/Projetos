using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(new string[] { "http://127.0.0.1:8787", "https://127.0.0.1:8788" });
                });
    }
}
