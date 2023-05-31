using AutoMapper;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WebApp.BLL.Interfaces;
using WebApp.BLL.Services;
using WebApplication1.Infrastructure;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            builder.Services.AddAuthentication("Cookies")
                .AddCookie(options => options.LoginPath = "/account/login");
            builder.Services.AddAuthorization();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new UserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // BLL
            builder.Services.AddSingleton<IUserService, UserService>();

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
                    new CookieRequestCultureProvider()
                    {
                        CookieName = "lang"
                    }
                }
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=todo}/{action=list}/{id?}");

            app.Run();
        }
    }
}