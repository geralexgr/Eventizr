using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using eventizr.Helpers;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Connectivity;
using System.Threading.Tasks;
using eventizr.Views;
using eventizr.Services;
using System.Collections.ObjectModel;
using eventizr.Models;
using System.Linq;
using Plugin.Permissions;

namespace eventizr.ViewModels
{
    public class MainPageViewModel:INotifyPropertyChanged
    {

        FbService _fbservice;
        ModelHelper _modelhelper;

        private ObservableCollection<SqliteEvent> events = new ObservableCollection<SqliteEvent>();


		public ObservableCollection<SqliteEvent> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }

        public MainPageViewModel()
        {
          
            _fbservice = new FbService();
            _modelhelper = new ModelHelper();

            DeviceIsConnected();
        }

      
       

        public async void GetPagesEvents()
        {
            try
            {
                var ids = await App.SqliteDB.GetPagesIds();
                if (ids.Count > 0)
                {
                    Events.Clear();
                    IsBusy = true;

                    for (int i = 0; i < ids.Count; i++)
                    {
                        var result = await _fbservice.GetPageEvents(ids[i]);
                        if (result.Data != null)
                        {
                            if (result.Data.Count > 0)
                            {
                                for (int x = 0; x < result.Data.Count; x++)
                                {
                                    SqliteEvent sqlEvent = _modelhelper.FbEventToSQLite(result.Data[x]);
                                    Events.Add(sqlEvent);
                                }
                            }
                        }

                    }
                    var desOrder = Events.OrderBy(x => x.Time).ToList();
                    Events = new ObservableCollection<SqliteEvent>(desOrder);
                    IsBusy = false;
                }
            }
            catch(Exception)
            {
                IsBusy = false;
            }


        }


        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public void DeviceIsConnected()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                IsBusy = true;
                GetPagesEvents();
                IsBusy = false;
            }
        }

        public async Task CheckConnectionOnStart()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Check your internet connection.", "Dismiss");
            }
        }


        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () => {
                    if (!CrossConnectivity.Current.IsConnected)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Check your internet connection.", "Dismiss");
                    }
                    else
                    {
                        GetPagesEvents();
                    }
                });
            }
        }



        public ICommand NavigateMapCommand
        {
            get
            {
                return new Command(async () => {
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
                    if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                        await App.Current.MainPage.Navigation.PushAsync(new MapView(Events), true);
                   else
                        await Application.Current.MainPage.DisplayAlert("Error", "You must enable location permissions for eventizr.", "Dismiss");

                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}
