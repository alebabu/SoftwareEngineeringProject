<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="PortCDM.SendMessage" %>

<asp:Content ID="MessageContent" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="smContent">
        <ol id="messageSteps">
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter listCounterComplete">
                        <svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg>
                    </icon>
                    <h2>Ship</h2>
                </div>
                <div class="stepContent">
                    <asp:DropDownList runat="server" ID="shipsDropDown">
                    </asp:DropDownList>
                    <asp:HiddenField runat="server" ID="shipArrival"/>
                    <asp:Button CssClass="smButton" runat="server" Text="Continue"/>
                </div>
            </li>
            <li class="messageStep">
                <div class="stepHeader">
                    <icon class="listCounter">
                        <svg width="24" height="24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"></path></svg>
                    </icon>
                    <h2>Message Type</h2>
                </div>
            </li>
        </ol>
    </div>
</asp:Content>