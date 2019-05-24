using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingScreen : ContentPage
	{

        Post post = new Post();
        Kryesore lajmi;
        int id;
        public LoadingScreen (Kryesore lajmi,int id)
		{
            this.lajmi = lajmi;
            this.id = id;
			InitializeComponent ();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (id == 0)
                post = await ApiCall.getPost(lajmi.Id);
            else
                post = await ApiCall.getPost(id);

             await Navigation.PushAsync(new SinglePost(post));
             Navigation.RemovePage(this);
        }
	}
}