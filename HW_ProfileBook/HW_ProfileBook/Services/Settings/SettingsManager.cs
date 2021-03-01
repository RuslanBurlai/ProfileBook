﻿using System;
using Xamarin.Essentials;

namespace HW_ProfileBook.Services.Settings
{
    public class SettingsManager : ISettingsManager
    {
        public int Id 
        { 
            get => Preferences.Get(nameof(Id), 0); 
            set => Preferences.Set(nameof(Id), value);
        }
    }
}