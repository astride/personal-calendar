using PersonalCalendar.Models.Calendar;
using PersonalCalendar.Models.Calendar.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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

        public static string GetSpokenDateStringOrEmpty(DateTime? date, bool capitalFirstLetter = true)
        {
            if (date == null) return string.Empty;

            var today = DateTime.Today.Date;
            var reference = date.Value.Date;
            var differenceInDays = reference.Subtract(today).Days;

            var spokenDateString = Math.Abs(differenceInDays) > 7
                ? GetDateStringWithWrittenMonth(reference)
                : differenceInDays == -7
                    ? "for én uke siden"
                    : differenceInDays == 7
                        ? "om én uke"
                        : differenceInDays < -1
                            ? $"for {differenceInDays} dager siden"
                            : differenceInDays > 1
                                ? $"om {differenceInDays} dager"
                                : differenceInDays == -1
                                    ? "i går"
                                    : differenceInDays == 1
                                        ? "i morgen"
                                        : differenceInDays == 0
                                            ? "idag"
                                            : "ukjent dato";

            if (capitalFirstLetter) spokenDateString = GetCapitalizedString(spokenDateString);

            return spokenDateString;
        }

        private static string GetCapitalizedString(string sourceString)
        {
            return char.ToUpper(sourceString[0]) + sourceString.Substring(1);
        }

        public static string GetDateStringWithWrittenMonth(DateTime date, bool capitalFirstLetter = false)
        {
            return $"{GetNorwegianDayOfWeek(date.DayOfWeek, capitalFirstLetter)} {date.Day}. {GetNorwegianMonth(date.Month)}";
        }

        private static string GetNorwegianDayOfWeek(DayOfWeek dayOfWeek, bool capitalFirstLetter = false)
        {
            var norwegianDayOfWeek = GetDisplayValue((NorwegianDayOfWeek) (int) dayOfWeek);

            if (capitalFirstLetter) norwegianDayOfWeek = GetCapitalizedString(norwegianDayOfWeek);

            return norwegianDayOfWeek;
        }

        private static string GetNorwegianMonth(int monthNumber, bool capitalFirstLetter = false)
        {
            var norwegianMonth = GetDisplayValue((NorwegianMonth) monthNumber);

            if (capitalFirstLetter) norwegianMonth = GetCapitalizedString(norwegianMonth);

            return norwegianMonth;
        }

        public static string GetDisplayValue<T>(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            if (descriptionAttributes == null)
                return string.Empty;

            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }

        private static string LookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey;
        }
    }
}
