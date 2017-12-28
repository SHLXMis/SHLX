namespace DW2Winform
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optFreeForm = new System.Windows.Forms.RadioButton();
            this.optGrid = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableDefinePath = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDesigner = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(818, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "容器名";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(866, 57);
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(100, 21);
            this.txtContainer.TabIndex = 3;
            this.txtContainer.Text = "panel1";
            this.txtContainer.Visible = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(340, 45);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(200, 21);
            this.txtFileName.TabIndex = 5;
            this.txtFileName.Text = "d:\\d_cc_h_ccjy6_updt.srd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "源DataWindow Srd文件名(DataWindow控件导出的文件名)";
            // 
            // optFreeForm
            // 
            this.optFreeForm.AutoSize = true;
            this.optFreeForm.Checked = true;
            this.optFreeForm.Location = new System.Drawing.Point(31, 13);
            this.optFreeForm.Name = "optFreeForm";
            this.optFreeForm.Size = new System.Drawing.Size(71, 16);
            this.optFreeForm.TabIndex = 6;
            this.optFreeForm.TabStop = true;
            this.optFreeForm.Text = "FreeForm";
            this.optFreeForm.UseVisualStyleBackColor = true;
            // 
            // optGrid
            // 
            this.optGrid.AutoSize = true;
            this.optGrid.Location = new System.Drawing.Point(133, 13);
            this.optGrid.Name = "optGrid";
            this.optGrid.Size = new System.Drawing.Size(47, 16);
            this.optGrid.TabIndex = 7;
            this.optGrid.Text = "Grid";
            this.optGrid.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTableDefinePath);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.optGrid);
            this.panel1.Controls.Add(this.txtContainer);
            this.panel1.Controls.Add(this.optFreeForm);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 118);
            this.panel1.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(829, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "代码生成目标目录";
            // 
            // txtTableDefinePath
            // 
            this.txtTableDefinePath.Location = new System.Drawing.Point(218, 84);
            this.txtTableDefinePath.Name = "txtTableDefinePath";
            this.txtTableDefinePath.Size = new System.Drawing.Size(322, 21);
            this.txtTableDefinePath.TabIndex = 9;
            this.txtTableDefinePath.Text = "D:\\MyProduct\\SHLX\\SHLX\\BaseData\\xingneng";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 118);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(998, 472);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDesigner);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(990, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "窗体设计器代码";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDesigner
            // 
            this.txtDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesigner.Location = new System.Drawing.Point(3, 3);
            this.txtDesigner.Multiline = true;
            this.txtDesigner.Name = "txtDesigner";
            this.txtDesigner.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDesigner.Size = new System.Drawing.Size(984, 440);
            this.txtDesigner.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLoad);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(990, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FormLoad事件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLoad
            // 
            this.txtLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoad.Location = new System.Drawing.Point(3, 3);
            this.txtLoad.Multiline = true;
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLoad.Size = new System.Drawing.Size(984, 440);
            this.txtLoad.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 590);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Datawindow转winform用户控件";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtContainer;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optFreeForm;
        private System.Windows.Forms.RadioButton optGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtDesigner;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTableDefinePath;
        private System.Windows.Forms.Button button2;
    }
}

