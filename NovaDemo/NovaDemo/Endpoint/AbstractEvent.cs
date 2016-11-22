using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovaDemo.Endpoint
{
	public abstract class AbstractEvent
	{
		protected DataGridView DGEvent { get; set; }

		public AbstractEvent(DataGridView DGEvent)
		{
			this.DGEvent = DGEvent;
		}

		public abstract void Handle(String payload);

		public DateTime FromEpoch(long secondsFromEpoch)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(secondsFromEpoch));
		}

	}
}
