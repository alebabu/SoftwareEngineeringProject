<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Ships.aspx.cs" Inherits="PortCDM.Ships" EnableEventValidation="false"%> 
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
		<asp:UpdatePanel ID="updatePanelAdd" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<div class="add-ship">
					<div>
			            <input id="as-1" name="accordion-1" type="checkbox" />
			            <label for="as-1">
							<img class="add-icon" src="../Images/add_blue.svg" />		
						</label>
						<div class="article ac-small">
							<h1>Add new ship</h1>
							<p>
								Name of the ship:
								<asp:DropDownList CssClass="imo-box" id="addShipDropDown" runat="server"></asp:DropDownList>
							</p>
							<asp:Button CssClass="add-button" runat="server" id="addShipButton" Text="Add ship" onClick="addNewShip" AutoPostBack="true"/>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>


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
								</div>
							</div>
							<div class="ship-links">
								<ul>
									<li><a href="../SendMessage.aspx"><img src="../Images/message_blue.svg" />New PortCDM message</a></li>
									<li><a href="../Timeline.aspx"><img src="../Images/timeline_blue.svg" />Go to timeline</a></li>
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