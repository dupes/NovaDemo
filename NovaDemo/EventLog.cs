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
		private DateTime m_lastRecordDateTime = default(DateTime);

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

			LVEventLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
		}

		/********************************************************************************/

		public void Clear()
		{
			LVEventLog.Clear();
		}
		/********************************************************************************/

		public void LogNewEvent(RequestData.NewEvent newEvent)
		{
			LogEvent(true, "new event", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		public void LogStartEvent(RequestData.NewEvent newEvent)
		{
			LogEvent(true, "start event", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		public void LogStartEventInterval(RequestData.NewEvent newEvent)
		{
			LogEvent(false, "start event interval", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		public void LogModifyEvent(RequestData.NewEvent newEvent)
		{
			LogEvent(true, "event modified", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		public void LogEndEvent(RequestData.EndEvent endEvent)
		{
			LogEvent(true, "end event", endEvent.EventId, "", "");
		}

		/********************************************************************************/

		public void LogDeleteEvent(RequestData.EndEvent endEvent)
		{
			LogEvent(true, "event deleted", endEvent.EventId, "", "");
		}


		/********************************************************************************/

		public void LogCancelEvent(RequestData.EndEvent endEvent)
		{
			LogEvent(true, "event cancelled", endEvent.EventId, "", "");
		}

		/********************************************************************************/

		private void LogEvent(bool calculateDifference, string text, string eventId, string startTime, string durationInSeconds)
		{
			string[] columnData = new string[LVEventLog.Columns.Count];

			// only track with m_recordDateTime when a difference is calculated
			DateTime recordDateTime = DateTime.Now;

			string difference = "-";
			if (calculateDifference || true)
			{
				if (m_lastRecordDateTime != default(DateTime))
				{
					difference = recordDateTime.Subtract(m_lastRecordDateTime).Seconds.ToString();
				}

				m_lastRecordDateTime = recordDateTime;
			}

			columnData[(int)EventListViewColumns.LogDate] = recordDateTime.ToString();
			columnData[(int)EventListViewColumns.LogDateDifference] = difference;
			columnData[(int)EventListViewColumns.Message] = text;
			columnData[(int)EventListViewColumns.EventId] = eventId;
			columnData[(int)EventListViewColumns.StartTime] = startTime;
			columnData[(int)EventListViewColumns.Duration] = durationInSeconds;

			//LVEventLog.Items.Add(new ListViewItem(columnData));
			LVEventLog.Items.Insert(0, new ListViewItem(columnData));
		}
	}
}
