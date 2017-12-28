using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CYQ.Data;
using CYQ.Data.Table;
using System.Data.SqlClient;
using System.Threading;
namespace Redsoft
{
    public partial class w_t_t9_3 : Form
    {
        public w_t_t9_3()
        {
            InitializeComponent();
        }
        string id;
        public str_sys_dw i5dww;
        public str_win_dw9 i5wd = null;
        private string windowName;

        public string WindowName
        {
            get { return windowName; }
            set { windowName = value; }
        }
        private void w_t_t9_3_Load(object sender, EventArgs e)
        {
            if (!Common.isDesignMode())
            {
                i5dww = new str_sys_dw();
                i5wd = new str_win_dw9();
                global.g5_sys.s_object = windowName;
                i5wd.win0 = this;
                global.gu_dw1.f_open0(i5wd);
                ue_open0();

                long ll_i;
                foreach (TabPage p in tab_t3.TabPages)
                    p.Parent = null;
                for (ll_i = 9; ll_i <= 16; ll_i++)
                {
                    if (i5wd.b_dw0[ll_i])
                    {
                        switch (ll_i)
                        {
                            case 9:
                                i5wd.l_tab3 = 1;
                                i5wd.dw0[ll_i] = dw_t31;
                                tap31.Parent = tab_t3;
                                break;
                            case 10:
                                i5wd.dw0[ll_i] = dw_t32;
                                tap32.Parent = tab_t3;
                                break;
                            case 11:
                                i5wd.dw0[ll_i] = dw_t33;
                                tap33.Parent = tab_t3;
                                break;
                            case 12:
                                i5wd.dw0[ll_i] = dw_t34;
                                tap34.Parent = tab_t3;
                                break;
                            case 13:
                                i5wd.dw0[ll_i] = dw_t35;
                                tap35.Parent = tab_t3;
                                break;
                            case 14:
                                i5wd.dw0[ll_i] = dw_t36;
                                tap36.Parent = tab_t3;
                                break;
                            case 15:
                                i5wd.dw0[ll_i] = dw_t37;
                                tap37.Parent = tab_t3;
                                break;
                            case 16:
                                i5wd.dw0[ll_i] = dw_t38;
                                tap38.Parent = tab_t3;
                                break;
                        }
                        //tab_t3.Controls[(int)(ll_i - 8)].Visible = true;
                    }
                    else
                        break;

                }
                foreach (TabPage p in tab_t3.TabPages)
                    p.Parent = null;
                for (ll_i = 17; ll_i <= 24; ll_i++)
                {
                    if (i5wd.b_dw0[ll_i])
                    {
                        switch (ll_i)
                        {
                            case 17:
                                if (i5wd.l_tab3 == 0)
                                    i5wd.l_tab3 = 2;
                                i5wd.dw0[ll_i] = dw_t41;
                                tap31.Parent = tab_t3;
                                break;
                            case 18:
                                i5wd.dw0[ll_i] = dw_t42;
                                tap32.Parent = tab_t3;
                                break;
                            case 19:
                                i5wd.dw0[ll_i] = dw_t43;
                                tap33.Parent = tab_t3;
                                break;
                            case 20:
                                i5wd.dw0[ll_i] = dw_t44;
                                tap34.Parent = tab_t3;
                                break;
                            case 21:
                                i5wd.dw0[ll_i] = dw_t45;
                                tap35.Parent = tab_t3;
                                break;
                            case 22:
                                i5wd.dw0[ll_i] = dw_t46;
                                tap36.Parent = tab_t3;
                                break;
                            case 23:
                                i5wd.dw0[ll_i] = dw_t47;
                                tap37.Parent = tab_t3;
                                break;
                            case 24:
                                i5wd.dw0[ll_i] = dw_t48;
                                tap38.Parent = tab_t3;
                                break;
                        }
                        //tab_t3.Controls[(int)ll_i - 16].Visible = true;
                    }
                    else
                        break;

                }
                foreach (TabPage p in tab_t5.TabPages)
                    p.Parent = null;
                for (ll_i = 25; ll_i <= 32; ll_i++)
                {
                    if (i5wd.b_dw0[ll_i])
                    {
                        switch (ll_i)
                        {
                            case 25:
                                i5wd.dw0[ll_i] = dw_t51;
                                tap51.Parent = tab_t5;
                                break;
                            case 26:
                                i5wd.dw0[ll_i] = dw_t52;
                                tap52.Parent = tab_t5;
                                break;
                            case 27:
                                i5wd.dw0[ll_i] = dw_t53;
                                tap53.Parent = tab_t5;
                                break;
                            case 28:
                                i5wd.dw0[ll_i] = dw_t54;
                                tap54.Parent = tab_t5;
                                break;
                            case 29:
                                i5wd.dw0[ll_i] = dw_t55;
                                tap55.Parent = tab_t5;
                                break;
                            case 30:
                                i5wd.dw0[ll_i] = dw_t56;
                                tap56.Parent = tab_t5;
                                break;
                            case 31:
                                i5wd.dw0[ll_i] = dw_t57;
                                tap57.Parent = tab_t5;
                                break;
                            case 32:
                                i5wd.dw0[ll_i] = dw_t58;
                                tap58.Parent = tab_t5;
                                break;
                        }
                        //tab_t5.Controls[(int)ll_i - 24].Visible = true;
                    }
                    else
                        break;
                }



                if (i5wd.l_tab3 >= 1)
                {
                    //cb_tab3_export.visible = true;
                    tab_t3.Visible = true;
                }
                foreach (TabPage p in tab_t1.TabPages)
                    p.Parent = null;
                for (ll_i = 1; ll_i <= 8; ll_i++)
                {
                    if (i5wd.b_dw0[ll_i])
                    {
                        switch (ll_i)
                        {
                            case 1:
                                tab_t1.Visible = true;
                                i5wd.dw0[ll_i] = dw_t01;
                                tap01.Parent = tab_t1;
                                break;
                            case 2:
                                i5wd.dw0[ll_i] = dw_t02;
                                tap02.Parent = tab_t1;
                                break;
                            case 3:
                                i5wd.dw0[ll_i] = dw_t03;
                                tap03.Parent = tab_t1;
                                break;
                            case 4:
                                i5wd.dw0[ll_i] = dw_t04;
                                tap04.Parent = tab_t1;
                                break;
                            case 5:
                                i5wd.dw0[ll_i] = dw_t05;
                                tap05.Parent = tab_t1;
                                break;
                            case 6:
                                i5wd.dw0[ll_i] = dw_t06;
                                tap06.Parent = tab_t1;
                                break;
                            case 7:
                                i5wd.dw0[ll_i] = dw_t07;
                                tap07.Parent = tab_t1;
                                break;
                            case 8:
                                i5wd.dw0[ll_i] = dw_t08;
                                tap08.Parent = tab_t1;
                                break;
                        }
                        //tab_t1.TabPages[(int)ll_i - 1].Parent = tab_t1;
                    }
                    else
                        break;
                }

                ue_open1();
                i5wd.s_wintitle = this.Text;
                //if isvalid(w_main) then w_main.tab_title.of_openwin(this)
                ue_constructor_private();
                ue_constructor_load();
                //if (i5wd.s_gjz_parm.Substring(0, 5) != "@@@@@")
                global.gu_dw1.f_sql_retrieve("", i5wd.s_cx_sql[1], ref i5wd.dw0[1], true);
                //global.gu_dw1.f_dddwq_open(i5wd.dw0[1], tab_t1.tap01.dddw_t0105);
                wtf_open_cb_resize();
                //setpointer(arrow!)
                ue_open9();



            }
        }
        public virtual void ue_open0()
        {

        }
        public virtual void ue_open1()
        {

        }
        public virtual void ue_constructor_private()
        {
            long ll_i;
            for (ll_i = 1; ll_i <= 32; ll_i++)
            {
                if (i5wd.b_dw0[ll_i])
                {
                    global.gu_dw1.f_constr_private(ref i5wd.dw0[ll_i]);
                    if (ll_i <= 8)
                        global.gu_dw1.f_get_sql_id_table(ref i5wd.dw0[ll_i], ref i5wd.s_id_n[ll_i], ref i5wd.s_sql_n[ll_i], ref i5wd.s_tb_n[ll_i]);
                }
                else
                {
                    if (ll_i < 8)
                        ll_i = 8;
                    else if (ll_i < 16)
                        ll_i = 16;
                    else if (ll_i < 24)
                        ll_i = 24;
                    else
                        break;

                }
            }
        }
        public virtual void ue_constructor_load()
        {
            global.gu_dw1.f_constr_win0(global.g5_sys.username, windowName, ref i5dww, ref i5wd);
            i5wd.l_focuschanged = 888;
            long ll_i;
            for (ll_i = 1; ll_i <= 32; ll_i++)
            {
                if (i5wd.b_dw0[ll_i])
                {
                    global.gu_dw1.f_constr_load(global.g5_sys.username, windowName, ref i5wd.dw0[ll_i], ref global.g5_dws2, ref i5dww);
                    if (ll_i <= 8)
                    {
                        if (i5wd.d_tab_h[ll_i] <= 0.05 || i5wd.d_tab_h[ll_i] >= 0.95)
                            i5wd.d_tab_h[ll_i] = 0.7;
                    }
                }
                else
                {
                    if (ll_i < 8)
                        ll_i = 8;
                    else if (ll_i < 16)
                        ll_i = 16;
                    else if (ll_i < 24)
                        ll_i = 24;
                    else
                        break;

                }
            }
            i5wd.l_focuschanged = 0;
        }
        public virtual void ue_open9()
        {

        }
        public virtual void wtf_open_cb_resize()
        {
            splitContainer1.Dock = DockStyle.Fill;
            switch (i5wd.s_resize.Substring(0, 1))
            {
                case "h":
                    splitContainer1.Panel1.Controls.Add(tab_t1);
                    splitContainer2.Panel1.Controls.Add(tab_t3);
                    splitContainer2.Panel2.Controls.Add(tab_t5);
                    break;
                case "v":
                    splitContainer1.Panel1.Controls.Add(splitContainer2);
                    splitContainer2.Panel1.Controls.Add(tab_t1);
                    splitContainer2.Panel2.Controls.Add(tab_t3);
                    splitContainer1.Panel2.Controls.Add(tab_t5);
                    splitContainer2.Orientation = Orientation.Vertical;
                    break;
            }
            tab_t1.Dock = DockStyle.Fill;
            tab_t3.Dock = DockStyle.Fill;
            tab_t5.Dock = DockStyle.Fill;
            //choose case left(i5wd.s_resize,2)
            //    case "h1"
            //        if i5wd.b_dw0[9] or i5wd.b_dw0[17] then
            //            //
            //        else
            //            tab_t3.height = 0
            //            cb_tab3_export.height = 0
            //            return
            //        end if
            //    case "h2"
            //            tab_t3.height = 0
            //            cb_tab3_export.height = 0
            //            return
            //    case "h3"
            //        tab_t3.height = 0
            //        cb_tab3_export.height = 0
            //        return
            //end choose

            //if i5wd.b_dw0[17] then
            //    if tab_t3.tap31.cb_t211.visible = false then tab_t3.tap31.cb_t211.width = 0
            //    if tab_t3.tap31.cb_t212.visible = false then tab_t3.tap31.cb_t212.width = 0
            //    if tab_t3.tap31.cb_t213.visible = false then tab_t3.tap31.cb_t213.width = 0
            //        tab_t3.tap31.cb_t212.x = tab_t3.tap31.cb_t211.x + tab_t3.tap31.cb_t211.width
            //        tab_t3.tap31.cb_t213.x = tab_t3.tap31.cb_t212.x + tab_t3.tap31.cb_t212.width
            //if i5wd.b_dw0[18] then
            //    if tab_t3.tap32.cb_t221.visible = false then tab_t3.tap32.cb_t221.width = 0
            //    if tab_t3.tap32.cb_t222.visible = false then tab_t3.tap32.cb_t222.width = 0
            //    if tab_t3.tap32.cb_t223.visible = false then tab_t3.tap32.cb_t223.width = 0
            //        tab_t3.tap32.cb_t222.x = tab_t3.tap32.cb_t221.x + tab_t3.tap32.cb_t221.width
            //        tab_t3.tap32.cb_t223.x = tab_t3.tap32.cb_t222.x + tab_t3.tap32.cb_t222.width
            //if i5wd.b_dw0[19] then
            //    if tab_t3.tap33.cb_t231.visible = false then tab_t3.tap33.cb_t231.width = 0
            //    if tab_t3.tap33.cb_t232.visible = false then tab_t3.tap33.cb_t232.width = 0
            //    if tab_t3.tap33.cb_t233.visible = false then tab_t3.tap33.cb_t233.width = 0
            //        tab_t3.tap33.cb_t232.x = tab_t3.tap33.cb_t231.x + tab_t3.tap33.cb_t231.width
            //        tab_t3.tap33.cb_t233.x = tab_t3.tap33.cb_t232.x + tab_t3.tap33.cb_t232.width
            //if i5wd.b_dw0[20] then
            //    if tab_t3.tap34.cb_t241.visible = false then tab_t3.tap34.cb_t241.width = 0
            //    if tab_t3.tap34.cb_t242.visible = false then tab_t3.tap34.cb_t242.width = 0
            //    if tab_t3.tap34.cb_t243.visible = false then tab_t3.tap34.cb_t243.width = 0
            //        tab_t3.tap34.cb_t242.x = tab_t3.tap34.cb_t241.x + tab_t3.tap34.cb_t241.width
            //        tab_t3.tap34.cb_t243.x = tab_t3.tap34.cb_t242.x + tab_t3.tap34.cb_t242.width
            //if i5wd.b_dw0[21] then
            //    if tab_t3.tap35.cb_t251.visible = false then tab_t3.tap35.cb_t251.width = 0
            //    if tab_t3.tap35.cb_t252.visible = false then tab_t3.tap35.cb_t252.width = 0
            //    if tab_t3.tap35.cb_t253.visible = false then tab_t3.tap35.cb_t253.width = 0
            //        tab_t3.tap35.cb_t252.x = tab_t3.tap35.cb_t251.x + tab_t3.tap35.cb_t251.width
            //        tab_t3.tap35.cb_t253.x = tab_t3.tap35.cb_t252.x + tab_t3.tap35.cb_t252.width
            //if i5wd.b_dw0[22] then
            //    if tab_t3.tap36.cb_t261.visible = false then tab_t3.tap36.cb_t261.width = 0
            //    if tab_t3.tap36.cb_t262.visible = false then tab_t3.tap36.cb_t262.width = 0
            //    if tab_t3.tap36.cb_t263.visible = false then tab_t3.tap36.cb_t263.width = 0
            //        tab_t3.tap36.cb_t262.x = tab_t3.tap36.cb_t261.x + tab_t3.tap36.cb_t261.width
            //        tab_t3.tap36.cb_t263.x = tab_t3.tap36.cb_t262.x + tab_t3.tap36.cb_t262.width
            //if i5wd.b_dw0[23] then
            //    if tab_t3.tap37.cb_t271.visible = false then tab_t3.tap37.cb_t271.width = 0
            //    if tab_t3.tap37.cb_t272.visible = false then tab_t3.tap37.cb_t272.width = 0
            //    if tab_t3.tap37.cb_t273.visible = false then tab_t3.tap37.cb_t273.width = 0
            //        tab_t3.tap37.cb_t272.x = tab_t3.tap37.cb_t271.x + tab_t3.tap37.cb_t271.width
            //        tab_t3.tap37.cb_t273.x = tab_t3.tap37.cb_t272.x + tab_t3.tap37.cb_t272.width
            //if i5wd.b_dw0[24] then
            //    if tab_t3.tap38.cb_t281.visible = false then tab_t3.tap38.cb_t281.width = 0
            //    if tab_t3.tap38.cb_t282.visible = false then tab_t3.tap38.cb_t282.width = 0
            //    if tab_t3.tap38.cb_t283.visible = false then tab_t3.tap38.cb_t283.width = 0
            //        tab_t3.tap38.cb_t282.x = tab_t3.tap38.cb_t281.x + tab_t3.tap38.cb_t281.width
            //        tab_t3.tap38.cb_t283.x = tab_t3.tap38.cb_t282.x + tab_t3.tap38.cb_t282.width
            //end if
            //end if
            //end if
            //end if
            //end if
            //end if
            //end if
            //end if
        }
        private void dataWindow1_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            //MessageBox.Show(e.ColumnName + " " + e.Data);
            switch (e.ColumnName)
            {
                case "pihao":

                    MProc proc = new MProc("select top 1 cpbh_id,cpbh,guige,dc,sl ,xn ,zl, jgdw,ddh from dbo.jf_lljs where pihao ='" + e.Data + "'");
                    MDataTable dt = proc.ExeMDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {

                            dw_t02.setitem(0, dt.Columns[i].ColumnName, dt.Rows[0][i].StringValue);
                        }
                    }
                    break;
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (!wtf_gnqx_inst())
            {
                MessageBox.Show("很抱歉！您没有添加权限！");
                return;
            }

            i5wd.l_oldindex = 1;

            wtf_set_win_title();

            switch (i5wd.s_selectionchanged)
            {
                case "default":
                    ue_inst_clicked_default();
                    break;
                case "custom":
                    //ue_inst_clicked_custom();
                    break;
                case "multiline":
                    //ue_inst_clicked_multiline();
                    break;
            }

        }
        public virtual long ue_inst_clicked_default()
        {
            if (cb_save.Enabled)
            {
                MessageBox.Show("请先保存后再添加！");
                return -1;
            }

            if (ue_inst_pre() == -1)
                return -1;


            long ll_i = 0, ll_dw = 0;
            ll_dw = 2;
            if (i5wd.l_newindex == 2)
            {
                if (cb_save.Enabled)
                {
                    MessageBox.Show("有未保存的数据保存失败");
                    return -1;
                }
                global.gu_dw1.f_dw_l_idid(ll_dw, ref i5wd, 0);
                //i5wd.dw0[1].selectrow(0,false);
            }
            else
            {
                //i5wd.dw0[1].selectrow(0,false);
                global.gu_dw1.f_dw_l_idid(ll_dw, ref i5wd, 0);
                tab_t1.SelectedIndex = 1;
                wtf_save_denable();
            }

            if (i5wd.b_dw0[ll_dw])
                i5wd.dw0[ll_dw].reset();
            for (ll_i = 17; ll_i <= 24; ll_i++)
            {
                if (i5wd.b_dw0[ll_i])
                {
                    i5wd.dw0[ll_i].reset();
                    i5wd.b_dw0[ll_i + 32] = false; //不用retrieve了
                }
            }

            long ll_newrow = 0, ll_id = 0;
            ll_newrow = i5wd.dw0[ll_dw].InsertRow(0);
            //ll_id = global.gu_dw1.f_get_id_max1(i5wd.s_tb_n[ll_dw],i5wd.s_sql_n[ll_dw],true);
            ll_id = Common.GetID(i5wd.dw0[ll_dw].TableName, i5wd.dw0[ll_dw].IdCol);
            if (ll_id <= 0)
            {
                i5wd.dw0[ll_dw].deleterow(ll_newrow);
                return -1; ;
            }
            //i5wd.dw0[ll_dw].setfocus();
            i5wd.dw0[ll_dw].setitem(ll_newrow, i5wd.s_id_n[ll_dw], ll_id);
            //i5wd.dw0[ll_dw].scrolltorow(ll_newrow);
            global.gu_dw1.f_dw_l_idid(ll_dw, ref i5wd, ll_newrow);
            if (i5wd.l_idid[ll_dw] != ll_id)
            {
                i5wd.dw0[ll_dw].deleterow(ll_newrow);
                return -1; ;
            }

            if (ue_inst_after(ll_newrow) == -1)
                return -1;

            wtf_save_enabled();
            i5wd.b_newrow = true; // 是否新增加的记录，针对表头

            return 0;
        }
        private bool wtf_gnqx_inst()
        {
            long ll_len;
            ll_len = i5wd.s_gnqx.Length - 1;

            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len], ref ll_len, ll_len - 4) >= 1)
                return true; //删除
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 1], ref ll_len, ll_len - 4) >= 1)
                return true; //修改
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 2], ref ll_len, ll_len - 4) >= 1)
                return true; //修改
            return false;
        }
        public void wtf_rowfocuschanged_3all()
        {
            long ll_i;
            for (ll_i = 17; ll_i <= 24; ll_i++)
            {
                if (i5wd.b_dw0[ll_i])
                    wtf_rowfocuschanged_0123(2, ll_i, -2147483647);
            }
        }
        private void cb_save_Click(object sender, EventArgs e)
        {
            if (i5wd.dw0[2].rowcount() != 1)
            {
                this.Enabled = false;
                return;
            }
            //long ll_modifiedcount
            //if wtf_accepttext(ll_modifiedcount) = -1 then return -1
            //if ll_modifiedcount = 0 then
            //    this.enabled = false
            //    return -1
            //end if
            //wtf_rowfocuschanged_3all();
            if (ue_save_pre() == -1)
                return;
            if (wtf_save_save(2, "default") == -1)
                return;
            wtf_save_denable();
            if (ue_save_after() == -1)
                return;

        }
        public virtual long ue_save_pre()
        {
            return 0;

        }
        public virtual long ue_save_after()
        {
            return 0;

        }

        private void listWindow1_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            tab_t1.SelectedIndex = 1;
            id = Common.GetString(dw_t01.dataGridView1.Rows[e.RowIndex].Cells[dw_t01.IdCol].Value);
            if (id != "")
                dw_t02.Retrieve(id);
            //Thread thread = new Thread(InitCombo);
            //thread.Start();
            InitCombo();
        }
        private void InitCombo()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            dw_t02.IsRetrieve = true;
            dw_t02.InitCombobox("jcgj", "cxn_h", "riqi>= getdate() -100", "jcgj", "");
            dw_t02.IsRetrieve = false;
        }
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (!wtf_gnqx_delt())
            {

                MessageBox.Show("很抱歉！您没有删除权限！");
                return;
            }

            if (MessageBox.Show("您确实要删除吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (wtf_delt_pre(2) == -1)
                return; //删除前的统一检查

            wtf_set_win_title();

            switch (i5wd.s_selectionchanged)
            {
                case "default":
                    ue_delt_clicked_default();
                    break;
                //	case "custom"
                //		return this.event ue_clicked_custom()
                case "multiline":
                    ue_delt_clicked_multiline();
                    break;
            }


        }
        private long ue_delt_clicked_default()
        {
            wtf_rowfocuschanged_3all();
            if (ue_delt_pre() == -1) return -1;
            long ll_j, ll_i;
            if (i5wd.b_dw0[2])
            {
                i5wd.dw0[2].Delete(i5wd.l_idid[1]);
            }

            for (ll_i = 17; ll_i <= 24; ll_i++)
            {
                if (i5wd.b_dw0[ll_i])
                {
                    for (ll_j = i5wd.dw0[ll_i].rowcount() - 1; ll_j >= 0; ll_j--)
                    {
                        i5wd.dw0[ll_i].Delete(ll_j);
                    }
                }
            }
            if (i5wd.b_dw0[2])
            {
                i5wd.dw0[1].deleterow(i5wd.l_selectrow[1]);
            }
            //if (wtf_save_save(2, "default") == -1) return -1;//暂不调用保存，在删除中直接删除了
            wtf_save_denable();
            if (ue_delt_after() == -1) return -1;
            tab_t1.SelectedIndex = (int)i5wd.l_oldindex;

            return 0;
        }
        private long ue_delt_clicked_multiline()
        {
            if (ue_delt_pre() == -1) return -1;
            if (i5wd.b_dw0[2])
                global.gu_dw1.f_delt_dw_row(2, ref i5wd, -1);
            if (ue_delt_after() == -1) return -1;
            wtf_save_enabled();
            return 0;

        }

        public long wtf_delt_pre(long al_dw)
        {
            long ll_i;
            if (al_dw <= 0 || al_dw >= 9)
                return -1;
            if (i5wd.b_dw0[al_dw])
            {
                if (i5wd.dw0[al_dw].rowcount() <= 0) return -1;
                if (global.gu_dw1.f_delt_dw_pre_file(ref i5wd.dw0[al_dw]) == -1) return -1;
            }
            else
                return -1;


            if (tab_t3.Visible && i5wd.l_tab3 == 2)
            {
                for (ll_i = 17; ll_i <= 24; ll_i++)
                {
                    if (i5wd.b_dw0[ll_i])
                    {
                        if (global.gu_dw1.f_delt_dw_pre_file(ref i5wd.dw0[ll_i]) == -1) return -1;
                    }
                }
            }

            return 0;
        }
        public bool wtf_gnqx_delt()
        {

            long ll_len;
            ll_len = i5wd.s_gnqx.Length - 1;
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len], ref ll_len, ll_len - 4) >= 1)
                return true; //删除
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 1], ref ll_len, ll_len - 4) >= 1)
                return true; //修改
            if (i5wd.b_newrow)
            {
                if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 2], ref ll_len, ll_len - 4) >= 1)
                    return true; //添加
            }
            return false;
        }
        private void grid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Common.isDesignMode())
                return;
            if (tab_t1.SelectedIndex == 1)
            {//此为临时代码
                if (dw_t01.dataGridView1.SelectedRows.Count == 0)
                    return;
                id = Common.GetString(dw_t01.dataGridView1.SelectedRows[0].Cells[dw_t01.IdCol].Value);
                if (id != "")
                    dw_t02.Retrieve(id);
                //Thread thread = new Thread(InitCombo);
                //thread.Start();
                InitCombo();
            }
            //以上为临时代码

            global.g5_sys.s_object = i5wd.win0.Name + windowName;
            if (tab_t1.SelectedIndex >= 0)
                i5wd.l_newindex = tab_t1.SelectedIndex + 1;
            if (!this.Visible)
                return;
            //if (newindex == oldindex )
            //    return;
            //else
            //    i5wd.l_oldindex = oldindex;

            if (i5wd.s_selectionchanged == "default")
                ue_selectionchanged_default(0, tab_t1.SelectedIndex + 1);
            else //    case "multiline","custom"
                ue_selectionchanged(0, tab_t1.SelectedIndex + 1);


            wtf_tab3_dw_visible();
            wtf_gjz_reset("");
            wtf_rowfocuschanged_0123(1, tab_t3.SelectedIndex + 1, i5wd.l_selectrow[tab_t1.SelectedIndex + 1]);
        }
        public void wtf_gjz_reset(string as_temp)
        {
            //choose case i5wd.l_newindex
            //    case 1
            //        if tab_t1.tap01.st_t0101.tag = "custom" then return
            //    case 2
            //        if tab_t1.tap02.st_t0201.tag = "custom" then return
            //    case 3			
            //        if tab_t1.tap03.st_t0301.tag = "custom" then return
            //    case 4			
            //        if tab_t1.tap04.st_t0401.tag = "custom" then return
            //    case 5			
            //        if tab_t1.tap05.st_t0501.tag = "custom" then return
            //    case 6			
            //        if tab_t1.tap06.st_t0601.tag = "custom" then return
            //    case 7			
            //        if tab_t1.tap07.st_t0701.tag = "custom" then return
            //    case 8			
            //        if tab_t1.tap08.st_t0801.tag = "custom" then return
            //end choose	

            //        long ll_tab
            //        ll_tab = i5wd.l_newindex
            //        choose case i5wd.s_selectionchanged
            //            case "default"
            //                if ll_tab = 2 then return	
            //        end choose

            //        string ls_gjz_text
            //        if i5wd.b_dw0[ll_tab] then
            //            if as_temp = i5wd.s_gjz_colname[ll_tab] + "_t" then return
            //            if as_temp = "" and i5wd.s_gjz_colname[ll_tab] <> "" then return
            //            ls_gjz_text = gu_dw1.f_dw_gjz(i5wd.dw0[ll_tab],i5wd.s_gjz_sqlname[ll_tab],i5wd.s_gjz_colname[ll_tab],i5wd.s_gjz_coltype[ll_tab],as_temp)
            //            if ls_gjz_text = "" then return
            //        else
            //            return
            //        end if
            //        choose case ll_tab
            //            case 1
            //                tab_t1.tap01.st_t0101.text = ls_gjz_text
            //                tab_t1.tap01.sle_t0102.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap01.sle_t0102.text = ""
            //            case 2
            //                tab_t1.tap02.st_t0201.text = ls_gjz_text
            //                tab_t1.tap02.sle_t0202.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap02.sle_t0202.text = ""
            //            case 3			
            //                tab_t1.tap03.st_t0301.text = ls_gjz_text
            //                tab_t1.tap03.sle_t0302.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap03.sle_t0302.text = ""
            //            case 4			
            //                tab_t1.tap04.st_t0401.text = ls_gjz_text
            //                tab_t1.tap04.sle_t0402.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap04.sle_t0402.text = ""
            //            case 5			
            //                tab_t1.tap05.st_t0501.text = ls_gjz_text
            //                tab_t1.tap05.sle_t0502.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap05.sle_t0502.text = ""
            //            case 6			
            //                tab_t1.tap06.st_t0601.text = ls_gjz_text
            //                tab_t1.tap06.sle_t0602.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap06.sle_t0602.text = ""
            //            case 7			
            //                tab_t1.tap07.st_t0701.text = ls_gjz_text
            //                tab_t1.tap07.sle_t0702.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap07.sle_t0702.text = ""
            //            case 8			
            //                tab_t1.tap08.st_t0801.text = ls_gjz_text
            //                tab_t1.tap08.sle_t0802.tag = ls_gjz_text
            //                if as_temp <> "" then tab_t1.tap08.sle_t0802.text = ""
            //        end choose			

            //        if as_temp <> "" then wtf_presskeyup2_filter(ll_tab,"")
        }
        public virtual int ue_selectionchanged(int oldindex, int newindex)
        {
            return 0;
        }
        public int ue_selectionchanged_default(int oldindex, int newindex)
        {
            switch (newindex)
            {
                case 1:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    {
                        if (i5wd.b_dw0[9] || i5wd.b_dw0[10] || i5wd.b_dw0[11] || i5wd.b_dw0[12] ||
                i5wd.b_dw0[13] || i5wd.b_dw0[14] || i5wd.b_dw0[15] || i5wd.b_dw0[16])
                        {
                            tab_t3.Visible = true;
                            i5wd.l_tab3 = 1;
                        }
                        else
                        {
                            tab_t3.Visible = false;
                            i5wd.l_tab3 = 0;
                        }
                        //i5wd.dw0[newindex].setfocus()
                    }
                    break;
                case 2:
                    if (i5wd.b_dw0[17] || i5wd.b_dw0[18] || i5wd.b_dw0[19] || i5wd.b_dw0[20] ||
                     i5wd.b_dw0[21] || i5wd.b_dw0[22] || i5wd.b_dw0[23] || i5wd.b_dw0[24])
                    {
                        tab_t3.Visible = true;
                        i5wd.l_tab3 = 2;
                    }
                    else
                    {
                        tab_t3.Visible = false;
                        i5wd.l_tab3 = 0;
                    }
                    break;
                //i5wd.dw0[newindex].setfocus()
            }
            ue_selectionchanged(oldindex, newindex);

            ue_resize0();

            return 0;
        }
        public void wtf_tab3_dw_visible()
        {
            if (tab_t3.Visible)
            {
                long li_t3 = 0;
                if (tab_t3.SelectedIndex >= 0)
                    li_t3 = tab_t3.SelectedIndex + 1;
                switch (i5wd.l_tab3)
                {
                    case 1: // 显示不可更新的datawindow
                        if (i5wd.b_dw0[li_t3 + 8])
                        {
                            i5wd.dw0[li_t3 + 8].Visible = true;
                            //i5wd.dw0[li_t3 + 8].BringToTop = true
                        }
                        if (i5wd.b_dw0[li_t3 + 16])
                        {
                            i5wd.dw0[li_t3 + 16].Visible = false;
                            //i5wd.dw0[li_t3 + 16].BringToTop = false
                        }
                        if (li_t3 == 1)
                        {
                            cb_t211.Visible = false;
                            cb_t212.Visible = false;
                            cb_t213.Visible = false;
                        }
                        if (li_t3 == 2)
                        {
                            cb_t221.Visible = false;
                            cb_t222.Visible = false;
                            cb_t223.Visible = false;
                        }
                        if (li_t3 == 3)
                        {
                            cb_t231.Visible = false;
                            cb_t232.Visible = false;
                            cb_t233.Visible = false;
                        }
                        if (li_t3 == 4)
                        {
                            cb_t241.Visible = false;
                            cb_t242.Visible = false;
                            cb_t243.Visible = false;
                        }
                        if (li_t3 == 5)
                        {
                            cb_t251.Visible = false;
                            cb_t252.Visible = false;
                            cb_t253.Visible = false;
                        }
                        if (li_t3 == 6)
                        {
                            cb_t261.Visible = false;
                            cb_t262.Visible = false;
                            cb_t263.Visible = false;
                        }
                        if (li_t3 == 7)
                        {
                            cb_t271.Visible = false;
                            cb_t272.Visible = false;
                            cb_t273.Visible = false;
                        }
                        if (li_t3 == 8)
                        {
                            cb_t281.Visible = false;
                            cb_t282.Visible = false;
                            cb_t283.Visible = false;
                        }
                        break;
                    case 2:
                        if (i5wd.b_dw0[li_t3 + 8])
                        {
                            i5wd.dw0[li_t3 + 8].Visible = false;
                            // i5wd.dw0[li_t3 + 8].BringToTop = false
                        }
                        if (i5wd.b_dw0[li_t3 + 16])
                        {
                            i5wd.dw0[li_t3 + 16].Visible = true;
                            //i5wd.dw0[li_t3 + 16].BringToTop = true
                        }
                        if (li_t3 == 1)
                        {
                            cb_t211.Visible = true;
                            cb_t212.Visible = true;
                            cb_t213.Visible = true;
                        }
                        if (li_t3 == 2)
                        {
                            cb_t221.Visible = true;
                            cb_t222.Visible = true;
                            cb_t223.Visible = true;
                        }
                        if (li_t3 == 3)
                        {
                            cb_t231.Visible = true;
                            cb_t232.Visible = true;
                            cb_t233.Visible = true;
                        }
                        if (li_t3 == 4)
                        {
                            cb_t241.Visible = true;
                            cb_t242.Visible = true;
                            cb_t243.Visible = true;
                        }
                        if (li_t3 == 5)
                        {
                            cb_t251.Visible = true;
                            cb_t252.Visible = true;
                            cb_t253.Visible = true;
                        }
                        if (li_t3 == 6)
                        {
                            cb_t261.Visible = true;
                            cb_t262.Visible = true;
                            cb_t263.Visible = true;
                        }
                        if (li_t3 == 7)
                        {
                            cb_t271.Visible = true;
                            cb_t272.Visible = true;
                            cb_t273.Visible = true;
                        }
                        if (li_t3 == 8)
                        {
                            cb_t281.Visible = true;
                            cb_t282.Visible = true;
                            cb_t283.Visible = true;
                        }
                        break;
                }
            }
        }
        public bool wtf_gnqx_browse()
        {
            if (i5wd.s_gnqx == null)
                return false;
            if (i5wd.s_gnqx[1] == "99")
                return true;
            long ll_len;
            ll_len = i5wd.s_gnqx.Length;
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 3], ref ll_len, ll_len - 4) >= 1)
                return true; //浏览
            else
                return false;

        }

        private void w_t_t9_3_Activated(object sender, EventArgs e)
        {

        }

        private void w_t_t9_3_Shown(object sender, EventArgs e)
        {
            if (!Common.isDesignMode())
            {
                if (!wtf_gnqx_browse())
                {
                    MessageBox.Show("很抱歉！您没有浏览 《" + this.Text + "》 的权限！");
                    Close();
                    return;
                }
            }
        }

        private void w_t_t9_3_Resize(object sender, EventArgs e)
        {
            ue_resize0();
        }

        public virtual void ue_resize0()
        {

        }

        private void w_t_t9_3_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (ue_closequery() == 1)
            {
                e.Cancel = true;
                return;
            }
            if (wtf_switch(2, 1) == 1)
            { // 检测保存提示
                e.Cancel = true;
                return;
            }
            ue_constructor_save();

        }
        public virtual int ue_closequery()
        {
            return 0;
        }
        public long wtf_switch(int oldindex, int newindex)
        {
            if (oldindex == 1 && newindex != 1 && cb_save.Visible && cb_save.Enabled)
            {
                DialogResult ret = MessageBox.Show("数据已经发生变化,是否保存?", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (ret == DialogResult.Yes)
                {
                    cb_save_Click(null, null);
                    if (cb_save.Enabled)
                        return 1;//返回1不允许切换tabpage，不允许关闭窗口
                    else
                        return 0;
                }
                if (ret == DialogResult.No)
                {
                    wtf_save_denable();
                    global.gu_dw1.f_dw_l_idid(2, ref i5wd, 0);
                    return 0; //不做任何操作直接切换tabpage，直接关闭窗口
                }
                if (ret == DialogResult.No)
                {
                    return 1; //返回1不允许切换tabpage，不允许关闭窗口
                }
            }
            return 0;

        }
        public void wtf_save_denable()
        {
            cb_save.Enabled = false;
            i5wd.l_save_cpu = 0;
        }
        public void ue_constructor_save()
        {
            string ls_tab_h, ls_window1;
            ls_window1 =windowName;
            ls_tab_h = global.gu_pub1.f_s_arraytolista(i5wd.d_tab_h, ",");
            //update mis_dw_argument set colname = :ls_tab_h,lrsj=getdate()
            //        where user_name1 = :g5_sys.username and window1 = :ls_window1 and dataobject = '' ;
            //    if not (sqlca.sqlcode = 0 and sqlca.sqlnrows = 1) then
            //        insert into mis_dw_argument (user_name1,window1,dataobject,colname,lrsj) 
            //        values (:g5_sys.username,:ls_window1,'',:ls_tab_h,getdate()) ;
            //    end if

            long ll_i;
            for (ll_i = 1; ll_i <= 32; ll_i++)
            {
                if (i5wd.b_dw0[ll_i])
                    global.gu_dw1.f_constr_save(global.g5_sys.username,windowName, i5wd.dw0[ll_i]);
                else
                {
                    if (ll_i < 8)
                        ll_i = 8;
                    else if (ll_i < 16)
                        ll_i = 16;
                    else if (ll_i < 24)
                        ll_i = 24;
                    else
                        break;

                }
            }

        }

        private void tab_t1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (Common.isDesignMode())
                return;
            if (wtf_switch(e.TabPageIndex, 100) == 1)
                e.Cancel = true;
        }
        public void wtf_editchanged_23(long al_dw, long row, string dwo, string data)
        {
            if (!i5wd.b_dw0[65])
                return;
            ue_dw_editchanged00(ref al_dw, ref row, dwo, ref data);
            if (wtf_gnqx_updt())
            {
                switch (al_dw)
                {
                    case 2:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                        wtf_save_enabled();
                        break;
                }
            }
            //下面两个函数功能已经写在基本控件中
            //global.gu_dw1.f_dddw_show("", ref i5wd.dw0[al_dw], ref i5wd.l_dropdown_show);
            //global.gu_dw1.f_editchanged(row, dwo, data, i5wd.dw0[al_dw]);
        }
        public virtual void ue_dw_editchanged00(ref long al_dw, ref long row, string dwo, ref string data)
        {

        }
        public bool wtf_gnqx_updt()
        {
            long ll_len;
            ll_len = i5wd.s_gnqx.Length - 1;
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len], ref ll_len, ll_len - 4) >= 1)
                return true; //删除
            if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 1], ref ll_len, ll_len - 4) >= 1)
                return true; //修改
            if (i5wd.b_newrow)
            {
                if (global.gu_pub1.f_array_find(i5wd.s_gnqx, i5wd.s_gnqx[ll_len - 2], ref ll_len, ll_len - 4) >= 1)
                    return true; //添加
            }
            return false;
        }
        public void wtf_save_enabled()
        {

            cb_save.Enabled = true;
            i5wd.l_save_cpu = Common.GetCurrentTimeUnix();

        }

        private void dw_t02_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(2, e.Row, e.ColumnName, e.Data);
        }
        public long wtf_itemchanged_23(long al_dw, long row, string dwo, string data)
        {
            if (!i5wd.b_dw0[65]) return 2;
            if (i5wd.dw0[al_dw].Tag.ToString().Substring(0, 1) == "0" ||
                i5wd.dw0[al_dw].Tag.ToString().Substring(0, 1) == "1")

                return 2;


            long ll_return;
            ll_return = ue_dw_itemchanged00(al_dw, row, dwo, data);
            if (ll_return >= 1)
            {
                i5wd.b_itemerror = false;
                //i5wd.dw0[al_dw].setfocus();
                return ll_return;
            }

            ll_return = global.gu_dw1.f_itemchanged(ref row, ref dwo, ref data, ref i5wd.dw0[al_dw], global.gu_pub1.f_getdate());
            if (ll_return >= 1)
            {
                i5wd.b_itemerror = false;
                //i5wd.dw0[al_dw].setfocus()
                return ll_return;
            }


            if (wtf_gnqx_updt())
                if (al_dw == 2)
                    wtf_save_enabled();
                else
                {
                    i5wd.b_itemerror = false;
                    //i5wd.dw0[al_dw].setfocus()
                    return 2;
                }
            return 0;
        }
        public virtual long ue_dw_itemchanged00(long al_dw, long row, string dwo, string data)
        {
            return 1;
        }

        private void dw_t01_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(1, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t03_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(3, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t04_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(4, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t05_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(5, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t06_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(6, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t07_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(7, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t08_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(8, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t41_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_editchanged_23(17, e.Row, e.ColumnName, e.Data);
            wtf_itemchanged_23(17, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t42_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(18, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t43_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(19, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t44_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(20, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t45_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(21, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t46_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(22, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t47_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(23, e.Row, e.ColumnName, e.Data);
        }

        private void dw_t48_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            wtf_itemchanged_23(24, e.Row, e.ColumnName, e.Data);
        }
        public int wtf_rowfocuschanged_0123(long al_index1, long al_index3, long currentrow)
        {
            if (tab_t3.Visible)
            {
                if (al_index3 <= 8)
                    switch (i5wd.l_tab3)
                    {
                        case 1:
                            al_index3 += 8;
                            break;
                        case 2:
                            al_index3 += 16;
                            break;
                        default:
                            return 0;
                    }
            }
            else
                al_index3 = 0;
            //以下改为一句
            global.gu_dw1.f_t_rowfocuschanged(currentrow, al_index1, al_index3, ref i5wd);
            //if (al_index3 > 0 )
            //    if isnumber(mid(i5wd.dw0[al_index3].Tag,2,1)) 
            //        global.gu_dw1.f_t_rowfocuschanged(currentrow,al_index1,al_index3,i5wd);
            //else
            //    global.gu_dw1.f_t_rowfocuschanged(currentrow,al_index1,al_index3,i5wd);

            if (currentrow != -2147483647)
                wtf_set_win_title();
            return 0;

        }
        public void wtf_set_win_title()
        {
            if (i5wd.dw0[i5wd.l_newindex] == null)
                return;
            if (i5wd.l_newindex <= 8)
            {
                if (i5wd.dw0[i5wd.l_newindex].dataGridView1.CurrentCell != null)
                    i5wd.win0.Text = i5wd.s_wintitle + " " + tab_t1.TabPages[(int)i5wd.l_newindex - 1].Text + " " +
                    (i5wd.dw0[i5wd.l_newindex].dataGridView1.CurrentCell.RowIndex + 1).ToString() + '/' +
                    i5wd.dw0[i5wd.l_newindex].rowcount().ToString() + " " +
                    i5wd.s_cx_text[i5wd.l_newindex];
            }
            else
                i5wd.win0.Text = i5wd.s_wintitle + " " + tab_t1.TabPages[(int)i5wd.l_newindex - 1].Text;

        }

        private void dw_t01_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            wtf_clicked_012(1, e.RowIndex, dw_t01.dataGridView1.Columns[e.ColumnIndex].Name);
            wtf_rowfocuschanged_0123(1, tab_t3.SelectedIndex + 1, e.RowIndex);
        }
        public long wtf_clicked_012(long al_dw, long row, string dwo)
        {
            wtf_set_win_title();
            //if i5wd.dw0[al_dw].Describe(dwo.name + ".band") = "header" then
            //    if al_dw <= 8 and left(i5wd.dw0[al_dw].tag,1) <> "3" then gu_dw1.f_dw_l_idid(al_dw,i5wd,0)
            //    return 0
            //end if
            switch (ue_dw_clicked00(al_dw, row, dwo))
            {
                case -1:
                    return 0;
                case 1:
                    return 1;
                default:
                    if (global.gu_dw1.f_clicked(ref al_dw, ref row, ref dwo, ref i5wd) == 1)
                        return 1;
                    break;
            }
            return 0;

        }
        public virtual long ue_dw_clicked00(long al_dw, long row, string dwo)
        {
            return 0;
        }

        private void dw_t01_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            wtf_clicked_012(1, e.RowIndex, dw_t01.dataGridView1.Columns[e.ColumnIndex].Name);
        }

        private void cb_t211_Click(object sender, EventArgs e)
        {
            if (!this.Visible || !this.Enabled)
                return;
            if (wtf_tab3_ins_del_pre() == -1)
                return;
            global.g5_sys.s_object = i5wd.win0.Name + windowName;
            if (ue_inst_pre() == -1)
                return;
            long ll_newrow = 0;
            ll_newrow = wtf_tab3_inst(17);
            if (ll_newrow == -1)
                return;
            if (ue_inst_after(ll_newrow) == -1)
                return;

        }
        public virtual long ue_inst_pre()
        {
            return 0;
        }
        public virtual long ue_inst_after(long ll_newrow)
        {
            return 0;
        }
        public long wtf_tab3_inst(long al_dw)
        {
            //if i5wd.dw0[al_dw].accepttext() = -1 then return -1
            long ll_newrow = 0;
            ll_newrow = i5wd.dw0[al_dw].InsertRow(0);
            //i5wd.dw0[al_dw].setfocus();
            i5wd.dw0[al_dw].ScrollToRow(ll_newrow);
            i5wd.dw0[al_dw].setitem(ll_newrow, i5wd.s_id_n[i5wd.l_newindex], i5wd.l_idid[i5wd.l_newindex]);
            //if (i5wd.dw0[al_dw].Describe('#1.coltype') = "long") and (i5wd.dw0[al_dw].Describe("#1.name") <> i5wd.s_id_n[i5wd.l_newindex]) then
            //    i5wd.dw0[al_dw].setitem(ll_newrow,i5wd.dw0[al_dw].Describe("#1.name"),ll_newrow)
            //end if
            if (i5wd.dw0[al_dw].Cols[0].Name != i5wd.s_id_n[i5wd.l_newindex])
                i5wd.dw0[al_dw].setitem(ll_newrow, i5wd.dw0[al_dw].Cols[0].Name, ll_newrow + 1);
            wtf_save_enabled();
            return ll_newrow;
        }
        public virtual long wtf_tab3_ins_del_pre()
        {
            if (!wtf_gnqx_updt())
            {
                MessageBox.Show("很抱歉！您没有权限！");
                return -1;
            }
            if (i5wd.dw0[2].rowcount() != 1)
                return -1;
            long ll_modifiedcount = 0;
            if (wtf_accepttext(ref ll_modifiedcount) == -1)
                return -1;
            return 0;
        }
        public long wtf_accepttext(ref long al_modifiedcount)
        {
            //long li_return,li_i
            //li_return = 1
            //al_modifiedcount = 0
            //choose case i5wd.s_selectionchanged
            //    case "default"
            //        li_i = 1
            //        do while li_return = 1
            //            if i5wd.b_dw0[li_i] then 
            //                choose case left(i5wd.dw0[li_i].tag, 1)
            //                    case "2","3"
            //                        li_return = i5wd.dw0[li_i].AcceptText()
            //                        al_modifiedcount += i5wd.dw0[li_i].deletedcount() + i5wd.dw0[li_i].modifiedcount()
            //                end choose
            //            end if
            //            li_i++
            //            if li_i > upperbound(i5wd.dw0[]) then exit
            //        loop
            //    case "multiline"
            //        if i5wd.b_dw0[2] and li_return = 1 then
            //            choose case left(i5wd.dw0[2].tag, 1)
            //                case "2","3"
            //                    li_return = i5wd.dw0[2].accepttext()
            //                    al_modifiedcount += i5wd.dw0[2].deletedcount() + i5wd.dw0[2].modifiedcount()
            //            end choose
            //        end if
            //end choose

            //return li_return
            return 0;
        }

        private void dw_t02_RetrieveEnd(object sender, EventArgs e)
        {
            wtf_retrieveend_0123(2);
        }
        public long wtf_retrieveend_0123(long al_dw)
        {
            long ll_i;
            // 3
            if (i5wd.dw0[al_dw].Tag.ToString().Substring(0, 1) == "3")
            {
                wtf_set_win_title();
                switch (i5wd.dw0[al_dw].Tag.ToString().Substring(0, 1))
                {
                    case "2":
                    case "3":
                        if (i5wd.dw0[al_dw].rowcount() >= 0)
                        {
                            DateTime lrsj = DateTime.MinValue;
                            DateTime.TryParse(i5wd.dw0[al_dw].GetItemData(1, "lrsj"),out lrsj);
                            if (lrsj.AddDays(3).CompareTo(DateTime.Now) <= 0)
                                i5wd.b_newrow = true; // 是否新增加的记录，针对表头

                            i5wd.b_newrow = false;

                        }
                        i5wd.b_newrow = false;
                        break;
                }
                switch (i5wd.dw0[al_dw].Tag.ToString().Substring(0, 1))
                {
                    case "0":
                    case "1":
                    case "2":
                        // global.gu_dw1.f_dwsort(i5wd.dw0[al_dw], i5wd.dw0[al_dw].title);
                        break;
                }
                //i5wd.dw0[al_dw].SetRedraw(true)
                global.gu_dw1.f_dw_l_idid(al_dw, ref i5wd, i5wd.dw0[al_dw].rowcount());
                return 0;
            }

            // 0,1,2

            //setpointer(arrow!)
            if (al_dw <= 8)
            {
                switch (i5wd.l_focuschanged)
                {
                    case 999:
                        return 0;
                    default:
                        wtf_set_win_title();
                        break;
                }
            }

            i5wd.l_focuschanged = 0;
            //global.gu_dw1.f_dwsort(i5wd.dw0[al_dw], i5wd.dw0[al_dw].title);
            //i5wd.dw0[al_dw].SetRedraw(true);
            if (al_dw >= 9)
            {
                i5wd.b_dw0[al_dw + 32] = false;
                return 0;
            }
            return 0;
        }

        private void dw_t31_ItemChanged(object sender, ItemChangedEventArgs e)
        {

        }

        private void cb_t212_Click(object sender, EventArgs e)
        {

            if (wtf_tab3_ins_del_pre() == -1)
                return;
            global.g5_sys.s_object = i5wd.win0.Name + windowName;
            if (ue_delt_pre() == -1)
                return;
            if (wtf_tab3_delt(17) == -1)
                return;
            if (ue_delt_after() == -1)
                return;

        }
        public virtual long ue_delt_pre()
        {
            return 0;
        }
        public virtual long ue_delt_after()
        {
            return 0;
        }
        public long wtf_tab3_delt(long al_dw)
        {
            wtf_save_enabled();
            if (i5wd.dw0[al_dw].Cols[0].Name == i5wd.s_id_n[i5wd.l_newindex])
                return global.gu_dw1.f_delt_dw_row(ref i5wd.dw0[al_dw], ref i5wd.l_focuschanged, 0);
            else
                return global.gu_dw1.f_delt_dw_row(ref i5wd.dw0[al_dw], ref i5wd.l_focuschanged, 1);
        }
        public long wtf_save_save(long al_dw, string as_save)
        {
            if (i5wd.l_save_cpu >= 1)
            {
                if (Common.GetCurrentTimeUnix() - i5wd.l_save_cpu >= 8280000) // 2.4小时=8640000
                {
                    MessageBox.Show("这条数据不能被保存了，因为添加后已经超过2小时了！");
                    return -1;
                }
            }
            long ll_modify = 0;
            bool llb_modified;
            long ll_j, ll_i, ll_cj;
            long[] ll_null;
            string[] ls_sort;
            string ls_message = "";
            if (i5wd.b_dw0[al_dw])
            {
                //if global.gu_dw1.f_dddw_ddlb_find(i5wd.dw0[al_dw]) then return -1
                ll_modify += i5wd.dw0[al_dw].deletedcount() + i5wd.dw0[al_dw].modifiedcount();
                //if (as_save == "default") && isnumber(mid(i5wd.dw0[al_dw].tag,2,1)) and (i5wd.dw0[al_dw].rowcount() >= 1) 
                //{
                //    ll_cj = i5wd.dw0[al_dw].rowcount();
                //    for (ll_j = 1;ll_j<= to ll_cj;ll_j++)
                //    {
                //        if isnull(i5wd.dw0[al_dw].getitemnumber(ll_j , i5wd.s_id_n[al_dw])) or i5wd.dw0[al_dw].getitemnumber(ll_j , i5wd.s_id_n[al_dw]) <> i5wd.l_idid[al_dw] then
                //            gu_dw1.f_msg("保存失败，表头ID号错误" + string(i5wd.l_idid[al_dw]))
                //            return -1
                //        end if
                //        }
                //    }
                //}

                //if tab_t3.visible and i5wd.l_tab3 = 2 then
                //    for ll_i = 17 to 24
                //        if i5wd.b_dw0[ll_i] then
                //            if not gu_dw1.f_dddw_ddlb_find(i5wd.dw0[ll_i]) then return -1
                //            ll_modify += i5wd.dw0[ll_i].deletedcount() + i5wd.dw0[ll_i].modifiedcount()
                //            if (as_save = "default") and isnumber(mid(i5wd.dw0[ll_i].tag,2,1)) and (i5wd.dw0[ll_i].rowcount() >= 1) then
                //                ll_cj = i5wd.dw0[ll_i].rowcount()
                //                for ll_j = 1 to ll_cj
                //                    if isnull(i5wd.dw0[ll_i].getitemnumber(ll_j , i5wd.s_id_n[al_dw])) or &
                //                        i5wd.dw0[ll_i].getitemnumber(ll_j , i5wd.s_id_n[al_dw]) <> i5wd.l_idid[al_dw] then
                //                        gu_dw1.f_msg("保存失败，表体" + string(ll_i - 16) + "ID号错误")
                //                        return -1
                //                    end if
                //                next
                //            end if
                //        end if
                //    next
                //end if

                if (ll_modify > 0)
                {
                    //    if tab_t3.visible and i5wd.l_tab3 = 2 then
                    //        for ll_i = 17 to 24
                    //            if i5wd.b_dw0[ll_i] then
                    //                if (i5wd.dw0[ll_i].Describe("#1.coltype") = "long") and (i5wd.dw0[ll_i].Describe("#1.name") <> i5wd.s_id_n[al_dw]) then
                    //                    ls_sort[ll_i] = i5wd.dw0[ll_i].title
                    //                    gu_dw1.f_dwsort(i5wd.dw0[ll_i],i5wd.dw0[ll_i].Describe("#1.name") + " A")
                    //                end if
                    //            end if
                    //        next
                    //    end if
                    //    yield()
                    //    if not SQLCA.AutoCommit then
                    //        rollback;
                    //        yield()
                    //        gu_dw1.f_msg("SQLCA.AutoCommit应为true，现在是false")
                    //        return -1
                    //    end if
                    //    SQLCA.AutoCommit = false
                    //    yield()
                    //    if SQLCA.AutoCommit then
                    //        yield()
                    //        gu_dw1.f_msg("SQLCA.AutoCommit应为false，现在是true")
                    //        return -1
                    //    end if
                    //    yield()
                    //    llb_modified = true
                    //暂时实现，注意要用事务
                    try
                    {
                        if (i5wd.b_dw0[al_dw])
                        {
                            i5wd.dw0[al_dw].update(i5wd.l_idid[al_dw]);

                        }
                        if (tab_t3.Visible && i5wd.l_tab3 == 2)
                        {
                            for (ll_i = 17; ll_i <= 24; ll_i++)
                            {
                                if (i5wd.b_dw0[ll_i])
                                {
                                    i5wd.dw0[ll_i].update(0);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return -1;
                    }
                    //    if llb_modified then
                    //        if gu_dw1.f_t_updt_id_max(i5wd.dw0[al_dw],i5wd.s_id_n[al_dw],i5wd.s_tb_n[al_dw]) = -1 then goto rollback_end
                    //        if event ue_updt_id_max(ls_message) = -1 then goto rollback_end
                    //        commit;
                    //        choose case i5wd.s_updtend
                    //            case "n_n"
                    //                gu_dw1.f_t_updt_n_del(i5wd)
                    //        end choose
                    //        if i5wd.b_dw0[al_dw] then i5wd.dw0[al_dw].ResetUpdate() // commit与resetupdate中间的代码不能有yeild()，否则背景色不变化
                    //        SQLCA.AutoCommit = true
                    //        if tab_t3.visible and i5wd.l_tab3 = 2 then
                    //            for ll_i = 17 to 24
                    //                if i5wd.b_dw0[ll_i] then
                    //                    i5wd.dw0[ll_i].ResetUpdate()
                    //                    if (i5wd.dw0[ll_i].Describe("#1.coltype") = "long") and (i5wd.dw0[ll_i].Describe("#1.name") <> i5wd.s_id_n[al_dw]) then
                    //                        gu_dw1.f_dwsort(i5wd.dw0[ll_i],ls_sort[ll_i])
                    //                    end if
                    //                end if
                    //            next
                    //        end if
                    //        //位置变化了，不然修改过的字段背景色不变过来，PB的bug本来可以不用gu_dw1.f_t_updt_n_del(i5wd)的，直接放在resetupdate前面
                    //        choose case i5wd.s_updtend
                    //            case "n_n"
                    //                gu_dw1.f_t_updt_n_n(i5wd)
                    //        end choose
                    //        wtf_set_win_title()
                    //    else
                    //        rollback_end:
                    //        yield()
                    //        rollback;
                    //        yield()
                    //        rollback;
                    //        yield()
                    //        SQLCA.AutoCommit = true
                    //        yield()
                    //        if not SQLCA.AutoCommit then
                    //            yield()
                    //            SQLCA.AutoCommit = true
                    //            yield()
                    //        end if
                    //        yield()
                    //        if tab_t3.visible and i5wd.l_tab3 = 2 then
                    //            for ll_i = 17 to 24
                    //                if i5wd.b_dw0[ll_i] then
                    //                    if (i5wd.dw0[ll_i].Describe("#1.coltype") = "long") and (i5wd.dw0[ll_i].Describe("#1.name") <> i5wd.s_id_n[al_dw]) then
                    //                        gu_dw1.f_dwsort(i5wd.dw0[ll_i],ls_sort[ll_i])
                    //                    end if
                    //                end if
                    //            next
                    //        end if
                    //        gu_dw1.f_msg("提交数据库失败1" + sqlca.sqlerrtext + "~r~n" + ls_message)
                    //        return -1
                    //    end if
                    //else
                    //    return 0
                }

            }
            return 0;
        }

        private void cb_print_Click(object sender, EventArgs e)
        {

            if (i5wd.dw0[tab_t1.SelectedIndex + 1] != null)
                i5wd.dw0[tab_t1.SelectedIndex + 1].PrintPreview();

        }

        private void cb_tab3_export_Click(object sender, EventArgs e)
        {
            ExcelHelper.GridToExcel(dw_t31.dataGridView1, System.IO.Path.GetTempFileName() + ".xls");
        }
    }
}
