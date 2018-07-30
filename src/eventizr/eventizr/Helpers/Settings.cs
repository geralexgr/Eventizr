using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace eventizr.Helpers
{

    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;


        public static int Distance
        {
            get => AppSettings.GetValueOrDefault(nameof(Distance), 0);
            set => AppSettings.AddOrUpdateValue(nameof(Distance), value);
        }

        public static string CurrentPage 
        {
            get => AppSettings.GetValueOrDefault(nameof(CurrentPage), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(CurrentPage), value);
        }



    }
}
