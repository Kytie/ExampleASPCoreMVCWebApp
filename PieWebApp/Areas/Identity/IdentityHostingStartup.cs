using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PieWebApp.Areas.Identity.IdentityHostingStartup))]
namespace PieWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}