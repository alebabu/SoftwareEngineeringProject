<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="PortCDM.Inbox"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
		<h1>Messages from PortCDM</h1>
		<asp:Repeater id="messageRepeater" runat="server">
			<ItemTemplate>
				<div class="inboxItem">
					<h3>Message id: <asp:Literal runat="server" Text='<%# Eval("id") %>'/></h3>
					<p>Vessel name: <asp:Literal runat="server" Text='<%# Eval("vessel.name") %>'/></p>
					<p>Arrival date: <asp:Literal runat="server" Text='<%# Eval("arrivalDate") %>'/></p>
					<p><asp:Image CssClass="shipPic" runat="server" ImageUrl='<%# Eval("vessel.photoURL") %>' /></p>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>