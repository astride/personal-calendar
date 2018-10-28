using PersonalCalendar.Models.Helpers;
using PersonalCalendar.Models.Calendar;
using PersonalCalendar.Services;
using PersonalCalendar.ViewModels;
using System.Web.Mvc;
using System;

namespace PersonalCalendar.Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private IPlanService _planService;

        public CalendarController() : this(new PlanService(new Data.PlanDbContext())) { }

        public CalendarController(IPlanService planService)
        {
            _planService = planService;
        }
        
        public ActionResult Index(string exception = null)
        {
            ViewBag.Exception = exception;

            return View();
        }

        public ActionResult AddPlan()
        {
            return View(new PlanViewModel());
        }

        public ActionResult SavePlan(PlanViewModel model)
        {
            var plan = new Plan
            {
                Category = model.Category,
                Description = model.Description,
                EndDate = model.EndDate,
                IsAllDayEvent = model.IsAllDayEvent,
                Location = model.Location,
                Participants = CalendarHelpers.GetParticipantsFromString(model.ParticipantsAsString),
                StartDate = model.StartDate,
                Title = model.Title,
            };

            var exception = _planService.SaveToDatabase(plan);

            return RedirectToAction("Index", exception);
        }

        public ActionResult ViewCalendar()
        {
            var plans = _planService.GetPlans(DateTime.Now, 3);

            return View(plans);
        }
    }
}