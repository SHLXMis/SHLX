using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CYQ.Data;
using CYQ.Data.Table;
using System.Diagnostics;

namespace Redsoft
{
    public partial class DataWindow : UserControl
    {
        private bool isRetrieve;//是否加载数据

        public bool IsRetrieve
        {
            get { return isRetrieve; }
            set { isRetrieve = value; }
        }
        IList<Column> cols;

        public IList<Column> Cols
        {
            get
            {
                if (cols != null)
                    return cols;
                else
                {
                    if (grid != null)
                        return grid.GetCols();
                    else if (freeForm != null)
                        return freeForm.GetCols();
                    else
                        return null;
                }
            }
            set { cols = value; }
        }
        private string fixCondition;

        public string FixCondition
        {
            get { return fixCondition; }
            set { fixCondition = value; }
        }
        private string currentConditoin;

        public string CurrentConditoin
        {
            get { return currentConditoin; }
            set { currentConditoin = value; }
        }
        private string currentConditionDisplay;

        public string CurrentConditionDisplay
        {
            get { return currentConditionDisplay; }
            set { currentConditionDisplay = value; }
        }
        private bool hideQuery;
        [DefaultValue(false)]
        public bool HideQuery
        {
            get { return hideQuery; }
            set
            {
                hideQuery = value;
                pnlQuery.Visible = !value;
            }
        }
        private bool hidePager;
        [DefaultValue(false)]
        public bool HidePager
        {
            get { return hidePager; }
            set
            {
                hidePager = value;
                pagerControl1.Visible = !value;
            }
        }
        private bool readOnly;
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                dataGridView1.ReadOnly = value;
            }
        }
        private bool hideExport;
        [DefaultValue(false)]
        public bool HideExport
        {
            get { return hideExport; }
            set
            {
                hideExport = value;
                btnOutput.Visible = !value;
            }
        }
        public DataWindow()
        {
            InitializeComponent();
        }
        IFreeForm freeForm;
        IGrid grid;
        private RowStatus rowState;

        public RowStatus RowState
        {
            get { return rowState; }
            set { rowState = value; }
        }
        private DataWindowTypes _dataWindowType;
        public DataWindowTypes DataWindowType
        {
            get { return _dataWindowType; }

        }
        private string dataObject;
        [Description("DataObject"), Category("自定义属性")]
        // 控件的自定义属性值 
        public string DataObject
        {
            get
            {
                return dataObject;
            }
            set
            {
                dataObject = value;
                if (!isDesignMode())
                {
                    object o = Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
                    if (o is Redsoft.IFreeForm)
                    {
                        freeForm = (IFreeForm)o;
                        _dataWindowType = DataWindowTypes.FreeForm;
                    }
                    else
                    {
                        grid = (IGrid)o;
                        _dataWindowType = DataWindowTypes.Grid;
                        dataGridView1.Visible = true;
                        pagerControl1.Visible = true;
                        pnlQuery.Visible = true;
                    }
                }
            }
        }
        public string TableName
        {
            get
            {
                if (grid != null)
                    return grid.TableName;
                else if (freeForm != null)
                    return freeForm.TableName;
                return "";
            }

        }
        public string IdCol
        {
            get
            {
                if (grid != null)
                    return grid.IdCol;
                else if (freeForm != null)
                    return freeForm.IdCol;
                return "";
            }

        }
        public string SqlName
        {
            get
            {
                if (grid != null)
                    return grid.SqlName;
                else if (freeForm != null)
                    return freeForm.SqlName;
                return "";
            }

        }
        public string IdDataType
        {
            get
            {
                if (grid != null)
                    return grid.IdDataType;
                else if (freeForm != null)
                    return freeForm.IdDataType;
                return "";
            }
        }

        private List<DataGridViewRow> deletedRows;

        public List<DataGridViewRow> DeletedRows
        {
            get { return deletedRows; }
            set { deletedRows = value; }
        }
        public long deletedcount()
        {
            if (deletedRows == null)
                return 0;
            else
                return deletedRows.Count;
        }
        public long modifiedcount()
        {
            if (DataWindowType == DataWindowTypes.FreeForm)
                return 1;
            else
            {
                long mCount = 0;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.IsNewRow || Common.GetString(r.Tag) == "Update")
                        mCount++;
                }
                return mCount;
            }
        }
        public void setitem(long row, string colName, object data)
        {
            if (_dataWindowType == DataWindowTypes.FreeForm)
            {
                Control[] c = this.Controls.Find(colName, true);
                if (c.Length > 0)
                {
                    c[0].Text = Common.GetString(data);
                }
            }
            else
            {
                dataGridView1.Rows[(int)row].Cells[colName].Value = data;
            }
        }
        public void SetItemVisible(string colName, bool visible)
        {
            if (_dataWindowType == DataWindowTypes.FreeForm)
            {
                Control[] c = this.Controls.Find(colName, true);
                if (c.Length > 0)
                {
                    c[0].Visible = visible;
                }
            }
        }
        public void SetItemEnable(string colName, bool enable)
        {
            if (_dataWindowType == DataWindowTypes.FreeForm)
            {
                Control[] c = this.Controls.Find(colName, true);
                if (c.Length > 0)
                {
                    c[0].Enabled = enable;
                }
            }
        }

        public void Retrieve(params string[] arguments)
        {
            isRetrieve = true;
            deletedRows = new List<DataGridViewRow>();
            if (DataWindowType == DataWindowTypes.FreeForm)
            {
                IList<NameValue> args = freeForm.GetArguments();
                string sql = freeForm.Sql;
                //参数替换
                int i = 0;
                foreach (string s in arguments)
                {
                    if (args[i].Value == "number")
                        sql = sql.Replace(":" + args[i].Name, s);
                    else
                        sql = sql.Replace(":" + args[i].Name, "'" + s + "'");
                    i++;
                }
                MAction action = new MAction(sql, global.g5_sys.connStr);
                DataTable dt = action.Select().ToDataTable();
                bool firstRetrieve = false;
                if (this.Controls.Find("panel1", true).Length == 0)
                    firstRetrieve = true;
                else
                    firstRetrieve = false;
                this.Controls.Clear();
                Panel panel1 = freeForm.GetPanel;
                panel1.AutoScroll = true;
                this.Controls.Add(panel1);
                isRetrieve = true;
                Common.SetUIValue(dt, this.Controls[0]);
                isRetrieve = false;
                if (firstRetrieve)
                {
                    foreach (Control c in this.Controls[0].Controls)
                    {
                        //c.TextChanged += new EventHandler(c_TextChanged);
                        c.LostFocus += new EventHandler(c_TextChanged);
                        MyComboBox mycbo = c as MyComboBox;
                        if (mycbo != null)
                        {
                            mycbo.SelectedIndexChanged += new EventHandler(mycbo_SelectedIndexChanged);
                        }
                    }
                }
                this.rowState = RowStatus.Edit;
            }
            else
            {
                 
                IList<NameValue> args = grid.GetArguments();
                string sql = grid.Sql;

                //参数替换
                int iArg = 0;
                foreach (string s in arguments)
                {
                    if (args[iArg].Value == "number")
                        sql = sql.Replace(":" + args[iArg].Name, s.ToString());
                    else
                        sql = sql.Replace(":" + args[iArg].Name, "'" + s + "'");
                    iArg++;
                }

                using (MAction action = new MAction(sql, global.g5_sys.connStr))
                {
                    if (hidePager)
                    {
                        pagerControl1.PageSize = 1000;
                        pagerControl1.Visible = !hidePager;
                    }
                    pnlQuery.Visible = !hideQuery;

                    int count;
                    MDataTable dt = action.Select(pagerControl1.PageIndex, pagerControl1.PageSize, "", out count);


                    dataGridView1.Rows.Clear();
                    if (dataGridView1.Columns.Count == 0)
                    {
                        DataGridView dv = grid.GetGrid();

                        for (int j = 0; j < dv.Columns.Count; j++)
                        {
                            dataGridView1.Columns.Add((DataGridViewColumn)dv.Columns[j].Clone());
                            if (this.Tag.ToString().Substring(0, 1) != "2" ||
                                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.BackColor == SystemColors.Control)
                                dataGridView1.Columns[dataGridView1.Columns.Count - 1].ReadOnly = true;
                        }
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dataGridView1.Columns.Contains(dt.Columns[j].ColumnName))
                            {
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dt.Columns[j].ColumnName].Value =
                                    GetFormattedValue(dt.Rows[i], dt.Columns[j].ColumnName, dataGridView1.Columns[dt.Columns[j].ColumnName]);

                            }
                        }
                    }

                    pagerControl1.DrawControl(count);
                }
            }
            if (RetrieveEnd != null)
                RetrieveEnd(this, new EventArgs());
            isRetrieve = false;
        }
        public void Retrieve(params long[] arguments)
        {
            isRetrieve = true;
            deletedRows = new List<DataGridViewRow>();
            if (DataWindowType == DataWindowTypes.FreeForm)
            {
                IList<NameValue> args = freeForm.GetArguments();
                string sql = "";
                //参数替换
                int i = 0;
                foreach (long s in arguments)
                {
                    if (args[i].Value == "number")
                        sql = freeForm.Sql.Replace(":" + args[i].Name, s.ToString());
                    else
                        sql = freeForm.Sql.Replace(":" + args[i].Name, "'" + s + "'");
                    i++;
                }
                MAction action = new MAction(sql, global.g5_sys.connStr);
                DataTable dt = action.Select().ToDataTable();
                bool firstRetrieve = false;
                if (this.Controls.Find("panel1", true).Length == 0)
                    firstRetrieve = true;
                else
                    firstRetrieve = false;
                this.Controls.Clear();
                Panel panel1 = freeForm.GetPanel;
                panel1.AutoScroll = true;
                this.Controls.Add(panel1);
                isRetrieve = true;
                Common.SetUIValue(dt, this.Controls[0]);
                isRetrieve = false;
                if (firstRetrieve)
                {
                    foreach (Control c in this.Controls[0].Controls)
                    {
                        c.TextChanged += new EventHandler(c_TextChanged);
                        MyComboBox mycbo = c as MyComboBox;
                        if (mycbo != null)
                        {
                            mycbo.SelectedIndexChanged += new EventHandler(mycbo_SelectedIndexChanged);
                        }
                    }
                }
                this.rowState = RowStatus.Edit;
            }
            else
            {
                
                IList<NameValue> args = grid.GetArguments();
                string sql = "";
                //参数替换
                int iArg = 0;
                foreach (long s in arguments)
                {
                    if (args[iArg].Value == "number")
                        sql = grid.Sql.Replace(":" + args[iArg].Name, s.ToString());
                    else
                        sql = grid.Sql.Replace(":" + args[iArg].Name, "'" + s + "'");
                    iArg++;
                }

                using (MAction action = new MAction(sql, global.g5_sys.connStr))
                {
                    if (hidePager)
                    {
                        pagerControl1.PageSize = 1000;
                        pagerControl1.Visible = !hidePager;
                    }
                    pnlQuery.Visible = !hideQuery;

                    int count;
                    MDataTable dt = action.Select(pagerControl1.PageIndex, pagerControl1.PageSize, "", out count);


                    dataGridView1.Rows.Clear();
                    if (dataGridView1.Columns.Count == 0)
                    {
                        DataGridView dv = grid.GetGrid();

                        for (int j = 0; j < dv.Columns.Count; j++)
                        {
                            dataGridView1.Columns.Add((DataGridViewColumn)dv.Columns[j].Clone());
                            if (this.Tag.ToString().Substring(0, 1) != "2" ||
                                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.BackColor == SystemColors.Control)
                                dataGridView1.Columns[dataGridView1.Columns.Count - 1].ReadOnly = true;
                        }
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dataGridView1.Columns.Contains(dt.Columns[j].ColumnName))
                            {
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dt.Columns[j].ColumnName].Value =
                                    GetFormattedValue(dt.Rows[i], dt.Columns[j].ColumnName, dataGridView1.Columns[dt.Columns[j].ColumnName]);

                            }
                        }
                    }

                    pagerControl1.DrawControl(count);
                }

            }
            if (RetrieveEnd != null)
                RetrieveEnd(this, new EventArgs());
            isRetrieve = false;
        }

        void mycbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemChanged != null)
            {
                if (!isRetrieve)
                {
                    ItemChangedEventArgs icea = new ItemChangedEventArgs();
                    Control c = sender as Control;
                    icea.ColumnName = c.Name;
                    icea.Data = c.Text;
                    ItemChanged(this, icea);
                }
            }
        }
        void c_TextChanged(object sender, EventArgs e)
        {
            if (ItemChanged != null)
            {
                if (!isRetrieve)
                {
                    ItemChangedEventArgs icea = new ItemChangedEventArgs();
                    Control c = sender as Control;
                    icea.ColumnName = c.Name;
                    icea.Data = c.Text;
                    ItemChanged(this, icea);
                }
            }
        }
        public event ItemChangedHandler ItemChanged;
        public delegate void ItemChangedHandler(object sender, ItemChangedEventArgs e);
        public void Retrieve()
        {
            isRetrieve = true;
            if (grid != null)
            {
                pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

                cols = grid.GetCols();
                LoadData(dataObject, currentConditoin);

                lblQueryField.Text = dataGridView1.Columns[0].HeaderText;
                BindingSource bs = new BindingSource();
                bs.DataSource = cols;

                comboCol.DataSource = bs;
                comboCol.DisplayMember = "Text";
                comboCol.ValueMember = "Name";
                comboCol.Text = lblQueryField.Text;
            }
            if (RetrieveEnd != null)
                RetrieveEnd(this, new EventArgs());
            isRetrieve = false;
        }
        public void BindData(string condition)
        {
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            cols = grid.GetCols();
            if (!string.IsNullOrEmpty(fixCondition))
            {
                if (condition != "")
                    condition += " and " + fixCondition;
                else
                    condition = fixCondition;
            }
            LoadData(dataObject, condition);

            lblQueryField.Text = dataGridView1.Columns[0].HeaderText;
            BindingSource bs = new BindingSource();
            bs.DataSource = cols;

            comboCol.DataSource = bs;
            comboCol.DisplayMember = "Text";
            comboCol.ValueMember = "Name";
            comboCol.Text = lblQueryField.Text;
        }
        void LoadData(string dataOjbect, string condition)
        {

            if (string.IsNullOrEmpty(condition))
                condition = "";
            int count;
            try
            {
                using (MAction action = new MAction(grid.Sql, global.g5_sys.connStr))
                {
                    if (hidePager)
                        pagerControl1.PageSize = 1000;
                    MDataTable dt = action.Select(pagerControl1.PageIndex, pagerControl1.PageSize, condition, out count);

                   
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.Columns.Count == 0)
                    {
                        DataGridView dv = grid.GetGrid();

                        for (int j = 0; j < dv.Columns.Count; j++)
                        {
                            dataGridView1.Columns.Add((DataGridViewColumn)dv.Columns[j].Clone());
                            if (this.Tag.ToString().Substring(0, 1) != "2" ||
                                dataGridView1.Columns[dataGridView1.Columns.Count - 1].DefaultCellStyle.BackColor == SystemColors.Control)
                                dataGridView1.Columns[dataGridView1.Columns.Count - 1].ReadOnly = true;
                        }
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dataGridView1.Columns.Contains(dt.Columns[j].ColumnName))
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dt.Columns[j].ColumnName].Value =
                                    GetFormattedValue(dt.Rows[i], dt.Columns[j].ColumnName, dataGridView1.Columns[dt.Columns[j].ColumnName]);
                        }
                    }

                    pagerControl1.DrawControl(count);
                    if (RowEnter != null)
                    {
                        DataGridViewCellEventArgs e =
                            new DataGridViewCellEventArgs(0, 0);
                        RowEnter(this, e);
                    }
                }
            }
            catch
            {

            }
        }

        public void SetGridStyle(string windowName)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            MAction action = new MAction("mis_dw_argument", global.g5_sys.connStr);
            DataTable dt= action.Select("user_name1='"+ global.g5_sys.username +"' and window1='"+ windowName +"' and dataobject='"+ this.dataObject +"'").ToDataTable();
            if (dt.Rows.Count == 0)
                dt = action.Select("user_name1='" + global.g5_sys.username + "' and window1='" + windowName + "' and dataobject=''").ToDataTable();
            if (dt.Rows.Count == 0)
                dt = action.Select("user_name1='" + global.g5_sys.username + "' and window1='' and dataobject=''").ToDataTable();

            if (dt.Rows.Count == 0)
            {
                
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(193, 205, 205);
                dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(207, 207, 207);
                dataGridView1.GridColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 224);
            }
            else
            {
                long headercolor = Common.GetLong(dt.Rows[0]["header_color"]);
                if (headercolor != 0)
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromWin32((int)headercolor);
                long headerfontcolor = Common.GetLong(dt.Rows[0]["header_fontcolor"]);
                if (headerfontcolor != 0)
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromWin32((int)headerfontcolor);
                long headerfontsize = Common.GetLong(dt.Rows[0]["header_fontsize"]);
                string headerfontfamily = Common.GetString(dt.Rows[0]["header_fontface"]);
                if (headerfontsize != 0 && headerfontfamily!="")
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(headerfontfamily, Math.Abs(headerfontsize));

                long detailfontsize = Common.GetLong(dt.Rows[0]["detail_fontsize"]);
                string detailfontfamily = Common.GetString(dt.Rows[0]["detail_fontface"]);
                if (detailfontsize != 0 && detailfontfamily != "")
                    dataGridView1.DefaultCellStyle.Font = new Font(detailfontfamily, Math.Abs(detailfontsize));
                long detailheight = Common.GetLong(dt.Rows[0]["detail_height"]);
                dataGridView1.RowTemplate.Height =(int) detailheight / 4;
                string dw_2_3 = Common.GetString(dt.Rows[0]["dw_2_3"]);
                if (dw_2_3 == "2")
                {
                   //奇偶列
                    long detailcolor1 = Common.GetLong(dt.Rows[0]["detail_color1"]);
                    if (detailcolor1 != 0)
                        dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromWin32((int)detailcolor1);
                    long detailfontcolor1 = Common.GetLong(dt.Rows[0]["detail_fontcolor1"]);
                    if (detailfontcolor1 != 0)
                        dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = ColorTranslator.FromWin32((int)detailfontcolor1);

                    long detailcolor2 = Common.GetLong(dt.Rows[0]["detail_color2"]);
                    if (detailcolor2 != 0)
                        dataGridView1.DefaultCellStyle.BackColor = ColorTranslator.FromWin32((int)detailcolor2);
                    long detailfontcolor2 = Common.GetLong(dt.Rows[0]["detail_fontcolor2"]);
                    if (detailfontcolor2 != 0)
                        dataGridView1.DefaultCellStyle.ForeColor = ColorTranslator.FromWin32((int)detailfontcolor2);

                }
                else if (dw_2_3 == "3")
                {
                    //三列循环

                }
            }
            
        }
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData(dataObject, currentConditoin);
        }
        private string GetFormattedValue(MDataRow r, string colName, DataGridViewColumn c)
        {
            if (Common.GetString(c.DefaultCellStyle.Tag) == "yyyy-mm-dd")
            {
                return r[colName].ToString().Substring(0, 10);
            }
            else
                return r[colName].ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData("");
        }
        private void RefreshData(string find)
        {
            int icol = 0;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.HeaderText == lblQueryField.Text)
                {
                    icol = col.Index;
                    break;
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string s = Common.GetString(row.Cells[icol].Value);
                row.Visible = s.ToLower().Contains(find.ToLower());

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboValue.Text == "")
            {
                MessageBox.Show("请填写查询值！", "提示", MessageBoxButtons.OK);
                return;
            }
            string col = comboCol.SelectedValue.ToString();

            MAction action = new MAction(grid.Sql, global.g5_sys.connStr);
            if (!action.Data.Columns.Contains(col))
                return;
            SqlDbType dbtype = action.Data.Columns[col].SqlType;
            if (dbtype == SqlDbType.DateTime ||
                dbtype == SqlDbType.DateTime2 ||
                dbtype == SqlDbType.Date ||
                dbtype == SqlDbType.SmallDateTime)
            {
                DateTime dt = DateTime.MinValue;
                if (!DateTime.TryParse(comboValue.Text, out dt))
                {
                    MessageBox.Show(comboValue.Text + "不能转化为日期！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            if (dbtype == SqlDbType.Decimal ||
                dbtype == SqlDbType.Float ||
                dbtype == SqlDbType.Int ||
                dbtype == SqlDbType.Money ||
                dbtype == SqlDbType.Real ||
                dbtype == SqlDbType.SmallInt ||
                dbtype == SqlDbType.SmallMoney ||
                dbtype == SqlDbType.TinyInt
                )
            {
                double dt = 0;
                if (!double.TryParse(comboValue.Text, out dt))
                {
                    MessageBox.Show(comboValue.Text + "不能转化为数字！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(fixCondition))
                currentConditoin = fixCondition + " and " + getCondition(col, dbtype, comboRel.Text, comboValue.Text);
            else
                currentConditoin = getCondition(col, dbtype, comboRel.Text, comboValue.Text);
            LoadData(dataObject, currentConditoin);
        }
        private string getCondition(string col, SqlDbType dbtype, string rel, string val)
        {
            string findval = val; ;
            if (dbtype == SqlDbType.Char ||
                dbtype == SqlDbType.NChar ||
                dbtype == SqlDbType.NText ||
                dbtype == SqlDbType.NVarChar ||
                dbtype == SqlDbType.VarChar ||
                dbtype == SqlDbType.DateTime ||
                dbtype == SqlDbType.DateTime2 ||
                dbtype == SqlDbType.Date
                )
            {
                findval = "'" + val + "'";
            }
            switch (rel)
            {
                case "等于":
                    return col + " = " + findval;
                case "大于等于":
                    return col + " >= " + findval;
                case "小于等于":
                    return col + " <= " + findval;
                case "大于":
                    return col + " > " + findval;
                case "小于":
                    return col + " < " + findval;
                case "不等于":
                    return col + " <> " + findval;
                case "为空":
                    return col + " is null";
                case "为非空":
                    return col + " is not null";
                case "类似":
                    return col + " like '%" + val + "%'";
                case "不类似":
                    return col + " not like '%" + val + "%'";
            }
            return "";
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (grid != null)
            {
                if (!hidePager)
                {
                    MAction action = new MAction(grid.Sql, global.g5_sys.connStr);
                    if (pagerControl1.RecordCount > 50000)
                    {
                        MessageBox.Show("记录数超过5万行，请分开导出！");
                        return;
                    }
                    DataTable dt = action.Select(currentConditoin).ToDataTable();
                    ExcelHelper.TableToExcel(dt, System.IO.Path.GetTempFileName() + ".xls");
                }
                else
                    ExcelHelper.GridToExcel(dataGridView1, System.IO.Path.GetTempFileName() + ".xls");

            }
        }

        private void comboCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAction action = new MAction(grid.Sql, global.g5_sys.connStr);
            comboRel.Items.Clear();
            string col = comboCol.SelectedValue.ToString();
            if (!action.Data.Columns.Contains(col))
                return;
            SqlDbType dbtype = action.Data.Columns[col].SqlType;
            if (dbtype == SqlDbType.Char ||
                dbtype == SqlDbType.NChar ||
                dbtype == SqlDbType.NText ||
                dbtype == SqlDbType.NVarChar ||
                dbtype == SqlDbType.VarChar
                )
            {
                comboRel.Items.AddRange(new object[] {
                "等于",
                "大于等于",
                "小于等于",
                "大于",
                "小于",
                "类似","不类似",
                "为空",
                "为非空",
                "不等于"});
            }
            else
            {
                comboRel.Items.AddRange(new object[] {
                "等于",
                "大于等于",
                "小于等于",
                "大于",
                "小于",
                "为空",
                "为非空",
                "不等于"});
            }
            comboRel.Text = "等于";
        }
        public void InitCombobox(string fieldName, string tableName, string where, string colName, string order)
        {

            if (DataWindowType == DataWindowTypes.Grid)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Name == fieldName)
                    {
                        DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)dataGridView1.Columns[i];

                        if (cb != null)
                        {

                            Common.InitCombobox(cb, tableName, where, colName, order);

                        }
                    }
                }
            }
            else
            {
                Control[] c = this.Controls.Find(fieldName, true);
                if (c.Length > 0)
                {
                    MyComboBox combobox = c[0] as MyComboBox;
                    if (combobox != null && combobox.DataSource == null)
                    {
                        string value = combobox.Text;
                        Common.InitCombobox(combobox, tableName, where, colName);
                        combobox.Text = value;
                    }
                }
            }

        }
        public void UpdateRow(MAction action)
        {
            if (DataWindowType == DataWindowTypes.Grid)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    dataGridView1.CurrentRow.Cells[col.Name].Value = action.Get(col.Name, "");
                }
            }
        }
        public void AddRow(MAction action)
        {
            if (DataWindowType == DataWindowTypes.Grid)
            {
                dataGridView1.Rows.Add();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[col.Name].Value = action.Get(col.Name, "");
                }
            }
        }

        public long InsertRow(long row)
        {
            if (DataWindowType == DataWindowTypes.FreeForm)
            {
                if (this.Controls.Count <= 3)
                {
                    this.Controls.Clear();
                    this.Controls.Add(freeForm.GetPanel);
                    foreach (Control c in this.Controls[0].Controls)
                    {
                        //c.TextChanged += new EventHandler(c_TextChanged);
                        c.LostFocus += new EventHandler(c_TextChanged);
                    }
                }

                for (int i = 0; i < this.Controls[0].Controls.Count; i++)
                {
                    string controlName = this.Controls[0].Controls[i].Name;

                    IMyControl mycontrol = this.Controls[0].Controls[i] as IMyControl;
                    if (mycontrol != null)
                    {
                        mycontrol.OldText = "";
                        mycontrol.SetText("");

                        //设置一些默认字段，示例
                        if (controlName == "collrsj")
                            mycontrol.SetText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }


                }
                rowState = RowStatus.Add;
                return 1;
            }
            else
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = "Add";
                return dataGridView1.Rows.Count - 1;
            }
        }
        public void ScrollToRow(long row)
        {
            if (DataWindowType == DataWindowTypes.Grid)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[(int)row].Cells[0];
            }
        }
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //双击排序
            if (e.Button == MouseButtons.Left)
            {
                SortByColumn(dataGridView1, e.ColumnIndex);
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                //个性化设置
            }
            else
                OnCellDoubleClick(e);
        }
        private void SortByColumn(DataGridView listData, int columnIndex)
        {
            DataGridViewColumn newColumn = listData.Columns[columnIndex];
            newColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            DataGridViewColumn oldColumn = listData.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    listData.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }
            try
            {
                listData.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
            }
            catch
            {
                //return;
            }

        }
        public event CellDoubleClickHandler CellDoubleClick;
        public delegate void CellDoubleClickHandler(object sender, DataGridViewCellMouseEventArgs e);

        protected void OnCellDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(this, e);
            }
        }
        public event CellClickHandler CellClick;
        public delegate void CellClickHandler(object sender, DataGridViewCellMouseEventArgs e);

        protected void OnCellClick(DataGridViewCellMouseEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(this, e);
            }
        }
        public event RowEnterHandler RowEnter;
        public delegate void RowEnterHandler(object sender, DataGridViewCellEventArgs e);
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (RowEnter != null)
            {
                RowEnter(this, e);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void comboValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnOk_Click(null, null);
        }
        public static bool isDesignMode()
        {
            bool returnflag = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnflag = true;
            }
            else if (Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnflag = true;
            }

            return returnflag;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            RefreshData(txtFind.Text);
        }
        public void PrintPreview()
        {
            //datawindow打印

            printPreviewDialog1.PrintPreviewControl.StartPage = 0;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            //设置或返回窗口状态，即该窗口是最小化、正常大小还是其他状态。 
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            //设置和获取需要预览的文档 
            //将窗体显示为指定者的模式对话框 
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

           
        }
        public void Print()
        {
            printDialog1.ShowDialog();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                lblQueryField.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            else
                OnCellClick(e);
        }
        public long rowcount()
        {
            if (DataWindowType == DataWindowTypes.Grid)
                return dataGridView1.Rows.Count;
            else
                return 1;
        }
        public void reset()
        {
            if (DataWindowType == DataWindowTypes.Grid)
                dataGridView1.Rows.Clear();
        }

        public string GetItemData(long row, string colName)
        {
            if (_dataWindowType == DataWindowTypes.FreeForm)
            {
                Control[] c = this.Controls.Find(colName, true);
                if (c.Length > 0)
                {
                    return c[0].Text;
                }
            }
            else
            {
                return Common.GetString(dataGridView1.Rows[(int)row].Cells[colName].Value);
            }
            return "";
        }
        public long RowCount()
        {
            if (DataWindowType == DataWindowTypes.FreeForm)
                return 1;
            else
                return dataGridView1.Rows.Count;
        }

        public event RetrieveEndHandler RetrieveEnd;
        public delegate void RetrieveEndHandler(object sender, EventArgs e);

        public void deleterow(long row)
        {//界面上删除
            if (DataWindowType == DataWindowTypes.Grid)
            {
                if (deletedRows == null)
                {
                    deletedRows = new List<DataGridViewRow>();
                }
                deletedRows.Add(dataGridView1.Rows[(int)row]);
                dataGridView1.Rows.RemoveAt((int)row);
            }
            else
            {

            }
        }
        public void Delete(long row)
        {
            //从数据库中删除
            if (DataWindowType == DataWindowTypes.Grid)
            {
                using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                {
                    DataGridViewRow r = dataGridView1.Rows[(int)row];
                    action.Fill(getWhere(r));
                    if (!action.Delete())
                    {
                        MessageBox.Show(action.DebugInfo);
                        return;
                    }


                }
            }
            else
            {
                using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                {
                    action.Fill("" + IdCol + "=" + row + "");
                    if (!action.Delete())
                    {
                        MessageBox.Show(action.DebugInfo);
                        return;
                    }
                }
            }
        }
        public bool IsSelected(long row)
        {
            if (DataWindowType == DataWindowTypes.Grid)
            {
                return dataGridView1.Rows[(int)row - 1].Selected;
            }
            return false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemChanged != null)
            {
                if (!isRetrieve)
                {
                    ItemChangedEventArgs icea = new ItemChangedEventArgs();
                    icea.ColumnName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
                    icea.Data = Common.GetString(dataGridView1.CurrentCell.Value);
                    icea.Row = dataGridView1.CurrentCell.RowIndex;
                    if (Common.GetString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Tag) != "Add")
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Tag = "Update";
                    ItemChanged(this, icea);
                }
            }
        }
        public bool update(long id)
        {
            if (DataWindowType == DataWindowTypes.FreeForm)
            {
                if (RowState == RowStatus.Add)
                {
                    using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                    {
                        //从UI取值
                        string checkResult = Common.CheckValid(action, Controls[0], RowState, errorProvider1);
                        if (checkResult != "")
                            return false;
                        Common.GetUIValue(action, Controls[0], RowState);
                        if (!action.Insert())
                        {
                            MessageBox.Show(action.DebugInfo);
                            return false;
                        }
                        else
                        {
                            AddRow(action);
                            RowState = RowStatus.Edit;
                            return true;
                        }

                    }


                }
                else if (RowState == RowStatus.Edit)
                {
                    using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                    {
                        action.Fill("" + IdCol + "=" + id + "");
                        Common.GetUIValue(action, Controls[0], RowState);
                        if (!action.Update())
                        {
                            MessageBox.Show(action.DebugInfo);
                            return false;
                        }
                        else
                        {
                            UpdateRow(action);
                            return true;
                        }

                    }
                }
            }
            else
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (Common.GetString(r.Tag) == "Add")
                    {
                        using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                        {
                            Common.GetUIValue(action, r);
                            if (!action.Insert())
                            {
                                MessageBox.Show(action.DebugInfo);
                                return false;
                            }

                        }
                    }
                    if (Common.GetString(r.Tag) == "Update")
                    {
                        using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                        {
                            Common.GetUIValue(action, r);
                            if (!action.Update())
                            {
                                MessageBox.Show(action.DebugInfo);
                                return false;
                            }

                        }
                    }

                }
                if (deletedRows != null)
                {
                    foreach (DataGridViewRow r in deletedRows)
                    {
                        using (MAction action = new MAction(TableName, global.g5_sys.connStr))
                        {
                            action.Fill(getWhere(r));
                            if (!action.Delete())
                            {
                                MessageBox.Show(action.DebugInfo);
                                return false;
                            }

                        }
                    }
                }
            }
            RowState = RowStatus.Edit;
            return true;
        }
        private string getWhere(DataGridViewRow r)
        {
            string where = "";
            if (DataWindowType == DataWindowTypes.Grid)
                cols = grid.GetCols();
            foreach (Column col in cols)
            {
                if (col.KeyCol)
                {
                    if (col.ColType == "long" || col.ColType == "number")
                    {
                        if (where == "")
                        {
                            where = col.Name + "=" + Common.GetString(r.Cells[dataGridView1.Columns[col.Name].Index].Value) + "";
                        }
                        else
                        {
                            where += " and " + col.Name + "=" + Common.GetString(r.Cells[dataGridView1.Columns[col.Name].Index].Value) + "";
                        }
                    }
                    else
                    {
                        if (where == "")
                        {
                            where = col.Name + "='" + Common.GetString(r.Cells[dataGridView1.Columns[col.Name].Index].Value) + "'";
                        }
                        else
                        {
                            where += " and " + col.Name + "='" + Common.GetString(r.Cells[dataGridView1.Columns[col.Name].Index].Value) + "'";
                        }
                    }

                }
            }
            return where;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            if (DataWindowType == DataWindowTypes.FreeForm)
            {
                Panel panel1 = this.Controls[0] as Panel;
                Bitmap _NewBitmap = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
                e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
            }
            else
            {

                Bitmap _NewBitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
                e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
            }
        }

        public void SetItemText(string colName, string data)
        {
            if (_dataWindowType == DataWindowTypes.FreeForm)
            {
                Control[] c = this.Controls.Find(colName, true);
                if (c.Length > 0)
                {
                    c[0].Text = data;
                }
            }
            else
            {
                if (dataGridView1.Columns.Contains(colName))
                    dataGridView1.Columns[colName].HeaderText = data;
            }
        }

        public double getitemnumber(long row, string colName)
        {
            if (_dataWindowType == DataWindowTypes.FreeForm)
            {
                Control[] c = this.Controls.Find(colName, true);
                if (c.Length > 0)
                {
                    double ret = 0;
                    double.TryParse(c[0].Text, out ret);
                    return ret;
                }
            }
            else
            {
                double ret = 0;
                double.TryParse(Common.GetString(dataGridView1.Rows[(int)row].Cells[colName].Value), out ret);
                return ret;
            }
            return 0;
        }
        public void SetSort(string sort)
        {

        }
        public void Sort()
        {
             
        }
    }
}
