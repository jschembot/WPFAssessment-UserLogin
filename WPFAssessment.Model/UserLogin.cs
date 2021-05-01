using System;
using System.ComponentModel.DataAnnotations;

namespace WPFAssessment.Model
{
    public class UserLogin
    {
        [Key]
        public int UserLoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }

    }
}
