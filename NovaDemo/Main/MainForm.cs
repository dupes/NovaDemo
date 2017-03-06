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

namespace NovaDemo.Main
{
	public partial class MainForm : Form
	{
		private Listener.Listener m_listener = null;

		private Dictionary<String, HandlePayload> m_eventHandlers = null;

		private Dictionary<String, DataGridViewRow> m_eventRows = null;

		private delegate void HandlePayload(string payload);

		private Uri m_novaUri;

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

			m_listener = new Listener.Listener();

			m_eventHandlers = new Dictionary<string, HandlePayload>();

			m_novaUri = new Uri("http://localhost:8000");

			// map the names of the endpoints to objects that can handle the request
			m_eventHandlers.Add("newevent", new HandlePayload(HandlePayload_NewEvent));
			m_eventHandlers.Add("startevent", new HandlePayload(HandlePayload_StartEvent));
			m_eventHandlers.Add("starteventinterval", new HandlePayload(HandlePayload_StartEventInterval));
			m_eventHandlers.Add("modifyevent", new HandlePayload(HandlePayload_ModifyEvent));
			m_eventHandlers.Add("cancelevent", new HandlePayload(HandlePayload_CancelEvent));
			m_eventHandlers.Add("deleteevent", new HandlePayload(HandlePayload_DeleteEvent));
			m_eventHandlers.Add("endevent", new HandlePayload(HandlePayload_EndEvent));
			m_eventHandlers.Add("status", new HandlePayload(HandlePayload_Status));

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

			UCEventLog.LogNewEvent(newEvent);
		}


		private void HandlePayload_StartEvent(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			if (m_eventRows.ContainsKey(newEvent.EventId))
			{
				m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.Status].Value = "active";
			}

			UCEventLog.LogStartEvent(newEvent);
		}


		private void HandlePayload_StartEventInterval(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			// the event is already active, just need to log this message
			UCEventLog.LogStartEventInterval(newEvent);
		}


		private void HandlePayload_ModifyEvent(string payload)
		{
			RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

			if (m_eventRows.ContainsKey(newEvent.EventId))
			{
				m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.StartTime].Value = Util.FromEpoch(newEvent.DtStartTimet);
				m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.Duration].Value = newEvent.DurationInSeconds;
			}

			UCEventLog.LogModifyEvent(newEvent);
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

			UCEventLog.LogDeleteEvent(endEvent);
		}


		private void HandlePayload_EndEvent(string payload)
		{
			RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

			if (m_eventRows.ContainsKey(endEvent.EventId))
			{
				m_eventRows[endEvent.EventId].Cells[(int)DGEventCells.Status].Value = "complete";
			}

			UCEventLog.LogEndEvent(endEvent);
		}


		private void HandlePayload_CancelEvent(string payload)
		{
			RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

			// TODO: update the status of the row in the DataGridView

			UCEventLog.LogCancelEvent(endEvent);
		}


		private void HandlePayload_Status(string payload)
		{
			// just displaying we received the message, not processing the payload
			LabelEventPollDynamic.Text = DateTime.Now.ToString();
		}

		private void BClearEvents_Click(object sender, EventArgs e)
		{
			string message = 
			"{ " +
			"    \"namespace\": \"ven.clearEvents\"," +
			"    \"parameters\": { }" +
			"}";

			string response;
			if (!Http.Request.Post(m_novaUri, message, out response))
			{
				System.Console.WriteLine("Error sending message " + message + "\n" + response);
			}
			else
			{
				System.Console.WriteLine("Sending message " + message + " successful:\n" + response);

				UCEventLog.Clear();
			}
		}

		private void DGEvent_MouseClick(object sender, MouseEventArgs eventArgs)
		{
			//if (eventArgs.Button == MouseButtons.Right)
			//{
			//	int selectedRowIndex = DGEvent.HitTest(eventArgs.X, eventArgs.Y).RowIndex;

			//	if (!(selectedRowIndex < 0))
			//	{
			//		string eventId = DGEvent.Rows[selectedRowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

			//		ContextMenu contextMenu = new ContextMenu();

			//		contextMenu.MenuItems.Add(new MenuItem("Opt In", (object s, EventArgs e) => { SendCreatedEvent(eventId, "optIn"); } ));
			//		contextMenu.MenuItems.Add(new MenuItem("Opt Out", (object s, EventArgs e) => { SendCreatedEvent(eventId, "optOut"); }));
			//		contextMenu.MenuItems.Add("-");
			//		contextMenu.MenuItems.Add(new MenuItem("Create Opt ..."));

			//		contextMenu.Show(DGEvent, new Point(eventArgs.X, eventArgs.Y));
			//	}
			//}
		}


		private void SendCreateOpt(string eventId, string optType, string optReason)
		{
			string message =
			"{" +
			"    \"namespace\": \"ven.eventOpt\"," +
			"    \"parameters\": {" +
			"        \"optId\" : \"optId\"," +
			"        \"eventId\" : \"" + eventId + "\"," +
			"        \"optType\" : \"" + optType + "\"," +
			"        \"optReason\" : \"" + optReason + "\"" +
			"    }" +
			"}";

			string response;
			if (!Http.Request.Post(m_novaUri, message, out response))
			{
				System.Console.WriteLine("Error sending message " + message + "\n" + response);
			}
			else
			{
				System.Console.WriteLine("Sending message " + message + " successful:\n" + response);
			}
		}


		private void SendCreatedEvent(string eventId, string optType)
		{
			string message =
			"{" +
			"    \"namespace\": \"ven.createdEvent\"," +
			"    \"parameters\": {" +
			"        \"eventId\" : \"" + eventId + "\"," +
			"        \"optType\" : \"" + optType + "\"" +
			"     }" +
			"}";

			string response;
			if (!Http.Request.Post(m_novaUri, message, out response))
			{
				System.Console.WriteLine("Error sending message " + message + "\n" + response);
			}
			else
			{
				System.Console.WriteLine("Sending message " + message + " successful:\n" + response);

				// TODO: what should be displayed for the status for "opt in" ?
				m_eventRows[eventId].Cells[(int)DGEventCells.Status].Value = optType;
			}
		}

		private void optInToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowIndex = (DGEvent.SelectedRows.Count > 0 ? DGEvent.SelectedRows[0].Index : -1);

			if (!(rowIndex < 0))
			{
				string eventId = DGEvent.Rows[rowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

				SendCreatedEvent(eventId, "optIn");
			}
		}

		private void optOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowIndex = (DGEvent.SelectedRows.Count > 0 ? DGEvent.SelectedRows[0].Index : -1);

			if (!(rowIndex < 0))
			{
				string eventId = DGEvent.Rows[rowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

				SendCreatedEvent(eventId, "optOut");
			}
		}

		private void createOptToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			int rowIndex = (DGEvent.SelectedRows.Count > 0 ? DGEvent.SelectedRows[0].Index : -1);

			if (!(rowIndex < 0))
			{
				string eventId = DGEvent.Rows[rowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

				Main.FormCreateOpt createOptForm = new Main.FormCreateOpt();

				DialogResult result = createOptForm.ShowDialog();

				if (result != DialogResult.OK)
					return;

				SendCreateOpt(eventId, createOptForm.OptType, createOptForm.OptReason);
			}
		}
	}
}
