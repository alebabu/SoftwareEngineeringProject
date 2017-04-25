<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="PortCDM.Inbox"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
		<h1>Messages from PortCDM regarding PortCall 1234</h1>
		<asp:Repeater id="messageRepeater" runat="server">
			<ItemTemplate>
				<div class="inboxItem">
					<h3>Message id: </h3>
					<asp:Literal runat="server" id="messageLiteral" Text='<%# Eval("content") %>'></asp:Literal><br/>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>