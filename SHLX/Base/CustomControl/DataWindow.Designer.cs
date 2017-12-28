namespace Redsoft
{
    partial class DataWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataWindow));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlQuery = new System.Windows.Forms.Panel();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.comboValue = new System.Windows.Forms.ComboBox();
            this.comboRel = new System.Windows.Forms.ComboBox();
            this.comboCol = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblQueryField = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(942, 399);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // pnlQuery
            // 
            this.pnlQuery.Controls.Add(this.btnOutput);
            this.pnlQuery.Controls.Add(this.btnOk);
            this.pnlQuery.Controls.Add(this.comboValue);
            this.pnlQuery.Controls.Add(this.comboRel);
            this.pnlQuery.Controls.Add(this.comboCol);
            this.pnlQuery.Controls.Add(this.btnQuery);
            this.pnlQuery.Controls.Add(this.btnRefresh);
            this.pnlQuery.Controls.Add(this.txtFind);
            this.pnlQuery.Controls.Add(this.lblQueryField);
            this.pnlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuery.Location = new System.Drawing.Point(0, 0);
            this.pnlQuery.Name = "pnlQuery";
            this.pnlQuery.Size = new System.Drawing.Size(942, 41);
            this.pnlQuery.TabIndex = 3;
            this.pnlQuery.Visible = false;
            // 
            // btnOutput
            // 
            this.btnOutput.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOutput.Location = new System.Drawing.Point(799, 7);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(59, 27);
            this.btnOutput.TabIndex = 8;
            this.btnOutput.Text = "导出(&X)";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(720, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(59, 27);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定(&4)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // comboValue
            // 
            this.comboValue.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboValue.FormattingEnabled = true;
            this.comboValue.Location = new System.Drawing.Point(594, 11);
            this.comboValue.Name = "comboValue";
            this.comboValue.Size = new System.Drawing.Size(121, 20);
            this.comboValue.TabIndex = 3;
            this.comboValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboValue_KeyDown);
            // 
            // comboRel
            // 
            this.comboRel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboRel.FormattingEnabled = true;
            this.comboRel.Location = new System.Drawing.Point(505, 11);
            this.comboRel.Name = "comboRel";
            this.comboRel.Size = new System.Drawing.Size(83, 20);
            this.comboRel.TabIndex = 2;
            // 
            // comboCol
            // 
            this.comboCol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboCol.FormattingEnabled = true;
            this.comboCol.Location = new System.Drawing.Point(378, 11);
            this.comboCol.Name = "comboCol";
            this.comboCol.Size = new System.Drawing.Size(121, 20);
            this.comboCol.TabIndex = 1;
            this.comboCol.SelectedIndexChanged += new System.EventHandler(this.comboCol_SelectedIndexChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(305, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(59, 27);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(232, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(59, 27);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFind.Location = new System.Drawing.Point(85, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(141, 21);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // lblQueryField
            // 
            this.lblQueryField.AutoSize = true;
            this.lblQueryField.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryField.Location = new System.Drawing.Point(13, 11);
            this.lblQueryField.Name = "lblQueryField";
            this.lblQueryField.Size = new System.Drawing.Size(53, 12);
            this.lblQueryField.TabIndex = 0;
            this.lblQueryField.Text = "查询字段";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // pagerControl1
            // 
            this.pagerControl1.BackColor = System.Drawing.SystemColors.Control;
            this.pagerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "跳转";
            this.pagerControl1.Location = new System.Drawing.Point(0, 440);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(942, 29);
            this.pagerControl1.TabIndex = 4;
            this.pagerControl1.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // DataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.pnlQuery);
            this.DoubleBuffered = true;
            this.Name = "DataWindow";
            this.Size = new System.Drawing.Size(942, 469);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.Panel pnlQuery;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox comboValue;
        private System.Windows.Forms.ComboBox comboRel;
        private System.Windows.Forms.ComboBox comboCol;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lblQueryField;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
