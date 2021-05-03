using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Styles;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HW_ProfileBook.Services.Theme
{
    public class LoadAppereance : ILoadAppereance
    {
        private readonly ISettingsManager _settingsManager;

        public LoadAppereance(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public void SetAppTheme()
        {
            ICollection<ResourceDictionary> mergeDictionaries = Application.Current.Resources.MergedDictionaries;
            mergeDictionaries.Clear();
            if (_settingsManager.Appearance == nameof(DarkTheme))
                mergeDictionaries.Add(new DarkTheme());
            else mergeDictionaries.Add(new LightTheme());
        }
    }
}
