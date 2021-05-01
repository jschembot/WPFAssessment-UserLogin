
using System.Threading.Tasks;
using WPFAssessment.Model;
using WPFAssessment.UI.Data;

namespace WPFAssessment.UI.ViewModel
{
    public class UserDetailViewModel : IUserDetailViewModel
    {
        private IUserDataService _dataService;

        public UserDetailViewModel(IUserDataService userDataService)
        {
            _dataService = userDataService;
        }

        public async Task LoadAsync(int userId)
        {
            UserLogin = await _dataService.GetByIdAsync(userId);
        }

        private UserLogin _userLogin;
        public UserLogin UserLogin;
    }
}
