using AL.Events.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AL.Events.WEB.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date required")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Picture")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Address plz")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Current status")]
        public EventStatus Status { get; set; }

        public Category Category { get; set; }
        public Organizer Organizer { get; set; }

        [Required(ErrorMessage = "Fill in category")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Fill in organizer")]
        [Display(Name = "Organizer")]
        public string OrganizerName { get; set; }
        public int OrganizerId { get; set; }

        public int UserId { get; set; }
        public int StatusId { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Organizer> OrganizerList { get; set; }
        public IEnumerable<User> UserList { get; set; }

        public IEnumerable<EventStatus> StatusList { get; set; }

    }
}