using PersonalCalendar.Data;
using PersonalCalendar.Models.Calendar;
using PersonalCalendar.Services;
using System.Collections.ObjectModel;

namespace PersonalCalendar.Calendar.Controllers
{
    public class PlanService : IPlanService
    {
        private PlanDbContext _planDbService;
        
        public PlanService(PlanDbContext planDbService)
        {
            _planDbService = planDbService;
        }

        public void InsertPlan()
        {
            var newPlan = new Plan()
            {
                IsAllDayEvent = false,
                StartDate = new Date()
                {
                    Year = 2017,
                    Month = 7,
                    DateOfMonth = 1,
                },
                EndDate = new Date()
                {
                    Year = 2017,
                    Month = 7,
                    DateOfMonth = 2,
                },
                StartTime = new Time()
                {
                    Hour = 18,
                    Minute = 0,
                },
                EndTime = new Time()
                {
                    Hour = 20,
                    Minute = 30,
                },
                Title = "Kafé med Susanne",
                Category = PlanCategory.Venner,
                Description = "Vi må planlegge sommerferien i Risør!",
                Location = "Mormors stue",
                Participants = new Collection<string>()
                {
                    "Susanne Hansen"
                },
            };

            using (var db = new PlanDbContext())
            {
                db.Plans.Add(newPlan);
                db.SaveChanges();
            }
        }
    }
}
