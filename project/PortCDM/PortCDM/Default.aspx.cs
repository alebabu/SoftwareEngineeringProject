using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using PortCDM_App_Code;
using PortCDM_RestStructs;

namespace PortCDM
{
	public partial class Default : System.Web.UI.Page                                    
	{

		protected void Page_Load(Object sender, EventArgs e)
		{
			DataTable activeShipsDt = new DataTable();
			activeShipsDt = DataBaseHandler.getActiveShipWComments();
			shipRepeater.DataSource = activeShipsDt;
			shipRepeater.DataBind();

		}
		
        
	}
}
