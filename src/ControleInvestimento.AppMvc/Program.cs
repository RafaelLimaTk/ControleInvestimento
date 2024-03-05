using ControleInvestimento.Business.Core.Notifications;
using ControleInvestimento.Business.Models.Asset;
using ControleInvestimento.Business.Models.Asset.Services;
using ControleInvestimento.Infra.Data.Context;
using ControleInvestimento.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ControleInvestimento.AppMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                    .Assembly.FullName)));

            builder.Services.AddScoped<IAssetRepository, AssetRepository>();

            builder.Services.AddScoped<IAssetService, AssetService>();
            builder.Services.AddScoped<INotifier, Notifier>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}