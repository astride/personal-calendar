using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCalendar.Models.Calendar.Enums
{
    public enum NorwegianDayOfWeek
    {
        [Display(Name = "mandag")]
        Monday = 0,
        [Display(Name = "tirsdag")]
        Tuesday = 1,
        [Display(Name = "onsdag")]
        Wednesday = 2,
        [Display(Name = "torsdag")]
        Thursday = 3,
        [Display(Name = "fredag")]
        Friday = 4,
        [Display(Name = "lørdag")]
        Saturday = 5,
        [Display(Name = "søndag")]
        Sunday = 6
    }
}
