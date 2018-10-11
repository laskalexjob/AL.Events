using AL.Events.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название события")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите дату")]
        [Display(Name = "Дата и время")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Укажите категорию")]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Укажите организатора")]
        [Display(Name = "Организатор")]
        public string OrganizerName { get; set; }

        [Display(Name = "Фото")]
        public string ImagePath { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Место проведения")]
        public string Location { get; set; }

        public Category Category { get; set; }
        public Organizer Organizer { get; set; }

        public int CategoryId { get; set; }
        public int OrganizerId { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Organizer> OrganizerList { get; set; }

    }
}