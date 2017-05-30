<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Ships.aspx.cs" Inherits="PortCDM.Ships" EnableEventValidation="false"%>
<%@ Import Namespace="PortCDM.Code" %>
<asp:Content runat="server" ContentPlaceHolderID="cpHeadContent">
	<!-- enableEventValidation should not be false....-->

	<title>Ships</title>
	<script type="text/javascript" src="Scripts/sifter.min.js"></script>
	<script type="text/javascript" src="Scripts/microplugin.min.js"></script>
    <script type="text/javascript" src="Scripts/selectize.min.js"></script>
	<script type="text/javascript" src="Scripts/Selectship.js"></script>
    <link rel="stylesheet" href="Style/selectize.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
		<h1>Ships</h1>
		<asp:ScriptManager runat="server"/>
			<div class="add-ship">
				<div>
		            <input id="as-1" name="accordion-1" type="checkbox" />
		            <label for="as-1">
						<img class="add-icon" src="../Images/add_blue.svg" />		
					</label>
					<div class="article ac-small">
						<h1>Add new ship</h1>
						<p>
							IMO of the ship:
							<asp:DropDownList id="addShipDropDown" runat="server" placeholder="Select ship..."></asp:DropDownList>
						</p>
						<asp:Button CssClass="add-button" runat="server" id="addShipButton" Text="Add ship" onClick="addNewShip" AutoPostBack="true"/>
					</div>
				</div>
			</div>
		<div class="accordion">
			
			<asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<asp:Repeater id="shipRepeater" runat="server">
						<ItemTemplate>
							<div>
					            <input class="hidden" id="ac-<%# ((RepeaterItem)Container).ItemIndex + 1%>" name="accordion-1" type="checkbox" />
					            <label for="ac-<%# ((RepeaterItem)Container).ItemIndex + 1%>">
									<div class="left-content"> 
										<h2><asp:Literal runat="server" Text='<%# Eval("name") %>'/></h2>
										<p>Vessel ID: <asp:Literal runat="server" id="imo" Text='<%# Eval("imoNumber") %>'/></p>
									</div>
									<div class="right-content">
										<!--<img class="icon" src="../Images/edit_blue.svg" />
										<br/>-->
										<asp:Image CssClass="ship-img" runat="server" ImageUrl='<%# Eval("imgURL") %>' />
									</div>
								</label>
								<div class="article ac-small">
									
									<h3>Comments</h3>
									<asp:TextBox CssClass="ship-comment" runat="server" placeholder="Add comment..." Text='<%# Eval("comment") %>' onTextChanged="commentChanged" AutoPostBack="true" CommandArgument='<%#Eval("imoNumber")%>' CommandName="ImoNumber"></asp:TextBox>
									<h3>Arrival date</h3>
									<p><asp:Literal runat="server" Text='<%# Utils.newTime(Eval("arrivalDate")) %>'/></p>
									<h3>PortCall ID</h3>
									<p><asp:Literal runat="server" Text='<%# Eval("portCallId") %>'/></p>
								</div>
							</div>
							<div class="ship-links">
								<ul>
									<li><a href='<%# string.Concat("../SendMessage.aspx?imo=", Eval("imoNumber"))%>'><img src="../Images/message_blue.svg" />New PortCDM message</a></li>
									<li><a href='<%# string.Concat("../Timeline.aspx?portCallId=", Eval("portCallID"))%>'><img src="../Images/timeline_blue.svg" />Go to timeline</a></li>
									<li><a href='<%# string.Concat("../DepartureMessagePage.aspx?imo=", Eval("imoNumber"))%>'><img src="../Images/dep_message_blue.svg" />Create departure message</a></li>
									<li><asp:Button CssClass="deactivate-button" runat="server" Text="Deactivate ship" OnClick="deactivateShip"/></li>
								</ul>
							</div>
						</ItemTemplate>
					</asp:Repeater>
				</ContentTemplate>
			</asp:UpdatePanel>


			
		</div>
	</div>
</asp:Content>