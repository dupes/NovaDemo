using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace NovaDemo.UserControls
{
    public partial class EventList : UserControl
    {
        private Dictionary<String, DataGridViewRow> m_eventRows = new Dictionary<string, DataGridViewRow>();

        private Uri m_novaUri;

        enum DGEventCells
        {
            EventId,
            StartTime,
            Duration,
            Status
        }

        /********************************************************************************/

        public EventList()
        {
            InitializeComponent();
            m_novaUri = new Uri("http://localhost:8000");
        }

        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void NewEvent(RequestData.NewEvent newEvent)
        {
            // assume an event can only start if Nova sends a start event message, so 
            // the status here will either be complete because the event start time 
            // plus duration is in the past, or the event will be pending
            string status = ((Util.FromEpochToLocalTime(newEvent.DtStartTimet).AddSeconds(newEvent.DurationInSeconds) < DateTime.Now) ? "complete" : "pending");

            DGEvent.Rows.Add(newEvent.EventId, Util.FromEpochToLocalTime(newEvent.DtStartTimet), newEvent.DurationInSeconds, status);

            // and track the stored row in our dictionary (the row just added is the last row)
            m_eventRows[newEvent.EventId] = DGEvent.Rows[DGEvent.Rows.Count - 1];

        }

        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void CancelEvent(RequestData.EndEvent endEvent)
        {
            // the event isn't cancelled til the end event is received
            m_eventRows[endEvent.EventId].Cells[(int)DGEventCells.Status].Value = "cancelling";
        }

        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ModifyEvent(RequestData.NewEvent newEvent)
        {
            if (m_eventRows.ContainsKey(newEvent.EventId))
            {
                m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.StartTime].Value = Util.FromEpochToLocalTime(newEvent.DtStartTimet);
                m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.Duration].Value = newEvent.DurationInSeconds;
            }
        }

        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StartEvent(RequestData.NewEvent newEvent)
        {
            if (m_eventRows.ContainsKey(newEvent.EventId))
            {
                m_eventRows[newEvent.EventId].Cells[(int)DGEventCells.Status].Value = "active";
            }
        }

        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StartEventInterval(RequestData.NewEvent newEvent)
        {

        }

        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void EndEvent(RequestData.EndEvent endEvent)
        {
            if (m_eventRows.ContainsKey(endEvent.EventId))
            {
                string text = (m_eventRows[endEvent.EventId].Cells[(int)DGEventCells.Status].Value.ToString() == "cancelling" ? "cancelled" : "complete");

                m_eventRows[endEvent.EventId].Cells[(int)DGEventCells.Status].Value = text;
            }
        }
        
        /********************************************************************************/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteEvent(RequestData.EndEvent endEvent)
        {
            if (m_eventRows.ContainsKey(endEvent.EventId))
            {
                // retrieve row from out dictionary
                DataGridViewRow row = m_eventRows[endEvent.EventId];

                // remove row from the GUI
                DGEvent.Rows.Remove(row);

                // remove row from out dictionary
                m_eventRows.Remove(endEvent.EventId);
            }
        }

        /********************************************************************************/

        private void SendCreateOpt(string eventId, string optType, string optReason)
        {
            string message =
            "{" +
            "    \"namespace\": \"ven.eventOpt\"," +
            "    \"parameters\": {" +
            "        \"optId\" : \"optId\"," +
            "        \"eventId\" : \"" + eventId + "\"," +
            "        \"optType\" : \"" + optType + "\"," +
            "        \"optReason\" : \"" + optReason + "\"" +
            "    }" +
            "}";

            string response;
            if (!Http.Request.Post(m_novaUri, message, out response))
            {
                System.Console.WriteLine("Error sending message " + message + "\n" + response);
            }
            else
            {
                System.Console.WriteLine("Sending message " + message + " successful:\n" + response);
            }
        }

        /********************************************************************************/
  
        private void SendCreatedEvent(string eventId, string optType)
        {
            string message =
            "{" +
            "    \"namespace\": \"ven.createdEvent\"," +
            "    \"parameters\": {" +
            "        \"eventId\" : \"" + eventId + "\"," +
            "        \"optType\" : \"" + optType + "\"" +
            "     }" +
            "}";

            string response;
            if (!Http.Request.Post(m_novaUri, message, out response))
            {
                System.Console.WriteLine("Error sending message " + message + "\n" + response);
            }
            else
            {
                System.Console.WriteLine("Sending message " + message + " successful:\n" + response);

                // TODO: what should be displayed for the status for "opt in" ?
                m_eventRows[eventId].Cells[(int)DGEventCells.Status].Value = optType;
            }
        }

        /********************************************************************************/

        private void optInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = (DGEvent.SelectedRows.Count > 0 ? DGEvent.SelectedRows[0].Index : -1);

            if (!(rowIndex < 0))
            {
                string eventId = DGEvent.Rows[rowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

                SendCreatedEvent(eventId, "optIn");
            }
        }

        /********************************************************************************/

        private void optOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = (DGEvent.SelectedRows.Count > 0 ? DGEvent.SelectedRows[0].Index : -1);

            if (!(rowIndex < 0))
            {
                string eventId = DGEvent.Rows[rowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

                SendCreatedEvent(eventId, "optOut");
            }
        }

        /********************************************************************************/

        private void createOptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int rowIndex = (DGEvent.SelectedRows.Count > 0 ? DGEvent.SelectedRows[0].Index : -1);

            if (!(rowIndex < 0))
            {
                string eventId = DGEvent.Rows[rowIndex].Cells[(int)DGEventCells.EventId].Value.ToString();

                Main.FormCreateOpt createOptForm = new Main.FormCreateOpt();

                DialogResult result = createOptForm.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                SendCreateOpt(eventId, createOptForm.OptType, createOptForm.OptReason);
            }
        }
    }
}
