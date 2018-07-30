using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eventizr.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eventizr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPageView : ContentPage
	{
		public AddPageView ()
		{
			InitializeComponent ();
		}

   //     protected override bool OnBackButtonPressed()
   //     {
			//Navigation.PushAsync(new PagesView(), true);
        //    return true;
        //}


    }
}