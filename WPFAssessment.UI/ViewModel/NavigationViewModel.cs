using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAssessment.Model;
using WPFAssessment.UI.Data;

namespace WPFAssessment.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IUserLookupDataService _userLookupDataService;

        public NavigationViewModel(IUserLookupDataService userLookupDataService)
        {
            _userLookupDataService = userLookupDataService;
            Users = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _userLookupDataService.GetUserLookupAsync();
            Users.Clear();
            foreach (var user in lookup)
            {
                Users.Add(user);
            }
        }

        public ObservableCollection<LookupItem> Users { get; set; }
    }
}
