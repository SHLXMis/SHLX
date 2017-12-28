using System.Drawing;
namespace Redsoft
{
    partial class d_cxn_q039_b_updt
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            
this.aa = new System.Windows.Forms.DataGridViewTextBoxColumn();
this.bb = new System.Windows.Forms.DataGridViewTextBoxColumn();
this.cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
this.xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
this.dd = new System.Windows.Forms.DataGridViewTextBoxColumn();
this.ee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aa,this.bb,this.cc,this.xh,this.xgsj,this.dd,this.ee});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(804, 458);
            this.dataGridView1.TabIndex = 0;
            
  aa.DefaultCellStyle.BackColor =  ColorTranslator.FromWin32(16777215);
  bb.DefaultCellStyle.BackColor =  ColorTranslator.FromWin32(16777215);
  cc.DefaultCellStyle.BackColor =  SystemColors.Control;
  xh.DefaultCellStyle.BackColor =  SystemColors.Control;
  xgsj.DefaultCellStyle.BackColor =  SystemColors.Control;
  dd.DefaultCellStyle.BackColor =  SystemColors.Control;
  ee.DefaultCellStyle.BackColor =  ColorTranslator.FromWin32(16777215);

this.aa.HeaderText = "常温磁通";
this.aa.Name = "aa";
this.aa.Width = 67;
this.aa.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.aa.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
this.aa.DefaultCellStyle.Tag = "[general]";

this.bb.HeaderText = "高温后磁通";
this.bb.Name = "bb";
this.bb.Width = 75;
this.bb.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.bb.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
this.bb.DefaultCellStyle.Tag = "[general]";

this.cc.HeaderText = "Flux loss";
this.cc.Name = "cc";
this.cc.Width = 90;
this.cc.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.cc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.cc.DefaultCellStyle.Tag = "[general]";

this.xh.HeaderText = "序号";
this.xh.Name = "xh";
this.xh.Width = 49;
this.xh.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.xh.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
this.xh.DefaultCellStyle.Tag = "[general]";

this.xgsj.HeaderText = "修改时间";
this.xgsj.Name = "xgsj";
this.xgsj.Width = 149;
this.xgsj.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.xgsj.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.xgsj.DefaultCellStyle.Tag = "[shortdate] [time]";

this.dd.HeaderText = "常温磁矩";
this.dd.Name = "dd";
this.dd.Width = 83;
this.dd.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.dd.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.dd.DefaultCellStyle.Tag = "[general]";

this.ee.HeaderText = "高温磁矩";
this.ee.Name = "ee";
this.ee.Width = 101;
this.ee.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
this.ee.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // 
            // UserControl1
            // 
            this.Controls.Add(this.dataGridView1);
            this.Name = "d_cxn_q039_b_updt";
            this.Size = new System.Drawing.Size(804, 458);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        
private System.Windows.Forms.DataGridViewTextBoxColumn aa;
private System.Windows.Forms.DataGridViewTextBoxColumn bb;
private System.Windows.Forms.DataGridViewTextBoxColumn cc;
private System.Windows.Forms.DataGridViewTextBoxColumn xh;
private System.Windows.Forms.DataGridViewTextBoxColumn xgsj;
private System.Windows.Forms.DataGridViewTextBoxColumn dd;
private System.Windows.Forms.DataGridViewTextBoxColumn ee;
    }
}
