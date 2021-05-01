using System.Collections.ObjectModel;
using WPFAssessment.Model;
using WPFAssessment.UI.Data;

namespace WPFAssessment.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IUserDataService _userDataService;
        private UserLogin _selectedUser;

        public MainViewModel(IUserDataService userDataService)
        {
            //Using OCollection so that databinding is notified when the collection has changed.
            Users = new ObservableCollection<UserLogin>();
            _userDataService = userDataService;
        }

        public void Load()
        {
            var users = _userDataService.GetAll();
            // In case Load() is called twice so we don't see duplicates.
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public ObservableCollection<UserLogin> Users { get; set; }

        public UserLogin SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }
    }
}
