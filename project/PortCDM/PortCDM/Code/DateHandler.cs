using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM_App_Code
{
    public class DateHandler
    {
        public string getCurrentTimeString()
        {
            return DateTime.UtcNow.ToString("O");
        }
    }
}