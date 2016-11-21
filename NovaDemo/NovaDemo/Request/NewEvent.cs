using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaDemo.Request
{
	class NewEvent
	{
		public int DtStartTimet { get; set; }
		public int DurationInSeconds { get; set; }
		public string EventId { get; set; }
		public string NotifierEventType { get; set; }
		public double payload { get; set; }
		public string SignalName { get; set; }
		public string SignalType { get; set; }
		public string Version { get; set; }
	}
}
