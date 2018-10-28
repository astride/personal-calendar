using PersonalCalendar.Models.Calendar;
using System;
using System.Collections.Generic;

namespace PersonalCalendar.Services
{
    public interface IPlanService
    {
        IList<Plan> GetPlans(DateTime? fromDate = null, int? numberOfPlans = null);
        string SaveToDatabase(Plan plan);
        void InsertPlan();
    }
}