using App3.Models;
using App3.Views;
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
	public partial class MasterPage : MasterDetailPage
	{
        public List<MenuPageItems> menuList { get; set; }
        public Type targetpage;
        public static string idCategory;
        public MasterPage ()
		{
			InitializeComponent ();

            menuList = new List<MenuPageItems>();
            menuList.Add(new MenuPageItems()
            {
                Category = "Kryesore",
                Title = "Ballina",
                Icon = "news.png",
                TargetType = typeof(MainPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Politike",
                Title = "Lajme",
                Icon = "politics.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Ekonomi",
                Title = "Ekonomi",
                Icon = "economy.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Intervista",
                Title = "Intervista",
                Icon = "interviews.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Opinione",
                Title = "Opinione",
                Icon = "opinions.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Komuna",
                Title = "Komuna",
                Icon = "city.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Bote",
                Title = "Botë",
                Icon = "world.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Kulture",
                Title = "Kulturë",
                Icon = "culture.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Sport",
                Title = "Sport",
                Icon = "sport.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Spekter",
                Title = "Spektër",
                Icon = "spectre.png",
                TargetType = typeof(CategoryPage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Shpallje",
                Title = "Shpallje",
                Icon = "publications.png",
                TargetType = typeof(ShpalljePage)
            });
            menuList.Add(new MenuPageItems()
            {
                Category = "Tech",
                Title = "Tech",
                Icon = "tech.png",
                TargetType = typeof(CategoryPage)
            });

            MenuList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
        }
        private async void Selected_MenuList(object sender, SelectedItemChangedEventArgs e)
        {
            IsPresented = false;
            var item = (MenuPageItems)e.SelectedItem;
            targetpage = item.TargetType;
            idCategory = item.Category;
            Detail = new NavigationPage((Page)Activator.CreateInstance(targetpage));

            await Navigation.PopAsync();
        }

        private async void Tapped_Settings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMenu());
        }
        private async void Tapped_EpokaEReMenu(object sender, EventArgs e)
        {
            IsPresented = false;
            await Navigation.PopAsync();
        }
    }
}