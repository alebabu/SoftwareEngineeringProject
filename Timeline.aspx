<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Timeline.aspx.cs" Inherits="PortCDM.Timeline"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">

   <div id="messageBox">
        <h1>Timeline</h1>
		<table id="events">
            <asp:Repeater id="eventListBox" runat="server">
			    <ItemTemplate>
                    <tr>
                        <td id="timeline">
                            <h1><asp:Literal runat="server" Text='<%# Eval("locationState.time") %>'/></h1>
                        </td>
                        <td id="shipEvents">
                            <h3>
                                <asp:Literal runat="server" Text='<%# Eval("serviceState.serviceObject") %>'></asp:Literal>
                                <asp:Literal runat="server" />
                                <asp:Literal runat="server" Text='<%# Eval("serviceState.at.name") %>'></asp:Literal>
                                
                            </h3>
                        </td>
                    </tr>
                 </ItemTemplate>
             </asp:Repeater>
					

                </table>
    </div>
</asp:Content>