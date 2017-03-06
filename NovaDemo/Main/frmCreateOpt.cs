using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovaDemo.Main
{
	public partial class FormCreateOpt : Form
	{
		public FormCreateOpt()
		{
			InitializeComponent();

			cmbOptType.SelectedIndex = 0;
			cmbOptReason.SelectedIndex = 0;
		}

		/********************************************************************************/

		public string OptReason { get { return cmbOptReason.SelectedItem.ToString(); } }

		/********************************************************************************/

		public string OptType { get { return cmbOptType.SelectedItem.ToString(); } }

		/********************************************************************************/

		public string ResourceID { get { return cmbResource.SelectedItem.ToString(); } }
	}
}
