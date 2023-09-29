using Serilog;
using StudentsDbApp.Configuration;
using StudentsDbApp.DAO;
using System.ComponentModel.DataAnnotations;

namespace StudentsDbApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, config) =>
            {
                config.MinimumLevel
                    .Debug()
                    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                    .WriteTo.Console()
                    .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{ Timestamp:dd-mm-yyyy HH:mm:ss} {SourceContext} {level} {Message} ]",
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: null
                    );
            });

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IStudentDAO, StudentDAOImpl>();
            builder.Services.AddAutoMapper(typeof(MapperConfig));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}