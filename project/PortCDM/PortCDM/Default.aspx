<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PortCDM.Default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">

    <div id="messageBox">
        <h1>Dashboard</h1>

        <div class="dashBox">
            Next Arrival
            <h2>Stena Line at 13:00</h2>
            <img src="../Images/testImage_stenaline.png" />
        </div>
		<div class="dashBoxDark">
			
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