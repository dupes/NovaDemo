using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovaDemo
{
	public partial class EventLog : UserControl
	{
		public EventLog()
		{
			InitializeComponent();
		}

		/********************************************************************************/

		public void Clear()
		{
			LVEventLog.Clear();
		}

		/********************************************************************************/

		public void LogEvent(string eventId, string text)
		{
			string[] columnData = new string[LVEventLog.Columns.Count];

			columnData[0] = "";
			columnData[1] = text;
			columnData[2] = eventId;
			columnData[3] = "";
			columnData[4] = "";
			columnData[5] = "";

			LVEventLog.Items.Add(new ListViewItem(columnData));
		}
	}
}
