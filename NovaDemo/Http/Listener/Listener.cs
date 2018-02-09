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
        private HttpListener m_listener;

		private Thread m_listenerThread = null;

		private bool m_isRequestHandlerExited = false;

		// provide framework to pass json message of request to calling code
		public delegate void RequestHandler(Uri uri, string payload);

		private RequestHandler m_requestHandler = null;

		public Listener()
		{
		}

        /********************************************************************************/

        public void Start(RequestHandler handler, string port)
		{
			m_requestHandler = handler;

            m_listener = new HttpListener();

            m_listener.Prefixes.Add("http://*:" + port + "/");

            // start the listener first... 
            m_listener.Start();

			// ...because the thread will exit when the listener is no longer listening
			m_listenerThread = new Thread(new ThreadStart(ThreadLoop));

			m_listenerThread.Start();
		}

        /********************************************************************************/

        public void Stop()
		{
			m_listener.Close();

			m_listenerThread.Join();
		}

        /********************************************************************************/

        private void ThreadLoop()
		{
			while (m_listener.IsListening)
			{
				IAsyncResult context = m_listener.BeginGetContext(new AsyncCallback(ListenerCallback), m_listener);
				context.AsyncWaitHandle.WaitOne();
			}

			m_isRequestHandlerExited = true;
		}

        /********************************************************************************/

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

        /********************************************************************************/

        private void ListenerCallback(IAsyncResult asyncResult)
		{
			// TODO: what is the proper check here
			// TODO: add try catch
			// not sure what the proper check is here but this code throws when the 
			// program is shut down if this check isn't here
			if (m_listener.IsListening)
			{
				HttpListener listener = asyncResult.AsyncState as HttpListener;

				// this call blocks until request received
				HttpListenerContext context = listener.EndGetContext(asyncResult);

				// create response body, formatted as follows:
				// {
				//    "status": {
				//      "code": number-here
				//      "message": "message here"
				//    }
				// }

				String statusMessage = "";

				// process the request
				try
				{
					Console.WriteLine("handling call to url " + context.Request.RawUrl);
					m_requestHandler(context.Request.Url, GetPayload(context.Request));

					statusMessage = "{\"status\": { \"code\": 200, \"message\": \"OK\" } }";
				}
				catch (Exception exception)
				{
					statusMessage = "{\"status\": { \"code\": 500, \"message\": \"" + exception.Message + "\" } }";
				}

				// populate buffer object for writing to response
				byte[] buffer = System.Text.Encoding.UTF8.GetBytes(statusMessage);

				// populate response metadata
				context.Response.ContentLength64 = buffer.Length;

				context.Response.ContentType = "application/json";

				// write body to response
				Stream responseStream = context.Response.OutputStream;

				responseStream.Write(buffer, 0, buffer.Length);

				// not sending anything in the response
				responseStream.Close();
			}
		}
	}
}
