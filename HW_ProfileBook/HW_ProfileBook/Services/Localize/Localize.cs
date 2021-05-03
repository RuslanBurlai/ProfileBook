using HW_ProfileBook.Services.Settings;
using System.Globalization;
using System.Resources;
using System.Threading;
using Xamarin.Forms;

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
            Resource.Resource.Culture = new CultureInfo(language);
            _settingManager.Language = language;
        }

        public void GetCurrentCultureInfo()
        {
            Resource.Resource.Culture = new CultureInfo(_settingManager.Language);
        }
    }
}
