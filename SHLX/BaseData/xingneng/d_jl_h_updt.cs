
 using System;
 using System.Collections.Generic;
 using System.Windows.Forms;
 using System.Data;
using System.ComponentModel;
namespace Redsoft
{
    public partial class d_jl_h_updt : UserControl, IFreeForm
    {
        public d_jl_h_updt()
        {
            InitializeComponent();


            
        }
	public IList<Column> GetCols()
        {
            IList<Column> cols = new List<Column>();
	    
             cols.Add(new Column("1","jl_id","",true,149,837,"1","long",true,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("2","baofei","",true,374,612,"0","char(1)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("3","ljmc","",true,374,117,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("4","bianhao","",true,374,117,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("5","xinghao","",true,374,612,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("6","clfw","",true,374,117,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("7","fbl","",true,374,612,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("8","sydd","",true,374,117,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("9","syr","",true,374,612,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("10","riqi_scys","",true,149,166,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("11","riqi_scjd","",true,149,501,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("12","zhouqi_w","",true,149,166,"1","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("13","zhouqi_n","",true,149,166,"1","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("14","riqi_w","",true,149,501,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("15","riqi_n","",true,149,501,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("16","riqi_songjian","",true,374,117,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("17","bz","",true,870,117,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("18","zhuangtai","",true,374,612,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("19","lrr","",true,138,747,"0","char(100)",false,"","",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("20","lrsj","",true,200,118,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("21","xgsj","",true,200,433,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("22","riqi_jhw","",true,149,837,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("23","riqi_jhn","",true,149,837,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("24","riqiwn","",false,152,1014,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("","bianhao_t","编号",true,99,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","baofei_t","报废",true,99,506,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","ljmc_t","量具名称",true,99,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","xinghao_t","型号",true,99,506,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","clfw_t","测量范围",true,100,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","fbl_t","分辨率",true,100,506,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sydd_t","使用地点",true,100,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","syr_t","使用人",true,99,506,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_songjian_t","送检日期",true,100,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","zhuangtai_t","状态",true,100,506,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","bz_t","备注",true,99,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","lrsj_t","录入时间",true,99,10,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_scys_t","首次验收日期",true,149,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","zhouqi_w_t","外检周期",true,149,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","zhouqi_n_t","内检周期",true,149,9,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_jhn_t","内检下次检定日期",true,149,681,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_jhw_t","外检下次检定日期",true,149,681,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","jl_id_t","计量ID",true,149,681,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_w_t","外检最后检定日期",true,149,345,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_n_t","内检最后检定日期",true,149,345,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_scjd_t","首次检定日期",true,149,345,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","xgsj_t","修改时间",true,99,325,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","lrr_t","修改人",true,99,641,"1","",false,"","",false,"","","",EditType.Edit,"")); 	
            return cols;

        }
        public string Sql
        {
            get { return "  SELECT jl_h.jl_id,jl_h.baofei,jl_h.ljmc,jl_h.bianhao,jl_h.xinghao,jl_h.clfw,jl_h.fbl,jl_h.sydd,jl_h.syr,jl_h.riqi_scys,jl_h.riqi_scjd,jl_h.zhouqi_w,jl_h.zhouqi_n,jl_h.riqi_w,jl_h.riqi_n,jl_h.riqi_songjian,jl_h.bz,jl_h.zhuangtai,jl_h.lrr,jl_h.lrsj,jl_h.xgsj,         jl_h.riqi_jhw,jl_h.riqi_jhn,jl_h.riqiwn      FROM jl_h     WHERE jl_h.jl_id = :jl_id    "; }
        }
        public Panel GetPanel
        {
            get
            {
                return panel1;
            }
            set { }
        }
        public IList<NameValue> GetArguments()
        {
            List<NameValue> result = new List<NameValue>();
            
            result.Add(new NameValue("jl_id", "number"));
            return result;
        }
      
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
            get { return "jl_id"; }
        }

        public string TableName
        {
            get { return "jl_h"; }
        }
	public string SqlName
        {
            get { return "jl_h.jl_id"; }
        }
	public string IdDataType
        {
            get { return "long"; }
        }

    }
}