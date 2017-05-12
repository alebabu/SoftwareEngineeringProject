<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Ships.aspx.cs" Inherits="PortCDM.Ships"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
		<h1>Ships</h1>


		<div class="add-ship">
			<div>
	            <input id="as-1" name="accordion-1" type="checkbox" />
	            <label for="as-1">
					<img class="add-icon" src="../Images/add_blue.svg" />		
				</label>
				<div class="article ac-small">
					<h1>Add new ship</h1>
					<p>
						IMO-number:
						<asp:TextBox CssClass="imo-box" id="addImoBox" runat="server"></asp:TextBox>
					</p>
					<asp:Button CssClass="add-button" runat="server" id="addShipButton" Text="Get Ship Info" onClick="addNewShip"/>
					
				</div>
			</div>
		</div>


		<div class="accordion">
			<asp:Repeater id="shipRepeater" runat="server">
				<ItemTemplate>

					<div>
			            <input class="hidden" id="ac-<%# ((RepeaterItem)Container).ItemIndex + 1%>" name="accordion-1" type="checkbox" />
			            <label for="ac-<%# ((RepeaterItem)Container).ItemIndex + 1%>">
							<div class="left-content"> 
								<h2><asp:Literal runat="server" Text='<%# Eval("name") %>'/></h2>
								<p>Vessel ID: <asp:Literal runat="server" Text='<%# Eval("imoNumber") %>'/></p>
							</div>
							<div class="right-content">
								<img class="icon" src="../Images/edit_blue.svg" />
								<br/>
								<asp:Image CssClass="ship-img" runat="server" ImageUrl='<%# Eval("imgURL") %>' />
							</div>
						</label>
						<div class="article ac-small">
							<h3>Comments</h3>
							<asp:TextBox CssClass="ship-comment" runat="server" Text='<%# Eval("comment") %>' onTextChanged="commentChanged" AutoPostBack="true"></asp:TextBox>

						</div>
					</div>
					<div class="ship-links">
						<ul>
							<li><a href="../NewPortCDMMessage.aspx"><img src="../Images/message_blue.svg" />New PortCDM message</a></li>
							<li><a href="../Timeline.aspx"><img src="../Images/timeline_blue.svg" />Go to timeline</a></li>
							<li><a href=""><img src="../Images/active_blue.svg"/>Active</a></li>
						</ul>
					</div>
					
				</ItemTemplate>
			</asp:Repeater>


			
		</div>
	</div>
</asp:Content>