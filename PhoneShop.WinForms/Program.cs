using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using PhoneShop.Data.Interfaces;
using PhoneShop.Business.Logic;
using PhoneShop.Business.Repositories;
using PhoneShop.Business.Interfaces;
using Microsoft.Extensions.Hosting;
using PhoneShop.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace Phoneshop.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


           
                Application.Run(builder.Services.GetRequiredService<PhoneOverview>());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped(typeof(IRepository<>), typeof(AdoRepository<>));
            services.AddScoped<IXmlService, XmlService>();

            services.AddScoped<PhoneOverview>();
                
            });

    }
}
