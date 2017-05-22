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
        private string imoQuery;
        private MessageIdGenerator messageIdGenerator;
        private DateHandler dateHandler;

        protected async void Page_Load(object sender, EventArgs e)
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
                initPage();
            }
        }

        protected void shipSelected(object sender, EventArgs e)
        {
            selectShip(shipsDropDown.SelectedValue);
            initStepTwo();
        }

        protected void messageTypeSelected(object sender, EventArgs e)
        {
            messageTypeHiddenField.Value = messageTypeDropDown.SelectedValue;
            initStepThree();
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

        private void initPage()
        {
            imoQuery = Request.QueryString["imo"];
            setUpDropDowns();
            setYearDropDown.SelectedValue = "2017";

            if(!string.IsNullOrEmpty(imoQuery))
            {
                string portCallId = shipList.Find(x => x.imo.Equals(imoQuery)).portCallId;
                shipImoHiddenField.Value = imoQuery;

                selectShip(portCallId);
                initStepTwo();
            }

            else
            {
                initStepOne();

                shipsDropDown.DataTextField = "name";
                shipsDropDown.DataValueField = "portCallId";
                shipsDropDown.DataSource = shipList;
                shipsDropDown.DataBind();
            }
        }

        private void initStepOne()
        {
            stepOne.Visible = true;
            stepOneCheck.Visible = false;
            stepTwo.Visible = false;
            stepTwoCheck.Visible = false;
            stepThree.Visible = false;
            stepThreeCheck.Visible = false;
            messageSentButton.Visible = false;
        }

        private void initStepTwo()
        {
            stepOne.Visible = false;
            stepOneCheck.Visible = true;
            listCounterOne.Visible = false;
            stepTwo.Visible = true;
            stepTwoCheck.Visible = false;
            stepThree.Visible = false;
            stepThreeCheck.Visible = false;
            messageSentButton.Visible = false;
        }

        private void initStepThree()
        {
            stepOne.Visible = false;
            stepOneCheck.Visible = true;
            stepTwo.Visible = false;
            stepTwoCheck.Visible = true;
            listCounterTwo.Visible = false;
            stepThree.Visible = true;
            stepThreeCheck.Visible = false;
            messageSentButton.Visible = false;
            bindPortLocations();
        }

        private void selectShip(string portCallId)
        {
            portCallIdHiddenField.Value = portCallId;
            var resultVessel = shipList.Find(ship => ship.portCallId == portCallIdHiddenField.Value);
            shipImoHiddenField.Value = resultVessel.imo;
        }

        private void bindPortLocations()
        {
            bindPortLocation(toLocationType, toLocationName);
            bindPortLocation(fromLocationType, fromLocationName);
            bindPortLocation(atLocationType, atLocationName);
        }

        private async void bindPortLocation(DropDownList locationType, DropDownList locationsddl)
        {
            List<PortLocation> locations = await RestHandler.getLocations();
            locations = locations.Where(x => x.URN.Contains(locationType.SelectedValue)).ToList();
            locationsddl.DataSource = locations;
            locationsddl.DataTextField = "name";
            locationsddl.DataValueField = "URN";
            locationsddl.DataBind();
        }

        protected void changeLocationDropDown(object sender, EventArgs e)
        {
            bindPortLocations();
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
                messageId = "urn:mrn:stm:portcdm:message:" + messageIdGenerator.generateMessageId(),
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
                if (atRadioButton.Checked)
                {
                    message.serviceState.at = new Location();
                    message.serviceState.at.locationMRN = atLocationName.SelectedValue;
                }

                //--------- Service state, location between --------
                else if (betweenRadioButton.Checked)
                {
                    message.serviceState.between = new ServiceStateBetween();
                    message.serviceState.between.from = new Location();
                    message.serviceState.between.from.locationMRN = fromLocationName.SelectedValue;
                    message.serviceState.between.to = new Location();
                    message.serviceState.between.to.locationMRN = toLocationName.SelectedValue;
                }
            }

            else
            {
                message.locationState = new LocationState();
                message.locationState.referenceObject = LocationReferenceObject.VESSEL;
                string locationStateTime = setYearDropDown.SelectedValue + "-" + setMonthDropDown.SelectedValue + "-" +
                                          setDayDropDown.SelectedValue + "T" + setHourDropDown.SelectedValue + ":" + setMinuteDropDown.SelectedValue + ":00Z";
                message.locationState.time = dateHandler.stringToDate(locationStateTime);
                message.locationState.timeType = (TimeType) Enum.Parse(typeof(TimeType), timeTypeDropDown.SelectedValue);
                if(messageTypeHiddenField.Value == "DEPARTURE_VESSEL")
                {
                    message.locationState.departureLocation = new LocationStateDepartureLocation();
                    //------ Location State , departure location, from
                    if (fromCheckBox.Checked)
                    {
                        message.locationState.departureLocation.from = new Location();
                        message.locationState.departureLocation.from.locationMRN = fromLocationName.SelectedValue;
                    }

                    //------ Location State , departure location, to
                    if (toCheckBox.Checked)
                    {
                        message.locationState.departureLocation.to = new Location();
                        message.locationState.departureLocation.to.locationMRN = fromLocationName.SelectedValue;
                    }

                }
                else if(messageTypeHiddenField.Value == "ARRIVAL_VESSEL")
                {
                    message.locationState.arrivalLocation = new LocationStateArrivalLocation();
                    //------ Location State , arrival location, from
                    if (fromCheckBox.Checked)
                    {
                        message.locationState.arrivalLocation.from = new Location();
                        message.locationState.arrivalLocation.from.locationMRN = fromLocationName.SelectedValue;
                    }

                    //------ Location State , arrival location, to
                    if (toCheckBox.Checked)
                    {
                        message.locationState.arrivalLocation.to = new Location();
                        message.locationState.arrivalLocation.to.locationMRN = toLocationName.SelectedValue;
                    }
                }
            }
            return message;
        }
    }
}