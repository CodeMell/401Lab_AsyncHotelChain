using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication1.Data;
using Microsoft.OpenApi.Models;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => {
                    //Ignore Data Cycling Errors
                    options.JsonSerializerOptions.ReferenceHandler
                        = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    //CamelCase JSON Attributes
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    //Leave out null data fields in objects
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            //builder.Services.addContext
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));
            builder.Services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });
            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<AsyncInnContext>();
            var app = builder.Build();

            //swagger 


             app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json",
                    "Async Inn");
                options.RoutePrefix = "docs";
            });

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