using System;
using System.ComponentModel.DataAnnotations;

namespace WPFAssessment.Model
{
    public class LoginTracker
    {
        [Key]
        public int TrackerId { get; set; }
        public int UserLoginId { get; set; }
        public DateTime LoginTime { get; set; }

    }
}
