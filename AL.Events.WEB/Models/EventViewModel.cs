using AL.Events.Common.Entities;
using System;

namespace AL.Events.WEB.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public Category Category { get; set; }
        public Organizer Organizer { get; set; }

    }
}