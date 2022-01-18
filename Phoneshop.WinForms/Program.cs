using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneShop.Business.Data;
using PhoneShop.Business.Interfaces;
using PhoneShop.Business.Logic;
using PhoneShop.Business.Repositories;
using PhoneShop.Data.Interfaces;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
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
                services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
                services.AddScoped<IXmlService, XmlService>();

                services.AddScoped<PhoneOverview>();

                services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

            });

    }
}
