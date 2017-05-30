using System;

namespace PortCDM.Code
{
    public static class DateHandler
    {
        public static string getCurrentTimeString()
        {
            return DateTime.UtcNow.ToString("O");
        }

        public static DateTime stringToDate(string date)
        {
            return DateTime.Parse(date, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }
    }
}