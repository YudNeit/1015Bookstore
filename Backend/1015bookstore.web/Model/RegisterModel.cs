using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Model
{
    public class RegisterModel
    {
        [Required]
        public string firstname { get; set; } = null!;
        [Required]
        public string lastname { get; set; } = null!;
        [Required]
        public string username { get; set; } = null!;
        [Required]
        public string password { get; set; } = null!;
        [Required]
        public string confirmpassword { get; set; } = null!;
        [Required]
        public string email { get; set; } = null!;
    }
}
