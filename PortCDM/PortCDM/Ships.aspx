<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Ships.aspx.cs" Inherits="PortCDM.Ships"%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
	<div id="messageBox">
		<h1>Ships</h1>
		<div class="accordion">
			<div>
	            <input id="ac-1" name="accordion-1" type="checkbox" />
	            <label for="ac-1">
					<div class="left-content"> 
						<h2>MS Titanic</h2>
						<p>Vessel ID: 1234</p>
					</div>
					<div class="right-content">
						<img class="icon" src="../Images/edit_blue.svg" />
						<br/>
						<img class="ship-img" src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fd/RMS_Titanic_3.jpg/1920px-RMS_Titanic_3.jpg"/>
					</div>
				</label>
				<div class="article ac-small">
					<h3>Comments</h3>
					<p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper.</p>
				</div>
			</div>
			<div class="ship-links">
				<ul>
					<li><a href="../NewPortCDMMessage.aspx"><img src="../Images/message_blue.svg" />New PortCDM message</a></li>
					<li><a href="../Timeline.aspx"><img src="../Images/timeline_blue.svg" />Go to timeline</a></li>
					<li><a href=""><img src="../Images/active_blue.svg"/>Active</a></li>
				</ul>
			</div>

			
		</div>
	</div>
</asp:Content>