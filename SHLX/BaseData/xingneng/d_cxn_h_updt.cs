
 using System;
 using System.Collections.Generic;
 using System.Windows.Forms;
 using System.Data;
using System.ComponentModel;
namespace Redsoft
{
    public partial class d_cxn_h_updt : UserControl, IFreeForm
    {
        public d_cxn_h_updt()
        {
            InitializeComponent();


            
            
             DataTable judge_list = new DataTable();
             judge_list.Columns.Add("Name");
             judge_list.Columns.Add("Value");
             judge_list.Rows.Add("合格", "合格");
             judge_list.Rows.Add("让步", "让步");
             judge_list.Rows.Add("报废", "报废");
             judge_list.Rows.Add("不合格", "不合格");
             judge_list.Rows.Add("CP无要求", "CP无要求");
             judge_list.Rows.Add("全检", "全检");
             Common.InitDDLB(judge,judge_list);
        }
	public IList<Column> GetCols()
        {
            IList<Column> cols = new List<Column>();
	    
             cols.Add(new Column("1","sy_id","",true,149,698,"1","long",true,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("2","riqi","",true,210,362,"0","datetime",false,"","yyyy-mm-dd",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("3","sy_name","",false,149,857,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("4","pihao","",true,213,88,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("5","bianhao","",true,77,494,"1","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("6","cpbh","",true,211,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_cpbh","cpbh","cpbh",EditType.DDDW,"1"));
             cols.Add(new Column("7","guige","",true,210,362,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_guige","guige","guige",EditType.DDDW,"1"));
             cols.Add(new Column("8","sl","",true,80,88,"1","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("9","zl","",true,85,218,"1","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("10","sl_cy","",true,48,388,"1","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("11","sl_sj","",true,49,523,"1","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("12","xn","",true,80,88,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("13","dc","",true,218,218,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("14","jcgj","",true,483,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_jcgj","jcgj","jcgj",EditType.DDDW,"1"));
             cols.Add(new Column("15","pdbz","",true,483,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_pdbz","pdbz","pdbz",EditType.DDDW,"1"));
             cols.Add(new Column("16","shiyanren","",true,112,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_shiyanren","shiyanren","shiyanren",EditType.DDDW,"1"));
             cols.Add(new Column("17","sytj","",true,483,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_sytj","sytj","sytj",EditType.DDDW,"1"));
             cols.Add(new Column("18","sysb","",true,483,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_sysb","sysb","sysb",EditType.DDDW,"1"));
             cols.Add(new Column("19","judge","",true,149,698,"0","char(100)",false,"","[general]",false,"","","",EditType.DDLB,"1"));
             cols.Add(new Column("20","manager","",true,149,698,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("21","bz","",true,485,88,"0","char(255)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("22","aaa1","",true,221,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_aaa1","aaa1","aaa1",EditType.DDDW,"1"));
             cols.Add(new Column("23","value_max","",true,75,865,"0","number",false,"","#,##0.00",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("24","value_min","",true,75,782,"0","number",false,"","#,##0.00",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("25","value_avg","",true,75,782,"0","number",false,"","#,##0.00",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("26","jgdw","",true,149,698,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("27","ddh","",true,149,698,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("28","bbb1","",true,145,88,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_bbb1","bbb1","bbb1",EditType.DDDW,"1"));
             cols.Add(new Column("29","lrr","",true,90,289,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_lrr","lrr","lrr",EditType.DDDW,"1"));
             cols.Add(new Column("30","gyy","",true,149,698,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_gyy","gyy","gyy",EditType.DDDW,"1"));
             cols.Add(new Column("31","fhx","",true,149,698,"0","char(100)",false,"","[general]",false,"d_cxn_h_updt_dddw_fhx","fhx","fhx",EditType.DDDW,"1"));
             cols.Add(new Column("32","sl_bhg","",true,46,486,"0","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("33","bili_bhg","",true,33,539,"0","decimal(2)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("34","cpk1","",true,120,88,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("35","ppk1","",true,120,268,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("36","cpk2","",true,120,88,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("37","ppk2","",true,120,268,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("38","mubiaozhi","",true,221,350,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("39","shangpiancha","",true,112,460,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("40","xiapiancha","",true,112,460,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("41","guke","",true,221,350,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("42","ceshixiangmu","",true,221,350,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("43","ccc1","",true,72,323,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("44","cpbh_id","",false,88,857,"0","long",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("45","lrsj","",true,174,88,"0","datetime",false,"","yyyy-mm-dd hh:mm:ss",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("46","xgsj","",true,174,88,"0","datetime",false,"","yyyy-mm-dd hh:mm:ss",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("47","pdsj","",true,174,88,"0","datetime",false,"","yyyy-mm-dd hh:mm:ss",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("48","wendu1","",true,65,434,"0","decimal(1)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("49","wendu2","",true,65,507,"0","decimal(1)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("50","bz1min","",true,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("51","bz1max","",true,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("52","bz2min","",true,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("53","bz2max","",true,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("54","ctcw0min","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("55","ctcw0avg","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("56","ctcw0max","",false,75,865,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("57","ctcw1min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("58","ctcw1max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("59","ctcw2min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("60","ctcw2max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("61","ctgw0min","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("62","ctgw0avg","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("63","ctgw0max","",false,75,865,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("64","ctgw1min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("65","ctgw1max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("66","ctgw2min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("67","ctgw2max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("68","cjcw0min","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("69","cjcw0avg","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("70","cjcw0max","",false,75,865,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("71","cjcw1min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("72","cjcw1max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("73","cjcw2min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("74","cjcw2max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("75","cjgw0min","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("76","cjgw0avg","",false,75,782,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("77","cjgw0max","",false,75,865,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("78","cjgw1min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("79","cjgw1max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("80","cjgw2min","",false,75,617,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("81","cjgw2max","",false,75,699,"0","number",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("82","bzpdjg","",false,112,856,"0","char(50)",false,"","[general]",false,"","","",EditType.Edit,"1"));
             cols.Add(new Column("","dc_t","镀层",true,40,173,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","bianhao_t","编号",true,40,450,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","riqi_t","日期",true,40,315,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","guige_t","规格",true,40,315,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","zl_t","重量",true,38,174,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sl_cy_t","抽样数量",true,75,308,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sl_sj_t","实际数量",true,75,442,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","xn_t","性能",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","pihao_t","批号",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","cpbh_t","产品编号",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sl_t","数量",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","ccc1_t","客户系数",true,75,242,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sl_bhg_t","不合格数",true,75,404,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","jcgj_t","检测工具",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sysb_t","试验设备",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","pdbz_t","判断标准",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","bbb1_t","磁矩系数",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sytj_t","试验条件",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","ceshixiangmu_t","测试项目",true,75,269,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_4","温度",true,40,387,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","lrsj_t","录入时间",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","shiyanren_t","试验人",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","cpk2_t","cpk2",true,57,25,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","xiapiancha_t","下偏差",true,57,398,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","ppk2_t","ppk2",true,57,206,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","bz_t","备注",true,38,43,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","aaa1_t","磁通单位",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","guke_t","顾客",true,75,269,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","pdsj_t","判断时间",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","xgsj_t","修改时间",true,75,6,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","mubiaozhi_t","目标值",true,57,288,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","cpk1_t","cpk1",true,57,25,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","shangpiancha_t","上偏差",true,57,398,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","ppk1_t","ppk1",true,57,206,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_2","工艺员",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_1","复核项",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","judge_t","判断",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","manager_t","主管",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","ddh_t","订单号",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sy_id_t","ID号",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","jgdw_t","加工单位",true,75,616,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","sy_name_t","试验名称",false,75,857,"1","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_1111","磁通常温",false,80,868,"0","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_1112","磁通高温",false,80,868,"0","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_1113","磁矩常温",false,80,868,"0","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_1114","磁矩高温",false,80,868,"0","",false,"","",false,"","","",EditType.Edit,""));
             cols.Add(new Column("","t_3","录入人",true,75,208,"1","",false,"","",false,"","","",EditType.Edit,"")); 	
            return cols;

        }
        public string Sql
        {
            get { return "  SELECT cxn_h.sy_id,cxn_h.riqi,cxn_h.sy_name,cxn_h.pihao,cxn_h.bianhao,cxn_h.cpbh,cxn_h.guige,cxn_h.sl,cxn_h.zl,cxn_h.sl_cy,cxn_h.sl_sj,cxn_h.xn,cxn_h.dc,cxn_h.jcgj,cxn_h.pdbz,cxn_h.shiyanren,cxn_h.sytj,cxn_h.sysb,cxn_h.judge,cxn_h.manager,cxn_h.bz,cxn_h.aaa1,cxn_h.value_max,cxn_h.value_min,cxn_h.value_avg,cxn_h.jgdw,cxn_h.ddh,cxn_h.bbb1,cxn_h.lrr,cxn_h.gyy,cxn_h.fhx,cxn_h.sl_bhg,cxn_h.bili_bhg,cxn_h.cpk1,cxn_h.ppk1,cxn_h.cpk2,cxn_h.ppk2,cxn_h.mubiaozhi,cxn_h.shangpiancha,cxn_h.xiapiancha,cxn_h.guke,cxn_h.ceshixiangmu,cxn_h.ccc1,cxn_h.cpbh_id,cxn_h.lrsj,cxn_h.xgsj,cxn_h.pdsj,cxn_h.wendu1,cxn_h.wendu2,cxn_h.bz1min,cxn_h.bz1max,cxn_h.bz2min,cxn_h.bz2max,cxn_h.ctcw0min,cxn_h.ctcw0avg,cxn_h.ctcw0max,cxn_h.ctcw1min,cxn_h.ctcw1max,cxn_h.ctcw2min,cxn_h.ctcw2max,cxn_h.ctgw0min,cxn_h.ctgw0avg,cxn_h.ctgw0max,cxn_h.ctgw1min,cxn_h.ctgw1max,cxn_h.ctgw2min,cxn_h.ctgw2max,cxn_h.cjcw0min,cxn_h.cjcw0avg,cxn_h.cjcw0max,cxn_h.cjcw1min,cxn_h.cjcw1max,cxn_h.cjcw2min,cxn_h.cjcw2max,cxn_h.cjgw0min,cxn_h.cjgw0avg,cxn_h.cjgw0max,cxn_h.cjgw1min,cxn_h.cjgw1max,cxn_h.cjgw2min,cxn_h.cjgw2max,cxn_h.bzpdjg      FROM cxn_h     WHERE cxn_h.sy_id = :sy_id    "; }
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
            
            result.Add(new NameValue("sy_id", "number"));
            result.Add(new NameValue("pihao", "string"));
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
            get { return "sy_id"; }
        }

        public string TableName
        {
            get { return "cxn_h"; }
        }
	public string SqlName
        {
            get { return "cxn_h.sy_id"; }
        }
	public string IdDataType
        {
            get { return "long"; }
        }

    }
}