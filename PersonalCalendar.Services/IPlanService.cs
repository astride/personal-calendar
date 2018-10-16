using PersonalCalendar.Models.Calendar;
using System;

namespace PersonalCalendar.Services
{
    public interface IPlanService
    {
        string SaveToDatabase(Plan plan);
        void InsertPlan();
    }
}