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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        /********************************************************************************/

        public string NovaUri
        {
            get
            {
                return txtNovaURL.Text;
            }
        }

        /********************************************************************************/

        public string ListeningPort
        {
            get
            {
                return txtListeningPort.Text;
            }
        }

        /********************************************************************************/

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
