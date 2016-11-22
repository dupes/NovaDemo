using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Threading;
using System.IO;

namespace NovaDemo.Listener
{
	class Listener
	{
		private HttpListener m_listener = new HttpListener();

		private Thread m_listenerThread = null;

		private bool m_isRequestHandlerExited = false;

		// provide framework to pass json message of request to calling code
		public delegate void RequestHandler(Uri uri, string payload);

		private RequestHandler m_requestHandler = null;

		public Listener()
		{
			// add endpoints to listener
			m_listener.Prefixes.Add("http://*:8383/");
		}


		public void Start(RequestHandler handler)
		{
			m_requestHandler = handler;

			// start the listener first... 
			m_listener.Start();

			// ...because the thread will exit when the listener is no longer listening
			m_listenerThread = new Thread(new ThreadStart(ThreadLoop));

			m_listenerThread.Start();
		}


		public void Stop()
		{
			// this will also cause the listener thread to stop
			m_listener.Stop();

			// TODO: determine if this needs to be done and if so, what way it should be done
			// attempting to wait while pending requests are being processed
			while (!m_isRequestHandlerExited) { }

			m_listener.Close();

			m_listenerThread.Join();
		}


		private void ThreadLoop()
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
				m_requestHandler(context.Request.Url, GetPayload(context.Request));
			}
		}
	}
}
