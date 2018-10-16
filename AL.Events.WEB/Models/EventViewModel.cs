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
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Fill in category")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Fill in organizer")]
        [Display(Name = "Organizer")]
        public string OrganizerName { get; set; }

        [Display(Name = "Picture")]
        public string ImagePath { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Venue")]
        public string Location { get; set; }

        [Display(Name = "Current status")]
        public EventStatus Status { get; set; }

        public Category Category { get; set; }
        public Organizer Organizer { get; set; }

        public int CategoryId { get; set; }
        public int OrganizerId { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Organizer> OrganizerList { get; set; }

        public IEnumerable<EventStatus> StatusList { get; set; }
    }
}