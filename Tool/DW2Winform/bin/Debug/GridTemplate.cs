
 using System;
 using System.Collections.Generic;
 using System.Windows.Forms;
 using System.Data;
using System.ComponentModel;
namespace Redsoft
{
    public partial class @ClassName : UserControl, IGrid
    {
        public @ClassName()
        {
            InitializeComponent();
	    @FormLoad
        }
        public IList<Column> GetCols()
        {
            IList<Column> cols = new List<Column>();
	    @ColumnsDefine 	
            return cols;

        }
        public string Sql
        {
            get { return "@SQL"; }
        }
        public DataGridView GetGrid()
        {
            return dataGridView1;
        }
	public IList<NameValue> GetArguments()
        {
            List<NameValue> result = new List<NameValue>();
            @Arguments
            return result;
        }
        #region IGrid 成员

        public string Updatewhere
        {
            get
            {
                return "@updatewhere";
            }
             
        }
       
        public string Updatekeyinplace
        {
            get
            {
                return "@updatekeyinplace";
            }
             
        }
	public string IdCol
        {
            get { return "@IdCol"; }
        }

        public string TableName
        {
            get { return "@TableName"; }
        }
	public string SqlName
        {
            get { return "@SqlName"; }
        }
	public string IdDataType
        {
            get { return "@IdDataType"; }
        }
        #endregion
    }
}