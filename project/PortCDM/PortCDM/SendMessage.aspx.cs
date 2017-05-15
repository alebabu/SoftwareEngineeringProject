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

            setUpDropDowns();
            setYearDropDown.SelectedValue = "2017";

            shipsDropDown.DataTextField = "name";
            shipsDropDown.DataValueField = "imo";
            shipsDropDown.DataSource = shipList;
            shipsDropDown.DataBind();
        }

        protected void shipSelected(object sender, EventArgs e)
        {
            shipArrivalHiddenField.Value = shipsDropDown.SelectedValue;
        }

        protected void messageTypeSelected(object sender, EventArgs e)
        {
            messageTypeHiddenField.Value = messageTypeDropDown.SelectedValue;
        }

        private void setUpDropDowns()
        {
            int[] days = new int[31];
            int[] months = new int[12];
            int[] years = new int[256];

            for (int i = 0; i < 31; i++)
                days[i] = i + 1;
            for (int i = 0; i < 12; i++)
                months[i] = i + 1;
            for (int i = 0; i < 256; i++)
                years[i] = i + 1980;

            bindDateDropDown(setDayDropDown, days);
            bindDateDropDown(setMonthDropDown, months);
            bindDateDropDown(setYearDropDown, years);
        }

        private void bindDateDropDown(DropDownList ddl, int[] data)
        {
            ddl.DataSource = data;
            ddl.DataBind();
        }
    }
}