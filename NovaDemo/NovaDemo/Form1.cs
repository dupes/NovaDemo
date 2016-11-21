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
			// m_listener.Prefixes.Add("http://localhost:8383/newevent/");
			// m_listener.Prefixes.Add("http://127.0.0.1:8383/newevent/");
			m_listener.Prefixes.Add("http://141.219.240.248:7999/newevent/");
			// m_listener.Prefixes.Add("http://10.0.2.15:83/newevent/");
		}


		private void RequestHandler()
		{
			Console.WriteLine("requestHandler called");
			while (m_listener.IsListening)
			{
				IAsyncResult context = m_listener.BeginGetContext(new AsyncCallback(ListenerCallback), m_listener);
				context.AsyncWaitHandle.WaitOne();
			}

			m_isRequestHandlerExited = true;
		}


		private void ListenerCallback(IAsyncResult ar)
		{
			Console.WriteLine("ListenerCallback");
			// TODO: what is the proper check here
			// TODO: add try catch
			// not sure what the proper check is here but this code throws when the 
			// program is shut down if this check isn't here
			if (m_listener.IsListening)
			{
				HttpListener listener = ar.AsyncState as HttpListener;

				HttpListenerContext context = listener.EndGetContext(ar);

				HttpListenerRequest request = context.Request;

				long dataLength = request.ContentLength64;

				string text;
				using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
				{
					text = reader.ReadToEnd();
				}

				// DGEvent.Rows.Add(text, "aoeu", "aoeu");
				DGEvent.BeginInvoke((MethodInvoker)delegate () { DGEvent.Rows.Add(text, "aoeu", "aoeu"); });

				Console.WriteLine("size of buffer " + text);
			}
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				Console.WriteLine("Form1_Load");
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
