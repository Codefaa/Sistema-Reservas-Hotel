using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
namespace UI
{
    public partial class frmErrorDigito : Form
    {
        public frmErrorDigito()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            BLLUser user = new BLLUser();

            user.regenerarDigito();
        }
    }
}
