using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            //builder.Services.addContext
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));

            var app = builder.Build();


            //app.MapGet("/", () => "Hello World!");
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapControllerRoute(
            //    name: "api",
            //    pattern: "api/{controller=Home}/{action=Index}/{id?}");

            //https://localhost:7014/Hotel/CheckIn/1

            app.Run();
        }
    }
}