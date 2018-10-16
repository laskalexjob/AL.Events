using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class OrganizerViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Write name or organization")]
        [Display(Name = "Organizer")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required")]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter phone")]
        [Display(Name = "Phone number")]
        public string Phones { get; set; }
    }
}