using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eventizr.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eventizr.Helpers;
using eventizr.Services;

namespace eventizr.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationBar : ContentView
	{
		public NavigationBar ()
		{
			InitializeComponent ();
		}
        
        private async void NavigateToHome(object sender, EventArgs e)
        {
            if (Settings.CurrentPage != "home") await Navigation.PushAsync(new MainPage(), true);
            Settings.CurrentPage = "home";
        }

        private async void NavigateToPages(object sender, EventArgs e)
        {
            if (Settings.CurrentPage != "pages") await Navigation.PushAsync(new PagesView() , true);
            Settings.CurrentPage = "pages";
        }

        private async void NavigateToSettings(object sender, EventArgs e)
        {
            if (Settings.CurrentPage != "settings") await Navigation.PushAsync(new SettingsView(), true);
            Settings.CurrentPage = "settings";
        }



    }
}