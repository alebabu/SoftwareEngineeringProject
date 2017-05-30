using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code
{
    public static class MessageIdGenerator
    {
        public static string generateMessageId()
        {
            string id = Randomizer.genRandomStringAF(8);
            id += "-" + Randomizer.genRandomStringAF(4);
            id += "-4" + Randomizer.genRandomStringAF(3);
            id += "-" + Randomizer.genRandomStringAB89(1);
            id += Randomizer.genRandomStringAF(3);
            id += "-" + Randomizer.genRandomStringAF(12);
            return id;
        }
    }
}