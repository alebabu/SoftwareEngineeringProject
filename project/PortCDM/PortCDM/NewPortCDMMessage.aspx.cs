﻿using System;
using System.Web;
using System.Web.UI;
namespace PortCDM
{
	public partial class NewPortCDMMessage : System.Web.UI.Page
	{
		string id; protected void Page_Load(object sender, EventArgs e)
		{
		messageConfirmationLiteral.Text = "";

		}

		protected void sendMessage(object sender, EventArgs e)
		{
		messageConfirmationLiteral.Text = "Your message has been sent";
		}
	}
}
