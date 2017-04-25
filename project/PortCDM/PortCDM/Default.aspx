<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PortCDM.Default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
			<h1>Message to PortCDM</h1>
			<table align="center">
				<tr>
					<td align="right">PortCall Id:</td>
					<td align="left">1234</td>
				</tr>
				<tr>
					<td align="right">Local PortCall Id:</td>
					<td align="left">5678</td>
				</tr>
				<tr>
					<td align="right">Vessel id:</td>
					<td align="left">1347</td>
				</tr>
				<tr>
					<td align="right">Reference Object:</td>
					<td align="left">Vessel</td>
				</tr>
				<tr>
					<td align="right">Timetype:</td>
					<td align="left">Estimated</td>
				</tr>
				<tr>
					<td align="right">Time:</td>
					<td align="left">2017-09-09 23:00</td>
				</tr>
				<tr>
					<td align="right">Location type:</td>
					<td align="left">Traffic Area</td>
				</tr>
				<tr>
					<td align="right">Latitude:</td>
					<td align="left">0.0</td>
				</tr>
				<tr>
					<td align="right">Longitude:</td>
					<td align="left">0.0</td>
				</tr>
				<tr>
					<td align="right">Position name:</td>
					<td align="left">Port of Gothenburg Traffic Area</td>
				</tr>
			</table>
		<asp:Button CssClass="sendButton" runat="server" id="sendMessageButton" Text="Send" onClick="sendMessage"/>
	</div>
</asp:Content>