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

		private Dictionary<String, Endpoint.AbstractEvent> m_eventHandlers = null;


		public MainForm()
		{
			InitializeComponent();

			m_listener = new Listener.Listener();

			m_eventHandlers = new Dictionary<string, Endpoint.AbstractEvent>();

			// map the names of the endpoints to objects that can handle the request
			m_eventHandlers.Add("newevent", new EndpointHandler.NewEvent(DGEvent));
		}


		private void HandleRequest(Uri uri, string payload)
		{
			// get the endpoint name to access dictionary
			string key = Path.GetFileName(uri.AbsolutePath.TrimEnd('/', '\\'));

			if (m_eventHandlers.Keys.Contains(key))
			{
				m_eventHandlers[key].Handle(payload);
			}
			else
			{
				Console.WriteLine("endpoint '" + key + "' did not match key");
			}
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
