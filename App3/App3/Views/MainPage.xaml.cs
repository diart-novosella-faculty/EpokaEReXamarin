using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        List<Kryesore> _kryesore = new List<Kryesore>();
        //List<String> _imagesAds = new List<String>();
        int count = 0;
        public MainPage()
        {
            InitializeComponent();

            this._kryesore = SplashScreenPage._home;
            var _listHome = _kryesore.ToList();
            
            var newsSlider = _kryesore[0];
            sliderImage.Source = newsSlider.Image;
            lblSlider.Text = newsSlider.Title;

            LoadGrid();
            _listHome.RemoveRange(0, 10);
            listView.ItemsSource = _listHome;
         
            getAds();
        }
        public void getAds()
        {
            var imgRow3 = new List<String> {
                "https://naimi.gjirafa.com/gjan/img/4574ADEE12903770C97AB4BBAEEFC7D4.png",
                "https://naimi.gjirafa.com/gjan/html5/Tiki-Nentor18/s/s.html",
                "http://www.epokaere.com/wp-content/uploads/2018/09/TELEKOM-300x250.gif"
            };

            carouselAdsRow3.ItemsSource = imgRow3;

            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
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
        private void SliderGetContent()
        {
            var newsSlider = _kryesore[count];
            sliderImage.Source = newsSlider.Image;
            lblSlider.Text = newsSlider.Title;
        }
        private void Slider_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadingScreen(_kryesore[count], 0));
        }
        private void ImgLeft_Clicked(object sender, EventArgs e)
        {
            if (count != 2)
            {
                ++count;
                SliderGetContent();
            }
            else
            {
                count = 0;
                SliderGetContent();
            }
        }
        private void ImgRight_Clicked(object sender, EventArgs e)
        {
            if (count != 0)
            {
                --count;
                SliderGetContent();
            }
            else
            {
                count = 2;
                SliderGetContent();
            }
        }
        private void LoadGrid()
        {
            grid1.Source  = _kryesore[3].Image;
            lblGrid1.Text = RemoveTitle(3);
            lblDate1.Text = _kryesore[3].Date;

            grid2.Source  = _kryesore[4].Image;
            lblGrid2.Text = RemoveTitle(4);
            lblDate2.Text = _kryesore[4].Date;


            grid3.Source  = _kryesore[5].Image;
            lblGrid3.Text = RemoveTitle(5);
            lblDate3.Text = _kryesore[5].Date;


            grid4.Source  = _kryesore[6].Image;
            lblGrid4.Text = RemoveTitle(6);
            lblDate4.Text = _kryesore[6].Date;


            grid5.Source  = _kryesore[7].Image;
            lblGrid5.Text = RemoveTitle(7);
            lblDate5.Text = _kryesore[7].Date;


            grid6.Source  = _kryesore[8].Image;
            lblGrid6.Text = RemoveTitle(8);
            lblDate6.Text = _kryesore[8].Date;
        }
        private void Grid_Tapped(object sender, EventArgs e)
        {
            StackLayout grid = sender as StackLayout;
            string idstring = grid.ClassId;
            int id = Convert.ToInt32(idstring);

            switch (id)
            {
                case 1:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[3], 0));
                    break;
                case 2:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[4], 0));
                    break;
                case 3:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[5], 0));
                    break;
                case 4:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[6], 0));
                    break;
                case 5:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[7], 0));
                    break;
                case 6:
                    Navigation.PushAsync(new LoadingScreen(_kryesore[8], 0));
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


//List<Kryesore> GetPosts(string searchText = null)
//{
//    this._kryesore = SplashScreenPage._home;
//    var _listHome = _kryesore.ToList();

//    if (String.IsNullOrWhiteSpace(searchText))
//        return _listHome;

//    return _listHome.Where(c => c.Title.ToLower().StartsWith(searchText.ToLower())).ToList();
//}
//private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
//{
//    listView.ItemsSource = GetPosts(e.NewTextValue);
//}

//protected async override void OnAppearing()
//{
//    base.OnAppearing();

//    _imagesAds = await ApiCall.getAds();
//}
