using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code
{
    public class MessageIdGenerator
    {
        public MessageIdGenerator()
        {
        }

        public string generateMessageId()
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