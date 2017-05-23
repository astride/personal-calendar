using System.Collections.Generic;

namespace PersonalCalendar.Models.Calendar
{
    public class Plan
    {
        public int Id { get; set; }
        public bool IsAllDayEvent { get; set; }
        public int? StartDateId { get; set; }
        public Date StartDate { get; set; }
        public int? EndDateId { get; set; }
        public Date EndDate { get; set; }
        public int? StartTimeId { get; set; }
        public Time StartTime { get; set; }
        public int? EndTimeId { get; set; }
        public Time EndTime { get; set; }
        public string Title { get; set; }
        public PlanCategory Category { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<string> Participants { get; set; }
    }
}