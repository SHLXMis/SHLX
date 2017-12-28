using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Redsoft
{
    public partial class w_cxn_q000 : w_t_t9_3
    {
        int originalSplitterDistance = 0;
        string is_sy_name;

        public string Is_sy_name
        {
            get { return is_sy_name; }
            set { is_sy_name = value; }
        }
        string is_lrr, is_gyy, is_fhx;
        string is_shiyan, is_nw, is_qbh;
        public w_cxn_q000()
        {
            InitializeComponent();
        }

        private void w_cxn_q000_Load(object sender, EventArgs e)
        {

        }

        private void w_cxn_q000_Activated(object sender, EventArgs e)
        {

        }
        public override void ue_open0()
        {
            base.ue_open0();

            if (i5wd.s_gjz_parm != null)
            {
                if (i5wd.s_gjz_parm.Substring(0, 5) == "@@@@@")
                    is_sy_name = i5wd.s_gjz_parm.Substring(5);
                else
                    is_sy_name = i5wd.s_gjz_parm;
            }
            if (is_sy_name == "")
                i5wd.s_gjz_parm = "@@@@@";


            i5wd.s_cx_sql[1] = "sy_name='" + is_sy_name + "' and  riqi >= getdate() - 50 ";
            is_nw = is_sy_name.Substring(is_sy_name.Length - 1, 1);
            is_shiyan = is_sy_name.Substring(0, is_sy_name.Length - 1);
            if (is_nw == "N")
            {
                cb_copy_nw.Text = ">" + is_shiyan + "二";
                this.Text = is_shiyan + "一检测报告";
                i5wd.s_cx_text[1] = "最近5天" + is_shiyan + "一";
            }
            else
            {
                cb_copy_nw.Text = ">" + is_shiyan + "一";
                this.Text = is_shiyan + "二检测报告";
                i5wd.s_cx_text[1] = "最近5天" + is_shiyan + "二";
            }

            i5wd.b_dw0[1] = true;
            i5wd.b_dw0[2] = true;
            i5wd.b_dw0[9] = true;
            i5wd.b_dw0[17] = true;
            i5wd.b_dw0[25] = true;
            i5wd.dw0[32] = dw_t58;

            i5wd.s_resize = "v1ha";
            //i5wd.s_selectionchanged = "default";


            Common.gf_gnqx_n(global.g5_sys.username, "性能三-" + is_shiyan, ref i5wd.s_gnqx);
        }
        public override void ue_open1()
        {
            base.ue_open1();
            wf_dw9_dataobject();
            //datawindow固定过滤参数，临时加入，待优化
            i5wd.dw0[1].FixCondition = " sy_name='" + is_sy_name + "' ";
        }
        public void wf_dw9_dataobject()
        {
            string is_qbh = "q326";
            i5wd.dw0[9].DataObject = "d_cxn_" + is_qbh + "_b_updt";
            i5wd.dw0[17].DataObject = i5wd.dw0[9].DataObject;
            tap31.Text = is_shiyan;
            switch (is_shiyan)
            {
                case "表场": // Q326
                    is_qbh = "q326";
                    break;
                case "磁通": // Q330
                    cb_q330_ctcj.Visible = true;
                    is_qbh = "q330";

                    i5wd.dw0[1].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1max", true);

                    i5wd.dw0[1].SetItemVisible("ctcw2min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2max", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0min", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0avg", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0max", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1min", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1max", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2min", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2max_t", true);

                    i5wd.dw0[2].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[2].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[2].SetItemVisible("ctcw1min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw1max", true);
                    i5wd.dw0[2].SetItemVisible("ctcw2min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw2max", true);
                    i5wd.dw0[2].SetItemVisible("cjcw0min", true);
                    i5wd.dw0[2].SetItemVisible("cjcw0avg", true);
                    i5wd.dw0[2].SetItemVisible("cjcw0max", true);
                    i5wd.dw0[2].SetItemVisible("cjcw1min", true);
                    i5wd.dw0[2].SetItemVisible("cjcw1max", true);
                    i5wd.dw0[2].SetItemVisible("cjcw2min", true);
                    i5wd.dw0[2].SetItemVisible("cjcw2max", true);

                    i5wd.dw0[25].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2max", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0min", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0avg", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0max", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1min", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1max", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2min", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2max_t", true);


                    i5wd.dw0[25].SetItemText("ctcw0min_t", "客户磁通小");
                    i5wd.dw0[25].SetItemText("ctcw0max_t", "客户磁通大");
                    i5wd.dw0[25].SetItemText("ctcw0avg_t", "客户磁通平");
                    i5wd.dw0[25].SetItemText("cjcw0min_t", "磁矩小");
                    i5wd.dw0[25].SetItemText("cjcw0max_t", "磁矩大");
                    i5wd.dw0[25].SetItemText("cjcw0avg_t", "磁矩平");

                    i5wd.dw0[1].SetItemText("ctcw0min_t", "客户磁通小");
                    i5wd.dw0[1].SetItemText("ctcw0max_t", "客户磁通大");
                    i5wd.dw0[1].SetItemText("ctcw0avg_t", "客户磁通平");
                    i5wd.dw0[1].SetItemText("cjcw0min_t", "磁矩小");
                    i5wd.dw0[1].SetItemText("cjcw0max_t", "磁矩大");
                    i5wd.dw0[1].SetItemText("cjcw0avg_t", "磁矩平");

                    i5wd.dw0[2].SetItemVisible("l_1111", true);
                    i5wd.dw0[2].SetItemVisible("l_1112", true);
                    i5wd.dw0[2].SetItemVisible("t_1111", true);
                    i5wd.dw0[2].SetItemVisible("t_1113", true);
                    i5wd.dw0[2].SetItemText("t_1111", "客户磁通");
                    i5wd.dw0[2].SetItemText("t_1113", "磁矩");
                    break;
                case "高减":
                case "高矩": //Q412 //Q039
                    cb_q039_cwcj.Visible = true;
                    cb_q039_gwcj.Visible = true;
                    cb_q039_cwct.Visible = true;
                    if (is_shiyan == "高减")
                    {
                        is_qbh = "q039";

                        tap31.Text = "高温减磁";
                        cb_q412_gjgj.Visible = true;
                        i5wd.dw0[1].SetItemText("aaa1_t", "磁通单位");
                        i5wd.dw0[2].SetItemText("aaa1_t", "磁通单位");
                    }
                    else
                    {
                        is_qbh = "q412";
                        tap31.Text = "高温磁矩";
                        i5wd.dw0[1].SetItemText("aaa1_t", "磁矩单位");
                        i5wd.dw0[2].SetItemText("aaa1_t", "磁矩单位");
                    }
                    i5wd.dw0[1].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2max", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0min", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0avg", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0max", true);
                    i5wd.dw0[1].SetItemVisible("ctgw1min", true);
                    i5wd.dw0[1].SetItemVisible("ctgw1max", true);
                    i5wd.dw0[1].SetItemVisible("ctgw2min", true);
                    i5wd.dw0[1].SetItemVisible("ctgw2max", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0min", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0avg", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0max", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1min", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1max", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2min", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2max", true);
                    i5wd.dw0[1].SetItemVisible("cjgw0min", true);
                    i5wd.dw0[1].SetItemVisible("cjgw0avg", true);
                    i5wd.dw0[1].SetItemVisible("cjgw0max", true);
                    i5wd.dw0[1].SetItemVisible("cjgw1min", true);
                    i5wd.dw0[1].SetItemVisible("cjgw1max", true);
                    i5wd.dw0[1].SetItemVisible("cjgw2min", true);
                    i5wd.dw0[1].SetItemVisible("cjgw2max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw1max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw2max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw1min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw1max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw2min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw2max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw1max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjcw2max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw1min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw1max_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw2min_t", true);
                    i5wd.dw0[1].SetItemVisible("cjgw2max_t", true);

                    i5wd.dw0[2].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[2].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[2].SetItemVisible("ctcw1min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw1max", true);
                    i5wd.dw0[2].SetItemVisible("ctcw2min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw2max", true);
                    i5wd.dw0[2].SetItemVisible("ctgw0min", true);
                    i5wd.dw0[2].SetItemVisible("ctgw0avg", true);
                    i5wd.dw0[2].SetItemVisible("ctgw0max", true);
                    i5wd.dw0[2].SetItemVisible("ctgw1min", true);
                    i5wd.dw0[2].SetItemVisible("ctgw1max", true);
                    i5wd.dw0[2].SetItemVisible("ctgw2min", true);
                    i5wd.dw0[2].SetItemVisible("ctgw2max", true);
                    i5wd.dw0[2].SetItemVisible("cjcw0min", true);
                    i5wd.dw0[2].SetItemVisible("cjcw0avg", true);
                    i5wd.dw0[2].SetItemVisible("cjcw0max", true);
                    i5wd.dw0[2].SetItemVisible("cjcw1min", true);
                    i5wd.dw0[2].SetItemVisible("cjcw1max", true);
                    i5wd.dw0[2].SetItemVisible("cjcw2min", true);
                    i5wd.dw0[2].SetItemVisible("cjcw2max", true);
                    i5wd.dw0[2].SetItemVisible("cjgw0min", true);
                    i5wd.dw0[2].SetItemVisible("cjgw0avg", true);
                    i5wd.dw0[2].SetItemVisible("cjgw0max", true);
                    i5wd.dw0[2].SetItemVisible("cjgw1min", true);
                    i5wd.dw0[2].SetItemVisible("cjgw1max", true);
                    i5wd.dw0[2].SetItemVisible("cjgw2min", true);
                    i5wd.dw0[2].SetItemVisible("cjgw2max", true);

                    i5wd.dw0[2].SetItemVisible("l_1111", true);
                    i5wd.dw0[2].SetItemVisible("l_1112", true);
                    i5wd.dw0[2].SetItemVisible("t_1111", true);
                    i5wd.dw0[2].SetItemVisible("t_1112", true);
                    i5wd.dw0[2].SetItemVisible("t_1113", true);
                    i5wd.dw0[2].SetItemVisible("t_1114", true);

                    i5wd.dw0[25].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2max", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0min", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0avg", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0max", true);
                    i5wd.dw0[25].SetItemVisible("ctgw1min", true);
                    i5wd.dw0[25].SetItemVisible("ctgw1max", true);
                    i5wd.dw0[25].SetItemVisible("ctgw2min", true);
                    i5wd.dw0[25].SetItemVisible("ctgw2max", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0min", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0avg", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0max", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1min", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1max", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2min", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2max", true);
                    i5wd.dw0[25].SetItemVisible("cjgw0min", true);
                    i5wd.dw0[25].SetItemVisible("cjgw0avg", true);
                    i5wd.dw0[25].SetItemVisible("cjgw0max", true);
                    i5wd.dw0[25].SetItemVisible("cjgw1min", true);
                    i5wd.dw0[25].SetItemVisible("cjgw1max", true);
                    i5wd.dw0[25].SetItemVisible("cjgw2min", true);
                    i5wd.dw0[25].SetItemVisible("cjgw2max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw1max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw2max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw1min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw1max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw2min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw2max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw1max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjcw2max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw1min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw1max_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw2min_t", true);
                    i5wd.dw0[25].SetItemVisible("cjgw2max_t", true);
                    break;
                case "磁矩": //Q150
                    is_qbh = "q150";
                    //i5wd.dw0[2].modify('value_max.edit.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_max.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_min.edit.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_min.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_avg.edit.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_avg.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_avg2.edit.format="#,##0.0000"')
                    //i5wd.dw0[2].modify('value_avg2.format="#,##0.0000"')
                    break;
                case "吸力": //Q329
                    is_qbh = "q329";
                    tap31.Text = "常温吸力";
                    break;
                case "高吸": // Q328
                    is_qbh = "q328";
                    tap31.Text = "高温吸力";
                    break;
                case "角度": // Q141
                    is_qbh = "q141";
                    tap31.Text = "角度偏差";
                    i5wd.dw0[25].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[25].SetItemText("ctcw0min_t", "Z方向小");
                    i5wd.dw0[25].SetItemText("ctcw0max_t", "Z方向大");
                    i5wd.dw0[25].SetItemText("ctcw0avg_t", "Z方向平");
                    break;
                case "双表": // Q180
                    is_qbh = "q180";
                    tap31.Text = "双面表场";
                    i5wd.dw0[1].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("ctcw0max_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0min", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0avg", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0max", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0min_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0avg_t", true);
                    i5wd.dw0[1].SetItemVisible("ctgw0max_t", true);

                    i5wd.dw0[2].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[2].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[2].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[2].SetItemVisible("ctgw0min", true);
                    i5wd.dw0[2].SetItemVisible("ctgw0avg", true);
                    i5wd.dw0[2].SetItemVisible("ctgw0max", true);

                    i5wd.dw0[25].SetItemVisible("ctcw0min", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("ctcw0max_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0min", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0avg", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0max", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0min_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0avg_t", true);
                    i5wd.dw0[25].SetItemVisible("ctgw0max_t", true);
                    i5wd.dw0[25].SetItemText("ctcw0min_t", "N极表场小");
                    i5wd.dw0[25].SetItemText("ctcw0max_t", "N极表场大");
                    i5wd.dw0[25].SetItemText("ctcw0avg_t", "N极表场平");
                    i5wd.dw0[25].SetItemText("ctgw0min_t", "S极表场小");
                    i5wd.dw0[25].SetItemText("ctgw0max_t", "S极表场大");
                    i5wd.dw0[25].SetItemText("ctgw0avg_t", "S极表场平");

                    i5wd.dw0[1].SetItemText("ctcw0min_t", "N极表场小");
                    i5wd.dw0[1].SetItemText("ctcw0max_t", "N极表场大");
                    i5wd.dw0[1].SetItemText("ctcw0avg_t", "N极表场平");
                    i5wd.dw0[1].SetItemText("ctgw0min_t", "S极表场小");
                    i5wd.dw0[1].SetItemText("ctgw0max_t", "S极表场大");
                    i5wd.dw0[1].SetItemText("ctgw0avg_t", "S极表场平");

                    i5wd.dw0[2].SetItemVisible("l_1111", true);
                    i5wd.dw0[2].SetItemVisible("l_1112", true);
                    i5wd.dw0[2].SetItemVisible("t_1111", true);
                    i5wd.dw0[2].SetItemVisible("t_1112", true);
                    i5wd.dw0[2].SetItemText("t_1111", "N极表场");
                    i5wd.dw0[2].SetItemText("t_1112", "S极表场");
                    break;
            }
            i5wd.dw0[9].DataObject = "d_cxn_" + is_qbh + "_b_updt";
            i5wd.dw0[17].DataObject = i5wd.dw0[9].DataObject;

            //string ls_sql_cxtj;
            //ls_sql_cxtj = " cxn_h.sy_name = '" + is_sy_name + "' ";
            //global.gu_dw1.f_sql_retrieve("",ls_sql_cxtj,ref i5wd.dw0[1],false);
            //global.gu_dw1.f_sql_retrieve("",ls_sql_cxtj,ref i5wd.dw0[2],false);
        }
        public override int ue_selectionchanged(int oldindex, int newindex)
        {
            if (newindex == 2)
            {

                splitContainer1.SplitterDistance = 500;
                wf_dddw();

            }
            else
            {

                splitContainer1.SplitterDistance = splitContainer1.Height;
            }
            return base.ue_selectionchanged(oldindex, newindex);
        }
        public override long ue_dw_itemchanged00(long al_dw, long row, string dwo, string data)
        {
            //return base.ue_dw_itemchanged00(al_dw, row, dwo, data);
            if (al_dw == 2)
                return ue_dw_itemchanged02(ref al_dw, ref  row, ref  dwo, ref data);
            if (al_dw == 17)
                return ue_dw_itemchanged17(ref al_dw, ref  row, ref dwo, ref  data);
            return 0;
        }
        private long ue_dw_itemchanged02(ref long al_dw, ref long row, ref string dwo, ref string data)
        {
            //return 0;

            //        private long ue_dw_itemchanged02(ref long al_dw, ref long row, ref string dwo, ref string data)
            //        {
            switch (dwo)
            {
                case "riqi":
                case "sl_cy":
                case "pihao":
                    //if (global.gu_dw1.f_dw_col_isnull(row,dwo,data, i5wd.dw0[2]) == -1)
                    //{
                    //     return 2;
                    //   }
                    if (string.IsNullOrEmpty(data))
                        return 2;
                    string ls_cpbh = "", ls_guige = "", ls_dc = "", ls_xn = "";
                    long ll_sl=0, ll_sl_cy = 0, ll_sl_bhg = 0, ll_sy_id = 0, ll_cpbh_id = 0;
                    double ld_zl=0, ld_bili_bhg = 0;
                    string ls_jcgj = "", ls_sysb = "", ls_sytj = "", ls_pdbz = "", ls_aaa1 = "", ls_jgdw = "", ls_ddh = "";
                    switch (dwo)
                    {
                        case "judge":
                        case "manager":
                            i5wd.dw0[2].setitem(row, "pdsj", global.gu_pub1.f_getdate());
                            return 0;
                        case "riqi":
                            if (!wtf_gnqx_delt())
                            {
                                MessageBox.Show("很抱歉！您没有修改删除权限！", "提示");
                                return 2;
                            }
                            break;
                        case "sl_cy":
                            ll_sl_cy = long.Parse(data);
                            ll_sl_bhg = Common.GetLong(i5wd.dw0[2].GetItemData(row, "sl_bhg"));
                            break;
                        case "sl_bhg":
                            ll_sl_bhg = long.Parse(data);
                            ll_sl_cy = Common.GetLong(i5wd.dw0[2].GetItemData(row, "sl_cy"));
                            break;
                        case "lrr":
                            is_lrr = data;
                            break;
                        case "gyy":
                            is_gyy = data;
                            i5wd.dw0[2].setitem(row, "pdsj", global.gu_pub1.f_getdate());
                            return 0;
                        case "fhx":
                            is_fhx = data;
                            i5wd.dw0[2].setitem(row, "pdsj", global.gu_pub1.f_getdate());
                            return 0;
                        case "pihao":
                            string sql = @"select top 1 sy_id 
        			from cxn_h where pihao = @data and sy_name = @is_sy_name ";
                            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
                            SqlParameter para = null;
                            List<IDbDataParameter> paras = new List<IDbDataParameter>();
                            para = new SqlParameter("@data", data);
                            paras.Add(para);
                            para = new SqlParameter("@is_sy_name", is_sy_name);
                            paras.Add(para);
                            DataRow r=DBAccess.Query(sql, paras);
                            if (r != null)
                                ll_sy_id = Convert.ToInt64(r[0]);
                            if (ll_sy_id > 1 && ll_sy_id != Common.GetLong(i5wd.dw0[2].GetItemData(row, "sy_id")))
                            {
                                MessageBox.Show(data + " 批号重复了！");
                            }
                            ls_cpbh = "";
                            sql = @" select top 1 cpbh_id,cpbh,guige,dc,sl ,xn ,zl, jgdw,ddh
        				from dbo.jf_lljs where pihao = @data ;";
                            paras.Clear();
                            para = new SqlParameter("@data", data);
                            paras.Add(para);
                            DataRow dr = DBAccess.Query(sql, paras);
                            if (dr != null)
                            {
                                ll_cpbh_id = Convert.ToInt64(dr[0]);
                                ls_cpbh = Convert.ToString(dr[1]);
                                ls_guige = Convert.ToString(dr[2]);
                                ls_dc = Convert.ToString(dr[3]);
                                ll_sl = Convert.ToInt64(dr[4]);
                                ls_xn = Convert.ToString(dr[5]);
                                  double.TryParse(Common.GetString(dr[6]),out ld_zl);
                                ls_jgdw = Convert.ToString(dr[7]);
                                ls_ddh = Convert.ToString(dr[8]);
                            }
                            if (ls_cpbh == "")
                            {
                                sql = @" select top 1 cpbh_id,cpbh,jggg,jggz,jhcp,xn,jgdw,ddh
        			from jg_jgd_h where jgdh = @data ;";
                                paras.Clear();
                                para = new SqlParameter("@data", data);
                                paras.Add(para);
                                dr = DBAccess.Query(sql, paras);
                                if (dr != null)
                                {
                                    ll_cpbh_id = Convert.ToInt64(dr[0]);
                                    ls_cpbh = Convert.ToString(dr[1]);
                                    ls_guige = Convert.ToString(dr[2]);
                                    ls_dc = Convert.ToString(dr[3]);
                                    ll_sl = Convert.ToInt64(dr[4]);
                                    ls_xn = Convert.ToString(dr[5]);
                                    ls_jgdw = Convert.ToString(dr[6]);
                                    ls_ddh = Convert.ToString(dr[7]);
                                }
                            }
                            i5wd.dw0[2].setitem(row, "cpbh_id", ll_cpbh_id);
                            i5wd.dw0[2].setitem(row, "cpbh", ls_cpbh);
                            i5wd.dw0[2].setitem(row, "guige", ls_guige);
                            i5wd.dw0[2].setitem(row, "dc", ls_dc);
                            i5wd.dw0[2].setitem(row, "xn", ls_xn);
                            i5wd.dw0[2].setitem(row, "sl", ll_sl);
                            i5wd.dw0[2].setitem(row, "zl", ld_zl);
                            i5wd.dw0[2].setitem(row, "jgdw", ls_jgdw);
                            i5wd.dw0[2].setitem(row, "ddh", ls_ddh);
                            if (ls_cpbh == null || ls_cpbh.Trim() == "" || ls_cpbh.ToUpper() == "NO")
                            {

                            }
                            else
                            {
                                i5wd.dw0[25].Retrieve(ls_cpbh, is_sy_name);
                                if (i5wd.dw0[25].rowcount() >= 1)
                                {
                                    i5wd.dw0[2].setitem(row, "jcgj", i5wd.dw0[25].GetItemData(1, "jcgj"));
                                    //				i5wd.dw0[2].setitem(row , "sysb" , i5wd.dw0[25].getitemstring(1,"sysb"))
                                    i5wd.dw0[2].setitem(row, "sytj", i5wd.dw0[25].GetItemData(1, "sytj"));
                                    i5wd.dw0[2].setitem(row, "pdbz", i5wd.dw0[25].GetItemData(1, "pdbz"));
                                    i5wd.dw0[2].setitem(row, "aaa1", i5wd.dw0[25].GetItemData(1, "aaa1"));
                                    i5wd.dw0[2].setitem(row, "bbb1", i5wd.dw0[25].GetItemData(1, "bbb1"));
                                    i5wd.dw0[2].setitem(row, "manager", i5wd.dw0[25].GetItemData(1, "manager"));
                                    i5wd.dw0[2].setitem(row, "gyy", i5wd.dw0[25].GetItemData(1, "gyy"));
                                    i5wd.dw0[2].setitem(row, "mubiaozhi", i5wd.dw0[25].GetItemData(1, "mubiaozhi"));
                                    i5wd.dw0[2].setitem(row, "shangpiancha", i5wd.dw0[25].GetItemData(1, "shangpiancha"));
                                    i5wd.dw0[2].setitem(row, "xiapiancha", i5wd.dw0[25].GetItemData(1, "xiapiancha"));
                                    i5wd.dw0[2].setitem(row, "guke", i5wd.dw0[25].GetItemData(1, "guke"));
                                    i5wd.dw0[2].setitem(row, "ceshixiangmu", i5wd.dw0[25].GetItemData(1, "ceshixiangmu"));
                                    i5wd.dw0[2].setitem(row, "ccc1", i5wd.dw0[25].GetItemData(1, "ccc1"));

                                    //				i5wd.dw0[2].setitem(row , "wendu1" , gu_pub1.f_rounnd(i5wd.dw0[25].getitemnumber(1,"wendu1") , 1))
                                    //				i5wd.dw0[2].setitem(row , "wendu2" , gu_pub1.f_rounnd(i5wd.dw0[25].getitemnumber(1,"wendu2") , 1))
                                    i5wd.dw0[2].setitem(row, "bz1min", i5wd.dw0[25].GetItemData(1, "bz1min"));
                                    i5wd.dw0[2].setitem(row, "bz1max", i5wd.dw0[25].GetItemData(1, "bz1max"));
                                    i5wd.dw0[2].setitem(row, "bz2min", i5wd.dw0[25].GetItemData(1, "bz2min"));
                                    i5wd.dw0[2].setitem(row, "bz2max", i5wd.dw0[25].GetItemData(1, "bz2max"));
                                    i5wd.dw0[2].setitem(row, "ctcw1min", i5wd.dw0[25].GetItemData(1, "ctcw1min"));
                                    i5wd.dw0[2].setitem(row, "ctcw1max", i5wd.dw0[25].GetItemData(1, "ctcw1max"));
                                    i5wd.dw0[2].setitem(row, "ctcw2min", i5wd.dw0[25].GetItemData(1, "ctcw2min"));
                                    i5wd.dw0[2].setitem(row, "ctcw2max", i5wd.dw0[25].GetItemData(1, "ctcw2max"));
                                    i5wd.dw0[2].setitem(row, "ctgw1min", i5wd.dw0[25].GetItemData(1, "ctgw1min"));
                                    i5wd.dw0[2].setitem(row, "ctgw1max", i5wd.dw0[25].GetItemData(1, "ctgw1max"));
                                    i5wd.dw0[2].setitem(row, "ctgw2min", i5wd.dw0[25].GetItemData(1, "ctgw2min"));
                                    i5wd.dw0[2].setitem(row, "ctgw2max", i5wd.dw0[25].GetItemData(1, "ctgw2max"));
                                    i5wd.dw0[2].setitem(row, "cjcw1min", i5wd.dw0[25].GetItemData(1, "cjcw1min"));
                                    i5wd.dw0[2].setitem(row, "cjcw1max", i5wd.dw0[25].GetItemData(1, "cjcw1max"));
                                    i5wd.dw0[2].setitem(row, "cjcw2min", i5wd.dw0[25].GetItemData(1, "cjcw2min"));
                                    i5wd.dw0[2].setitem(row, "cjcw2max", i5wd.dw0[25].GetItemData(1, "cjcw2max"));
                                    i5wd.dw0[2].setitem(row, "cjgw1min", i5wd.dw0[25].GetItemData(1, "cjgw1min"));
                                    i5wd.dw0[2].setitem(row, "cjgw1max", i5wd.dw0[25].GetItemData(1, "cjgw1max"));
                                    i5wd.dw0[2].setitem(row, "cjgw2min", i5wd.dw0[25].GetItemData(1, "cjgw2min"));
                                    i5wd.dw0[2].setitem(row, "cjgw2max", i5wd.dw0[25].GetItemData(1, "cjgw2max"));
                                }
                            }
                            switch (dwo)
                            {
                                case "sl_cy":
                                case "sl_bhg":
                                    if (ll_sl_cy == 0 || ll_sl_cy == null)
                                    {
                                        //setnull(ld_bili_bhg)；
                                    }
                                    else
                                    {
                                        ld_bili_bhg = ll_sl_bhg * 100 / ll_sl_cy;
                                    }
                                    i5wd.dw0[2].setitem(row, "bili_bhg", ld_bili_bhg);
                                    break;
                            }

                            long ll_i = 0;
                            double ld_tmp1, ld_tmp2, ld_null = 0, ld_cjxs, ld_khxs = 0;
                            //setnull(ld_null);
                              double.TryParse(i5wd.dw0[2].GetItemData(1, "bbb1"),out ld_cjxs);
                              double.TryParse(i5wd.dw0[2].GetItemData(1, "ccc1"),out ld_khxs);
                            switch (is_shiyan)
                            {
                                case "磁矩":
                                    switch (dwo)
                                    {
                                        case "bbb1":
                                              double.TryParse(data,out ld_cjxs);
                                            break;
                                        case "ccc1":
                                              double.TryParse(data,out ld_khxs);
                                            break;
                                    }
                                    switch (dwo)
                                    {
                                        case "bbb1":
                                        case "ccc1":
                                            if (ld_cjxs <= 0 || ld_cjxs == null)
                                            {
                                                for (int i = 0; i < i5wd.dw0[17].rowcount(); i++)
                                                {
                                                    i5wd.dw0[17].setitem(ll_i, "bb", ld_null);
                                                }
                                                return 0;
                                            }
                                            if (ld_khxs < 0 || ld_khxs == null)
                                                ld_khxs = 1;
                                            for (int i = 0; i < i5wd.dw0[17].rowcount(); i++)
                                            {
                                                //i5wd.dw0[17].setitem(ll_i,"bb",global.gu_pub1.f(i5wd.dw0[17].getitemnumber(ll_i,"aa") * ld_cjxs * ld_khxs ,4));
                                            }
                                            break;
                                    }
                                    break;
                                case "磁通":
                                    switch (dwo)
                                    {
                                        case "bbb1":
                                              double.TryParse(data,out ld_cjxs);
                                            break;
                                        case "ccc1":
                                              double.TryParse(data,out ld_khxs);
                                            break;
                                    }
                                    switch (dwo)
                                    {
                                        case "bbb1":
                                        case "ccc1":
                                            if (ld_cjxs <= 0) ld_cjxs = 0;
                                            if (ld_khxs <= 0) ld_khxs = 1;
                                            for (ll_i = 0; ll_i < i5wd.dw0[17].rowcount(); ll_i++)
                                            {
                                                if (ld_cjxs == 0)
                                                    i5wd.dw0[17].setitem(ll_i, "cc", ld_null);
                                                else
                                                    i5wd.dw0[17].setitem(ll_i, "cc", Math.Round(i5wd.dw0[17].getitemnumber(ll_i, "aa") * ld_cjxs * ld_khxs, 4));

                                                if (ld_khxs == 1)
                                                    i5wd.dw0[17].setitem(ll_i, "bb", ld_null);
                                                else
                                                    i5wd.dw0[17].setitem(ll_i, "bb", Math.Round(i5wd.dw0[17].getitemnumber(ll_i, "aa") * ld_khxs, 4));

                                            }
                                            break;
                                    }
                                    break;
                                case "高减":
                                case "高矩":
                                    switch (dwo)
                                    {
                                        case "bbb1":
                                              double.TryParse(data,out ld_cjxs);
                                            break;
                                        case "ccc1":
                                              double.TryParse(data,out ld_khxs);
                                            break;
                                    }
                                    switch (dwo)
                                    {
                                        case "bbb1":
                                        case "ccc1":
                                            {
                                                if (ld_cjxs <= 0)
                                                {
                                                    for (ll_i = 0; ll_i < i5wd.dw0[17].rowcount(); ll_i++)
                                                    {
                                                        i5wd.dw0[17].setitem(ll_i, "dd", ld_null);
                                                        i5wd.dw0[17].setitem(ll_i, "ee", ld_null);
                                                    }
                                                    return 0;
                                                }
                                                if (ld_khxs < 0) ld_khxs = 1;
                                                for (ll_i = 0; ll_i < i5wd.dw0[17].rowcount(); ll_i++)
                                                {
                                                    i5wd.dw0[17].setitem(ll_i, "dd", Math.Round(i5wd.dw0[17].getitemnumber(ll_i, "aa") * ld_cjxs * ld_khxs, 4));
                                                    i5wd.dw0[17].setitem(ll_i, "ee", Math.Round(i5wd.dw0[17].getitemnumber(ll_i, "bb") * ld_cjxs * ld_khxs, 4));
                                                }
                                            }
                                            break;
                                    }

                                    i5wd.dw0[al_dw].setitem(row, "xgsj", global.gu_pub1.f_getdate());
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return 0;
        }
        //return 0;

        //        }
        //        private 
        private long ue_dw_itemchanged17(ref long al_dw, ref long row, ref string dwo, ref string data)
        {
            i5wd.dw0[17].setitem(row, "xgsj", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return 0;
        }
        private void dw_t02_ItemChanged(object sender, ItemChangedEventArgs e)
        {

        }

        private void cb_copy_nw_Click(object sender, EventArgs e)
        {
            //TODO:if not wtf_gnqx_other("4复制") then
            //messagebox("提示","很抱歉！您没有复制权限！")
            if (this.cb_save.Enabled)
            {
                MessageBox.Show("很抱歉！还没有保存！");
                return;
            }

            string ls_namesy;
            if (is_nw == "N")
            {
                ls_namesy = is_shiyan + "W";
            }
            else
            {
                ls_namesy = is_shiyan + "N";
            }
            if (MessageBox.Show("您确实要从 " + is_sy_name + " 拷贝到 " + ls_namesy + " 吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (i5wd.dw0[2].rowcount() != 1)
            {
                MessageBox.Show("出错了，拷贝失败！");
                return;
            }
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            string ls_return = string.Empty;
            //TODO:
            /*
if not SQLCA.AutoCommit then
	rollback;
	messagebox("提示","SQLCA.AutoCommit应为true，现在是false")*/
            //            string sqlProc = @"

            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = null;
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@sy_id", i5wd.l_idid[2]);
            paras.Add(para);
            para = new SqlParameter("@fuzhi", "内外部复制");
            paras.Add(para);
            para = new SqlParameter("@cjxs", "");
            paras.Add(para);
            para = new SqlParameter("@cpbh", "");
            paras.Add(para);
            para = new SqlParameter("@sy_name", ls_namesy);
            paras.Add(para);
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;

            try
            {
                ls_return = DBAccess.ExecSP("cxn_h_copy", paras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示信息", "连库有误,操作失败。" + ex.Message);
                return;
            }

            long ll_return;
            if (long.TryParse(ls_return, out ll_return))
            {
                ll_return = long.Parse(ls_return);
            }
            else
            {
                ll_return = 0;
            }
            if (ll_return != 0)
            {
                switch (ll_return)
                {
                    case 107:
                        MessageBox.Show("磁矩系数不能转化为数值！");
                        break;
                    default:
                        MessageBox.Show("操作错误，导致数据库执行了 " + ls_return + " 回滚操作！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("拷贝成功，从 " + is_sy_name + " 拷贝到 " + ls_namesy);
            }
        }

        private void cb_q039_cwcj_Click(object sender, EventArgs e)
        {
            //TODO:
            //        if not wtf_gnqx_other("4复制") then
            //messagebox("提示","很抱歉！您没有复制权限！")
            //return -1
            if (cb_save.Enabled)
            {
                MessageBox.Show("很抱歉！还没有保存！");
                return;
            }


            string ls_return = string.Empty, ls_cjxs, ls_khxs, ls_cpbh;
            string ls_namesy;
            ls_namesy = "磁矩" + is_sy_name.Substring(is_sy_name.Length - 1, 1);

            if (MessageBox.Show("您确实要从 " + is_sy_name + " 拷贝到 " + ls_namesy + " 吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (i5wd.dw0[2].rowcount() != 1)
            {
                MessageBox.Show("出错了，拷贝失败！");
                return;
            }
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            ls_cjxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "bbb1"));
            ls_khxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "ccc1"));
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            long result;
            if (!long.TryParse(ls_cjxs, out result) || ls_cjxs == null || ls_cjxs.Trim() == "")
            {
                MessageBox.Show("磁矩系数不能转化为数值，拷贝失败！");
                return;
            }
            if (!long.TryParse(ls_khxs, out result) || ls_khxs == null || ls_khxs.Trim() == "")
            {
                MessageBox.Show("客户系数不能转化为数值，拷贝失败！");
                return;
            };
            ls_cjxs = ls_cjxs + ";" + ls_khxs;
            //TODO:
            //if not SQLCA.AutoCommit then
            //    rollback;
            //    messagebox("提示","SQLCA.AutoCommit应为true，现在是false")
            //    return -1
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;
            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = null;
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@sy_id", i5wd.l_idid[2]);
            paras.Add(para);
            para = new SqlParameter("@fuzhi", "高减常温->磁矩");
            paras.Add(para);
            para = new SqlParameter("@cjxs", ls_cjxs);
            paras.Add(para);
            para = new SqlParameter("@cpbh", ls_cpbh);
            paras.Add(para);
            para = new SqlParameter("@sy_name", ls_namesy);
            paras.Add(para);
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;

            try
            {
                ls_return = DBAccess.ExecSP("cxn_h_copy", paras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示信息", "连库有误,操作失败。" + ex.Message);
                return;
            }

            long ll_return;
            if (long.TryParse(ls_return, out result))
            {
                ll_return = long.Parse(ls_return);
            }
            else
            {
                ll_return = 0;
            };

            if (ll_return != 0)
            {
                switch (ll_return)
                {
                    case 107:
                        MessageBox.Show("磁矩系数不能转化为数值！");
                        break;
                    default:
                        MessageBox.Show("操作错误，导致数据库执行了 " + ls_return + " 回滚操作！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("拷贝成功，从 " + is_sy_name + " 拷贝到 " + ls_namesy);
            }
        }

        private void cb_q039_gwcj_Click(object sender, EventArgs e)
        {
            //TODO:
            //        if not wtf_gnqx_other("4复制") then
            //messagebox("提示","很抱歉！您没有复制权限！")
            //return -1
            if (cb_save.Enabled)
            {
                MessageBox.Show("很抱歉！还没有保存！");
                return;
            }

            string ls_return = string.Empty, ls_cjxs, ls_khxs, ls_cpbh;
            string ls_namesy;
            ls_namesy = "磁矩" + is_sy_name.Substring(is_sy_name.Length - 1, 1) + "G";

            if (MessageBox.Show("您确实要从 " + is_sy_name + " 的高温磁通拷贝到 " + ls_namesy + " 吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (i5wd.dw0[2].rowcount() != 1)
            {
                MessageBox.Show("出错了，拷贝失败！");
                return;
            }
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            ls_cjxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "bbb1"));
            ls_khxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "ccc1"));
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            long result;
            if (!long.TryParse(ls_cjxs, out result) || ls_cjxs == null || ls_cjxs.Trim() == "")
            {
                MessageBox.Show("磁矩系数不能转化为数值，拷贝失败！");
                return;
            }
            if (!long.TryParse(ls_khxs, out result) || ls_khxs == null || ls_khxs.Trim() == "")
            {
                MessageBox.Show("客户系数不能转化为数值，拷贝失败！");
                return;
            };
            ls_cjxs = ls_cjxs + ";" + ls_khxs;
            //TODO:
            //if not SQLCA.AutoCommit then
            //    rollback;
            //    messagebox("提示","SQLCA.AutoCommit应为true，现在是false")
            //    return -1
            //end if

            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;
            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = null;
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@sy_id", i5wd.l_idid[2]);
            paras.Add(para);
            para = new SqlParameter("@fuzhi", "高减高温->磁矩");
            paras.Add(para);
            para = new SqlParameter("@cjxs", ls_cjxs);
            paras.Add(para);
            para = new SqlParameter("@cpbh", ls_cpbh);
            paras.Add(para);
            para = new SqlParameter("@sy_name", ls_namesy);
            paras.Add(para);
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;

            try
            {
                ls_return = DBAccess.ExecSP("cxn_h_copy", paras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示信息", "连库有误,操作失败。" + ex.Message);
                return;
            }


            long ll_return;
            if (long.TryParse(ls_return, out result))
            {
                ll_return = long.Parse(ls_return);
            }
            else
            {
                ll_return = 0;
            };

            if (ll_return != 0)
            {
                switch (ll_return)
                {
                    case 107:
                        MessageBox.Show("磁矩系数不能转化为数值！");
                        break;
                    default:
                        MessageBox.Show("操作错误，导致数据库执行了 " + ls_return + " 回滚操作！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("拷贝成功，从 " + is_sy_name + " 拷贝到 " + ls_namesy);
            }
        }

        private void cb_q039_cwct_Click(object sender, EventArgs e)
        {
            //TODO:
            //        if not wtf_gnqx_other("4复制") then
            //messagebox("提示","很抱歉！您没有复制权限！")
            //return -1
            if (cb_save.Enabled)
            {
                MessageBox.Show("很抱歉！还没有保存！");
                return;
            }

            string ls_return = string.Empty, ls_cpbh;
            string ls_namesy;
            ls_namesy = "磁通" + is_sy_name.Substring(is_sy_name.Length - 1, 1);

            if (MessageBox.Show("您确实要从 " + is_sy_name + " 拷贝到 " + ls_namesy + " 吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            if (i5wd.dw0[2].rowcount() != 1)
            {
                MessageBox.Show("出错了，拷贝失败！");
                return;
            }
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            //TODO:
            //if not SQLCA.AutoCommit then
            //    rollback;
            //    messagebox("提示","SQLCA.AutoCommit应为true，现在是false")
            //    return -1

            SqlParameter para = null;
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@sy_id", i5wd.l_idid[2]);
            paras.Add(para);
            para = new SqlParameter("@fuzhi", "高减常温->磁通");
            paras.Add(para);
            para = new SqlParameter("@cjxs", "");
            paras.Add(para);
            para = new SqlParameter("@cpbh", ls_cpbh);
            paras.Add(para);
            para = new SqlParameter("@sy_name", ls_namesy);
            paras.Add(para);
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;

            try
            {
                ls_return = DBAccess.ExecSP("cxn_h_copy", paras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示信息", "连库有误,操作失败。" + ex.Message);
                return;
            }

            long ll_return;
            long result;
            if (long.TryParse(ls_return, out result))
            {
                ll_return = long.Parse(ls_return);
            }
            else
            {
                ll_return = 0;
            };

            if (ll_return != 0)
            {
                switch (ll_return)
                {
                    case 107:
                        MessageBox.Show("磁矩系数不能转化为数值！");
                        break;
                    default:
                        MessageBox.Show("操作错误，导致数据库执行了 " + ls_return + " 回滚操作！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("拷贝成功，从 " + is_sy_name + " 拷贝到 " + ls_namesy);
            }
        }

        private void cb_q330_ctcj_Click(object sender, EventArgs e)
        {
            //TODO:
            //        if not wtf_gnqx_other("4复制") then
            //messagebox("提示","很抱歉！您没有复制权限！")
            //return -1
            if (cb_save.Enabled)
            {
                MessageBox.Show("很抱歉！还没有保存！");
                return;
            }

            string ls_return = string.Empty, ls_cjxs, ls_khxs, ls_cpbh;
            string ls_namesy;
            ls_namesy = "磁矩" + is_sy_name.Substring(is_sy_name.Length - 1, 1);
            if (MessageBox.Show("您确实要从 " + is_sy_name + " 拷贝到 " + ls_namesy + " 吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            if (i5wd.dw0[2].rowcount() != 1)
            {
                MessageBox.Show("出错了，拷贝失败！");
                return;
            }
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            ls_cjxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "bbb1"));
            ls_khxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "ccc1"));
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            long result;
            if (!long.TryParse(ls_cjxs, out result) || ls_cjxs == null || ls_cjxs.Trim() == "")
            {
                MessageBox.Show("磁矩系数不能转化为数值，拷贝失败！");
                return;
            }
            if (!long.TryParse(ls_khxs, out result) || ls_khxs == null || ls_khxs.Trim() == "")
            {
                MessageBox.Show("客户系数不能转化为数值，拷贝失败！");
                return;
            }
            ls_cjxs = ls_cjxs + ";" + ls_khxs;
            //TODO:
            //if not SQLCA.AutoCommit then
            //    rollback;
            //    messagebox("提示","SQLCA.AutoCommit应为true，现在是false")
            //    return -1

            SqlParameter para = null;
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@sy_id", i5wd.l_idid[2]);
            paras.Add(para);
            para = new SqlParameter("@fuzhi", "磁通->磁矩");
            paras.Add(para);
            para = new SqlParameter("@cjxs", ls_cjxs);
            paras.Add(para);
            para = new SqlParameter("@cpbh", ls_cpbh);
            paras.Add(para);
            para = new SqlParameter("@sy_name", ls_namesy);
            paras.Add(para);
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;

            try
            {
                ls_return = DBAccess.ExecSP("cxn_h_copy", paras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连库有误,操作失败。" + ex.Message);
                return;
            }

            long ll_return;
            if (long.TryParse(ls_return, out result))
            {
                ll_return = long.Parse(ls_return);
            }
            else
            {
                ll_return = 0;
            };

            if (ll_return != 0)
            {
                switch (ll_return)
                {
                    case 107:
                        MessageBox.Show("磁矩系数不能转化为数值！");
                        break;
                    default:
                        MessageBox.Show("操作错误，导致数据库执行了 " + ls_return + " 回滚操作！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("拷贝成功，从 " + is_sy_name + " 拷贝到 " + ls_namesy);
            }
        }

        private void cb_q412_gjgj_Click(object sender, EventArgs e)
        {
            //TODO:
            //        if not wtf_gnqx_other("4复制") then
            //messagebox("提示","很抱歉！您没有复制权限！")
            //return -1
            if (cb_save.Enabled)
            {
                MessageBox.Show("很抱歉！还没有保存！");
                return;
            }

            string ls_return = string.Empty, ls_cjxs, ls_khxs, ls_cpbh;
            string ls_namesy;
            ls_namesy = "高矩" + is_sy_name.Substring(is_sy_name.Length - 1, 1);
            if (MessageBox.Show("您确实要从 " + is_sy_name + " 拷贝到 " + ls_namesy + " 吗？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (i5wd.dw0[2].rowcount() != 1)
            {
                MessageBox.Show("出错了，拷贝失败！");
                return;
            }
            if (i5wd.l_idid[2] != Common.GetLong(i5wd.dw0[2].GetItemData(1, "sy_id")))
            {
                MessageBox.Show("出错了，拷贝失败！请记下详细的操作步骤，并重现此操作以查找错误！");
                return;
            }
            ls_cjxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "bbb1"));
            ls_khxs = Common.GetString(i5wd.dw0[2].GetItemData(1, "ccc1"));
            ls_cpbh = Common.GetString(i5wd.dw0[2].GetItemData(1, "cpbh"));
            long result;
            if (!long.TryParse(ls_cjxs, out result) || ls_cjxs == null || ls_cjxs.Trim() == "")
            {
                MessageBox.Show("磁矩系数不能转化为数值，拷贝失败！");
                return;
            }
            if (!long.TryParse(ls_khxs, out result) || ls_khxs == null || ls_khxs.Trim() == "")
            {
                MessageBox.Show("客户系数不能转化为数值，拷贝失败！");
                return;
            }
            ls_cjxs = ls_cjxs + ";" + ls_khxs;
            //TODO:
            //if not SQLCA.AutoCommit then
            //    rollback;
            //    messagebox("提示","SQLCA.AutoCommit应为true，现在是false")
            //    return -1


            SqlParameter para = null;
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@sy_id", i5wd.l_idid[2]);
            paras.Add(para);
            para = new SqlParameter("@fuzhi", "高减->高矩");
            paras.Add(para);
            para = new SqlParameter("@cjxs", ls_cjxs);
            paras.Add(para);
            para = new SqlParameter("@cpbh", ls_cpbh);
            paras.Add(para);
            para = new SqlParameter("@sy_name", ls_namesy);
            paras.Add(para);
            //TODO:
            //if sqlca.sqlcode = 0 then
            //    //
            //else
            //    messagebox("提示信息","连库有误,操作失败。"+SQLCA.SQLErrText);
            //    return;

            try
            {
                ls_return = DBAccess.ExecSP("cxn_h_copy", paras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示信息", "连库有误,操作失败。" + ex.Message);
                return;
            }

            long ll_return;
            if (long.TryParse(ls_return, out result))
            {
                ll_return = long.Parse(ls_return);
            }
            else
            {
                ll_return = 0;
            };

            if (ll_return != 0)
            {
                switch (ll_return)
                {
                    case 107:
                        MessageBox.Show("磁矩系数不能转化为数值！");
                        break;
                    default:
                        MessageBox.Show("操作错误，导致数据库执行了 " + ls_return + " 回滚操作！");
                        break;
                }
            }
            else
            {
                MessageBox.Show("拷贝成功，从 " + is_sy_name + " 拷贝到 " + ls_namesy);
            }
        }

        public void wf_dddw()
        {
            dw_t02.IsRetrieve = true;
            dw_t02.InitCombobox("jcgj", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "jcgj", "");
            dw_t02.InitCombobox("aaa1", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "aaa1", "");
            dw_t02.InitCombobox("cbph", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "cpbh", "");
            dw_t02.InitCombobox("fhx", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "fhx", "");
            dw_t02.InitCombobox("guige", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "guige", "");
            dw_t02.InitCombobox("gyy", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "gyy", "");
            dw_t02.InitCombobox("lrr", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "lrr", "");
            dw_t02.InitCombobox("pdbz", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "pdbz", "");
            dw_t02.InitCombobox("shiyanren", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "shiyanren", "");
            dw_t02.InitCombobox("sysb", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "sysb", "");
            dw_t02.InitCombobox("sytj", "cxn_h", "riqi>= getdate() -400 and sy_name='" + is_sy_name + "'", "sytj", "");
            dw_t02.IsRetrieve = false;
        }

        public override long ue_inst_after(long ll_newrow)
        {
            i5wd.dw0[2].setitem(ll_newrow, "riqi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            i5wd.dw0[2].setitem(ll_newrow, "sy_name", is_sy_name);
            i5wd.dw0[2].setitem(ll_newrow, "lrr", is_lrr);
            i5wd.dw0[2].setitem(ll_newrow, "gyy", is_gyy);
            i5wd.dw0[2].setitem(ll_newrow, "fhx", is_fhx);
            i5wd.dw0[25].reset();

            switch (is_shiyan)
            {
                case "表场":// Q326
                case "磁通":// Q330
                    i5wd.dw0[2].setitem(ll_newrow, "ccc1", "1");
                    break;
                case "高减": //Q039
                    i5wd.dw0[2].setitem(ll_newrow, "ccc1", "1");
                    break;
                case "磁矩": //Q150
                    i5wd.dw0[2].setitem(ll_newrow, "ccc1", "1");
                    break;
                case "吸力": //Q329
                case "高吸": // Q328
                case "角度": // Q141
                case "双表": // Q180
                    break;
                default:
                    break;
            }

            return 1;
        }
        public override long ue_save_pre()
        {
            //return base.ue_save_pre();
            DateTime ldt_riqi;
            long ll_bianhao, ll_bh_count, ll_sl_sj;
            //i5wd.dw0[17].accepttext();
            //i5wd.dw0[2].accepttext();

            double ld_value_min = 0, ld_value_max = 0;
            double ld_bz1_min = 0, ld_bz1_max = 0, ld_bz2_min = 0, ld_bz2_max = 0;
            string ls_judge;
            try
            {
                ld_value_min = long.Parse(i5wd.dw0[2].GetItemData(1, "value_min"));
                ld_value_max = long.Parse(i5wd.dw0[2].GetItemData(1, "value_max"));
                ld_bz1_min = long.Parse(i5wd.dw0[2].GetItemData(1, "bz1min"));
                ld_bz1_max = long.Parse(i5wd.dw0[2].GetItemData(1, "bz1max"));
                ld_bz2_min = long.Parse(i5wd.dw0[2].GetItemData(1, "bz2min"));
                ld_bz2_max = long.Parse(i5wd.dw0[2].GetItemData(1, "bz2max"));
            }
            catch { }
            ls_judge = i5wd.dw0[2].GetItemData(1, "judge");
            if (ls_judge == "合格" && is_nw == "N")
            {
                if (ld_value_min < ld_bz1_min || (ld_value_max > ld_bz1_max && ld_bz1_max > 0))
                {
                    MessageBox.Show("最小值或最大值超标1");
                    return -1;
                }
                if (ld_value_min < ld_bz2_min || (ld_value_max > ld_bz2_max && ld_bz2_max > 0))
                {
                    MessageBox.Show("最小值或最大值超标2");
                    return -1;
                }
            }


            //if global.gu_dw1.f_dw_col_isnull("pihao",i5wd.dw0[2]) = -1 then return -1


            if (string.IsNullOrEmpty(i5wd.dw0[2].GetItemData(1, "riqi")))
            {
                MessageBox.Show("日期没有录入");
                return -1;
            }
            ldt_riqi = DateTime.Parse(i5wd.dw0[2].GetItemData(1, "riqi"));
            if (!wtf_gnqx_updt())
            {
                MessageBox.Show("很抱歉！您没有修改权限！");
                return -1;
            }

            long.TryParse(i5wd.dw0[2].GetItemData(1, "bianhao"), out ll_bianhao);
            if (ldt_riqi.Day > (global.gu_pub1.f_getdate().Day))
            {
                MessageBox.Show("很抱歉！日期不能大于当天！");
                return -1;
            }
            if (ldt_riqi.CompareTo(DateTime.Parse("2000-01-01")) < 0)
            {
                MessageBox.Show("很抱歉！日期不能小于2000-01-01！");
                return -1;
            }
            ll_sl_sj = i5wd.dw0[17].rowcount();
            if (ll_sl_sj == 0 || ll_sl_sj is Nullable)
            {
                MessageBox.Show("很抱歉！实际数量为0！");
                return -1;
            }
            if (ll_sl_sj != long.Parse(i5wd.dw0[2].GetItemData(1, "sl_cy")))
            {
                MessageBox.Show("很抱歉！实际数量和抽样数量不相同！");
                return -1;
            }

            if (ll_bianhao == 0)
            {
                //select max(bianhao) into :ll_bianhao from dbo.cxn_h where riqi = :ldt_riqi and sy_name = :is_sy_name ;
                //if ll_bianhao = 0 or isnull(ll_bianhao) then ll_bianhao = 0
                //ll_bianhao = ll_bianhao + 1;
                i5wd.dw0[2].setitem(1, "bianhao", ll_bianhao);
            }
            else
            {
                ll_bh_count = 0;
                //select count(bianhao) into :ll_bh_count from dbo.cxn_h 
                //    where riqi = :ldt_riqi and sy_name = :is_sy_name and sy_id <> :i5wd.l_idid[2] and bianhao = :ll_bianhao ;
                if (ll_bh_count >= 1)
                {
                    //select max(bianhao) into :ll_bianhao from dbo.cxn_h where riqi = :ldt_riqi and sy_name = :is_sy_name ;
                    //if ll_bianhao = 0 or isnull(ll_bianhao) then ll_bianhao = 0
                    //ll_bianhao = ll_bianhao + 1
                    i5wd.dw0[2].setitem(1, "bianhao", ll_bianhao);
                }
            }


            i5wd.dw0[2].setitem(1, "sl_sj", i5wd.dw0[17].rowcount());
            wf_max_min_avg0();
            // wf_judge();

            return 1;
        }
        public void wf_max_min_avg0()
        {
            string ls_zd = "";
            int li_round = 0;
            switch (is_shiyan)
            {
                case "表场": // Q326
                    wf_max_min_sb_q326();
                    return;
                case "磁通": // Q330
                    ls_zd = "aa";
                    li_round = 2;
                    wf_max_min_avg1("bb", li_round, "ctcw0");
                    wf_max_min_avg1("cc", 4, "cjcw0");
                    break;
                case "高减":
                case "高矩": //Q039 Q412
                    ls_zd = "cc";
                    li_round = 2;
                    wf_max_min_avg1("aa", li_round, "ctcw0");
                    wf_max_min_avg1("bb", li_round, "ctgw0");
                    wf_max_min_avg1("dd", 4, "cjcw0");
                    wf_max_min_avg1("ee", 4, "cjgw0");
                    break;
                case "磁矩": //Q150
                    ls_zd = "bb";
                    li_round = 4;
                    break;
                case "吸力"://Q329
                    ls_zd = "aa";
                    li_round = 2;
                    break;
                case "高吸": // Q328
                    ls_zd = "cc";
                    li_round = 2;
                    break;
                case "角度": // Q141
                    ls_zd = "dd";
                    li_round = 2;
                    wf_max_min_avg1("cc", li_round, "ctcw0");
                    break;
                case "双表": // Q180;
                    ls_zd = "cc";
                    li_round = 2;
                    wf_max_min_avg1("aa", li_round, "ctcw0");
                    wf_max_min_avg1("bb", li_round, "ctgw0");
                    break;
            }
            wf_max_min_avg1(ls_zd, li_round, "value_");

        }
        public void wf_max_min_avg1(string as_zd, int ai_round, string as_minmax)
        {
            if (i5wd.dw0[17].rowcount() <= 0) return;
            double ld_max, ld_min, ld_tt, ld_temp, ld_avg = 0;
            long ll_sl, ll_i;
            ld_max = 0;
            ld_min = 10000000;
            ld_tt = 0;
            ll_sl = 0;
            for (ll_i = 0; ll_i < i5wd.dw0[17].rowcount(); ll_i++)
            {
                double.TryParse(i5wd.dw0[17].GetItemData(ll_i, as_zd), out ld_temp);
                if (ld_temp >= 0)
                {
                    ll_sl++;
                    ld_tt += ld_temp;
                    if (ld_temp > ld_max)
                        ld_max = ld_temp;

                    if (ld_temp < ld_min)
                        ld_min = ld_temp;

                }
            }
            if (ll_sl == 0)
            {
                //setnull(ld_avg)
                //setnull(ld_min)
                //setnull(ld_max)
            }
            else
            {
                //ld_avg = global.gu_pub1.f_rounnd(ld_tt / ll_sl, ai_round);
                ld_avg = Math.Round(ld_tt / ll_sl, ai_round);
            }

            i5wd.dw0[2].setitem(1, as_minmax + "avg", ld_avg);
            i5wd.dw0[2].setitem(1, as_minmax + "min", ld_min);
            i5wd.dw0[2].setitem(1, as_minmax + "max", ld_max);

        }
        public void wf_max_min_sb_q326()
        {
            if (i5wd.dw0[17].rowcount() <= 0) return;
            double ld_max = 0, ld_min = 0, ld_tt = 0, ld_temp = 0, ld_avg = 0;
            long ll_sl = 0, ll_i = 0;
            ld_max = 0;
            ld_min = 10000000;
            ld_tt = 0;
            ll_sl = 0;
            for (ll_i = 0; ll_i < i5wd.dw0[17].rowcount(); ll_i++)
            {
                double.TryParse(i5wd.dw0[17].GetItemData(ll_i, "aa"), out ld_temp);
                if (ld_temp >= 0)
                {
                    ll_sl = ll_sl + 1;
                    ld_tt = ld_tt + ld_temp;
                    if (ld_temp > ld_max)
                        ld_max = ld_temp;

                    if (ld_temp < ld_min)
                        ld_min = ld_temp;

                }
                double.TryParse(i5wd.dw0[17].GetItemData(ll_i, "bb"), out ld_temp);
                if (ld_temp >= 0)
                    ll_sl = ll_sl + 1;
                ld_tt = ld_tt + ld_temp;
                if (ld_temp > ld_max)
                    ld_max = ld_temp;

                if (ld_temp < ld_min)
                    ld_min = ld_temp;

            }

            if (ll_sl <= 0) return;
            ld_avg = Math.Round(ld_tt / ll_sl, 2);

            i5wd.dw0[2].setitem(1, "value_min", ld_min);
            i5wd.dw0[2].setitem(1, "value_max", ld_max);
            i5wd.dw0[2].setitem(1, "value_avg", ld_avg);

        }
        public void wf_judge()
        {
            double ld_bz1min, ld_bz1max, ld_bz2min, ld_bz2max;
            double ld_ctcw1min, ld_ctcw1max, ld_ctcw2min, ld_ctcw2max;
            double ld_ctgw1min, ld_ctgw1max, ld_ctgw2min, ld_ctgw2max;
            double ld_cjcw1min, ld_cjcw1max, ld_cjcw2min, ld_cjcw2max;
            double ld_cjgw1min, ld_cjgw1max, ld_cjgw2min, ld_cjgw2max;
            double ld_bz0min, ld_bz0max;
            double ld_ctcw0min, ld_ctcw0max;
            double ld_ctgw0min, ld_ctgw0max;
            double ld_cjcw0min, ld_cjcw0max;
            double ld_cjgw0min, ld_cjgw0max;

            ld_bz1min = i5wd.dw0[2].getitemnumber(1, "bz1min");
            ld_bz1max = i5wd.dw0[2].getitemnumber(1, "bz1max");
            ld_bz2min = i5wd.dw0[2].getitemnumber(1, "bz2min");
            ld_bz2max = i5wd.dw0[2].getitemnumber(1, "bz2max");
            ld_ctcw1min = i5wd.dw0[2].getitemnumber(1, "ctcw1min");
            ld_ctcw1max = i5wd.dw0[2].getitemnumber(1, "ctcw1max");
            ld_ctcw2min = i5wd.dw0[2].getitemnumber(1, "ctcw2min");
            ld_ctcw2max = i5wd.dw0[2].getitemnumber(1, "ctcw2max");
            ld_ctgw1min = i5wd.dw0[2].getitemnumber(1, "ctgw1min");
            ld_ctgw1max = i5wd.dw0[2].getitemnumber(1, "ctgw1max");
            ld_ctgw2min = i5wd.dw0[2].getitemnumber(1, "ctgw2min");
            ld_ctgw2max = i5wd.dw0[2].getitemnumber(1, "ctgw2max");
            ld_cjcw1min = i5wd.dw0[2].getitemnumber(1, "cjcw1min");
            ld_cjcw1max = i5wd.dw0[2].getitemnumber(1, "cjcw1max");
            ld_cjcw2min = i5wd.dw0[2].getitemnumber(1, "cjcw2min");
            ld_cjcw2max = i5wd.dw0[2].getitemnumber(1, "cjcw2max");
            ld_cjgw1min = i5wd.dw0[2].getitemnumber(1, "cjgw1min");
            ld_cjgw1max = i5wd.dw0[2].getitemnumber(1, "cjgw1max");
            ld_cjgw2min = i5wd.dw0[2].getitemnumber(1, "cjgw2min");
            ld_cjgw2max = i5wd.dw0[2].getitemnumber(1, "cjgw2max");

            ld_bz0min = i5wd.dw0[2].getitemnumber(1, "value_min");
            ld_bz0max = i5wd.dw0[2].getitemnumber(1, "value_max");
            ld_ctcw0min = i5wd.dw0[2].getitemnumber(1, "ctcw0min");
            ld_ctcw0max = i5wd.dw0[2].getitemnumber(1, "ctcw0max");
            ld_ctgw0min = i5wd.dw0[2].getitemnumber(1, "ctgw0min");
            ld_ctgw0max = i5wd.dw0[2].getitemnumber(1, "ctgw0max");
            ld_cjcw0min = i5wd.dw0[2].getitemnumber(1, "cjcw0min");
            ld_cjcw0max = i5wd.dw0[2].getitemnumber(1, "cjcw0max");
            ld_cjgw0min = i5wd.dw0[2].getitemnumber(1, "cjgw0min");
            ld_cjgw0max = i5wd.dw0[2].getitemnumber(1, "cjgw0max");

            string[] ls_judge = new string[] { "", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N" };
            if (ld_bz0min < ld_bz1min || ld_bz0min < ld_bz2min) ls_judge[1] = "Y";
            if (ld_bz0max > ld_bz1max || ld_bz0max > ld_bz2max) ls_judge[2] = "Y";

            if (ld_ctcw0min < ld_ctcw1min || ld_ctcw0min < ld_ctcw2min) ls_judge[3] = "Y";
            if (ld_ctcw0max > ld_ctcw1max || ld_ctcw0max > ld_ctcw2max) ls_judge[4] = "Y";

            if (ld_ctgw0min < ld_ctgw1min || ld_ctgw0min < ld_ctgw2min) ls_judge[5] = "Y";
            if (ld_ctgw0max > ld_ctgw1max || ld_ctgw0max > ld_ctgw2max) ls_judge[6] = "Y";

            if (ld_cjcw0min < ld_cjcw1min || ld_cjcw0min < ld_cjcw2min) ls_judge[7] = "Y";
            if (ld_cjcw0max > ld_cjcw1max || ld_cjcw0max > ld_cjcw2max) ls_judge[8] = "Y";

            if (ld_cjgw0min < ld_cjgw1min || ld_cjgw0min < ld_cjgw2min) ls_judge[9] = "Y";
            if (ld_cjgw0max > ld_cjgw1max || ld_cjgw0max > ld_cjgw2max) ls_judge[10] = "Y";

            string s = ls_judge[1] + ls_judge[2] + ls_judge[3] + ls_judge[4] +
                                 ls_judge[5] + ls_judge[6] + ls_judge[7] + ls_judge[8] +
                                 ls_judge[9] + ls_judge[10];

            i5wd.dw0[2].setitem(1, "bzpdjg", s);
        }

    }
}
