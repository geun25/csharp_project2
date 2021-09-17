using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaferLineCommLib;

namespace Central_Control
{
    public partial class CentralForm : Form
    {
        public CentralForm()
        {
            InitializeComponent();
        }

        private void CentralForm_Load(object sender, EventArgs e)
        {
            IPAddress defaddr = MyNetwork.Addresses[0];
            tbox_me_ip.Text = defaddr.ToString();
        }
    }
}
