using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eventizr.Helpers;
using eventizr.Models;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace eventizr.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapView : ContentPage
	{
        ObservableCollection<SqliteEvent> collection = new ObservableCollection<SqliteEvent>();
        Plugin.Geolocator.Abstractions.Position position = new Plugin.Geolocator.Abstractions.Position();
        bool locationEnabled;

        public MapView (ObservableCollection<SqliteEvent> argument)
		{
			InitializeComponent ();

            collection = argument;
			GetUserLocation();
			CreatePins();
		}

        protected override void OnAppearing()
        {
		}

        private void CreatePins()
        {
            if (collection.Count > 0)
            {
				for (int i = 0; i < collection.Count(); i++)
				{
                    try
                    {
                        var location = new Position(collection[i].Latitude, collection[i].Longitude);
                        var pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = location,
                            Label = collection[i].Name,
                            Address = collection[i].Address
                        };
                        eventsMap.Pins.Add(pin);
                    }
                    catch (Exception) { }
					
				}
                if(!locationEnabled) SetMapLocation(collection[0].Latitude, collection[0].Longitude);
			}
        }

        private  void SetMapLocation(double lat,double lon) 
        {
            
			int sValue = Settings.Distance;
			if (sValue == 0) eventsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lon), Distance.FromKilometers(5.0)));
			else if (sValue == 1) eventsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lon), Distance.FromKilometers(10.0)));
			else if  (sValue == 2) eventsMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lat, lon), Distance.FromKilometers(25.0)));           			
		}



        public async void GetUserLocation()
        {

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;
				locationEnabled = true;

				if (!locator.IsGeolocationAvailable)
                {
                    locationEnabled = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "Please enable location permissions for eventizr.", "Dismiss");
                }
                else
                {
                    if (!locator.IsGeolocationEnabled)
                    {
                        locationEnabled = false;
                        await Application.Current.MainPage.DisplayAlert("Error", "Please enable location.", "Dismiss");
                    }
                    else
                    {
                        position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10), null, true);
                        SetMapLocation(position.Latitude, position.Longitude);
                    }
                }   

			}
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Couldn't get your location.", "Dismiss");
				locationEnabled = false;
			}
        }

	}
}