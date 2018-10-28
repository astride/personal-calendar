using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCalendar.Models.Calendar.Enums
{
    public enum NorwegianMonth
    {
        [Display(Name = "januar")]
        January = 1,
        [Display(Name = "februar")]
        February = 2,
        [Display(Name = "mars")]
        March = 3,
        [Display(Name = "april")]
        April = 4,
        [Display(Name = "mai")]
        May = 5,
        [Display(Name = "juni")]
        June = 6,
        [Display(Name = "juli")]
        July = 7,
        [Display(Name = "august")]
        August = 8,
        [Display(Name = "september")]
        September = 9,
        [Display(Name = "oktober")]
        October = 10,
        [Display(Name = "november")]
        November = 11,
        [Display(Name = "desember")]
        December = 12
    }
}
