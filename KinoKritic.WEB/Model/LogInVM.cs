using System.ComponentModel.DataAnnotations;

namespace KinoKritic.WEB.Model
{
    public class LogInVM
    {
        
        [Required]
        [Display(Name = "UserName")]
        public string UserName{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
