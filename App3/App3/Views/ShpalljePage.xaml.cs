using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShpalljePage : ContentPage
	{
        List<Kryesore> _kryesore = new List<Kryesore>();
        public ShpalljePage ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this._kryesore = await ApiCall.getByCategorie("shpallje");

            listView.ItemsSource = _kryesore;
            listView.IsRefreshing = false;
        }
        private void Post_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var post = e.SelectedItem as Kryesore;
            int id = post.Id;
            Navigation.PushAsync(new LoadingScreen(null, id));
        }
        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = _kryesore;

            listView.EndRefresh();
        }
    }
}