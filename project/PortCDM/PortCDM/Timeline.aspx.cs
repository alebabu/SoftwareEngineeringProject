using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PortCDM_RestStructs;
using PortCDM_App_Code;


namespace PortCDM
{
    public partial class Timeline : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<portCallMessage> list = await RestHandler.getEvents();
            eventListBox.DataSource = list;
            eventListBox.DataBind();


        }
    }
}