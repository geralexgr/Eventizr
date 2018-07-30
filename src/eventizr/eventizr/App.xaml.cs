using eventizr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using eventizr.Models;
using System.ComponentModel;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
//using Google.MobileAds;
//using Microsoft.Azure.Mobile.Crashes;


namespace eventizr
{
	public partial class App : Application
	{

        private static Database _database;
        public static Database SqliteDB => GetDatabase();

        private static Database GetDatabase()
        {
            if (_database == null)
            {
                _database = new Database();
            }

            return _database;
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) {
                BarBackgroundColor = Color.FromHex("#344354"),
                BarTextColor = Color.White,
            };
        }

      

        protected override void OnStart ()
		{
            MobileAds.Configure("ca-app-pub-KEY");
            MobileCenter.Start("ios=KEY;" +
                               "uwp=KEY;" +
                   "android=KEY;",
                   typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
