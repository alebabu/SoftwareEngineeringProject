<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" Async="true" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="PortCDM.SendMessage" %>

<asp:Content runat="server" ContentPlaceHolderID="cpHeadContent">
    <title>Send Message</title>
    <script type="text/javascript" src="Scripts/SendMessage.js"></script>
    <script type="text/javascript" src="Scripts/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" href="Style/jquery.fancybox-1.3.4.css" />
</asp:Content>

<asp:Content ID="MessageContent" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="smContent">
        <h1>Send Message</h1>
        <ol id="messageSteps">
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter listCounterComplete">
                        <div class="listCounterDiv" id="listCounterOne" runat="server">1</div>
                        <div id="stepOneCheck" runat="server"><svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg></div>
                    </icon>
                    <h2>Ship</h2>
                </div>
                <div class="stepContent" id="stepOne" runat="server">
                    <asp:DropDownList runat="server" ID="shipsDropDown" />
                    <asp:HiddenField runat="server" ID="portCallIdHiddenField" />
                    <asp:HiddenField runat="server" ID="shipImoHiddenField" />
                    <asp:Button CssClass="smButton shipButton" runat="server" Text="Continue" OnClick="shipSelected" />
                </div>
            </li>
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter">
                        <div class="listCounterDiv" id="listCounterTwo" runat="server">2</div>
                        <div id="stepTwoCheck" runat="server"><svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg></div>
                    </icon>
                    <h2>Message Type</h2>
                </div>
                <div class="stepContent" id="stepTwo" runat="server">
                    <asp:DropDownList ID="messageTypeDropDown" runat="server">
                        <asp:ListItem Text="Anchoring" Value="ANCHORING"></asp:ListItem>
                        <asp:ListItem Text="Arrival Mooring" Value="ARRIVAL_MOORING_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Escort Towage" Value="ESCORT_TOWAGE"></asp:ListItem>
                        <asp:ListItem Text="Pilotage" Value="PILOTAGE"></asp:ListItem>
                        <asp:ListItem Text="Ready-To-Sail Operations" Value="DEPARTURE_BERTH"></asp:ListItem>
                        <asp:ListItem Text="Slop Operation" Value="SLOP_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Sludge Operation" Value="SLUDGE_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Towage" Value="TOWAGE"></asp:ListItem>
                        <asp:ListItem Text="Vessel Arrival" Value="ARRIVAL_VESSEL"></asp:ListItem>
                        <asp:ListItem Text="Vessel Departure" Value="DEPARTURE_VESSEL"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="messageTypeHiddenField" />
                    <asp:Button CssClass="smButton messageButton" runat="server" Text="Continue" OnClick="messageTypeSelected" />
                </div>
            </li>
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter">
                        <div class="listCounterDiv" id="listCounterThree" runat="server">3</div>
                         <div id="stepThreeCheck" runat="server"><svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg></div>
                    </icon>
                    <h2>Info</h2>
                </div>
                <div class="stepContent" id="stepThree" runat="server">
                    <div class="formText">
                        <asp:Literal runat="server" ID="commentText">Comment</asp:Literal>
                    </div>
                    <asp:TextBox CssClass="textInput" ID="commentBox" runat="server"></asp:TextBox>
                    <div id="stageField" runat="server">
                        <div class="formText">
                            <asp:Literal runat="server" ID="serviceTimeSequenceText">Stage:</asp:Literal>
                        </div>
                        <asp:DropDownList runat="server" ID="serviceTimeSequenceDropDown">
                            <asp:ListItem Text="Commenced" Value="COMMENCED"></asp:ListItem>
                            <asp:ListItem Text="Completed" Value="COMPLETED"></asp:ListItem>
                            <asp:ListItem Text="Confirmed" Value="CONFIRMED"></asp:ListItem>
                            <asp:ListItem Text="Denied" Value="DENIED"></asp:ListItem>
                            <asp:ListItem Text="Requested" Value="REQUESTED"></asp:ListItem>
                            <asp:ListItem Text="Request Received" Value="REQUEST_RECEIVED"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="time">
                        <div class="formText">
                            <asp:Label runat="server">Time Type</asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="timeTypeDropDown">
                            <asp:ListItem Text="Estimated" Value="ESTIMATED"></asp:ListItem>
                            <asp:ListItem Text="Actual" Value="ACTUAL"></asp:ListItem>
                            <asp:ListItem Text="Target" Value="TARGET"></asp:ListItem>
                            <asp:ListItem Text="Recommended" Value="RECOMMENDED"></asp:ListItem>
                            <asp:ListItem Text="Cancelled" Value="CANCELLED"></asp:ListItem>
                        </asp:DropDownList>
                        <div id="dateField">

                            <span class="dateSeparator">Day
                                <asp:DropDownList runat="server" CssClass="dayDropDown dateDropDown" ID="setDayDropDown" /></span>
                            <span class="dateSeparator">Month
                                <asp:DropDownList runat="server" CssClass="monthDropDown dateDropDown" ID="setMonthDropDown" /></span>
                            <span class="dateSeparator">Year
                                <asp:DropDownList runat="server" CssClass="yearDropDown dateDropDown" ID="setYearDropDown" /></span>
                            <span class="dateSeparator">Hour
                                <asp:DropDownList runat="server" CssClass="hourDropDown dateDropDown" ID="setHourDropDown" /></span>
                            <span class="dateSeparator">Minute
                                <asp:DropDownList runat="server" CssClass="minuteDropDown dateDropDown" ID="setMinuteDropDown" /></span>

                        </div>
                        <div id="checkBoxes">
                            <div class="formText">
                                <asp:Literal runat="server">LocationType:</asp:Literal>
                            </div>
                            <br />
                            <div id="atOrBothBox" class="formText checkBoxes" runat="server">
                                <asp:Literal runat="server">At</asp:Literal><asp:RadioButton GroupName="locationButtons" ID="atRadioButton" runat="server" />
                                <asp:Literal runat="server">Between</asp:Literal><asp:RadioButton GroupName="locationButtons" ID="betweenRadioButton" runat="server" />
                            </div>
                            <div id="fromOrToBoxes" class="formText checkBoxes" runat="server">
                                <div id="fromCheckBoxCss">
                                    <asp:Literal runat="server">From</asp:Literal>
                                    <asp:CheckBox runat="server" ID="fromCheckBox" />
                                </div>
                                <div id="toCheckBoxCss">
                                    <asp:Literal runat="server">To</asp:Literal>
                                    <asp:CheckBox runat="server" ID="toCheckBox" />
                                </div>
                            </div>
                        </div>
                        <asp:ScriptManager runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="fromLocationForm" class="locationBox">
                                    <div class="formText">
                                        <asp:Literal runat="server">From Location Type:</asp:Literal>
                                    </div>
                                    <asp:DropDownList ID="fromLocationType" AutoPostBack="True" OnSelectedIndexChanged="fromChangeLocationDropDown" runat="server">
                                        <asp:ListItem Text="Anchoring Area" Value="ANCHORING_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Berth" Value="BERTH"></asp:ListItem>
                                        <asp:ListItem Text="Etug Zone" Value="ETUG_ZONE"></asp:ListItem>
                                        <asp:ListItem Text="Pilot Boarding Area" Value="PILOT_BOARDING_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Traffic Area" Value="TRAFFIC_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Tug Zone" Value="TUG_ZONE"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="formText">
                                        <asp:Literal runat="server">From Location Name:</asp:Literal>
                                    </div>
                                    <asp:DropDownList runat="server" ID="fromLocationName" />
                                </div>
                                <div id="toLocationForm" class="locationBox">
                                    <div class="formText">
                                        <asp:Literal runat="server">To Location Type:</asp:Literal>
                                    </div>
                                    <asp:DropDownList ID="toLocationType" AutoPostBack="True" OnSelectedIndexChanged="toChangeLocationDropDown" runat="server">
                                        <asp:ListItem Text="Anchoring Area" Value="ANCHORING_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Berth" Value="BERTH"></asp:ListItem>
                                        <asp:ListItem Text="Etug Zone" Value="ETUG_ZONE"></asp:ListItem>
                                        <asp:ListItem Text="Pilot Boarding Area" Value="PILOT_BOARDING_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Traffic Area" Value="TRAFFIC_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Tug Zone" Value="TUG_ZONE"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="formText">
                                        <asp:Literal runat="server">To Location Name:</asp:Literal>
                                    </div>
                                    <asp:DropDownList runat="server" ID="toLocationName" />
                                </div>
                                <div id="atLocationForm" class="locationBox">
                                    <div class="formText">
                                        <asp:Literal runat="server">At Location Type:</asp:Literal>
                                    </div>
                                    <asp:DropDownList ID="atLocationType" AutoPostBack="True" OnSelectedIndexChanged="atChangeLocationDropDown" runat="server">
                                        <asp:ListItem Text="Anchoring Area" Value="ANCHORING_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Berth" Value="BERTH"></asp:ListItem>
                                        <asp:ListItem Text="Etug Zone" Value="ETUG_ZONE"></asp:ListItem>
                                        <asp:ListItem Text="Pilot Boarding Area" Value="PILOT_BOARDING_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Traffic Area" Value="TRAFFIC_AREA"></asp:ListItem>
                                        <asp:ListItem Text="Tug Zone" Value="TUG_ZONE"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="formText">
                                        <asp:Literal runat="server">At Location Name:</asp:Literal>
                                    </div>
                                    <asp:DropDownList runat="server" ID="atLocationName" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:Button CssClass="smButton infoButton" href="#data" runat="server" ID="sendMessageButton" Text="Continue" OnClick="sendMessage" />
                        <asp:Button CssClass="fancyBoxButton" href="#data" runat="server" Text="Continue" />

                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="display: none">
                                    <div id="data">
                                        <img src="Images/ship_wheel_loading.gif" />
                                        <div id="loadingBox">
                                            <asp:Label runat="server" Text="Sending Message..." ID="loadingText"></asp:Label>
                                            <asp:Button CssClass="smButton" ID="messageSentButton" Text="Ok" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="sendMessageButton" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </li>
        </ol>
    </div>
</asp:Content>
