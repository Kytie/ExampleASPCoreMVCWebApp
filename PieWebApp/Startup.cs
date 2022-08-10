using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PieWebApp.Models;

namespace PieWebApp
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddScoped<IPieRepository, PieRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
      services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
      services.AddSession();
      services.AddHttpContextAccessor();
      services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      // Call this before use rouing. The order matters.
      app.UseSession();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        // endpoints.MapGet("/", async context =>
        // {
        //     await context.Response.WriteAsync("Hello World!");
        // });

        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id:int?}"
              );
        endpoints.MapRazorPages();
      });
    }
  }
}
