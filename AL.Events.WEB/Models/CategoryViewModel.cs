using AL.Events.Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Категория")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Ввведите имя")]
        [Display(Name = "Имя новой категории")]
        public string NewCategoryName { get; set; }
    }
}