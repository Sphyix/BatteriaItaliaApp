using System;
using Microsoft.Extensions.DependencyInjection;
using BatteriaItaliaApp.Models;
using BatteriaItaliaApp.Services;
using BatteriaItaliaApp.ViewModels;

namespace BatteriaItaliaApp
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<IDataStore<WorkOrder>, ApiService>(c =>
            {
                c.BaseAddress = new Uri("http://10.40.12.100:19752/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<SearchItemViewModel>();
            //services.AddTransient<AddBookViewModel>();
            //services.AddTransient<BookDetailsViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
