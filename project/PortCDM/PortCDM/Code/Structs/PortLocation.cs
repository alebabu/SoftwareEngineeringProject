using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM_RestStructs
{
    public struct PortLocation
    {
        public string name { get; set; }
        public string shortName { get; set; }
        public Position coordinates { get; set; }
        public string locationType { get; set; }
        public string URN { get; set; }
    }
}