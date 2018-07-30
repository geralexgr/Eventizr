using eventizr.Helpers;
using eventizr.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eventizr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagesView : ContentPage
	{
		public PagesView ()
		{
			InitializeComponent ();
            BindingContext = new PagesViewModel();
        }

        protected override void OnAppearing()
        {
            Settings.CurrentPage = "pages";
            BindingContext = new PagesViewModel();
		}


	}
}