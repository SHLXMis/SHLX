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
            Opencxn("表场N");
        }

        private void Opencxn(string sy_name)
        {
            w_cxn_q000 cxn = new w_cxn_q000();
            cxn.MdiParent = this;
            cxn.Is_sy_name = sy_name;
            cxn.Show();
            cxn.WindowState = FormWindowState.Maximized;
        }

        private void 磁通检测一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Opencxn("磁通N");
        }

        private void 高温减磁一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高减N");
        }

        private void 磁矩检测一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("磁矩N");
        }

        private void 高温磁矩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高矩N");
        }

        private void 磁体吸力一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("吸力N");
        }

        private void 高温吸力一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高吸N");

        }

        private void 角度偏差一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("角度N");
        }

        private void 双面表场一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("双表N");
        }

        private void 表场检则二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("表场W");
        }

        private void 磁通检测二ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Opencxn("磁通W");
        }

        private void 高温减磁二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高减W");
        }

        private void 磁矩检测二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("磁矩W");
        }

        private void 高温磁矩二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高矩W");
        }

        private void 磁体吸力二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("吸力W");
        }

        private void 高温吸力二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("高吸W");
        }

        private void 角度偏差二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("角度W");
        }

        private void 双面表场二ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opencxn("双表W");
        }

         
    }
}
