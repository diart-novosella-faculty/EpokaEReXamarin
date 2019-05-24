using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HtmlAgilityPack;
using System.Net;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SinglePost : ContentPage
    {
        List<Kryesore> _kryesore = new List<Kryesore>();
        public SinglePost (Post post)
		{
			InitializeComponent ();
           
            BindingContext = post;
            this._kryesore = SplashScreenPage._home;
            LoadList();
            LoadGrid();
            getAds();
        }
        private String RemoveTitle(int index)
        {
            var newsSlider = _kryesore[index];
            string title = "";
            if (newsSlider.Title.Length > 100)
            {
                return title = newsSlider.Title.Substring(0, 97) + "...";
            }
            else
            {
                return title = newsSlider.Title;
            }
        }
        private void Grid_Tapped(object sender, EventArgs e)
        {
            StackLayout grid = sender as StackLayout;
            string idstring = grid.ClassId;
            int id = Convert.ToInt32(idstring);

            switch (id)
            {
                case 1:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[0], 0));
                    break;
                case 2:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[1], 0));
                    break;
                case 3:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[2], 0));
                    break;
                case 4:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[3], 0));
                    break;

                default:
                    throw new Exception("Provo perseri");
            }
        }
        public void getAds()
        {
            var imgRow3 = new List<string>
            {
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg",
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg",
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg"
            };

            carouselAdsRow3.ItemsSource = imgRow3;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                carouselAdsRow3.Position = (carouselAdsRow3.Position + 1) % imgRow3.Count;

                return true;
            }));

            var imgRow9 = new List<string>
            {
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg",
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg",
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg"
            };

            carouselAdsRow9.ItemsSource = imgRow9;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                carouselAdsRow9.Position = (carouselAdsRow9.Position + 1) % imgRow9.Count;

                return true;
            }));

            var imgRow4 = new List<string>
            {
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg",
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg",
               "https://wallpaperbrowse.com/media/images/3848765-wallpaper-images-download.jpg"
            };

            carouselAdsRow4.ItemsSource = imgRow4;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                carouselAdsRow4.Position = (carouselAdsRow4.Position + 1) % imgRow4.Count;

                return true;
            }));
        }
        private void LoadGrid()
        {
            grid1.Source = _kryesore[0].Image;
            lblGrid1.Text = RemoveTitle(0);
            lblGridDate1.Text = _kryesore[0].Date;

            grid2.Source = _kryesore[1].Image;
            lblGrid2.Text = RemoveTitle(1);
            lblGridDate3.Text = _kryesore[1].Date;

            grid3.Source = _kryesore[2].Image;
            lblGrid3.Text = RemoveTitle(2);
            lblGridDate3.Text = _kryesore[2].Date;

            grid4.Source = _kryesore[3].Image;
            lblGrid4.Text = RemoveTitle(3);
            lblGridDate4.Text = _kryesore[3].Date;

        }
        private void LoadList()
        {
            var newsSlider = _kryesore[4];
            imgTeFundit1.Source = newsSlider.Image;
            lblTitle1.Text = newsSlider.Title;
            lblDate1.Text = newsSlider.Date;

            var newsSlider2 = _kryesore[5];
            imgTeFundit2.Source = newsSlider2.Image;
            lblTitle2.Text = newsSlider2.Title;
            lblDate2.Text = newsSlider2.Date;

            var newsSlider3 = _kryesore[6];
            imgTeFundit3.Source = newsSlider3.Image;
            lblTitle3.Text = newsSlider3.Title;
            lblDate3.Text = newsSlider3.Date;
        }
        private void TeFundit1_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadingScreen(_kryesore[4], 0));
            Navigation.RemovePage(this);
        }
        private void TeFundit2_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadingScreen(_kryesore[5], 0));
            Navigation.RemovePage(this);
        }
        private void TeFundit3_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadingScreen(_kryesore[6], 0));
            Navigation.RemovePage(this);
        }
        private void BtnFb_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/gazetaEpokaere/"));
        }
        private void BtnEpoka_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.epokaere.com"));

        }
    }
}