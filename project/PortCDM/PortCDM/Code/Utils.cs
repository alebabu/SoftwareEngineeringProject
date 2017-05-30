using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code
{
    public static class Utils
    {
        public static object niceDate(object badDate)
        {
            if (badDate == null)
                return null;

            DateTime dateTime = (DateTime) badDate;
            object niceDate = dateTime.ToString("yyyy-MM-dd HH:mm ");

            return niceDate;
        }

        public static object niceTime(object badTime)
        {
            if (badTime == null)
                return null;

            DateTime dateTime = (DateTime) badTime;
            object niceTime = dateTime.ToString("HH:mm ");

            return niceTime;
        }

        public static object newTime(object oldTime)
        {
            String s = (String) oldTime;
            DateTime time = DateHandler.stringToDate(s);
            object newTime = time.ToString("d MMM HH:mm");
            return newTime;
        }
    }
}