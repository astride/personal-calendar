using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCalendar.Models.Calendar
{
    public class Participant
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Name { get; set; }
    }
}
