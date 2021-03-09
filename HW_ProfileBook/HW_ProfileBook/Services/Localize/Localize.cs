using HW_ProfileBook.Services.Settings;
using System.Threading;

namespace HW_ProfileBook.Services.Localize
{
    public class Localize : ILocalize
    {
        private readonly ISettingsManager _settingManager;

        public Localize(ISettingsManager settingManager)
        {
            _settingManager = settingManager;
        }

        public void GetCurrentCultureInfo(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            //AppResourse = language;

            //var prefLanguage = "en-US";
            //System.Globalization.CultureInfo choisenLang = null;
            //try
            //{
            //    choisenLang = new System.Globalization.CultureInfo(language);
            //}
            //catch
            //{
            //    choisenLang = new System.Globalization.CultureInfo(prefLanguage);
            //}

        }
    }
}
