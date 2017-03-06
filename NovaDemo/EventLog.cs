using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NovaDemo
{
	public partial class EventLog : UserControl
	{
		// storing this outside the ListView gives more accurate calculation of time differernce between records
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

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Clear()
		{
			LVEventLog.Items.Clear();
		}

		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogNewEvent(RequestData.NewEvent newEvent)
		{
			LogEvent("new event", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogStartEvent(RequestData.NewEvent newEvent)
		{
			LogEvent("start event", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogStartEventInterval(RequestData.NewEvent newEvent)
		{
			LogEvent("start event interval", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogModifyEvent(RequestData.NewEvent newEvent)
		{
			LogEvent("event modified", newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet).ToString(), newEvent.DurationInSeconds.ToString());
		}

		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogEndEvent(RequestData.EndEvent endEvent)
		{
			LogEvent("end event", endEvent.EventId, "", "");
		}

		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogDeleteEvent(RequestData.EndEvent endEvent)
		{
			LogEvent("event deleted", endEvent.EventId, "", "");
		}


		/********************************************************************************/

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void LogCancelEvent(RequestData.EndEvent endEvent)
		{
			LogEvent("event cancelled", endEvent.EventId, "", "");
		}

		/********************************************************************************/

		private void LogEvent(string text, string eventId, string startTime, string durationInSeconds)
		{
			string[] columnData = new string[LVEventLog.Columns.Count];

			// only track with m_recordDateTime when a difference is calculated
			DateTime recordDateTime = DateTime.Now;

			string difference = "-";
			if (m_lastRecordDateTime != default(DateTime))
			{
				difference = Convert.ToInt32(recordDateTime.Subtract(m_lastRecordDateTime).TotalSeconds).ToString();
			}

			m_lastRecordDateTime = recordDateTime;

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
