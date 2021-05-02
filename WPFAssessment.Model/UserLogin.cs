using System;
using System.ComponentModel.DataAnnotations;

namespace WPFAssessment.Model
{
    public class UserLogin
    {
        [Key]
        public int UserLoginId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string EmailID { get; set; }
        public DateTime? CreationDateTime { get; set; }

    }
}
