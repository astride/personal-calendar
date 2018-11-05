using PersonalCalendar.Models.Calendar;
using System;
using System.Collections.Generic;

namespace PersonalCalendar.Services
{
    public interface IPlanService
    {
        IList<Plan> GetPlans(DateTime? fromDate = null, int? numberOfPlans = null);
        IList<Plan> GetPlansForDay(DateTime dateTime);
        string SaveToDatabase(Plan plan);
        void InsertPlan();
    }
}