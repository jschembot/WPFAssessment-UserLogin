using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPFAssessment.DataAccess;
using WPFAssessment.Model;

namespace WPFAssessment.UI.Data
{
    public class UserDataService : IUserDataService
    {
        private Func<UserLoginDbContext> _contextCreator;
        public UserDataService(Func<UserLoginDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<UserLogin> GetByIdAsync(int userId)
        {
            using (var context = _contextCreator())
            {
                return await context.UsersLogins.SingleAsync(x => x.UserLoginId == userId);
            }
        }

        public async Task<List<UserLogin>> GetAllAsync()
        {
            using(var context = _contextCreator())
            {
                return await context.UsersLogins.ToListAsync();
            }

            // TODO: Load data from db context;
            //yield return new UserLogin { FirstName = "Jon", LastName = "Schemmel", EmailID = "jonathan.schemmel@gmail.com"};
            //yield return new UserLogin { FirstName = "Tuan", LastName = "Nyguen", EmailID = "tuan.nyguen@gmail.com"};
            //yield return new UserLogin { FirstName = "Mitchell", LastName = "Dieckhoff", EmailID = "mitch.dieck@gmail.com"};
            //yield return new UserLogin { FirstName = "Kyle", LastName = "McKillup", EmailID = "kyle.mckillup@gmail.com"};
        }
    }
}
