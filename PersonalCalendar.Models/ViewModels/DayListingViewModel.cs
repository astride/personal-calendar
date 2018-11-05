using PersonalCalendar.Models.Calendar;
using PersonalCalendar.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalCalendar.ViewModels
{
    public class DayListingViewModel
    {
        public DayListingViewModel(Plan plan, DateTime referenceDate)
        {
            var startDateEqualsReferenceDate = plan.StartDate?.Date == referenceDate.Date;
            var endDateEqualsReferenceDate = plan.EndDate?.Date == referenceDate.Date;
            
            if (startDateEqualsReferenceDate)
            {
                if (!plan.IsAllDayEvent)
                {
                    StartTime = CalendarHelpers.GetTimeStringOrEmpty(plan.StartDate);
                }
            }
            else
            {
                EarlierStartDate = CalendarHelpers.GetDateStringOrEmpty(plan.StartDate);

                if (!plan.IsAllDayEvent)
                {
                    EarlierStartTime = CalendarHelpers.GetTimeStringOrEmpty(plan.StartDate);
                }
            }

            if (endDateEqualsReferenceDate)
            {
                if (!plan.IsAllDayEvent)
                {
                    EndTime = CalendarHelpers.GetTimeStringOrEmpty(plan.EndDate);
                }
            }
            else
            {
                LaterEndDate = CalendarHelpers.GetDateStringOrEmpty(plan.EndDate);

                if (!plan.IsAllDayEvent)
                {
                    LaterEndTime = CalendarHelpers.GetTimeStringOrEmpty(plan.EndDate);
                }
            }

            Title = plan.Title;
            CoversFullDay = plan.IsAllDayEvent
                || !(startDateEqualsReferenceDate || endDateEqualsReferenceDate);
        }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string EarlierStartDate { get; set; }
        public string EarlierStartTime { get; set; }
        public string LaterEndDate { get; set; }
        public string LaterEndTime { get; set; }
        public string Title { get; set; }
        public bool CoversFullDay { get; set; }
    }
}