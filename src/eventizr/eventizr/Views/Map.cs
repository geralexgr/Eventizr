using System;

using Xamarin.Forms;

namespace eventizr.Views
{
    public class Map : ContentPage
    {
        public Map()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

