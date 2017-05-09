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
            messageToSend.serviceState = new ServiceState();
            messageToSend.serviceState.at = new Location();
            testText.Text = dateHandler.getCurrentTimeString();
        }

        protected async void prepareMessage(object sender, EventArgs e)
        {
            string dateFormatted = getDropDownVal(vesselArrivalYear) + "-" + getDropDownVal(vesselArrivalMonth) + "-" +
                                   getDropDownVal(vesselArrivalDay) + "T00:00:00Z";
            //TODO(Olle): set either service or locationstate
            //TODO(Olle): should prolly move some stuff to another class that handles sending messages
            messageToSend.serviceState.serviceObject = (ServiceObject) Enum.Parse(typeof(ServiceObject),
                messageTypeDropDown.SelectedValue);
            messageToSend.vesselId = "urn:x-mrn:stm:vessel:IMO:" + vesselImoBox.Text;
            messageToSend.reportedAt = dateHandler.getCurrentTimeString();
            messageToSend.comment = commentBox.Text;
            messageToSend.portCallId = await RestHandler.getPortCallId(vesselImoBox.Text, dateFormatted);
            messageToSend.serviceState.at.locationType = LogicalLocation.ANCHORING_AREA;
            messageToSend.serviceState.timeSequence = (ServiceTimeSequence) Enum.Parse(typeof(ServiceTimeSequence),
                serviceTimeSequenceDropDown.SelectedValue); //TODO(Olle):change this to stage
            messageToSend.serviceState.timeType = TimeType.ESTIMATED;
            messageToSend.messageId = "afi3fj24f235r";

            testText.Text = await RestHandler.createPCM(messageToSend);
        }

        private string getDropDownVal(DropDownList dropDown)
        {
            return Request.Form[dropDown.UniqueID];
        }
    }
}