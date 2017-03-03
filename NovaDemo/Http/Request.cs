using System;
using System.Net;
using System.IO;
using System.Text;

namespace NovaDemo.Http
{
	public class Request
	{
		public static bool Post(string jsonMessage, out string responsePayload)
		{
			try
			{
				WebRequest request = WebRequest.Create(new Uri("http://localhost:8000"));

				request.Method = "POST";
				request.ContentType = "application/json";

				byte[] payload = Encoding.UTF8.GetBytes(jsonMessage);

				request.ContentLength = payload.Length;

				Stream requestStream = request.GetRequestStream();
				requestStream.Write(payload, 0, payload.Length);

				requestStream.Close();

				WebResponse response = request.GetResponse();

				Stream responseStream = response.GetResponseStream();

				// Open the stream using a StreamReader for easy access.  
				StreamReader reader = new StreamReader(responseStream);

				// Read the content
				responsePayload = reader.ReadToEnd();
				//System.Console.WriteLine("WebResponse to " + jsonMessage + ":\n" + responsePayload);

				response.Close();
				responseStream.Close();
				reader.Close();

				return true;
			}
			catch (Exception exception)
			{
				//System.Console.WriteLine("Exception posting message \n" + jsonMessage + ":\n" + exception.ToString());

				responsePayload = exception.ToString();

				return false;
			}
		}
	}
}
