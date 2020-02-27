using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MedalynxAPI
{
    public class Program
    {

        public static MedialynxData MedialynxData = new MedialynxData();

        public static void Main(string[] args)
        {
            Patches.ApplyPatches(); // Apply patches (sql)
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
