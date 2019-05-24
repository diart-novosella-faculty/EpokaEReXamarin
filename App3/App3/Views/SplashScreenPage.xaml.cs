using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        public static List<Kryesore> _home = new List<Kryesore>();
        public SplashScreenPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _home = await ApiCall.getHome();
            App.Current.MainPage = new NavigationPage(new MasterPage());
            activityrunning.IsRunning = false;
        }
    }
}