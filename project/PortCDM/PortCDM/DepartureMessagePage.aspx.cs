using System;
using System.Web;
using System.Web.UI;
using PortCDM_App_Code;

namespace PortCDM
{
    public partial class DepartureMessagePage : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            string shipIMO = Request.QueryString["imo"];

            message.Text = await DepartureMessage.createDepartureMessage(shipIMO);


        }
    }
}
