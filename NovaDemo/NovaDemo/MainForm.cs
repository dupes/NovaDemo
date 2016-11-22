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

		private delegate void HandlePayload(string payload);

		private string m_venLabelBase;


		public MainForm()
		{
			InitializeComponent();

			m_venLabelBase = LabelVenStatus.Text;

			m_listener = new Listener.Listener();

			m_eventHandlers = new Dictionary<string, HandlePayload>();

			// map the names of the endpoints to objects that can handle the request
			m_eventHandlers.Add("newevent", new HandlePayload(HandlePayload_NewEvent));
			m_eventHandlers.Add("startevent", new HandlePayload(HandlePayload_StartEvent));
			m_eventHandlers.Add("modifyevent", new HandlePayload(HandlePayload_ModifyEvent));
			m_eventHandlers.Add("cancelevent", new HandlePayload(HandlePayload_CancelEvent));
			m_eventHandlers.Add("endevent", new HandlePayload(HandlePayload_EndEvent));
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

			DGEvent.Rows.Add(newEvent.EventId, Util.FromEpoch(newEvent.DtStartTimet), newEvent.DurationInSeconds, "pending");
		}


		private void HandlePayload_StartEvent(string payload)
		{
			LabelVenStatus.Text = m_venLabelBase + " EVENT ACTIVE";
		}


		private void HandlePayload_ModifyEvent(string payload)
		{
			LabelVenStatus.Text = m_venLabelBase + " EVENT MODIFIED";
		}


		private void HandlePayload_EndEvent(string payload)
		{
			LabelVenStatus.Text = m_venLabelBase + " EVENT COMPLETE";
		}


		private void HandlePayload_CancelEvent(string payload)
		{
			LabelVenStatus.Text = m_venLabelBase + " EVENT CANCELLED";
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
	}
}
