using PersonalCalendar.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCalendar.Models.Helpers
{
    public static class CalendarHelpers
    {
        public static IList<Participant> GetParticipantsFromString(string participantsAsString)
        {
            var participants = new List<Participant>();

            if (participantsAsString != "")
            {
                var participantArray = participantsAsString.Split(',');

                for (int i = 0; i < participantArray.Length; i++)
                {
                    participants.Add(new Participant
                    {
                        Name = participantArray[i].Trim(),
                    });
                }
            }

            return participants;
        }

        public static string GetDateStringOrEmpty(DateTime? date)
        {
            return date != null
                ? date.Value.Date.ToShortDateString()
                : string.Empty;
        }

        public static string GetDateTimeStringOrEmpty(DateTime? date)
        {
            return date != null
                ? date.Value.Date.ToShortDateString() + " kl. " + date.Value.TimeOfDay.Hours + ":" + date.Value.TimeOfDay.Minutes
                : string.Empty;
        }
    }
}
