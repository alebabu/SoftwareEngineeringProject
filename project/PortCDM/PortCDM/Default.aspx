<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PortCDM.Default"%>
<%@ Import Namespace="PortCDM.Code" %>
<asp:Content runat="server" ContentPlaceHolderID="cpHeadContent">
	<title>Dashboard</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="messageBox">
        <h1>Dashboard</h1>

        <div class="dashBox dashBoxBright">
			UPCOMING ARRIVALS
        	<asp:Repeater id="nextArrivalRepeater" runat="server">
				<ItemTemplate>
					<p><asp:Literal runat="server" Text='<%# Eval("name") %>'/></p>
	            	<h2><asp:Literal runat="server" Text='<%# Utils.newTime(Eval("arrivalDate")) %>'/></h2>
				</ItemTemplate>
			</asp:Repeater>
        </div>
		
		<div class="dashBox dashBoxDark">
            REMINDERS
			<asp:Repeater id="shipRepeater" runat="server">
				<ItemTemplate>
					<p><asp:Literal runat="server" Text='<%# Eval("name") %>'/></p>
	            	<h2><asp:Literal runat="server" Text='<%# Eval("comment") %>'/></h2>
				</ItemTemplate>
			</asp:Repeater>
        </div>    
	</div>

</asp:Content>