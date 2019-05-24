using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        List<Kryesore> _kryesore = new List<Kryesore>();
        string category = "";
        int count = 0;
        public CategoryPage()
        {
            InitializeComponent();
            category = MasterPage.idCategory;
            Title = category.ToString();

            getAds();
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
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this._kryesore = await ApiCall.getByCategorie(category);

            var footerList = _kryesore.ToList();

            LoadGrid();

            footerList.RemoveRange(0, 10);
            listView.ItemsSource = footerList;


            var newsSlider = _kryesore[count];
            sliderImage.Source = newsSlider.Image;
            lblSlider.Text = newsSlider.Title;

            listView.IsRefreshing = false;
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
        private void SliderGetContent(int index)
        {
            var _gridNews = _kryesore;
            sliderImage.Source = _gridNews[index].Image;
            lblSlider.Text = _gridNews[index].Title;
        }
        private async void Slider_Tapped(object sender, EventArgs e)
        {
            var _gridNews = _kryesore;
            await Navigation.PushAsync(new LoadingScreen(_gridNews[count], 0));
        }
        private void ImgLeft_Clicked(object sender, EventArgs e)
        {
            if (count != 2)
            {
                ++count;
                SliderGetContent(count);
            }
            else
            {
                count = 0;
                SliderGetContent(count);
            }
        }
        private void ImgRight_Clicked(object sender, EventArgs e)
        {
            if (count != 0)
            {
                --count;
                SliderGetContent(count);
            }
            else
            {
                count = 2;
                SliderGetContent(count);
            }
        }
        private void LoadGrid()
        {
            var _gridNews = _kryesore;

            grid1.Source = _gridNews[3].Image;
            lblGrid1.Text = RemoveTitle(3);
            lblDate1.Text = _gridNews[3].Date;

            grid2.Source = _gridNews[4].Image;
            lblGrid2.Text = RemoveTitle(4);
            lblDate2.Text = _gridNews[4].Date;

            grid3.Source = _gridNews[5].Image;
            lblGrid3.Text = RemoveTitle(5);
            lblDate3.Text = _gridNews[5].Date;

            grid4.Source = _gridNews[6].Image;
            lblGrid4.Text = RemoveTitle(6);
            lblDate4.Text = _gridNews[6].Date;

            grid5.Source = _gridNews[7].Image;
            lblGrid5.Text = RemoveTitle(7);
            lblDate5.Text = _gridNews[7].Date;

            grid6.Source = _gridNews[8].Image;
            lblGrid6.Text = RemoveTitle(8);
            lblDate6.Text = _gridNews[8].Date;

        }
        private async void Grid_Tapped(object sender, EventArgs e)
        {
            StackLayout grid = sender as StackLayout;
            string idstring = grid.ClassId;
            int id = Convert.ToInt32(idstring);
            var _gridNews = _kryesore;

            switch (id)
            {
                case 1:
                    await Navigation.PushAsync(new LoadingScreen(_gridNews[3], 0));
                    break;
                case 2:
                    await Navigation.PushAsync(new LoadingScreen(_gridNews[4], 0));
                    break;
                case 3:
                    await Navigation.PushAsync(new LoadingScreen(_gridNews[5], 0));
                    break;
                case 4:
                    await Navigation.PushAsync(new LoadingScreen(_gridNews[6], 0));
                    break;
                case 5:
                    await Navigation.PushAsync(new LoadingScreen(_gridNews[7], 0));
                    break;
                case 6:
                    await Navigation.PushAsync(new LoadingScreen(_gridNews[8], 0));
                    break;

                default:
                    throw new Exception("Provo perseri");
            }
        }
        private void ListView_Refreshing(object sender, EventArgs e)
        {
            var _listHome = _kryesore.ToList();

            var newsSlider = _kryesore[0];
            sliderImage.Source = newsSlider.Image;
            lblSlider.Text = newsSlider.Title;

            LoadGrid();
            _listHome.RemoveRange(0, 10);
            listView.ItemsSource = _listHome;

            listView.EndRefresh();
        }
        private void Post_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var post = e.SelectedItem as Kryesore;
            int id = post.Id;
            Navigation.PushAsync(new LoadingScreen(null, id));
        }
    }
}
