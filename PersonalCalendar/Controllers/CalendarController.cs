using PersonalCalendar.Services;
using System.Web.Mvc;

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
        
        public ActionResult Index()
        {
            return View();
        }
    }
}