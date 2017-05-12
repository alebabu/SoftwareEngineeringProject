using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortCDM.Code;
using PortCDM_App_Code;


namespace PortCDM
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private DateHandler dateHandler;
        private portCallMessage messageToSend;
        private MessageIdGenerator messageIdGenerator;

        protected void Page_Load(object sender, EventArgs e)
        {
            messageIdGenerator = new MessageIdGenerator("Agent1-", 15);
            dateHandler = new DateHandler();
            testText.Text = dateHandler.getCurrentTimeString();
        }

        protected async void prepareMessage(object sender, EventArgs e)
        {
            //TODO(Olle): set either service or locationstate
            messageToSend = await genMessage();

            testText.Text = await RestHandler.createPCM(messageToSend);
        }

        private async Task<portCallMessage> genMessage()
        {
            string dateFormatted = getDropDownVal(vesselArrivalYear) + "-" + getDropDownVal(vesselArrivalMonth) + "-" +
                                   getDropDownVal(vesselArrivalDay) + "T00:00:00Z";

            //----------- Message ---------------
            portCallMessage message = new portCallMessage();
            message.portCallId = await RestHandler.getPortCallId(vesselImoBox.Text, dateFormatted);
            message.vesselId = "urn:x-mrn:stm:vessel:IMO:" + vesselImoBox.Text;
            message.messageId = messageIdGenerator.generateMessageId();
            message.reportedAt = dateHandler.getCurrentTimeString();
            message.comment = commentBox.Text;

            //--------- Service state -----------
            message.serviceState = new ServiceState();
            message.serviceState.serviceObject = (ServiceObject) Enum.Parse(typeof(ServiceObject),
                serviceTypeDropDown.SelectedValue);
            message.serviceState.timeSequence = (ServiceTimeSequence) Enum.Parse(typeof(ServiceTimeSequence),
                serviceTimeSequenceDropDown.SelectedValue);
            message.serviceState.timeType = (TimeType) Enum.Parse(typeof(TimeType), timeTypeDropDown.SelectedValue);
            string serviceStateTime = getDropDownVal(setYearDropDown) + "-" + getDropDownVal(setMonthDropDown) + "-" +
                                      getDropDownVal(setDayDropDown) + "T" + "00:00:00Z";
            message.serviceState.time = dateHandler.stringToDate(serviceStateTime);

            //--------- Service state, location At -----------
            message.serviceState.at = new Location();
            message.serviceState.at.locationType =
                (LogicalLocation) Enum.Parse(typeof(LogicalLocation), atLocationType.SelectedValue);
            message.serviceState.at.name = atLocationNameBox.Text;

            //--------- Service state, location at, position -----------
            message.serviceState.at.position = new Position();
            message.serviceState.at.position.latitude = double.Parse(string.IsNullOrEmpty(atLatitudeBox.Text) ? "0.0" : atLatitudeBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            message.serviceState.at.position.longitude = double.Parse(string.IsNullOrEmpty(atLongitudeBox.Text) ? "0.0" : atLongitudeBox.Text, System.Globalization.CultureInfo.InvariantCulture);

            //--------- Service state, location between --------
            message.serviceState.between = new ServiceStateBetween();
            message.serviceState.between.from = new Location();
            message.serviceState.between.from.locationType = (LogicalLocation) Enum.Parse(typeof(LogicalLocation), fromLocationType.SelectedValue);
            message.serviceState.between.from.name = fromLocationNameBox.Text;
            message.serviceState.between.to = new Location();
            message.serviceState.between.to.locationType = (LogicalLocation) Enum.Parse(typeof(LogicalLocation), toLocationType.SelectedValue);
            message.serviceState.between.to.name = toLocationNameBox.Text;

            //--------- Service state, location between, position --------
            message.serviceState.between.from.position = new Position();
            //TODO(Olle): check null strings in a better more readable way
            message.serviceState.between.from.position.latitude = double.Parse(string.IsNullOrEmpty(fromLatitudeBox.Text) ? "0.0" : fromLatitudeBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            message.serviceState.between.from.position.longitude = double.Parse(string.IsNullOrEmpty(fromLongitudeBox.Text) ? "0.0" : fromLongitudeBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            message.serviceState.between.to.position = new Position();
            message.serviceState.between.to.position.latitude = double.Parse(string.IsNullOrEmpty(toLatitudeBox.Text) ? "0.0" : toLatitudeBox.Text, System.Globalization.CultureInfo.InvariantCulture);
            message.serviceState.between.to.position.longitude = double.Parse(string.IsNullOrEmpty(toLongitudeBox.Text) ? "0.0" : toLongitudeBox.Text, System.Globalization.CultureInfo.InvariantCulture);

            return message;
        }

        private string getDropDownVal(DropDownList dropDown)
        {
            return Request.Form[dropDown.UniqueID];
        }
    }
}