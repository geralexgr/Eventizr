using eventizr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eventizr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventView : ContentPage
	{
		public EventView (Models.SqliteEvent item)

        {
			InitializeComponent ();
            BindingContext = new EventViewModel(item);
		}

       
    }
}