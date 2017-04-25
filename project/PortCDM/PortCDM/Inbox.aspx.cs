using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
namespace PortCDM
{
	public partial class Inbox : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			List<Message> list = new List<Message>();
			list.Add(new Message("1", "hej"));
			list.Add(new Message("2", "da"));
			list.Add(new Message("3", "bla"));
			messageRepeater.DataSource = list;
			messageRepeater.DataBind();
		}

		public class Message
		{
			private String _id;
			public String id;
			private String _content;
			public String content{
				get
   				{
      				return _content??"Content";
  				 }
  				 set
  				 {
      				_content = value;
   				}

			}

			public Message(String id, String content) {
				this.id = id;
				this.content = content;
			}
			
		}
	}


}
