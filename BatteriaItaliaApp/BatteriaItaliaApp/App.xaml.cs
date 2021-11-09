using BatteriaItaliaApp.Services;
using BatteriaItaliaApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatteriaItaliaApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Startup.ConfigureServices();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
