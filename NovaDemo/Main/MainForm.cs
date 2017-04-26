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
    public partial class MainForm : Form
    {
        private Listener.Listener m_listener = null;

        private Dictionary<String, HandlePayload> m_eventHandlers = null;

        private delegate void HandlePayload(string payload);

        private Uri m_novaUri;

        /********************************************************************************/

        public MainForm()
        {
            InitializeComponent();

            m_listener = new Listener.Listener();

            m_eventHandlers = new Dictionary<string, HandlePayload>();

            m_novaUri = new Uri("http://localhost:8282");

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
                UCEventLog.LogMessage("Form1_Load exception: " + exception.Message);
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
                UCEventLog.LogMessage("Form1_Load exception: " + exception.Message);
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
                UCEventLog.LogMessage("unable to handle request; ur no match: " + key);
            }
        }

        /********************************************************************************/

        private void HandlePayload_NewEvent(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            UCEventList.NewEvent(newEvent);

            UCEventLog.LogMessage("new event: " + newEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_StartEvent(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            UCEventList.StartEvent(newEvent);

            UCEventLog.LogMessage("start event: " + newEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_StartEventInterval(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            // the event is already active, just need to log this message
            UCEventLog.LogMessage("start event interval: " + newEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_ModifyEvent(string payload)
        {
            RequestData.NewEvent newEvent = JsonConvert.DeserializeObject<RequestData.NewEvent>(payload);

            UCEventList.ModifyEvent(newEvent);

            UCEventLog.LogMessage("modify event: " + newEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_DeleteEvent(string payload)
        {
            RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

            UCEventList.DeleteEvent(endEvent);

            UCEventLog.LogMessage("remove event: " + endEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_EndEvent(string payload)
        {
            RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

            UCEventList.EndEvent(endEvent);

            UCEventLog.LogMessage("end event: " + endEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_CancelEvent(string payload)
        {
            RequestData.EndEvent endEvent = JsonConvert.DeserializeObject<RequestData.EndEvent>(payload);

            UCEventList.CancelEvent(endEvent);

            UCEventLog.LogMessage("cancel event: " + endEvent.EventId);
        }

        /********************************************************************************/

        private void HandlePayload_Status(string payload)
        {
            toolStripStatusLabelLastPoll.Text = "Last status poll: " + DateTime.Now.ToString();
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
                UCEventLog.LogMessage("Error sending message: " + message + ", response: " + response);
            }
            else
            {
                UCEventLog.LogMessage("Successfully sent message: " + message + ", response: " + response);
            }
        }
    }
}
