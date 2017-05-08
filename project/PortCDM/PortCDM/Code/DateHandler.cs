using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code
{
    public class DateHandler
    {
        public string getCurrentTimeString()
        {
            return DateTime.UtcNow.ToString("O");
        }
    }
}