<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="PortCDM.SendMessage" %>

<asp:Content ID="MessageContent" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="smContent">
        <h1>Send Message</h1>
        <ol id="messageSteps">
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter listCounterComplete">
                        <svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg>
                    </icon>
                    <h2>Ship</h2>
                </div>
                <div class="stepContent">
                    <asp:DropDownList runat="server" ID="shipsDropDown" />
                    <asp:HiddenField runat="server" ID="shipArrivalHiddenField"/>
                    <asp:Button CssClass="smButton" runat="server" Text="Continue" OnClick="shipSelected"/>
                </div>
            </li>
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter">
                        <svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg>
                    </icon>
                    <h2>Message Type</h2>
                </div>
                <div class="stepContent">
                    <asp:DropDownList ID="messageTypeDropDown" runat="server">
                        <asp:ListItem Text="Anchoring" Value="ANCHORING"></asp:ListItem>
                        <asp:ListItem Text="Arrival Mooring" Value="ARRIVAL_MOORING_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Escort Towage" Value="ESCORT_TOWAGE"></asp:ListItem>
                        <asp:ListItem Text="Pilotage" Value="PILOTAGE"></asp:ListItem>
                        <asp:ListItem Text="Slop Operation" Value="SLOP_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Sludge Operation" Value="SLUDE_OPERATION"></asp:ListItem>
                        <asp:ListItem Text="Towage" Value="TOWAGE"></asp:ListItem>
                        <asp:ListItem Text="Vessel Berth Arrival" Value="ARRIVAL_VESSEL_BERTH"></asp:ListItem>
                        <asp:ListItem Text="Vessel Berth Departure" Value="DEPARTURE_VESSEL_BERTH"></asp:ListItem>
                        <asp:ListItem Text="Vessel Pilot Boarding Area Arrival" Value="ARRIVAL_VESSEL_PBA"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="messageTypeHiddenField"/>
                    <asp:Button CssClass="smButton" runat="server" Text="Continue" OnClick="messageTypeSelected"/>
                </div>
            </li>
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter">
                        <svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg>
                    </icon>
                    <h2>Info</h2>
                </div>
                <div class="stepContent">
                    <div class="formText"><asp:Literal runat="server" ID="commentText">Comment</asp:Literal></div>
                        <asp:TextBox CssClass="textInput" ID="commentBox" runat="server"></asp:TextBox>
                        <div class="time">
                            <div class="formText"><asp:Label runat="server">Time Type</asp:Label></div>
                            <asp:DropDownList runat="server" ID="timeTypeDropDown">
                                <asp:ListItem Text="Estimated" Value="ESTIMATED"></asp:ListItem>
                                <asp:ListItem Text="Actual" Value="ACTUAL"></asp:ListItem>
                                <asp:ListItem Text="Target" Value="TARGET"></asp:ListItem>
                                <asp:ListItem Text="Recommended" Value="RECOMMENDED"></asp:ListItem>
                                <asp:ListItem Text="Cancelled" Value="CANCELLED"></asp:ListItem>
                            </asp:DropDownList>
                            <div id="dateField">
                            <span class="dateSeparator">Day</span>
                            <asp:DropDownList runat="server" CssClass="dayDropDown dateDropDown" ID="setDayDropDown"/>
                            <span class="dateSeparator">Month</span>
                            <asp:DropDownList runat="server" CssClass="monthDropDown dateDropDown" ID="setMonthDropDown"/>
                            <span class="dateSeparator">Year</span>
                            <asp:DropDownList runat="server" CssClass="yearDropDown dateDropDown" ID="setYearDropDown"/>
                        </div>
                    </div>
                </div>
            </li>
        </ol>
    </div>
</asp:Content>