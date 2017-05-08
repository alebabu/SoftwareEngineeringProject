using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortCDM
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private portCallMessage messageToSend;
        protected void Page_Load(object sender, EventArgs e)
        {
            messageToSend = new portCallMessage();
        }
    }
}