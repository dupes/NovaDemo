using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NovaDemo.EndpointHandler
{
	class NewEvent : Endpoint.AbstractEvent
	{
		private DataGridView DGEvent { get; set; }

		public NewEvent(DataGridView DGEvent)
		{
			this.DGEvent = DGEvent;
		}

		public override void Handle(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			// update 
			DGEvent.BeginInvoke
			(
				(MethodInvoker)delegate () 
				{
					DGEvent.Rows.Add(newEvent.EventId, FromEpoch(newEvent.DtStartTimet), newEvent.DurationInSeconds, "pending");
				}
			);
		}
	}
}
