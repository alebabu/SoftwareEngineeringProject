using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using PortCDM.Code;
using PortCDM.Code.Structs;

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


			protected object newTime(object o)
			{
				String s = (String)o;
				Console.WriteLine(s);
				DateHandler dh = new DateHandler();
				DateTime time = dh.stringToDate(s);
				o = time.ToString("yyyy d MMM HH:mm");
				return o;
			}
		
        
	}
}
