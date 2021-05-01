using System.Collections.Generic;
using System.Threading.Tasks;
using WPFAssessment.Model;

namespace WPFAssessment.UI.Data
{
    public interface IUserDataService
    {
        Task<List<UserLogin>> GetAllAsync();
    }
}