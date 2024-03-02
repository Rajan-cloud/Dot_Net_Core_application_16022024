using System.ComponentModel.DataAnnotations;

namespace Dot_Net_Core_application_16022024.Models
{
    public class RR_table
    {
        [Key]
        public int rid { get; set; }
        [Required (ErrorMessage ="Name Field Is Not Empty")]
        public string Username { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.com", ErrorMessage = "Please enter correct email")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Password Should Not be Empty")]
        public string password { get; set;}
        public int Status { get; set; }
    }

    public class RRtbale1
    {
        [Required(ErrorMessage = "Email Should Not be Empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Should Not be Empty")]
        public string password { get; set; }
        public int Status { get; set; }
    }
}
