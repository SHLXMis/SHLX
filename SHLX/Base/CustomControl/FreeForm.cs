using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data.Table;
using System.Reflection;
using CYQ.Data;

namespace Redsoft
{
    public partial class FreeForm : UserControl
    {
        private RowStatus rowState;

        public RowStatus RowState
        {
            get { return rowState; }
            set { rowState = value; }
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
            }
        }
      
        public string TableName
        {
            get
            {
                IFreeForm dw = (IFreeForm)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
                return dw.TableName;
            }
           
        }
        public string IdCol
        {
            get
            {
                IFreeForm dw = (IFreeForm)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
                return dw.IdCol ;
            }

        }
        public FreeForm()
        {
            InitializeComponent();
        }
        public void Retrieve(MDataTable dt)
        {
            IFreeForm dw = (IFreeForm)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);

            this.Controls.Add(dw.GetPanel);
            Common.SetUIValue(dt, this.Controls[0]);
            foreach (Control c in this.Controls[0].Controls)
            {
                c.TextChanged += new EventHandler(c_TextChanged);

            }
            this.rowState = RowStatus.Edit;


        }
        public void Retrieve(params string[] arguments)
        {
            
            IFreeForm dw = (IFreeForm)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);
            IList<NameValue> args= dw.GetArguments();
            string sql = "";
            //参数替换
            int i = 0;
            foreach (string s in arguments)
            {
                if (args[i].Value == "number")
                    sql = dw.Sql.Replace(":" + args[i].Name, s);
                else
                    sql = dw.Sql.Replace(":" + args[i].Name, "'" + s + "'");
                i++;
            }
            MAction action = new MAction(sql,global.g5_sys.connStr);
            DataTable dt= action.Select().ToDataTable();
            this.Controls.Add(dw.GetPanel);
            Common.SetUIValue(dt, this.Controls[0]);
            foreach (Control c in this.Controls[0].Controls)
            {
                c.TextChanged += new EventHandler(c_TextChanged);

            }
            this.rowState = RowStatus.Edit;
        }
        public void InitCombobox(string fieldName, string tableName, string where, string colName)
        {
            Control[] c = this.Controls.Find(fieldName, true);
            if (c.Length > 0)
            {
                MyComboBox combobox = c[0] as MyComboBox;
                if (combobox!=null && combobox.DataSource==null)
                {
                    string value = combobox.Text;
                    Common.InitCombobox(combobox, tableName, where, colName);
                    combobox.Text = value;
                }
            }
        }
        void c_TextChanged(object sender, EventArgs e)
        {
            if (ItemChanged != null)
            {
                ItemChangedEventArgs icea = new ItemChangedEventArgs();
                Control c = sender as Control;
                icea.ColumnName = c.Name;
                icea.Data = c.Text;
                ItemChanged(this, icea);
            }
        }
        private void DataWindow_Load(object sender, EventArgs e)
        {

        }
        public event ItemChangedHandler ItemChanged;
        public delegate void ItemChangedHandler(object sender, ItemChangedEventArgs e);
        public void SetItemVisible(string colName, bool visible)
        {
            Control[] c = this.Controls.Find( colName, true);
            if (c.Length > 0)
            {
                c[0].Visible = visible;
            }
        }
        public void SetItemEnable(string colName, bool enable)
        {
            Control[] c = this.Controls.Find( colName, true);
            if (c.Length > 0)
            {
                c[0].Enabled = enable;
            }
        }
        public void SetItemData(string colName, string data)
        {
            Control[] c = this.Controls.Find( colName, true);
            if (c.Length > 0)
            {
                c[0].Text = data;
            }
        }
        public void InsertRow()
        {
            IFreeForm dw = (IFreeForm)Assembly.Load("BaseData").CreateInstance("Redsoft." + dataObject);

            if (this.Controls.Count == 0)
            {
                this.Controls.Add(dw.GetPanel);
                foreach (Control c in this.Controls[0].Controls)
                {
                    c.TextChanged += new EventHandler(c_TextChanged);

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

                    //设置一些默认字段
                    if (controlName == "collrsj")
                        mycontrol.SetText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }


            }
            rowState = RowStatus.Add;
        }
        public bool Save()
        {
            if (rowState == RowStatus.Add)
            {
                using (MAction action = new MAction(TableName,global.g5_sys.connStr))
                {
                    //收集数据

                    action.Set("", "");
                    return action.Insert();
                }
            }
            return false;
        }
    }

}