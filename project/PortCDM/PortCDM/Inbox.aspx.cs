using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using PortCDM_RestStructs;
using PortCDM_App_Code;
namespace PortCDM
{
	public partial class Inbox : System.Web.UI.Page
	{
		protected async void Page_Load(object sender, EventArgs e)
		{
			List<PortCall> portCallList = await RestHandler.getPortCalls();
			messageRepeater.DataSource = portCallList;
			messageRepeater.DataBind();
		}
	}
}
