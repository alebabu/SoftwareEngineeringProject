using System;
using System.Web;
using System.Web.UI;
using PortCDM_App_Code;

namespace PortCDM
{
	public partial class NewPortCDMMessage : System.Web.UI.Page
	{
	    private portCallMessage pcm;
		protected void Page_Load(object sender, EventArgs e)
		{
            pcm = new portCallMessage();
		    messageConfirmationLiteral.Text = "";
		}

		protected async void sendMessage(object sender, EventArgs e)
		{
		    string result;
		    pcm.vesselId = vesselId.Text;
		    pcm.messageId = messageId.Text;
		    pcm.locationState = new LocationState
		    {
		        referenceObject = LocationReferenceObject.VESSEL,
                timeType = TimeType.ESTIMATED,
                time = "2017-09-09T23:00:00.0000000",
                arrivalLocation = new LocationStateArrivalLocation
                {
                    to = new Location
                    {
                        locationType = LogicalLocation.BERTH,
                        position = new Position
                        {
                            latitude = 0.0,
                            longitude = 0.0
                        }
                    }
                }
		    };
		    result = await RestHandler.createPCM(pcm);
            messageConfirmationLiteral.Text = result;
		}
	}
}
