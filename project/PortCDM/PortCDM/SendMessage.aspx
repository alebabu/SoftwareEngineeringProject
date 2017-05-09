<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="PortCDM.SendMessage" %>
<asp:Content runat="server" ID="MessageHead" ContentPlaceHolderID="cpHeadContent">
    <!-- TODO ENABLE EVENT VALIDATION -->
    <script type="text/javascript" src="Scripts/SendMessage.js"></script>
</asp:Content>

<asp:Content ID="MessageContent" ContentPlaceHolderID="cpMainContent" runat="server">
    <asp:ScriptManager ID="SMScriptManager" runat="server"></asp:ScriptManager>
    <div id="messageBox">
		<h1>Send Message</h1>
        <asp:UpdatePanel runat="server" ID="SMUpdatePanel">
            <ContentTemplate>
                <div id="serviceField">
                    <div class="formText"><asp:Literal runat="server">Message Type:</asp:Literal></div>
                    <asp:DropDownList ID="messageTypeDropDown" runat="server">
                        <asp:ListItem Text="Anchoring" Value="ANCHORING"></asp:ListItem>
                        <asp:ListItem Text="Arrival Mooring" Value="ARRIVAL_MOORING_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Escort Towage" Value="ESCORT_TOWAGE"></asp:ListItem>
                        <asp:ListItem Text="Pilotage" Value="PILOTAGE"></asp:ListItem>
                        <asp:ListItem Text="Slop Operation" Value="SLOP_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Sludge Operation" Value="SLUDE_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Towage" Value="TOWAGE"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <br />
                <div id="vesselImoField">
                    <div class="formText"><asp:Literal runat="server" ID="vesselImoText" >Vessel IMO:</asp:Literal></div>
                    <asp:TextBox ID="vesselImoBox" runat="server"></asp:TextBox>
                </div>
                <br />
                <br />
                <div id="vesselDateField">
                    <div class="formText"><asp:Literal runat="server" ID="vesselDateText" >Vessel Arrival Date:</asp:Literal></div>
                    <asp:DropDownList runat="server" CssClass="dayDropDown" ID="vesselArrivalDay"/>
                    <span class="dateSeparator">/</span>
                    <asp:DropDownList runat="server" CssClass="monthDropDown" ID="vesselArrivalMonth"/>
                    <span class="dateSeparator">/</span>
                    <asp:DropDownList runat="server" CssClass="yearDropDown" ID="vesselArrivalYear"/>
                </div>
                <br />
                <br />
                <br />
                <div id="commentField">
                    <div class="formText"><asp:Literal runat="server" ID="commentText">Comment:</asp:Literal></div>
                    <asp:TextBox ID="commentBox" runat="server"></asp:TextBox>
                </div>
                <br />
                <br />
                <div id="stageField">
                    <div class="formText"><asp:Literal runat="server" ID="stageText">Stage:</asp:Literal></div>
                    <asp:DropDownList runat="server" ID="serviceTimeSequenceDropDown">
                        <asp:ListItem Text="Commenced" Value="COMMENCED"></asp:ListItem>
                        <asp:ListItem Text="Completed" Value="COMPLETED"></asp:ListItem>
                        <asp:ListItem Text="Confirmed" Value="CONFIRMED"></asp:ListItem>
                        <asp:ListItem Text="Denied" Value="DENIED"></asp:ListItem>
                        <asp:ListItem Text="Requested" Value="REQUESTED"></asp:ListItem>
                        <asp:ListItem Text="Request Received" Value="REQUEST_RECEIVED"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <br />
                <div id="dateField">
                    <div class="formText"><asp:Literal runat="server" ID="setDateText">Time:</asp:Literal></div>
                    <asp:DropDownList runat="server" CssClass="dayDropDown" ID="setDayDropDown"/>
                    <span class="dateSeparator">/</span>
                    <asp:DropDownList runat="server" CssClass="monthDropDown" ID="setMonthDropDown"/>
                    <span class="dateSeparator">/</span>
                    <asp:DropDownList runat="server" CssClass="yearDropDown" ID="setYearDropDown"/>
                </div>
                <br />
                <div id="chooseLocation">
                    <asp:Literal runat="server">LocationType:</asp:Literal>
                    <br />
                    <asp:Literal runat="server">At:</asp:Literal><asp:RadioButton GroupName="locationButtons" ID="atRadioButton" runat="server"/>
                    <asp:Literal runat="server">Between:</asp:Literal><asp:RadioButton GroupName="locationButtons" ID="betweenRadioButton" runat="server"/>
                </div>
                <br />
                <div id="atLocation">
                    <div class="formText"><asp:Literal runat="server">At Location Type:</asp:Literal></div>
                    <asp:DropDownList ID="atLocationType" runat="server">
                        <asp:ListItem Text="Anchoring Area" Value="ANCHORING_AREA"></asp:ListItem>
                        <asp:ListItem Text="Berth" Value="BERTH"></asp:ListItem>
                        <asp:ListItem Text="Etug Zone" Value="ETUG_ZONE"></asp:ListItem>
                        <asp:ListItem Text="Other Location" Value="LOC"></asp:ListItem>
                        <asp:ListItem Text="Pilot Boarding Area" Value="PILOT_BOARDING_AREA"></asp:ListItem>
                        <asp:ListItem Text="Rendezvous Area" Value="RENDEZV_AREA"></asp:ListItem>
                        <asp:ListItem Text="Traffic Area" Value="TRAFFIC_AREA"></asp:ListItem>
                        <asp:ListItem Text="Tug Zone" Value="TUG_ZONE"></asp:ListItem>
                        <asp:ListItem Text="Vessel" Value="Vessel"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="formText"><asp:Literal runat="server">At Location Name:</asp:Literal></div>
                    <asp:TextBox ID="atLocationNameBox" runat="server"></asp:TextBox>
                    <br />
                    <div class="formText"><asp:Literal runat="server">At Latitude:</asp:Literal></div>
                    <asp:TextBox ID="atLatitudeBox" runat="server"></asp:TextBox>
                    <div class="formText"><asp:Literal runat="server">At Longitude:</asp:Literal></div>
                    <asp:TextBox ID="atLongitudeBox" runat="server"></asp:TextBox>
                </div>
                <div id="fromLocation">
                    <div class="formText"><asp:Literal runat="server">From Location Type:</asp:Literal></div>
                    <asp:DropDownList ID="fromLocationType" runat="server">
                        <asp:ListItem Text="Anchoring Area" Value="ANCHORING_AREA"></asp:ListItem>
                        <asp:ListItem Text="Berth" Value="BERTH"></asp:ListItem>
                        <asp:ListItem Text="Etug Zone" Value="ETUG_ZONE"></asp:ListItem>
                        <asp:ListItem Text="Other Location" Value="LOC"></asp:ListItem>
                        <asp:ListItem Text="Pilot Boarding Area" Value="PILOT_BOARDING_AREA"></asp:ListItem>
                        <asp:ListItem Text="Rendezvous Area" Value="RENDEZV_AREA"></asp:ListItem>
                        <asp:ListItem Text="Traffic Area" Value="TRAFFIC_AREA"></asp:ListItem>
                        <asp:ListItem Text="Tug Zone" Value="TUG_ZONE"></asp:ListItem>
                        <asp:ListItem Text="Vessel" Value="Vessel"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <div class="formText"><asp:Literal runat="server">From Location Name:</asp:Literal></div>
                    <asp:TextBox ID="fromLocationNameBox" runat="server"></asp:TextBox>
                    <br />
                    <div class="formText"><asp:Literal runat="server">From Latitude:</asp:Literal></div>
                    <asp:TextBox ID="fromLatitudeBox" runat="server"></asp:TextBox>
                    <div class="formText"><asp:Literal runat="server">From Longitude:</asp:Literal></div>
                    <asp:TextBox ID="fromLongitudeBox" runat="server"></asp:TextBox>
                </div>
                <br />
                <div id="toLocation">
                    <div class="formText"><asp:Literal runat="server">To Location Type:</asp:Literal></div>
                    <asp:DropDownList ID="toLocationType" runat="server">
                        <asp:ListItem Text="Anchoring Area" Value="ANCHORING_AREA"></asp:ListItem>
                        <asp:ListItem Text="Berth" Value="BERTH"></asp:ListItem>
                        <asp:ListItem Text="Etug Zone" Value="ETUG_ZONE"></asp:ListItem>
                        <asp:ListItem Text="Other Location" Value="LOC"></asp:ListItem>
                        <asp:ListItem Text="Pilot Boarding Area" Value="PILOT_BOARDING_AREA"></asp:ListItem>
                        <asp:ListItem Text="Rendezvous Area" Value="RENDEZV_AREA"></asp:ListItem>
                        <asp:ListItem Text="Traffic Area" Value="TRAFFIC_AREA"></asp:ListItem>
                        <asp:ListItem Text="Tug Zone" Value="TUG_ZONE"></asp:ListItem>
                        <asp:ListItem Text="Vessel" Value="Vessel"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="formText"><asp:Literal runat="server">To Location Name:</asp:Literal></div>
                    <asp:TextBox ID="toLocationNameBox" runat="server"></asp:TextBox>
                    <br />
                    <div class="formText"><asp:Literal runat="server">To Latitude:</asp:Literal></div>
                    <asp:TextBox ID="toLatitudeBox" runat="server"></asp:TextBox>
                    <div class="formText"><asp:Literal runat="server">To Longitude:</asp:Literal></div>
                    <asp:TextBox ID="toLongitudeBox" runat="server"></asp:TextBox>
                </div>
                <br />
                <asp:Literal runat="server" ID="testText"></asp:Literal>
                <br />
                <asp:Button CssClass="sendButton" runat="server" id="sendMessageButton" OnClick="prepareMessage" Text="Send"/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    

    <!--<asp:Literal>
        <!-- EXAMPLE CALL
            <?xml version="1.0" encoding="UTF-8"?>
<ns2:portCallMessage xmlns:ns2="urn:x-mrn:stm:schema:port-call-message:0.0.16">
   <ns2:portCallId>urn:x-mrn:stm:portcdm:port_call:SEGOT:ca1a795e-ee95-4c96-96d1-53896617c9ac</ns2:portCallId>
   <ns2:vesselId>urn:x-mrn:stm:vessel:IMO:9398917</ns2:vesselId>
   <ns2:messageId>urn:x-mrn:stm:portcdm:message:{uuid()}</ns2:messageId>
   <ns2:reportedAt>2017-03-21T11:59:44.4935008Z</ns2:reportedAt>
  <ns2:serviceState>
    <ns2:serviceObject>ANCHORING</ns2:serviceObject>
    <ns2:time>2017-03-21T11:59:44.4935008Z</ns2:time>
    <ns2:timeSequence>COMMENCED</ns2:timeSequence>
    <ns2:timeType>ESTIMATED</ns2:timeType>
    <ns2:at>
      <ns2:locationType>BERTH</ns2:locationType>
      <ns2:name>UNSPECIFIED_BERTH</ns2:name>
    </ns2:at>
  </ns2:serviceState>
</ns2:portCallMessage>-->
    <!--</asp:Literal>-->
</asp:Content>