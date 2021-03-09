using HW_ProfileBook.Styles;
using System;
using Xamarin.Essentials;
using HW_ProfileBook;

namespace HW_ProfileBook.Services.Settings
{
    public class SettingsManager : ISettingsManager
    {
        public int Id 
        { 
            get => Preferences.Get(nameof(Id), 0); 
            set => Preferences.Set(nameof(Id), value);
        }

        public string SortMethod
        {
            get => Preferences.Get(nameof(SortMethod), String.Empty);
            set => Preferences.Set(nameof(SortMethod), value);
        }

        public string Appearance
        {
            get => Preferences.Get(nameof(Appearance), nameof(LightTheme));
            set => Preferences.Set(nameof(Appearance), value);
        }
    }
}
