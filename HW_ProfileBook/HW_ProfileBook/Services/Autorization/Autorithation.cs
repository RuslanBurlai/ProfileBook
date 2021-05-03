using HW_ProfileBook.Services.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Autorization
{
    public class Autorithation : IAutorithation
    {
        private readonly ISettingsManager _settingsManager;
        public Autorithation(ISettingsManager settings)
        {
            _settingsManager = settings;
        }

        public bool IsAutorized() => _settingsManager.Id != 0;
        public int LogOut() => _settingsManager.Id = 0;
    }
}
