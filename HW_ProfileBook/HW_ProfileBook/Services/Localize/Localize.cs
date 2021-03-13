using HW_ProfileBook.Services.Settings;
using System.Globalization;
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

        public void SetCurrentCultureInfo(string language)
        {
            var prefLanguage = "en-US";
            if (language != prefLanguage)
            {
                Resource.Resource.Culture = new CultureInfo(language);
                _settingManager.Language = language;
            }
            else
            {
                Resource.Resource.Culture = new CultureInfo(prefLanguage);
                _settingManager.Language = prefLanguage;
            }
        }

        public void GetCurrentCultureInfo()
        {
            Resource.Resource.Culture = new CultureInfo(_settingManager.Language);
        }
    }
}
