using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}