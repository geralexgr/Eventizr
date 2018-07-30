using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using eventizr.Views;

namespace eventizr.ViewModels
{
    public class SettingsViewModel: INotifyPropertyChanged
    {



        public ICommand NavigateToInfoCommand
        {
            get
            {
                return new Command(async () => {                					
					await App.Current.MainPage.Navigation.PushAsync(new AboutView(), true);
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
