using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redsoft.QM
{
    public partial class frmQMMain : Form
    {
        private int childFormNumber = 0;

        public frmQMMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmQMMain_Load(object sender, EventArgs e)
        {

        }

        private void 磁性能ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 表场检测一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("表场N", "w_cxn_bc_q326n");
        }

        private void Opencxn(string sy_name, string windowName)
        {
            w_cxn_q000 cxn = new w_cxn_q000();
            cxn.MdiParent = this;
            cxn.Is_sy_name = sy_name;
            cxn.WindowName = windowName;
            cxn.Show();
            cxn.WindowState = FormWindowState.Maximized;
        }

        private void 磁通检测一ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Opencxn("磁通N", "w_cxn_ct_q330n");
        }

        private void 高温减磁一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高减N", "w_cxn_gj_q039n");
        }

        private void 磁矩检测一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("磁矩N", "w_cxn_cj_q150n");
        }

        private void 高温磁矩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高矩N", "w_cxn_cj_q412n");
        }

        private void 磁体吸力一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("吸力N", "w_cxn_xl_q329n");
        }

        private void 高温吸力一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高吸N", "w_cxn_gx_q328n");

        }

        private void 角度偏差一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("角度N", "w_cxn_jd_q141n");
        }

        private void 双面表场一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("双表N", "w_cxn_sb_q180n");
        }

        private void 表场检则二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("表场W", "w_cxn_bc_q326w");
        }

        private void 磁通检测二ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opencxn("磁通W", "w_cxn_ct_q330w");
        }

        private void 高温减磁二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高减W", "w_cxn_gj_q039w");
        }

        private void 磁矩检测二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("磁矩W", "w_cxn_cj_q150w");
        }

        private void 高温磁矩二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高矩W", "w_cxn_cj_q412w");
        }

        private void 磁体吸力二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("吸力W", "w_cxn_xl_q329w");
        }

        private void 高温吸力二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高吸W", "w_cxn_gx_q328w");
        }

        private void 角度偏差二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("角度W", "w_cxn_jd_q141w");
        }

        private void 双面表场二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("双表W", "w_cxn_sb_q180w");
        }


    }
}
