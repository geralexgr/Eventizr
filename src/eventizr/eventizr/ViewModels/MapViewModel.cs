using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using eventizr.Models;
using Xamarin.Forms;

namespace eventizr.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {



        public MapViewModel() 
        {
			
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
