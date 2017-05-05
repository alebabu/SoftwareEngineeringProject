<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="NewPortCDMMessage.aspx.cs" Inherits="PortCDM.NewPortCDMMessage"%>
<asp:Content ID="MessageContent" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
			<h1>Message to PortCDM</h1>
			<table align="center">
				<tr>
					<td align="right">Vessel id:</td>
					<td align="left"><asp:Literal runat="server" id="vesselId" Text="urn:x-mrn:stm:vessel:IMO:9398917"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Service State Id:</td>
					<td align="left"><asp:Literal runat="server" id="messageId" Text="message-0x1FFE3A"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Location State Id:</td>
					<td align="left"><asp:Literal runat="server" id="locationStateId" Text="5678"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Timetype:</td>
					<td align="left"><asp:Literal runat="server" id="timeType" Text="Estimated"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Time:</td>
					<td align="left"><asp:Literal runat="server" id="time" Text="2017-09-09 23:00"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Location type:</td>
					<td align="left"><asp:Literal runat="server" id="locationType" Text="Traffic Area"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Latitude:</td>
					<td align="left"><asp:Literal runat="server" id="latitude" Text="0.0"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Longitude:</td>
					<td align="left"><asp:Literal runat="server" id="longitude" Text="0.0"></asp:Literal></td>
				</tr>
				<tr>
					<td align="right">Position name:</td>
					<td align="left"><asp:Literal runat="server" id="positionType" Text="Port of Gothenburg Traffic Area"></asp:Literal></td>
				</tr>
			</table>
		<asp:Button CssClass="sendButton" runat="server" id="sendMessageButton" Text="Send" onClick="sendMessage"/>
		<p><asp:Literal runat="server" id="messageConfirmationLiteral" Text=""></asp:Literal></p>
	</div>
</asp:Content>