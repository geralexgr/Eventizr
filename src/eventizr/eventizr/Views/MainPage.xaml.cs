using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eventizr.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eventizr.Helpers;
using eventizr.ViewModels;
using Plugin.Connectivity;

namespace eventizr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{

        public MainPage ()
		{
			InitializeComponent ();
        }


        protected async override void OnAppearing()
        {
            Settings.CurrentPage = "home";
            if (!CrossConnectivity.Current.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Check your internet connection.", "Dismiss");
            }
        }

        private async void ListviewItemTapped(object sender, ItemTappedEventArgs args)
        {
            var item =  (Models.SqliteEvent)args.Item;
            await App.Current.MainPage.Navigation.PushAsync(new EventView(item), true);
        }



    }
}