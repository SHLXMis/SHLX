using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data;
using System.Reflection;
using CYQ.Data.Table;

namespace Redsoft
{
    public partial class Grid : UserControl
    {
        public Grid()
        {
            InitializeComponent();
        }
        IList<Column> cols;
        private string dataObject;

        public string DataObject
        {
            get { return dataObject; }
            set { dataObject = value; }
        }
        public string TableName
        {
            get
            {
                IGrid dw = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
                return dw.TableName;
            }

        }
        public string IdCol
        {
            get
            {
                IGrid dw = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
                return dw.IdCol;
            }

        }

        private string fixCondition;

        public string FixCondition
        {
            get { return fixCondition; }
            set { fixCondition = value; }
        }
        private string currentConditoin;
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
            set { hideExport = value;
            btnOutput.Visible = !value;
            }
        }

        private void ListWindow_Load(object sender, EventArgs e)
        {
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
        }
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadData(dataObject, currentConditoin);
        }
        public void BindData()
        {
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
            
            IGrid grid = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
            cols = grid.GetCols();
            LoadData(dataObject, fixCondition);
          
            lblQueryField.Text = dataGridView1.Columns[0].HeaderText;
            BindingSource bs = new BindingSource();
            bs.DataSource = cols;

            comboCol.DataSource = bs;
            comboCol.DisplayMember = "Text";
            comboCol.ValueMember = "Name";
            comboCol.Text = lblQueryField.Text;
        }
        public void BindData(string condition)
        {
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

            IGrid grid = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
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
            IGrid grid = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
            if (string.IsNullOrEmpty(condition))
                condition = "";
            int count;
            try
            {
                using (MAction action = new MAction(grid.Sql,global.g5_sys.connStr))
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
                }
            }
            catch 
            {

            }
           // Common.UpdateColDisplay(dataGridView1, cols);
        }
        private string GetFormattedValue(MDataRow r,string colName,DataGridViewColumn c)
        {
            if (Common.GetString( c.DefaultCellStyle.Tag) == "yyyy-mm-dd")
            {
                return r[colName].ToString().Substring(0, 10);
            }
            else
                return r[colName].ToString();
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
        public  event CellDoubleClickHandler CellDoubleClick;
        public delegate void CellDoubleClickHandler(object sender, DataGridViewCellMouseEventArgs e);

        protected  void OnCellDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(this, e);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            OnDoubleClick(e);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                lblQueryField.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboValue.Text == "")
            {
                MessageBox.Show("请填写查询值！","提示", MessageBoxButtons.OK);
                return;
            }
            string col = comboCol.SelectedValue.ToString();
            IGrid grid = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
            MAction action = new MAction(grid.Sql,global.g5_sys.connStr);
            if (!action.Data.Columns.Contains(col))
                return;
            SqlDbType dbtype = action.Data.Columns[col].SqlType;
            if (dbtype == SqlDbType.DateTime ||
                dbtype == SqlDbType.DateTime2 ||
                dbtype == SqlDbType.Date ||
                dbtype == SqlDbType.SmallDateTime)
            {
                DateTime dt=DateTime.MinValue ;
                if (!DateTime.TryParse(comboValue.Text, out dt))
                {
                    MessageBox.Show(comboValue.Text+"不能转化为日期！", "提示", MessageBoxButtons.OK);
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
            if (fixCondition != "")
                currentConditoin =  fixCondition + " and " + getCondition(col,dbtype,comboCol.Text,comboValue.Text);
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
        private void comboCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGrid grid = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
            MAction action = new MAction(grid.Sql,global.g5_sys.connStr);
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

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //双击排序
            if (e.Button == MouseButtons.Left)
            {
                SortByColumn(dataGridView1,e.ColumnIndex);
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

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            RefreshData(txtFind.Text);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData("");
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            IGrid grid = (IGrid)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
            MAction action=new  MAction(grid.Sql,global.g5_sys.connStr);
            if (pagerControl1.RecordCount > 50000)
            {
                MessageBox.Show("记录数超过5万行，请分开导出！");
                return;
            }
            DataTable dt= action.Select(currentConditoin).ToDataTable();
            //Common.ExportExcel(dt,this.tableName+".xls" );
            ExcelHelper.TableToExcel(dt, System.IO.Path.GetTempFileName() + ".xls");
            
            //ExcelHelper.GridToExcel(dataGridView1, System.IO.Path.GetTempFileName() + ".xls");
        }

        private void comboValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnOk_Click(null, null);
        }
        public void UpdateRow(MAction  action)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataGridView1.CurrentRow.Cells[col.Name].Value = action.Get(col.Name, "");
            }
        }
        public void AddRow(MAction action)
        {
            dataGridView1.Rows.Add();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[col.Name].Value = action.Get(col.Name, "");
            }
        }
        public string DeleteRow()
        {
            MAction action=new MAction(dataObject,global.g5_sys.connStr);
            string id = dataGridView1.CurrentRow.Cells[IdCol].Value.ToString();
            action.Fill("" + IdCol + "=" + id + "");
            if (action.Delete())
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                return "";
            }
            else
            {
                return action.DebugInfo;
                
            }

        }
        public void InitCombobox(string fieldName,string tableName, string where, string colName, string order)
        {
            for (int i = 0; i < dataGridView1.Columns.Count;i++ )
            {
                if (dataGridView1.Columns[i].Name==fieldName)
                {
                    DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)dataGridView1.Columns[i];

                    if (cb != null)
                    {

                        Common.InitCombobox(cb, tableName, where, colName, order);
                        
                    }
                }
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

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }
    }
}
