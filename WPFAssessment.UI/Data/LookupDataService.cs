using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAssessment.DataAccess;
using WPFAssessment.Model;

namespace WPFAssessment.UI.Data
{
    public class LookupDataService : IUserLookupDataService
    {

        private Func<UserLoginDbContext> _contextCreator;
        public LookupDataService(Func<UserLoginDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetUserLookupAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.UsersLogins.Select(
                    x => new LookupItem
                    {
                        Id = x.UserLoginId,
                        DisplayMember = x.FirstName + " " + x.LastName
                    }).ToListAsync();
            }
        }
    }
}
