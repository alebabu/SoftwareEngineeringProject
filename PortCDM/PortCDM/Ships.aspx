<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Ships.aspx.cs" Inherits="PortCDM.Ships"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
		<h1>Ships</h1>
		<div class="accordion">

			<asp:Repeater id="shipRepeater" runat="server">
				<ItemTemplate>

					<div>
			            <input id="ac-<%# ((RepeaterItem)Container).ItemIndex + 1%>" name="accordion-1" type="checkbox" />
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
							<p><asp:Literal runat="server" Text='<%# Eval("comment") %>'/></p>
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