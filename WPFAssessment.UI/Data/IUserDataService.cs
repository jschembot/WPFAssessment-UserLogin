using System.Collections.Generic;
using WPFAssessment.Model;

namespace WPFAssessment.UI.Data
{
    public interface IUserDataService
    {
        IEnumerable<UserLogin> GetAll();
    }
}