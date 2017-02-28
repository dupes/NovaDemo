using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovaDemo
{
	public partial class EventLog : UserControl
	{
		// the enum order must match the column indexing of the ViewList
		private enum EventListViewColumns
		{
			LogDate,
			LogDateDifference,
			Message,
			EventId,
			StartTime,
			Duration
		}

		/********************************************************************************/

		public EventLog()
		{
			InitializeComponent();
		}

		/********************************************************************************/

		public void Clear()
		{
			LVEventLog.Clear();
		}
		/********************************************************************************/

		public void LogNewEvent(RequestData.NewEvent newEvent)
		{
			LogEvent(newEvent.EventId, "new event");
		}

		/********************************************************************************/

		public void LogStartEvent(RequestData.NewEvent newEvent)
		{
			LogEvent(newEvent.EventId, "start event");
		}

		/********************************************************************************/

		public void LogStartEventInterval(RequestData.NewEvent newEvent)
		{
			LogEvent(newEvent.EventId, "start event interval");
		}

		/********************************************************************************/

		public void LogModifyEvent(RequestData.NewEvent newEvent)
		{
			LogEvent(newEvent.EventId, "event modified");
		}

		/********************************************************************************/

		public void LogEndEvent(RequestData.EndEvent endEvent)
		{
			LogEvent(endEvent.EventId, "end event");
		}

		/********************************************************************************/

		public void LogDeleteEvent(RequestData.EndEvent endEvent)
		{
			LogEvent(endEvent.EventId, "event deleted");
		}


		/********************************************************************************/

		public void LogCancelEvent(RequestData.EndEvent endEvent)
		{
			LogEvent(endEvent.EventId, "event cancelled");
		}

		/********************************************************************************/

		private void LogEvent(string eventId, string text)
		{
			string[] columnData = new string[LVEventLog.Columns.Count];

			columnData[(int)EventListViewColumns.LogDate] = DateTime.Now.ToString();
			columnData[(int)EventListViewColumns.LogDateDifference] = "";
			columnData[(int)EventListViewColumns.Message] = text;
			columnData[(int)EventListViewColumns.EventId] = eventId;
			columnData[(int)EventListViewColumns.StartTime] = "";
			columnData[(int)EventListViewColumns.Duration] = "";

			LVEventLog.Items.Add(new ListViewItem(columnData));
		}
	}
}
