using PersonalCalendar.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalCalendar.ViewModels
{
    public class PlanViewModel
    {
        public PlanCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAllDayEvent { get; set; }
        public string Location { get; set; }
        public string ParticipantsAsString { get; set; }
        public DateTime? StartDate { get; set; }
        public string Title { get; set; }
    }
}