
<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Timeline.aspx.cs" Inherits="PortCDM.Timeline"%>

<asp:Content runat="server" ID="MessageHead" ContentPlaceHolderID="cpHeadContent">
    <script type="text/javascript" src="Scripts/TimeLine.js"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">


   <div id="messageBox">
        <h1>Timeline</h1>
		<div id="events">
			<asp:DropDownList runat="server" id="vesselDDList" CssClass="dropDownListStyle" OnSelectedIndexChanged="LoadEvents" AutoPostBack="True"></asp:DropDownList>
            <asp:Repeater id="eventListBox" runat="server">
			    <ItemTemplate>
                    <ul class="cbp_tmtimeline">
	                <li>
		                <time class="cbp_tmtime"> 
                            <span>
                                <asp:Literal runat="server" Text='<%# NiceTimeFormat(Eval("locationState.time")) %>'/>
                                <asp:Literal runat="server" Text='<%# NiceTimeFormat(Eval("serviceState.time")) %>'/>                            
                                <br />
                                <asp:Literal runat="server" Text='<%# Eval("locationState.timeType") %>'></asp:Literal>
                                <asp:Literal runat="server" Text='<%# Eval("serviceState.timeType") %>'></asp:Literal>                            
                            </span>
		                </time>
		                <div class="cbp_tmicon cbp_tmicon-phone"></div>
		                <div class="cbp_tmlabel">
			                <h2>
                                <asp:Literal runat="server" Text='<%# ShortenMRN(Eval("locationState.arrivalLocation.to.locationMRN")) %>'></asp:Literal>
                                <asp:Literal runat="server" Text='<%# ShortenMRN(Eval("locationState.arrivalLocation.from.locationMRN")) %>'></asp:Literal>
                                <asp:Literal runat="server" Text='<%# Eval("serviceState.serviceObject") %>'></asp:Literal>
                                <asp:Literal runat="server" Text='<%# Eval("serviceState.timeSequence") %>'></asp:Literal>
			                </h2>
			                <p>
                                <asp:Literal runat="server" Text='<%# Eval("locationState.referenceObject") %>'></asp:Literal>                               
                                <asp:Literal runat="server" Text='<%# Eval("serviceState.performingActor") %>'></asp:Literal>                                                             
                                
                                
                                <br />
                                Reported by:
                                <asp:Literal runat="server" Text='<%# ShortenMRN(Eval("reportedBy")) %>'></asp:Literal>
                                at
                                <asp:Literal runat="server" Text='<%# newTime(Eval("reportedAt")) %>'></asp:Literal>
			                </p>
		                </div>
	                </li>
					</ul>	
                 </ItemTemplate>
             </asp:Repeater>		
        </div>
    </div>

</asp:Content>