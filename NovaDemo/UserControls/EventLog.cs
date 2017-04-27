using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NovaDemo.UserControls
{
	public partial class EventLog : UserControl, ILogMessage
    {
		// storing this outside the ListView gives more accurate calculation of time differernce between records
		private DateTime m_lastRecordDateTime = default(DateTime);

		// the enum order must match the column indexing of the ViewList
		private enum EventListViewColumns
		{
			LogDate,
			LogDateDifference,
			Message
		}

		/********************************************************************************/

		public EventLog()
		{
			InitializeComponent();
		}

		/********************************************************************************/

        public void LogMessage(string text)
		{
            MethodInvoker mi = new MethodInvoker(delegate
            {
                string[] columnData = new string[LVEventLog.Columns.Count];

                // only track with m_recordDateTime when a difference is calculated
                DateTime recordDateTime = DateTime.Now;

                string difference = "-";
                if (m_lastRecordDateTime != default(DateTime))
                {
                    difference = Convert.ToInt32(recordDateTime.Subtract(m_lastRecordDateTime).TotalSeconds).ToString();
                }

                m_lastRecordDateTime = recordDateTime;

                columnData[(int)EventListViewColumns.LogDate] = recordDateTime.ToString();
                columnData[(int)EventListViewColumns.LogDateDifference] = difference;
                columnData[(int)EventListViewColumns.Message] = text;

                //LVEventLog.Items.Add(new ListViewItem(columnData));
                LVEventLog.Items.Insert(0, new ListViewItem(columnData));
            });

            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /********************************************************************************/

        private void LVEventLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                if (LVEventLog.SelectedIndices.Count == 0)
                    return;

                string message = LVEventLog.Items[LVEventLog.SelectedItems[0].Index].SubItems[(int)EventListViewColumns.Message].ToString();

                rtbLogMessage.Text = message;
            });

            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }
    }
}
