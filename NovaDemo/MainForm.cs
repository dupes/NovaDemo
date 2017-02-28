using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace NovaDemo
{
	public partial class MainForm : Form
	{
		private Listener.Listener m_listener = null;

		private Dictionary<String, HandlePayload> m_eventHandlers = null;

		private Dictionary<String, DataGridViewRow> m_eventRows = null;

		private delegate void HandlePayload(string payload);

		private string m_venLabelBase;

		enum DGEventCells
		{
			EventId,
			StartTime,
			Duration,
			Status
		}


		public MainForm()
		{
			InitializeComponent();

			m_venLabelBase = LabelVenStatus.Text;
			LabelVenStatus.Text = m_venLabelBase + " NO ACTIVE EVENTS";

			m_listener = new Listener.Listener();

			m_eventHandlers = new Dictionary<string, HandlePayload>();

			// map the names of the endpoints to objects that can handle the request
			m_eventHandlers.Add("newevent", new HandlePayload(HandlePayload_NewEvent));
			m_eventHandlers.Add("startevent", new HandlePayload(HandlePayload_StartEvent));
			m_eventHandlers.Add("starteventinterval", new HandlePayload(HandlePayload_StartEventInterval));
			m_eventHandlers.Add("modifyevent", new HandlePayload(HandlePayload_ModifyEvent));
			m_eventHandlers.Add("cancelevent", new HandlePayload(HandlePayload_CancelEvent));
			m_eventHandlers.Add("deleteevent", new HandlePayload(HandlePayload_DeleteEvent));
			m_eventHandlers.Add("endevent", new HandlePayload(HandlePayload_EndEvent));

			m_eventRows = new Dictionary<string, DataGridViewRow>();
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				m_listener.Start(new Listener.Listener.RequestHandler(HandleRequest));
			}
			catch (Exception exception)
			{
				Console.Out.WriteLine("Form1_Load exception:\n" + exception.Message);
			}
		}


		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				m_listener.Stop();
			}
			catch (Exception exception)
			{
				Console.Out.WriteLine("From1_FromClosed exception:\n" + exception.Message);
			}
		}


		/*
		 * Function called by the listener when a call to an endpoint has been made
		 */
		private void HandleRequest(Uri uri, string payload)
		{
			// get the endpoint name to access dictionary
			string key = Path.GetFileName(uri.AbsolutePath.TrimEnd('/', '\\'));

			if (m_eventHandlers.Keys.Contains(key))
			{
				// cause the specific handlers to be executed in the GUI thread
				this.BeginInvoke((MethodInvoker)delegate() { m_eventHandlers[key](payload); });
			}
			else
			{
				Console.WriteLine("endpoint '" + key + "' did not match key");
			}
		}


		private void HandlePayload_NewEvent(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			// assume an event can only start if Nova sends a start event message, so 
			// the status here will either be complete because the event start time 
			// plus duration is in the past, or the event will be pending
			string status = ((Util.FromEpoch(newEvent.DtStartTimet).AddSeconds(newEvent.DurationInSeconds) < DateTime.UtcNow) ? "complete" : "pending");

			DGEvent.Rows.Add(newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet), newEvent.DurationInSeconds, status);

			// and track the stored row in our dictionary (the row just added is the last row)
			m_eventRows[newEvent.EventId] = DGEvent.Rows[DGEvent.Rows.Count - 1];

			UCEventLog.LogEvent(newEvent.EventId, "new event");
		}


		private void HandlePayload_StartEvent(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			if (m_eventRows.ContainsKey(newEvent.EventId))
			{
				m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.Status].Value = "active";
			}

			LabelVenStatus.Text = m_venLabelBase + " EVENT ACTIVE";
			UCEventLog.LogEvent(newEvent.EventId, "start event");
		}


		private void HandlePayload_StartEventInterval(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			// the event is already active, just need to log this message
			UCEventLog.LogEvent(newEvent.EventId, "start event interval");
		}


		private void HandlePayload_ModifyEvent(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			if (m_eventRows.ContainsKey(newEvent.EventId))
			{
				m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.StartTime].Value = Util.FromEpoch(newEvent.DtStartTimet);
				m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.Duration].Value = newEvent.DurationInSeconds;
			}

			UCEventLog.LogEvent(newEvent.EventId, "event modified");
		}


		private void HandlePayload_DeleteEvent(string payload)
		{
			RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

			if (m_eventRows.ContainsKey(endEvent.EventId))
			{
				// retrieve row from out dictionary
				DataGridViewRow row = m_eventRows[endEvent.EventId];

				// remove row from the GUI
				DGEvent.Rows.Remove(row);

				// remove row from out dictionary
				m_eventRows.Remove(endEvent.EventId);
			}

			UCEventLog.LogEvent(endEvent.EventId, "event deleted");
		}


		private void HandlePayload_EndEvent(string payload)
		{
			RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

			if (m_eventRows.ContainsKey(endEvent.EventId))
			{
				m_eventRows[endEvent.EventId].Cells[(int)DGEventCells.Status].Value = "complete";
			}

			LabelVenStatus.Text = m_venLabelBase + " NO ACTIVE EVENTS";

			UCEventLog.LogEvent(endEvent.EventId, "end event");
		}


		private void HandlePayload_CancelEvent(string payload)
		{
			RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

			// TODO: update the status of the row in the DataGridView

			LabelVenStatus.Text = m_venLabelBase + " NO ACTIVE EVENTS";

			UCEventLog.LogEvent(endEvent.EventId, "event cancelled");
		}
	}
}
