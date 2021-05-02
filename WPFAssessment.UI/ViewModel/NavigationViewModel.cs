using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAssessment.Model;
using WPFAssessment.UI.Data;
using WPFAssessment.UI.Event;

namespace WPFAssessment.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IUserLookupDataService _userLookupDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IUserLookupDataService userLookupDataService, IEventAggregator eventAggregator)
        {
            _userLookupDataService = userLookupDataService;
            _eventAggregator = eventAggregator;
            Users = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterUserLoginSavedEvent>().Subscribe(AfterUserLoginSaved);
        }

        private void AfterUserLoginSaved(AfterUserLoginSavedEventArgs obj)
        {
            var lookupItem = Users.Single(x => x.Id == obj.Id);
            lookupItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _userLookupDataService.GetUserLookupAsync();
            Users.Clear();
            foreach (var user in lookup)
            {
                Users.Add(new NavigationItemViewModel(user.Id,user.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Users { get; set; }

        private NavigationItemViewModel _selectedUser;
        public NavigationItemViewModel SelectedUser
        {
            get { return _selectedUser; }
            set 
            {
                _selectedUser = value;
                OnPropertyChanged();
                if (_selectedUser != null)
                {
                    _eventAggregator.GetEvent<OpenUserLoginDetailViewEvent>()
                        .Publish(_selectedUser.Id);
                }
            }
        }

    }
}
