
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFAssessment.Model;
using WPFAssessment.UI.Data;
using WPFAssessment.UI.Event;
using WPFAssessment.UI.Wrapper;

namespace WPFAssessment.UI.ViewModel
{
    public class UserDetailViewModel : ViewModelBase, IUserDetailViewModel
    {
        private IUserDataService _dataService;
        private IEventAggregator _eventAggregator;
        private UserWrapper _userLogin;

        public UserDetailViewModel(IUserDataService userDataService, IEventAggregator eventAggregator)
        {
            _dataService = userDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenUserLoginDetailViewEvent>()
                .Subscribe(OnOpenUserLoginDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }
        public async Task LoadAsync(int userId)
        {
            var userLogin = await _dataService.GetByIdAsync(userId);
            UserLogin = new UserWrapper(userLogin);
            UserLogin.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(UserLogin.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public UserWrapper UserLogin
        {
            get { return _userLogin; }
            set
            {
                _userLogin = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync(UserLogin.Model);
            _eventAggregator.GetEvent<AfterUserLoginSavedEvent>().Publish(
                new AfterUserLoginSavedEventArgs
                {
                    Id = UserLogin.UserLoginId,
                    DisplayMember = $"{UserLogin.FirstName} {UserLogin.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            return UserLogin!=null && !UserLogin.HasErrors;
        }

        private async void OnOpenUserLoginDetailView(int userId)
        {
            await LoadAsync(userId);
        }
    }
}
