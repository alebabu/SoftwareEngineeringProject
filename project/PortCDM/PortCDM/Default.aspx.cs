using System;
using System.Web;
using System.Web.UI;
using PortCDM_App_Code;
using PortCDM_RestStructs;

namespace PortCDM
{
	public partial class Default : System.Web.UI.Page
	{
        string id;protected void Page_Load(object sender, EventArgs e)
        {
			messageConfirmationLiteral.Text = "";
            
		}

		protected void sendMessage(object sender, EventArgs e)
        {
            messageConfirmationLiteral.Text = "Your message has been sent";
		}
	}
}
