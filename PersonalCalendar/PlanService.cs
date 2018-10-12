using PersonalCalendar.Data;
using PersonalCalendar.Models.Calendar;
using PersonalCalendar.Services;
using System;
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
                StartDate = new DateTime(2017, 7, 1, 18, 0, 0),
                EndDate = new DateTime(2017, 7, 1, 20, 30, 0),
                Title = "Kafé med Susanne",
                Category = PlanCategory.Venner,
                Description = "Vi må planlegge sommerferien i Risør!",
                Location = "Mormors stue",
                Participants = new Collection<Participant>()
                {
                    new Participant { Name = "Susanne Hansen" },
                    new Participant { Name = "Johan Severinsen" }
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
