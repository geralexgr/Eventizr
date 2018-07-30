﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using eventizr.Views;
using eventizr.Helpers;
using eventizr.Services;
using eventizr.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace eventizr.ViewModels
{
    public class PagesViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<SqlitePage> pages = new ObservableCollection<SqlitePage>();

        public ObservableCollection<SqlitePage> Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                OnPropertyChanged("Pages");
            }
        }

        

        public PagesViewModel()
        {
            InitPages();
        }


        public async void InitPages()
        {
            try
            {
                Pages = await App.SqliteDB.GetAllPagesAsync();
            }
            catch (Exception) { }
        }

        public ICommand RemovePageCommand
        {
            get
            {
                return new Command(async (x) => {
                    
                    var page = (SqlitePage)x;
                    var result = await App.SqliteDB.DeletePageAsync(page);
                    Pages = await App.SqliteDB.GetAllPagesAsync();
                    await Application.Current.MainPage.DisplayAlert("Success", "Page deleted successfully.", "OK");
                });
            }
        }

       

        public ICommand AddPageCommand
        {
            get
            {
                return new Command(async () => {
					await App.Current.MainPage.Navigation.PushAsync(new AddPageView(), true);
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
