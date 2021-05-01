using System.Threading.Tasks;

namespace WPFAssessment.UI.ViewModel
{
    public interface IUserDetailViewModel
    {
        Task LoadAsync(int userId);
    }
}