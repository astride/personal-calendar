using PersonalCalendar.Data;
using PersonalCalendar.Models.Calendar;
using PersonalCalendar.Models.Helpers;
using PersonalCalendar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PersonalCalendar.Calendar.Controllers
{
    public class PlanService : IPlanService
    {
        private PlanDbContext _planDbService;
        
        public PlanService(PlanDbContext planDbService)
        {
            _planDbService = planDbService;
        }

        public IList<Plan> GetPlans(DateTime? fromDate = null, int? numberOfPlans = null)
        {
            using (var db = new PlanDbContext())
            {
                var plans = db.Plans.Include("Participants")
                    .Where(p => p.StartDate != null)
                    .OrderBy(p => p.StartDate)
                    .ThenBy(p => p.IsAllDayEvent)
                    .ThenByDescending(p => p.EndDate)
                    .ToList();

                if (fromDate != null)
                {
                    plans = plans.Where(p => p.StartDate?.Date >= fromDate?.Date).ToList();
                }

                if (numberOfPlans != null && plans.Count > 0)
                {
                    plans = plans.GetRange(0, Math.Min(numberOfPlans.Value, plans.Count));
                }

                return plans;
            }
        }

        public string SaveToDatabase(Plan plan)
        {
            using (var db = new PlanDbContext())
            {
                db.Plans.Add(plan);

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException exception)
                {
                    return exception.InnerException.ToString();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                {
                    return exception.InnerException.ToString();
                }
                catch (NotSupportedException exception)
                {
                    return exception.InnerException.ToString();
                }
                catch (ObjectDisposedException exception)
                {
                    return exception.InnerException.ToString();
                }
                catch (InvalidOperationException exception)
                {
                    return exception.InnerException.ToString();
                }

                return null;
            }
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
