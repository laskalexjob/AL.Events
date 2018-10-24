using System;

namespace AL.Events.Common.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public EventStatus Status { get; set; }

        public Category Category { get; set; }
        public Organizer Organizer { get; set; }
    }
}
