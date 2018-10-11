using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class OrganizerViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя или организацию")]
        [Display(Name = "Организатор")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите почту")]
        [Display(Name = "Почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ввведите имя")]
        [Display(Name = "Номер телефона")]
        public string Phones { get; set; }
    }
}