using eventizr.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using eventizr.Models;
using System.ComponentModel;

namespace eventizr.ViewModels
{
    public class EventViewModel: INotifyPropertyChanged
    {
        SqliteEvent data;

        public SqliteEvent Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

		private string title;

		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged("Title");
			}
		}


        public EventViewModel(Models.SqliteEvent item)
        {
            Data = item;
            Title = data.Name + " by #" + data.Host;
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
