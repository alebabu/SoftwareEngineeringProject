<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Timeline.aspx.cs" Inherits="PortCDM.Timeline"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">

   <div id="messageBox">
        <h1>Timeline</h1>
       <asp:Repeater id="eventListBox" runat="server">
			<ItemTemplate>
				<div id="events">
					<h3><asp:Literal runat="server" Text='<%# Eval("id") %>'/></h3>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
