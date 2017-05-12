<%@ Page Language="C#" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PortCDM.Default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">
    <div id="messageBox">
        <h1>Dashboard</h1>
        <div class="dashBox">
            Next Arrival
            <h2>Stena Line at 13:00</h2>
            <img src="../Images/testImage_stenaline.png" />
        </div><div class="dashBoxDark">
            Next Todo
            <h2>Order food at 13:00</h2>
        </div>    
	</div>
</asp:Content>