using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortCDM_App_Code;
using PortCDM_RestStructs;

namespace PortCDM
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable ships = DataBaseHandler.getActiveShips();
            List<Vessel> shipList = new List<Vessel>();
            foreach(DataRow ship in ships.Rows)
            {
                Vessel v = new Vessel();
                v.imo = ship["imoNumber"].ToString();
                v.name = ship["name"].ToString();
                v.photoURL = ship["imgURL"].ToString();
                shipList.Add(v);
            }

            shipsDropDown.DataTextField = "name";
            shipsDropDown.DataValueField = "imo";
            shipsDropDown.DataSource = shipList;
            shipsDropDown.DataBind();
        }
    }
}