using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace NovaDemo.Main
{
    public partial class MainForm2 : Form
    {
        private Listener.Listener m_listener = null;

        private Dictionary<String, HandlePayload> m_eventHandlers = null;

        private delegate void HandlePayload(string payload);

        private Uri m_novaUri;

        /********************************************************************************/

        public MainForm2()
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
        }

        /********************************************************************************/

        private void Form_Load(object sender, EventArgs e)
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

        /********************************************************************************/

        private void Form_Closed(object sender, FormClosedEventArgs e)
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

        /********************************************************************************/

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
                this.BeginInvoke((MethodInvoker)delegate () { m_eventHandlers[key](payload); });
            }
            else
            {
                Console.WriteLine("endpoint '" + key + "' did not match key");
            }
        }

        /********************************************************************************/

        private void HandlePayload_NewEvent(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            UCEventList.NewEvent(newEvent);

            UCEventLog.LogNewEvent(newEvent);
        }

        /********************************************************************************/

        private void HandlePayload_StartEvent(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            UCEventList.StartEvent(newEvent);

            UCEventLog.LogStartEvent(newEvent);
        }

        /********************************************************************************/

        private void HandlePayload_StartEventInterval(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            // the event is already active, just need to log this message
            UCEventLog.LogStartEventInterval(newEvent);
        }

        /********************************************************************************/

        private void HandlePayload_ModifyEvent(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            UCEventList.ModifyEvent(newEvent);

            UCEventLog.LogModifyEvent(newEvent);
        }

        /********************************************************************************/

        private void HandlePayload_DeleteEvent(string payload)
        {
            RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

            UCEventList.DeleteEvent(endEvent);

            UCEventLog.LogDeleteEvent(endEvent);
        }

        /********************************************************************************/

        private void HandlePayload_EndEvent(string payload)
        {
            RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

            UCEventList.EndEvent(endEvent);

            UCEventLog.LogEndEvent(endEvent);
        }

        /********************************************************************************/

        private void HandlePayload_CancelEvent(string payload)
        {
            RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

            UCEventList.CancelEvent(endEvent);

            UCEventLog.LogCancelEvent(endEvent);
        }

        /********************************************************************************/

        private void HandlePayload_Status(string payload)
        {
            toolStripStatusLabelLastPoll.Text = DateTime.Now.ToString();
        }

        /********************************************************************************/

        private void btnClearEvents_Click(object sender, EventArgs e)
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
    }
}
