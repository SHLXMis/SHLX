
 using System;
 using System.Collections.Generic;
 using System.Windows.Forms;
 using System.Data;
using System.ComponentModel;
namespace Redsoft
{
    public partial class d_cxn_h_list_cpbh : UserControl, IGrid
    {
        public d_cxn_h_list_cpbh()
        {
            InitializeComponent();
	    
        }
        public IList<Column> GetCols()
        {
            IList<Column> cols = new List<Column>();
	    
             cols.Add(new Column("1","sy_id","ID号",true,54,2248,"1","long",true,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("2","pihao","批号",true,112,2,"1","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("3","riqi","日期",true,76,116,"0","datetime",false,"","yyyy-mm-dd",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("4","sy_name","试验名称",true,69,195,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("5","bianhao","编号",true,66,2305,"1","long",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("6","cpbh_id","Cpbh Id",false,59,9066,"0","long",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("7","cpbh","产品编号",true,205,267,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("8","guige","规格",true,140,475,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("9","sl","数量",true,57,1977,"1","long",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("10","zl","重量",true,48,2036,"1","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("11","sl_cy","抽样数量",true,68,2086,"1","long",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("12","sl_sj","实际数量",true,70,1181,"1","long",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("13","xn","性能",true,84,1784,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("14","dc","镀层",true,141,705,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("15","jcgj","检测工具",true,158,1254,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("16","pdbz","判断标准",true,139,849,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("17","shiyanren","试验人",true,104,1870,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("18","sytj","试验条件",true,121,1491,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("19","sysb","试验设备",true,166,1614,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("20","judge","判断",true,84,618,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("21","manager","主管",true,88,2157,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("22","bz","备注",true,442,2782,"0","char(255)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("23","aaa1","检测单位",true,73,1416,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("24","value_max","最大值",true,62,990,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("25","value_min","最小值",true,67,1056,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("26","value_avg","平均值",true,53,1125,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("27","bbb1","参数2",true,133,2373,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("28","jgdw","加工单位",true,131,2509,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("29","ddh","订单号",true,137,2643,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("30","gyy","工艺员",true,74,3227,"2","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("31","lrr","录入人",true,69,3304,"2","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("32","fhx","复核项",true,72,3376,"2","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("33","sl_bhg","不合格数",true,74,3450,"0","long",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("34","bili_bhg","不合格比例",true,94,3526,"0","decimal(2)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("35","cpk1","cpk1",true,50,3624,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("36","ppk1","ppk1",true,41,3676,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("37","cpk2","Cpk2",true,50,3720,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("38","ppk2","Ppk2",true,48,3772,"0","decimal(3)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("39","mubiaozhi","目标值",true,64,3822,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("40","shangpiancha","上偏差",true,61,3889,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("41","xiapiancha","下偏差",true,64,3953,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("42","guke","顾客",true,99,4019,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("43","ceshixiangmu","测试项目",true,85,4121,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("44","ccc1","客户系数",true,85,4209,"0","char(100)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("45","lrsj","录入时间",true,138,4297,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("46","xgsj","修改时间",true,107,4437,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("47","pdsj","判断时间",true,107,4547,"0","datetime",false,"","[shortdate] [time]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("48","wendu1","温度1",true,121,4657,"0","decimal(1)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("49","wendu2","温度2",true,125,4780,"0","decimal(1)",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("50","bz1min","标准1小",true,93,4908,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("51","bz1max","标准1大",true,98,5004,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("52","bz2min","标准2小",true,91,5105,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("53","bz2max","标准2大",true,88,5198,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("54","ctcw0min","常温磁通小",false,105,5289,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("55","ctcw0avg","常温磁通均",false,99,5396,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("56","ctcw0max","常温磁通大",false,108,5498,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("57","ctcw1min","常温磁通标准1小",false,149,5609,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("58","ctcw1max","常温磁通标准1大",false,153,5761,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("59","ctcw2min","常温磁通标准2小",false,147,5916,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("60","ctcw2max","常温磁通标准2大",false,155,6066,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("61","ctgw0min","高温磁通小",false,101,6224,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("62","ctgw0avg","高温磁通均",false,100,6328,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("63","ctgw0max","高温磁通大",false,100,6430,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("64","ctgw1min","高温磁通标准1小",false,148,6533,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("65","ctgw1max","高温磁通标准1大",false,154,6684,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("66","ctgw2min","高温磁通标准2小",false,146,6841,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("67","ctgw2max","高温磁通标准2大",false,155,6989,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("68","cjcw0min","常温磁矩小",false,107,7147,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("69","cjcw0avg","常温磁矩均",false,106,7257,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("70","cjcw0max","常温磁矩大",false,100,7365,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("71","cjcw1min","常温磁矩标准1小",false,158,7468,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("72","cjcw1max","常温磁矩标准1大",false,160,7629,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("73","cjcw2min","常温磁矩标准2小",false,152,7792,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("74","cjcw2max","常温磁矩标准2大",false,154,7946,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("75","cjgw0min","高温磁矩小",false,108,8102,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("76","cjgw0avg","高温磁矩均",false,100,8213,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("77","cjgw0max","高温磁矩大",false,105,8316,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("78","cjgw1min","高温磁矩标准1小",false,162,8424,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("79","cjgw1max","高温磁矩标准1大",false,158,8588,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("80","cjgw2min","高温磁矩标准2小",false,152,8749,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0"));
             cols.Add(new Column("81","cjgw2max","高温磁矩标准2大",false,160,8904,"0","number",false,"","[general]",false,"","","",EditType.Edit,"0")); 	
            return cols;

        }
        public string Sql
        {
            get { return "  SELECT top 5 cxn_h.sy_id,cxn_h.pihao,cxn_h.riqi,cxn_h.sy_name,cxn_h.bianhao,cxn_h.cpbh_id,cxn_h.cpbh,cxn_h.guige,cxn_h.sl,cxn_h.zl,cxn_h.sl_cy,cxn_h.sl_sj,cxn_h.xn,cxn_h.dc,cxn_h.jcgj,cxn_h.pdbz,cxn_h.shiyanren,cxn_h.sytj,cxn_h.sysb,cxn_h.judge,cxn_h.manager,cxn_h.bz,cxn_h.aaa1,cxn_h.value_max,cxn_h.value_min,cxn_h.value_avg,cxn_h.bbb1,cxn_h.jgdw,cxn_h.ddh,cxn_h.gyy,cxn_h.lrr,cxn_h.fhx,cxn_h.sl_bhg,cxn_h.bili_bhg,cxn_h.cpk1,cxn_h.ppk1,cxn_h.cpk2,cxn_h.ppk2,cxn_h.mubiaozhi,cxn_h.shangpiancha,cxn_h.xiapiancha,cxn_h.guke,cxn_h.ceshixiangmu,cxn_h.ccc1,cxn_h.lrsj,cxn_h.xgsj,cxn_h.pdsj,cxn_h.wendu1,cxn_h.wendu2,cxn_h.bz1min,cxn_h.bz1max,cxn_h.bz2min,cxn_h.bz2max,cxn_h.ctcw0min,cxn_h.ctcw0avg,cxn_h.ctcw0max,cxn_h.ctcw1min,cxn_h.ctcw1max,cxn_h.ctcw2min,cxn_h.ctcw2max,cxn_h.ctgw0min,cxn_h.ctgw0avg,cxn_h.ctgw0max,cxn_h.ctgw1min,cxn_h.ctgw1max,cxn_h.ctgw2min,cxn_h.ctgw2max,cxn_h.cjcw0min,cxn_h.cjcw0avg,cxn_h.cjcw0max,cxn_h.cjcw1min,cxn_h.cjcw1max,cxn_h.cjcw2min,cxn_h.cjcw2max,cxn_h.cjgw0min,cxn_h.cjgw0avg,cxn_h.cjgw0max,cxn_h.cjgw1min,cxn_h.cjgw1max,cxn_h.cjgw2min,cxn_h.cjgw2max      FROM cxn_h    where riqi >= getdate() - 200 and cxn_h.sy_name = :ls_sy_name and cpbh = :ls_cpbh and judge <> '' order by sy_id desc"; }
        }
        public DataGridView GetGrid()
        {
            return dataGridView1;
        }
	public IList<NameValue> GetArguments()
        {
            List<NameValue> result = new List<NameValue>();
            
            result.Add(new NameValue("ls_cpbh", "string"));
            result.Add(new NameValue("ls_sy_name", "string"));
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
                return "no";
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
        #endregion
    }
}