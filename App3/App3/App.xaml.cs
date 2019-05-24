using App3.Views;
using Plugin.Connectivity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App3
{
    public partial class App : Application
    {
        public static NavigationPage NavPage { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashScreenPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Device.BeginInvokeOnMainThread(async () =>
            {
                var isConnected = CrossConnectivity.Current.IsConnected;

                if (isConnected == false)
                {
                    await MainPage.DisplayAlert("Gabim", "Ju lutem kontrolloni kyçjen tuaj në internet!", "Mbyll");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Device.BeginInvokeOnMainThread(async () =>
            {
                var isConnected = CrossConnectivity.Current.IsConnected;

                if (isConnected == false)
                {
                    await MainPage.DisplayAlert("Gabim", "Ju lutem kontrolloni kyçjen tuaj në internet!", "Mbyll");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            });
        }

        protected override void OnResume()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var isConnected = CrossConnectivity.Current.IsConnected;

                if (isConnected == false)
                {
                    await MainPage.DisplayAlert("Gabim", "Ju lutem kontrolloni kyçjen tuaj në internet!", "Mbyll");
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            });
            // Handle when your app resumes
        }
    }
}
