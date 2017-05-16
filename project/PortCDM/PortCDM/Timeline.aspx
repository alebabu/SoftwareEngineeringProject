<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Timeline.aspx.cs" Inherits="PortCDM.Timeline"%>
    
<asp:Content runat="server" ID="MessageHead" ContentPlaceHolderID="cpHeadContent">
    <script type="text/javascript" src="Scripts/TimeLine.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">


   <div id="messageBox">
        <h1>Timeline</h1>
		<div id="events">
			<asp:DropDownList runat="server" id="vesselDDList" CssClass=""></asp:DropDownList>
            <asp:Repeater id="eventListBox" runat="server">
			    <ItemTemplate>
                    <ul class="cbp_tmtimeline">
	                <li>
		                <div class="cbp_tmtime"> 
                            <span><asp:Literal runat="server" Text='<%# Eval("locationState.time") %>'/></span>
		                </div>
		                <div class="cbp_tmicon cbp_tmicon-phone"></div>
		                <div class="cbp_tmlabel">
			                <h2><asp:Literal runat="server" Text='<%# Eval("serviceState.serviceObject") %>'></asp:Literal></h2>
			                <p><asp:Literal runat="server" Text='<%# Eval("serviceState.at.name") %>'></asp:Literal></p>
		                </div>
	                </li>
					</ul>	
                 </ItemTemplate>
             </asp:Repeater>		
        </div>
    </div>

</asp:Content>