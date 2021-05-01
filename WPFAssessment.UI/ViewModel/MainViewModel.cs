using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPFAssessment.Model;
using WPFAssessment.UI.Data;

namespace WPFAssessment.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(INavigationViewModel navigationViewModel, IUserDetailViewModel userDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            UserDetailViewModel = userDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IUserDetailViewModel UserDetailViewModel { get; }
    }
}
