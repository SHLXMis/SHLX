using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Redsoft.HR;
using Redsoft.QM;

namespace Redsoft
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            frmHRMain hr = new frmHRMain();
            hr.Show();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            frmQMMain qmmain = new frmQMMain();
            qmmain.Show();
        }
    }
}
