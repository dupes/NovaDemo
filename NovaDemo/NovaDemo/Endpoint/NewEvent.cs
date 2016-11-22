﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NovaDemo.Endpoint
{
	class NewEvent : Endpoint.AbstractEvent
	{
		public NewEvent(DataGridView DGEvent) : base(DGEvent)
		{
		}

		public override void Handle(string payload)
		{
			Request.NewEvent newEvent = JsonConvert.DeserializeObject<Request.NewEvent>(payload);

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
