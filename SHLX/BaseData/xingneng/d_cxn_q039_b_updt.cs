
 using System;
 using System.Collections.Generic;
 using System.Windows.Forms;
 using System.Data;
using System.ComponentModel;
namespace Redsoft
{
    public partial class d_cxn_q039_b_updt : UserControl, IGrid
    {
        public d_cxn_q039_b_updt()
        {
            InitializeComponent();
	    
        }
        public IList<Column> GetCols()
        {
            IList<Column> cols = new List<Column>();
	    
             cols.Add(new Column("1","xh","序号",true,49,242,"1","long",true,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("2","sy_id","ID号",false,98,445,"1","long",true,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("3","aa","常温磁通",true,67,2,"1","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("4","bb","高温后磁通",true,75,72,"1","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("5","cc","Flux loss",true,90,149,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("6","dd","常温磁矩",true,83,546,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("7","ee","高温磁矩",true,101,632,"0","number",false,"","",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("8","xgsj","修改时间",true,149,293,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("","compute_5","",false,0,149,"0","",true,"min(cc for all)","#,##0.00",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_3","",false,0,72,"0","",true,"min(bb for all)","[general]",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_1","",false,0,2,"0","",true,"min(aa for all)","[general]",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_2","",false,0,2,"0","",true,"max(aa for all)","[general]",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_4","",false,0,72,"0","",true,"max(bb for all)","[general]",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_6","",false,0,149,"0","",true,"max(cc for all)","#,##0.00",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_9","",false,0,2,"0","",true,"avg(aa for all)","0",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_8","",false,0,72,"0","",true,"avg(bb for all)","0",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","compute_7","",false,0,149,"0","",true,"avg(cc for all)","#,##0.00",false,"","","",EditType.Edit,"")); 	
            return cols;

        }
        public string Sql
        {
            get { return "  SELECT cxn_b.xh,cxn_b.sy_id,cxn_b.aa,cxn_b.bb,cxn_b.cc,cxn_b.dd,         cxn_b.ee,cxn_b.xgsj      FROM cxn_b     WHERE cxn_b.sy_id = :sy_id    "; }
        }
        public DataGridView GetGrid()
        {
            return dataGridView1;
        }
	public IList<NameValue> GetArguments()
        {
            List<NameValue> result = new List<NameValue>();
            
            result.Add(new NameValue("sy_id", "number"));
            return result;
        }
        #region IGrid 成员

        public string Updatewhere
        {
            get
            {
                return "0";
            }
             
        }
       
        public string Updatekeyinplace
        {
            get
            {
                return "yes";
            }
             
        }
	public string IdCol
        {
            get { return "sy_id"; }
        }

        public string TableName
        {
            get { return "cxn_b"; }
        }
	public string SqlName
        {
            get { return "cxn_b.sy_id"; }
        }
	public string IdDataType
        {
            get { return "long"; }
        }
        #endregion
    }
}