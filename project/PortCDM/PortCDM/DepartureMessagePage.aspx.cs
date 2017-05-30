using System;
using System.Web;
using System.Web.UI;
using PortCDM.Code;

namespace PortCDM
{
    public partial class DepartureMessagePage : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            string shipIMO = Request.QueryString["imo"];

			string text = await DepartureMessage.createDepartureMessage(shipIMO);

            message.Text = text;


        }
    }
}
