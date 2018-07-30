using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eventizr.Helpers
{
    public class DialogHelper
    {

        public async Task DisplayErrorDialog(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
        }

        public async Task DisplayCorrectDialog(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Success", message, "OK");
        }
    }
}
