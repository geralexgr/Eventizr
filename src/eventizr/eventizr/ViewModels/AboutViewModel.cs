using System;
using System.Windows.Input;
using Plugin.Messaging;
using Xamarin.Forms;

namespace eventizr.ViewModels
{
    public class AboutViewModel
    {


		public ICommand ContactCommand
		{
			get
			{
				return new Command(async () => {

					var emailMessenger = CrossMessaging.Current.EmailMessenger;
					if (emailMessenger.CanSendEmail) emailMessenger.SendEmail("email", "eventizr Feedback", "Write your message HERE..");
					else await Application.Current.MainPage.DisplayAlert("Error", "You must set an email account on your phone.", "OK");

				});
			}

		}


    }
}
