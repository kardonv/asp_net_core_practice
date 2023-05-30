using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // DB
            builder.Services.AddScoped<ApplicationContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Localization
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("uk")
            };
            var localizationOptions = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider> {
                    new QueryStringRequestCultureProvider()
                    {
                        QueryStringKey = "lang"
                    }
                }
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Todo}/{action=List}/{id?}");

            app.Run();
        }
    }
}