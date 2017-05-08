using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortCDM_App_Code;


namespace PortCDM
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private DateHandler dateHandler;
        private portCallMessage messageToSend;

        protected void Page_Load(object sender, EventArgs e)
        {
            dateHandler = new DateHandler();
            messageToSend = new portCallMessage();
            testText.Text = dateHandler.getCurrentTimeString();
        }

        private void prepareMessage()
        {
            //TODO(Olle): set either service or locationstate
            messageToSend.serviceState.serviceObject = (ServiceObject) Enum.Parse(typeof(ServiceObject),
                messageTypeDropDown.SelectedValue);

        }
    }
}