using eventizr.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using eventizr.Services;
using eventizr.Views;
using eventizr.Models;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace eventizr.ViewModels
{
    public class AddPageViewModel : INotifyPropertyChanged
    {
        DialogHelper _dialoghelper;
        StringsHelper _stringshelper;
        private string page;
        FbService _fbservice;
        ModelHelper _modelhelper;
        SqlitePage sqlitepage;

        public string Page
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged("Page");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }

        private string picure;
        public string Picture
        {
            get { return picure; }
            set
            {
                picure = value;
                OnPropertyChanged("Picture");
            }
        }

        private bool visible = false;

        public bool Visible
        {
            get { return visible; }
            set
            {
                if (visible == value)
                    return;

                visible = value;
                OnPropertyChanged("Visible");
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

        private bool enabled = true;
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (enabled == value)
                    return;

                enabled = value;
                OnPropertyChanged("Enabled");
            }
        }

        public AddPageViewModel()
        {
            _dialoghelper = new DialogHelper();
            _stringshelper = new StringsHelper();
            _fbservice = new FbService();
            _modelhelper = new ModelHelper();
            Page = "facebook.com/";
        }


        public ICommand SearchPageCommand
        {
            get
            {
                return new Command(async () => {
                    IsBusy = true;

                    if (!CrossConnectivity.Current.IsConnected)
                    {
                        IsBusy = false;
                        await Application.Current.MainPage.DisplayAlert("Error", "Check your internet connection.", "Dismiss");
                    }
                    else if (String.IsNullOrEmpty(Page))
                    {
                        IsBusy = false;
                        await _dialoghelper.DisplayErrorDialog("Input cannot be empty.");
                    }
                    else if (!String.IsNullOrEmpty(Page))
                    {
                        var page = _stringshelper.FbPageRegex(Page.ToLower());

                        if (!page.Equals("error"))
                        {
                            var url = await _stringshelper.CreatePageRequestUrl(page);
                            var pageInfo = await _fbservice.GetPageInfo(url);
                            if ( pageInfo.Id !=null )
                            {

                                    sqlitepage = _modelhelper.FbPageToSQLite(pageInfo);
                                    bool exists = App.SqliteDB.CheckPageExists(sqlitepage.Id);

                                    if (!exists)
                                    {
                                        Name = sqlitepage.Name;
                                        Category = sqlitepage.Category;
                                        Visible = true;
                                        Picture = sqlitepage.Picture;
                                        IsBusy = false;
                                        Enabled = true;
                                    }
                                    else
                                    {
                                        IsBusy = false;
                                        await _dialoghelper.DisplayErrorDialog("Page already exists in database.");
                                    }
                                                               
                                
                            }
                            else if (pageInfo.Id == null)
                            {
                                IsBusy = false;
                                await _dialoghelper.DisplayErrorDialog("Facebook url returned an error. Try facebook.com/PAGEID.");
                            }
                        }
                        else
                        {
                            IsBusy = false;
                            await _dialoghelper.DisplayErrorDialog("Input is not a valid facebook url.");
                        }
                    }                    

                });
            }
        }

        public ICommand SavePageCommand
        {
            get
            {
                return new Command(async () => {
                    if (sqlitepage.Id != null)
                    {
                        await App.SqliteDB.CreatePageAsync(sqlitepage);
                        Enabled = false;
                        await _dialoghelper.DisplayCorrectDialog("Page saved successfully.");
                    } else
                    {
                        Enabled = false;
                        await _dialoghelper.DisplayErrorDialog("An unknown error occurred.");
                    }

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
