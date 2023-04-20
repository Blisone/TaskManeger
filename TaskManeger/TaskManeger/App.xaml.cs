using System;
using TaskManeger.Services;
using TaskManeger.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManeger
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStoreItems>();
            DependencyService.Register<DataStoreCategories>();
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
