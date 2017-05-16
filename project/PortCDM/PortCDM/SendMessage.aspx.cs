using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortCDM.Code;
using PortCDM_App_Code;
using PortCDM_RestStructs;

namespace PortCDM
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private List<Vessel> shipList;
        private MessageIdGenerator messageIdGenerator;
        private DateHandler dateHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable ships = DataBaseHandler.getActiveShips();

            messageIdGenerator = new MessageIdGenerator();
            shipList = new List<Vessel>();
            dateHandler = new DateHandler();
            foreach(DataRow ship in ships.Rows)
            {
                var v = new Vessel
                {
                    imo = ship["imoNumber"].ToString(),
                    name = ship["name"].ToString(),
                    photoURL = ship["imgURL"].ToString(),
                    portCallId = ship["portCallID"].ToString()
                };
                shipList.Add(v);
            }

            if(!IsPostBack)
            {
                initVisibilities();

                setUpDropDowns();
                setYearDropDown.SelectedValue = "2017";

                shipsDropDown.DataTextField = "name";
                shipsDropDown.DataValueField = "portCallId";
                shipsDropDown.DataSource = shipList;
                shipsDropDown.DataBind();

            }
        }

        private void initVisibilities()
        {
            stepOne.Visible = true;
            stepOneCheck.Visible = false;
            stepTwo.Visible = false;
            stepTwoCheck.Visible = false;
            stepThree.Visible = false;
            stepThreeCheck.Visible = false;
            messageSentButton.Visible = false;
        }

        protected void shipSelected(object sender, EventArgs e)
        {
            portCallIdHiddenField.Value = shipsDropDown.SelectedValue;
            var resultVessel = shipList.Find(ship => ship.portCallId == portCallIdHiddenField.Value);
            shipImoHiddenField.Value = resultVessel.imo;
            stepOne.Visible = false;
            stepOneCheck.Visible = true;
            listCounterOne.Visible = false;
            stepTwo.Visible = true;
        }

        protected void messageTypeSelected(object sender, EventArgs e)
        {
            messageTypeHiddenField.Value = messageTypeDropDown.SelectedValue;
            stepTwo.Visible = false;
            stepTwoCheck.Visible = true;
            listCounterTwo.Visible = false;
            stepThree.Visible = true;
            if (locationStateChosen())
            {
                stageField.Visible = false;
                atOrBothBox.Visible = false;
            }
            else
                fromOrToBoxes.Visible = false;
        }

        protected async void sendMessage(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "fancyboxscript", "$('.fancyBoxButton').click();", true);
            Task<portCallMessage> pcmTask = genMessage();
            var pcm = await pcmTask;
            string response = await RestHandler.createPCM(pcm);
            loadingText.Text = response;
            messageSentButton.Visible = true;
        }

        private bool locationStateChosen()
        {
            string chosenstate = messageTypeHiddenField.Value;
            return chosenstate == "ARRIVAL_VESSEL" || chosenstate == "DEPARTURE_VESSEL";
        }

        private void setUpDropDowns()
        {
            string[] days = new string[31];
            string[] months = new string[12];
            string[] years = new string[256];
            string[] hours = new string[24];
            string[] minutes = new string[60];


            //TODO(Olle): reuse the loops for performance
            for (int i = 0; i < 31; i++)
                days[i] = fromIntToDate(i + 1);
            for (int i = 0; i < 12; i++)
                months[i] = fromIntToDate(i + 1);
            for (int i = 0; i < 256; i++)
                years[i] = (i + 1980).ToString();
            for (int i = 0; i < 24; i++)
                hours[i] = fromIntToDate(i);
            for (int i = 0; i < 60; i++)
                minutes[i] = fromIntToDate(i);

            bindDateDropDown(setDayDropDown, days);
            bindDateDropDown(setMonthDropDown, months);
            bindDateDropDown(setYearDropDown, years);
            bindDateDropDown(setHourDropDown, hours);
            bindDateDropDown(setMinuteDropDown, minutes);
        }

        private string fromIntToDate(int i)
        {
            if (i < 10)
                return "0" + i.ToString();
            else
                return i.ToString();
        }

        private void bindDateDropDown(DropDownList ddl, string[] data)
        {
            ddl.DataSource = data;
            ddl.DataBind();
        }

        private async Task<portCallMessage> genMessage()
        {
            //----------- Message ---------------
            var message = new portCallMessage
            {
                portCallId = portCallIdHiddenField.Value,
                vesselId = "urn:mrn:stm:vessel:IMO:" + shipImoHiddenField.Value,
                messageId = "urn:x-mrn:stm:portcdm:message:" + messageIdGenerator.generateMessageId(),
                reportedAt = dateHandler.getCurrentTimeString(),
                comment = commentBox.Text
            };

            //--------- Service state -----------
            if(!locationStateChosen())
            {
                message.serviceState = new ServiceState();
                message.serviceState.serviceObject = (ServiceObject) Enum.Parse(typeof(ServiceObject),
                    messageTypeHiddenField.Value);
                message.serviceState.timeSequence = (ServiceTimeSequence) Enum.Parse(typeof(ServiceTimeSequence),
                    serviceTimeSequenceDropDown.SelectedValue);
                message.serviceState.timeType = (TimeType) Enum.Parse(typeof(TimeType), timeTypeDropDown.SelectedValue);
                string serviceStateTime = setYearDropDown.SelectedValue + "-" + setMonthDropDown.SelectedValue + "-" +
                                          setDayDropDown.SelectedValue + "T" + setHourDropDown.SelectedValue + ":" + setMinuteDropDown.SelectedValue + ":00Z";
                message.serviceState.time = dateHandler.stringToDate(serviceStateTime);

                //--------- Service state, location At -----------
                message.serviceState.at = new Location();
                message.serviceState.at.locationType =
                    (LogicalLocation) Enum.Parse(typeof(LogicalLocation), atLocationType.SelectedValue);
                message.serviceState.at.name = atLocationNameBox.Text;

                //--------- Service state, location at, position -----------
                message.serviceState.at.position = new Position();
                message.serviceState.at.position.latitude =
                    double.Parse(string.IsNullOrEmpty(atLatitudeBox.Text) ? "0.0" : atLatitudeBox.Text,
                        System.Globalization.CultureInfo.InvariantCulture);
                message.serviceState.at.position.longitude =
                    double.Parse(string.IsNullOrEmpty(atLongitudeBox.Text) ? "0.0" : atLongitudeBox.Text,
                        System.Globalization.CultureInfo.InvariantCulture);

                //--------- Service state, location between --------
                message.serviceState.between = new ServiceStateBetween();
                message.serviceState.between.from = new Location();
                message.serviceState.between.from.locationType =
                    (LogicalLocation) Enum.Parse(typeof(LogicalLocation), fromLocationType.SelectedValue);
                message.serviceState.between.from.name = fromLocationNameBox.Text;
                message.serviceState.between.to = new Location();
                message.serviceState.between.to.locationType =
                    (LogicalLocation) Enum.Parse(typeof(LogicalLocation), toLocationType.SelectedValue);
                message.serviceState.between.to.name = toLocationNameBox.Text;

                //--------- Service state, location between, position --------
                message.serviceState.between.from.position = new Position();
                //TODO(Olle): check null strings in a better more readable way
                message.serviceState.between.from.position.latitude =
                    double.Parse(string.IsNullOrEmpty(fromLatitudeBox.Text) ? "0.0" : fromLatitudeBox.Text,
                        System.Globalization.CultureInfo.InvariantCulture);
                message.serviceState.between.from.position.longitude =
                    double.Parse(string.IsNullOrEmpty(fromLongitudeBox.Text) ? "0.0" : fromLongitudeBox.Text,
                        System.Globalization.CultureInfo.InvariantCulture);
                message.serviceState.between.to.position = new Position();
                message.serviceState.between.to.position.latitude =
                    double.Parse(string.IsNullOrEmpty(toLatitudeBox.Text) ? "0.0" : toLatitudeBox.Text,
                        System.Globalization.CultureInfo.InvariantCulture);
                message.serviceState.between.to.position.longitude =
                    double.Parse(string.IsNullOrEmpty(toLongitudeBox.Text) ? "0.0" : toLongitudeBox.Text,
                        System.Globalization.CultureInfo.InvariantCulture);
            }

            else
            {
                message.locationState = new LocationState();
                message.locationState.referenceObject = LocationReferenceObject.VESSEL;
                string locationStateTime = setYearDropDown.SelectedValue + "-" + setMonthDropDown.SelectedValue + "-" +
                                          setDayDropDown.SelectedValue + "T" + setHourDropDown.SelectedValue + ":" + setMinuteDropDown.SelectedValue + ":00Z";
                message.locationState.time = locationStateTime;
                message.locationState.timeType = (TimeType) Enum.Parse(typeof(TimeType), timeTypeDropDown.SelectedValue);
                if(messageTypeHiddenField.Value == "DEPARTURE_VESSEL")
                {
                    message.locationState.departureLocation = new LocationStateDepartureLocation();
                    //------ Location State , departure location, from
                    message.locationState.departureLocation.from = new Location();
                    message.locationState.departureLocation.from.locationType = (LogicalLocation) Enum.Parse(typeof(LogicalLocation), fromLocationType.SelectedValue);
                    message.locationState.departureLocation.from.name = fromLocationNameBox.Text;
                    message.locationState.departureLocation.from.position = new Position();

                    message.locationState.departureLocation.from.position.latitude =
                        double.Parse(string.IsNullOrEmpty(fromLatitudeBox.Text) ? "0.0" : fromLatitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                    message.locationState.departureLocation.from.position.longitude =
                        double.Parse(string.IsNullOrEmpty(fromLongitudeBox.Text) ? "0.0" : fromLongitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                    //------ Location State , departure location, to
                    message.locationState.departureLocation.to = new Location();
                    message.locationState.departureLocation.to.locationType = (LogicalLocation) Enum.Parse(typeof(LogicalLocation), toLocationType.SelectedValue);
                    message.locationState.departureLocation.to.name = toLocationNameBox.Text;
                    message.locationState.departureLocation.to.position = new Position();

                    message.locationState.departureLocation.to.position.latitude =
                        double.Parse(string.IsNullOrEmpty(toLatitudeBox.Text) ? "0.0" : toLatitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                    message.locationState.departureLocation.to.position.longitude =
                        double.Parse(string.IsNullOrEmpty(toLongitudeBox.Text) ? "0.0" : toLongitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                }
                else if(messageTypeHiddenField.Value == "ARRIVAL_VESSEL")
                {
                    message.locationState.arrivalLocation = new LocationStateArrivalLocation();
                    //------ Location State , arrival location, from
                    message.locationState.arrivalLocation.from = new Location();
                    message.locationState.arrivalLocation.from.locationType = (LogicalLocation) Enum.Parse(typeof(LogicalLocation), fromLocationType.SelectedValue);
                    message.locationState.arrivalLocation.from.name = fromLocationNameBox.Text;

                    message.locationState.arrivalLocation.from.position = new Position();

                    message.locationState.arrivalLocation.from.position.latitude =
                        double.Parse(string.IsNullOrEmpty(fromLatitudeBox.Text) ? "0.0" : fromLatitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                    message.locationState.arrivalLocation.from.position.longitude =
                        double.Parse(string.IsNullOrEmpty(fromLongitudeBox.Text) ? "0.0" : fromLongitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                    //------ Location State , arrival location, to
                    message.locationState.arrivalLocation.to = new Location();
                    message.locationState.arrivalLocation.to.locationType = (LogicalLocation) Enum.Parse(typeof(LogicalLocation), toLocationType.SelectedValue);
                    message.locationState.arrivalLocation.to.name = toLocationNameBox.Text;

                    message.locationState.arrivalLocation.to.position = new Position();

                    message.locationState.arrivalLocation.to.position.latitude =
                        double.Parse(string.IsNullOrEmpty(toLatitudeBox.Text) ? "0.0" : toLatitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);

                    message.locationState.arrivalLocation.to.position.longitude =
                        double.Parse(string.IsNullOrEmpty(toLongitudeBox.Text) ? "0.0" : toLongitudeBox.Text,
                            System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return message;
        }
    }
}