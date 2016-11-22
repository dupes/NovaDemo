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
	public partial class Form1 : Form
	{
		private HttpListener m_listener = new HttpListener();
		Thread m_listenerThread = null;
		bool m_isRequestHandlerExited = false;

		public Form1()
		{
			InitializeComponent();
			m_listener.Prefixes.Add("http://*:8383/newevent/");
		}

		private DateTime FromEpoch(long secondsFromEpoch)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(secondsFromEpoch));
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

				Request.NewEvent newEvent = JsonConvert.DeserializeObject<Request.NewEvent>(GetPayload(context.Request));

				// DGEvent.Rows.Add(text, "aoeu", "aoeu");
				DGEvent.BeginInvoke((MethodInvoker)delegate () { DGEvent.Rows.Add(newEvent.EventId, FromEpoch(newEvent.DtStartTimet), newEvent.DurationInSeconds, "pending"); });
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
