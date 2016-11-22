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
		private HttpListener m_listener = new HttpListener();
		private Thread m_listenerThread = null;
		private bool m_isRequestHandlerExited = false;
		private Dictionary<String, Endpoint.AbstractEvent> m_eventHandlers = null;

		public MainForm()
		{
			InitializeComponent();

			m_eventHandlers = new Dictionary<string, Endpoint.AbstractEvent>();

			// map the names of the endpoints to objects that can handle the request
			m_eventHandlers.Add("newevent", new Endpoint.NewEvent(DGEvent));

			// add endpoints to listener
			m_listener.Prefixes.Add("http://*:8383/");
		}

		private void RequestHandler()
		{
			while (m_listener.IsListening)
			{
				IAsyncResult context = m_listener.BeginGetContext(new AsyncCallback(ListenerCallback), m_listener);
				context.AsyncWaitHandle.WaitOne();
			}

			m_isRequestHandlerExited = true;
		}

		private String GetPayload(HttpListenerRequest request)
		{
			long dataLength = request.ContentLength64;

			string result;
			using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
			{
				result = reader.ReadToEnd();
			}

			return result;
		}

		private void ListenerCallback(IAsyncResult ar)
		{
			// TODO: what is the proper check here
			// TODO: add try catch
			// not sure what the proper check is here but this code throws when the 
			// program is shut down if this check isn't here
			if (m_listener.IsListening)
			{
				HttpListener listener = ar.AsyncState as HttpListener;

				HttpListenerContext context = listener.EndGetContext(ar);

				Console.WriteLine("handling call to url " + context.Request.RawUrl);

				// get the endpoint name to access dictionary
				string key = Path.GetFileName(context.Request.RawUrl.TrimEnd('/', '\\'));

				if (m_eventHandlers.Keys.Contains(key))
				{
					m_eventHandlers[key].Handle(GetPayload(context.Request));
				}
				else
				{
					Console.WriteLine("endpoint '" + key + "' did not match key");
				}
			}
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				// start the listener first... 
				m_listener.Start();

				// ...because the thread will exit when the listener is no longer listening
				m_listenerThread = new Thread(new ThreadStart(RequestHandler));

				m_listenerThread.Start();
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
				// this will also cause the listener thread to stop
				m_listener.Stop();

				// TODO: determine if this needs to be done and if so, what way it should be done
				// attempting to wait while pending requests are being processed
				while (!m_isRequestHandlerExited) { }

				m_listener.Close();

				m_listenerThread.Join();
			}
			catch (Exception exception)
			{
				Console.Out.WriteLine("From1_FromClosed exception:\n" + exception.Message);
			}
		}
	}
}
