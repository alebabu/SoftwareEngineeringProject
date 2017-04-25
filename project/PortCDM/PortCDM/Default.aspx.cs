using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortCDM
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void sendMessage(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			button.Text = "Clicked";
		}
	}
}