using System;
using System.Data;
using PortCDM.Code;

namespace PortCDM
{
	public partial class Default : System.Web.UI.Page                                    
	{

		protected void Page_Load(Object sender, EventArgs e)
		{
			DataTable activeShipsWCommentsDt = new DataTable();
			activeShipsWCommentsDt = DataBaseHandler.getActiveShipWComments();
			shipRepeater.DataSource = activeShipsWCommentsDt;
			shipRepeater.DataBind();


			DataTable nextArrivalDt = new DataTable();
			nextArrivalDt = DataBaseHandler.getNextArrival();
			nextArrivalRepeater.DataSource = nextArrivalDt;
			nextArrivalRepeater.DataBind();
		}    
	}
}
