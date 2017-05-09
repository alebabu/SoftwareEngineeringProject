using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code
{
    public class MessageIdGenerator
    {
        public string prefix { get; private set; }
        public int idLength { get; private set; }

        public MessageIdGenerator(string prefix, int idLength)
        {
            this.prefix = prefix;
            this.idLength = idLength;
        }

        public string generateMessageId()
        {
            string id = Randomizer.genRandomString(idLength);
            id = prefix + id;
            return id;
        }
    }
}