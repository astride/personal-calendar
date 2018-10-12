using System;
using System.Collections.Generic;

namespace PersonalCalendar.Models.Calendar
{
    public class Plan
    {
        public int Id { get; set; }
        public bool IsAllDayEvent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public PlanCategory Category { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<Participant> Participants { get; set; }


    }
}