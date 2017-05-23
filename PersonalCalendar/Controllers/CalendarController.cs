using PersonalCalendar.Services;
using System.Web.Mvc;

namespace PersonalCalendar.Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private IPlanService _planService;

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