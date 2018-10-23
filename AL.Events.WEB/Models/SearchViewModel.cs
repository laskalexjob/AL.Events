using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.WEB.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<EventStatus> Statuses { get; set; }


    }
}