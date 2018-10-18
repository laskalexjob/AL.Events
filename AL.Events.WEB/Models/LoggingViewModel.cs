using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class LoggingViewModel
    {
        [Required(ErrorMessage = "wrong login")]
        [Display(Name = "login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "wrong password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}