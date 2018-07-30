using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eventizr.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eventizr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsView : ContentPage
	{
		public SettingsView ()
		{
			InitializeComponent ();
		}


        protected override void OnAppearing()
        {
            picker.SelectedIndex = Settings.Distance;
            Settings.CurrentPage = "settings";
        }

        private void PickerItemChanged(object sender, EventArgs args)
        {
            var item = picker.SelectedIndex;
            if (item == 0)
            {
                Settings.Distance = 0;
            } 
            else if (item ==1)
            {
                Settings.Distance = 1;
            }
            else if (item == 2)
            {
                Settings.Distance = 2;
            }
        }




    }
}