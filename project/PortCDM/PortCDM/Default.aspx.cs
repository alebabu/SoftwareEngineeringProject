using System;
using System.Web;
using System.Web.UI;
using PortCDM_App_Code;
using PortCDM_RestStructs;

namespace PortCDM
{
	public partial class Default : System.Web.UI.Page
	{
        string id;
		protected void Page_Load(object sender, EventArgs e)
        {
			messageConfirmationLiteral.Text = "";
            
		}

		protected void sendMessage(object sender, EventArgs e)
        {
            PortCall pc = RestHandler.getPortCallById(
                "urn:x-mrn:stm:portcdm:port_call:SEGOT:ca1a795e-ee95-4c96-96d1-53896617c9ac");
            portCallId.Text = pc.id;
            localportCallId.Text = pc.portUnLocode;
            vesselId.Text = pc.startTime;
            id = RestHandler.getPortCalls()[0].id;
            messageConfirmationLiteral.Text = id;
		}
	}
}
