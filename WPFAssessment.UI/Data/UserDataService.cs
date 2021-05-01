using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAssessment.Model;

namespace WPFAssessment.UI.Data
{
    public class UserDataService : IUserDataService
    {
        public IEnumerable<UserLogin> GetAll()
        {
            // TODO: Load data from db context;
            yield return new UserLogin { FirstName = "Jon", LastName = "Schemmel", EmailID = "jonathan.schemmel@gmail.com"};
            yield return new UserLogin { FirstName = "Tuan", LastName = "Nyguen", EmailID = "tuan.nyguen@gmail.com"};
            yield return new UserLogin { FirstName = "Mitchell", LastName = "Dieckhoff", EmailID = "mitch.dieck@gmail.com"};
            yield return new UserLogin { FirstName = "Kyle", LastName = "McKillup", EmailID = "kyle.mckillup@gmail.com"};
        }
    }
}
