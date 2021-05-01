using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAssessment.Model;

namespace WPFAssessment.DataAccess
{
    public class UserLoginDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public UserLoginDbContext() : base()
        {

        }
        public DbSet<UserLogin> UsersLogins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = new UserLogin[] {
                new UserLogin { FirstName = "Jon", LastName = "Schemmel", EmailID = "jonathan.schemmel@gmail.com" },
                new UserLogin { FirstName = "Tuan", LastName = "Nyguen", EmailID = "tuan.nyguen@gmail.com" },
                new UserLogin { FirstName = "Mitchell", LastName = "Dieckhoff", EmailID = "mitch.dieck@gmail.com" },
                new UserLogin { FirstName = "Kyle", LastName = "McKillup", EmailID = "kyle.mckillup@gmail.com" }
            };
        }
    }
}

