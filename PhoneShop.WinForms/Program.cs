using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using PhoneShop.Data.Interfaces;
using PhoneShop.Business.Logic;
using PhoneShop.Business.Repositories;

namespace Phoneshop.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                Application.Run(serviceProvider.GetRequiredService<PhoneOverview>());
        }


        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped(typeof(PhoneShop.Data.Interfaces.IRepository<>), typeof(PhoneShop.Business.Repositories.AdoRepository<>));

            services.AddScoped<PhoneOverview>();
        }
    }
}
