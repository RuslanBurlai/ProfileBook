using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_ProfileBook.Services.ProfileService
{
    public class ProfileSort : IProfileSort
    {
        #region --- Private Fields ---

        private readonly ISettingsManager _settingsManager;
        private readonly IRepository _repository;

        #endregion

        public ProfileSort(
            ISettingsManager settingsManager,
            IRepository repository)
        {
            _settingsManager = settingsManager;
            _repository = repository;
        }

        public IEnumerable<Profile> SortProfiles()
        {
            switch (_settingsManager.SortMethod)
            {
                case "Name": { return SortProfilesByName(); }
                case "NickName": { return SortProfilesByNickName(); }
                case "Date": { return SortProfilesByDate(); }
                default: return _repository.GetItems<Profile>().Where(x => x.UserId == _settingsManager.Id);
            }
            
        }

        #region --- Private Helpers ---

        private IEnumerable<Profile> SortProfilesByDate()
        {
            return _repository.GetItems<Profile>().Where(x => x.UserId == _settingsManager.Id).OrderBy(x => x.DateLabel);
        }

        private IEnumerable<Profile> SortProfilesByName()
        {
            return _repository.GetItems<Profile>().Where(x => x.UserId == _settingsManager.Id).OrderBy(x => x.NameLabel);
        }

        private IEnumerable<Profile> SortProfilesByNickName()
        {
            return _repository.GetItems<Profile>().Where(x => x.UserId == _settingsManager.Id).OrderBy(x => x.NickNameLabel);
        }

        #endregion
    }
}
