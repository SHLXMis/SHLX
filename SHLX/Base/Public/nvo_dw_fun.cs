using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Redsoft
{
    public class nvo_dw_fun
    {
        public long il_msg;
        public void f_open0(str_win_dw9 a5wd)
        {
            //第一位 
            //		0 表示主dw(表头)为list，不可更新，为grid
            //		1 表示此dw(表体)为list，不可更新，为grid
            //		2 表示此dw(表体)为update，可更新，多条数据，为grid
            //		3 表示此dw(表体)为update，可更新，单条数据，为freeform
            //第二三位  dw的代码，没有意义，只是为了区分，和第一位组合后不可重复
            //第四位  sql语句是否初始化，Y代表已初始化
            //第五位  是否可排序，Y代表可以排序
            //第六位  行是否可被选中，Y代表可以被选中
            //第七位  按enter键，光标跳转方式，H代表下一格，V代表下一行

            //为了下标从1开始，多定义一维
            a5wd.b_dw0 = new bool[66]
            {false,
                false,false,false,false,false,false,false,false,false,false,
	        false,false,false,false,false,false,false,false,false,false,
	        false,false,false,false,false,false,false,false,false,false,
	        false,false,
	        true,true,true,true,true,true,true,true,true,true,
	        true,true,true,true,true,true,true,true,true,true,
	        true,true,true,true,true,true,true,true,true,true,
	        true,true,
	        true};
            //	a5wd.b_dw0[ll_i] = false dw是否可用
            //	a5wd.b_dw0[ll_i + 32] = true // tab_t3需要retrieve
            // a5wd.b_dw0[65]代表可否修改数据
            a5wd.l_tab3 = 0; // 0代表没有tab_t3， 1 代表list9-16， 2代表update17-24， 3代表此界面没有tab_t3但其他界面有

            a5wd.s_cx_sql = new string[9] { "", "", "", "", "", "", "", "", "" };
            a5wd.s_id_n = new string[9];
            a5wd.s_tb_n = new string[9];
            a5wd.s_sql_n = new string[9];
            a5wd.s_cx_text = new string[9];
            a5wd.s_cx_sql = new string[9];
            a5wd.s_gjz_sqlname = new string[9];
            a5wd.s_gjz_colname = new string[9];
            a5wd.s_gjz_coltype = new string[9];
            a5wd.l_selectrow = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //选中的行号
            a5wd.l_idid = new long[9];
            a5wd.l_oldindex = 1;
            a5wd.b_itemerror = true; // 是否触发itemerror
            a5wd.l_focuschanged = 0; // 是否改变了焦点
            a5wd.b_log_pb = false;// 是否记录用户的操作日志
            a5wd.b_newrow = false;// 是否新增加的记录，针对表头
            a5wd.l_newindex = 1;
            a5wd.s_selectionchanged = "default";
            a5wd.s_resize = "h1";
            a5wd.s_updtend = "n_n";
            a5wd.l_save_cpu = 0;
            a5wd.d_tab_h = new double[]{0,
                0.7,0.7,0.7,0.7,0.7,0.7,0.7,0.7,
		    0.7,0.7,0.7,0.7,0.7,0.7,0.7,0.7,
		    0,0,0,0,0,0,0,0,
		    0,0,0,0,0,0,0,0,
		    0,0,0,0,0,0,0,0,
		    0,0,0,0,0,0,0,0,
            };

            //
            //datawindow idw_lis0,idw_updat0
            //datawindow idw_updat1_1,idw_updat1_2,idw_updat1_3,idw_updat1_4,idw_updat1_5,idw_updat1_6,idw_updat1_7,idw_updat1_8
            //datawindow idw_lis1_1,idw_lis1_2,idw_lis1_3,idw_lis1_4,idw_lis1_5,idw_lis1_6,idw_lis1_7,idw_lis1_8
            //string is_sql_cxtj="",is_id_name="",is_tb_name="",is_sql_name=""
            //long il_selectrow = 0,il_id = 0,il_oldindex=1
            //string is_localize_title="",is_localize_input=""
            //boolean a5wd.b_updt = false // 是否具有编辑权限
            //boolean ib_itemerror = true // 是否触发itemerror
            //boolean ib_itemfocuschanged = true // 是否改变了焦点
            //string is_gjz_text="",is_gjz_colname[1]="",is_gjz_coltype = "string",is_gjz_col_fl
            //boolean ib_log_pb = false // 是否记录用户的操作日志
            //long il_insted_id[],il_updtd_id[],il_deltd_id[]
            //boolean ib_newrow = false // 是否新增加的记录，针对表头
            //string is_wintitle


            a5wd.s_gjz_text = "";
            a5wd.b_updt = false; // 是否具有编辑权限
            a5wd.dw0 = new DataWindow[65];
        }
        public void f_sql_retrieve(string as_select, string as_cxtj, ref DataWindow adw_dw, bool ab_retrieve)
        {
            if (as_cxtj.Contains("\""))
            {
                MessageBox.Show("查询语句中不能含有双引号！");
                return;
            }
            adw_dw.CurrentConditoin = as_cxtj;
            adw_dw.Retrieve();

        }
        public void f_constr_private(ref DataWindow adw_dw)
        {
            //adw_dw.SetTransObject(sqlca)
            //string ls_sort
            //ls_sort = adw_dw.object.DataWindow.Table.Sort //adw_dw.describe("DataWindow.Table.Sort")
            //if not (((ls_sort = "?") or (ls_sort = "!") or (ls_sort = "") or isnull(ls_sort))) then
            //    adw_dw.title = ls_sort
            //    adw_dw.setsort("")
            //end if
            //adw_dw.object.DataWindow.Table.Sort=""
            ////adw_dw.modify('DataWindow.Table.Sort=""')
            ////settrans()和settransobject()得功能几乎一样，只是前者内部自动调用connect或disconnect,在系统中这样频繁的调用对系统的性能是有影响。 
            //string ls_colname,ls_t9,ls_9
            //string ls_lpobjects
            //long ll_looppos
            //ls_9 = char(9)
            //ls_t9 = "_t" + ls_9
            //ls_lpobjects = adw_dw.Describe("datawindow.objects") + ls_9
            //if ls_lpobjects = ls_9 then
            //    f_error("datawindow未设置", adw_dw.classname())
            ////f_msg("",g5_sys.s_object)
            //end if
            //ll_looppos = pos(ls_lpobjects,ls_t9)
            //do while ll_looppos >= 2
            //    ls_colname = left(ls_lpobjects, ll_looppos - 1)
            ////	ls_lpobjects = mid(ls_lpobjects, ll_looppos + 3)
            //    ll_looppos = pos(ls_lpobjects, ls_t9, ll_looppos + 3)
            //    if lastpos(ls_colname, ls_9) >= 1 then ls_colname = midw(ls_colname, lastpos(ls_colname, ls_9) + 1)
            //    if adw_dw.Describe(ls_colname + ".visible") = "0" then adw_dw.modify(ls_colname + '_t.tag="private"')
            //loop
            //adw_dw.object.datawindow.print.documentname = string(long(adw_dw.DesCribe('datawindow.detail.height')) - 8)
        }
        public void f_get_sql_id_table(ref DataWindow adw_dw, ref string as_id_name, ref string as_sql_name, ref string as_tb_name)
        {
            as_id_name = adw_dw.IdCol;
            as_sql_name = adw_dw.SqlName;
            as_tb_name = adw_dw.TableName;
            //if (lower(left(as_tb_name,4)) == "dbo." )
            //    as_tb_name = mid(as_tb_name,5);

        }
        public void f_constr_win0(string as_username, string as_winname, ref str_sys_dw a5dww, ref str_win_dw9 a5wd)
        {
            string ls_tab_h = "";

            string sql = "select top 1 colname,dw_2_3	.header_color,header_fontcolor,header_fontsize,header_fontface,header_height,detail_fontsize,detail_fontface,detail_height,detail_color1,detail_color2,detail_color3,detail_fontcolor1,detail_fontcolor2,detail_fontcolor3,detail_input_bcoloro,detail_input_bcolorm,dw_color,getdate() " +
              "  from mis_dw_argument WITH (NOLOCK) " +
              "  where user_name1 = :as_username and window1 = :as_winname and dataobject = '' ";

            global.gu_pub1.il_getdate = DateTime.Now.Millisecond;
            if (a5dww.detail_color1 != "")
                f_constr_color0_get(ref a5dww);
            if (a5wd.l_tab3 >= 1 && ls_tab_h != "")
            {
                global.gu_pub1.f_s_listtoarray(ls_tab_h, ",", ref a5wd.d_tab_h);
                //string[] ss = ls_tab_h.Split(','); ;
                //a5wd.d_tab_h = ss.Select(x => Convert.ToDouble(x)).ToArray();

            }
            if (a5wd.d_tab_h.Length < 48 && a5wd.l_tab3 >= 0)
                a5wd.d_tab_h = new double[] {0,
            0.7,0.7,0.7,0.7,0.7,0.7,0.7,0.7, 
		        0.7,0.7,0.7,0.7,0.7,0.7,0.7,0.7,
		        0,0,0,0,0,0,0,0,
		        0,0,0,0,0,0,0,0,
		        0,0,0,0,0,0,0,0,
		        0,0,0,0,0,0,0,0};

        }
        public void f_constr_color0_get(ref str_sys_dw astr_dws)
        {
            switch (astr_dws.dw_2_3)
            {
                case "2":
                    astr_dws.detail_color0 = "if(mod(getrow(),2)=1,' + astr_dws.detail_color1 + ',' + astr_dws.detail_color2 + ')";
                    astr_dws.detail_fontcolor0 = "if(mod(getrow(),2)=1,' + astr_dws.detail_fontcolor1 + ',' + astr_dws.detail_fontcolor2 + ')";
                    break;
                case "3":
                    astr_dws.detail_color0 = "case(mod(getrow(),3) when 1 then ' + astr_dws.detail_color1 + ' when 2 then ' + astr_dws.detail_color2 + ' else ' + astr_dws.detail_color3 + ')";
                    astr_dws.detail_fontcolor0 = "case(mod(getrow(),3) when 1 then ' + astr_dws.detail_fontcolor1 + ' when 2 then ' + astr_dws.detail_fontcolor2 + ' else ' + astr_dws.detail_fontcolor3 + ')";
                    break;
            }
        }
        public str_sys_dw f_constr_load(string as_username, string as_winname, ref DataWindow adw_dw, ref str_sys_dw astr_dws_g, ref str_sys_dw astr_dws_i)
        {
            //待实现
            str_sys_dw ret = new str_sys_dw();
            return ret;
        }
        public void f_dw_l_idid(long al_dw, ref str_win_dw9 a5wd, long al_selectrow)
        {
            a5wd.l_selectrow[al_dw] = al_selectrow;
            long ll_i;
            if (a5wd.l_selectrow[al_dw] >= 0 && a5wd.l_selectrow[al_dw] <= a5wd.dw0[al_dw].rowcount())
            {
                if (a5wd.s_id_n.Length >= al_dw)
                {
                    if (a5wd.s_id_n[al_dw] != "")
                    {
                        switch (a5wd.dw0[al_dw].IdDataType)
                        {

                            case "long":
                            case "ulong":
                            case "int":
                                {
                                    if (a5wd.l_idid[al_dw] != Common.GetLong(a5wd.dw0[al_dw].GetItemData(a5wd.l_selectrow[al_dw], a5wd.s_id_n[al_dw])))
                                    {
                                        if (a5wd.s_selectionchanged.Substring(0, 5) == "list8") // w_t_list8、w_t_list16使用
                                        {
                                            if (a5wd.b_dw0.Length >= 25)
                                            {
                                                for (ll_i = 25; ll_i <= 32; ll_i++)
                                                {
                                                    if (a5wd.b_dw0[ll_i])
                                                    {
                                                        a5wd.dw0[ll_i].reset();
                                                        a5wd.b_dw0[ll_i + 32] = true; //判断dw是否已经retrieve了 true表示没有retrieve，false表示已经retrieve了
                                                    }
                                                }
                                            }
                                            else if (al_dw <= 8) // w_t_t9等模板使用
                                            {
                                                if (a5wd.b_dw0.Length >= 9)
                                                    for (ll_i = 9; ll_i <= 16; ll_i++)
                                                    {
                                                        if (a5wd.b_dw0[ll_i])
                                                        {
                                                            a5wd.dw0[ll_i].reset();
                                                            a5wd.b_dw0[ll_i + 32] = true; //判断dw是否已经retrieve了 true表示没有retrieve，false表示已经retrieve了
                                                        }
                                                    }
                                            }
                                        }
                                        a5wd.l_idid[al_dw] = Common.GetLong(a5wd.dw0[al_dw].GetItemData(a5wd.l_selectrow[al_dw], a5wd.s_id_n[al_dw]));
                                    }
                                }
                                break;
                            default:
                                {
                                    a5wd.l_idid[al_dw] = 0;
                                    break;
                                }
                        }
                    }
                    else
                        a5wd.l_idid[al_dw] = 0;
                }
                else
                    a5wd.l_idid[al_dw] = 0;

            }
            else
            {
                a5wd.l_selectrow[al_dw] = 0;
                a5wd.l_idid[al_dw] = 0;
                if (a5wd.s_selectionchanged.Substring(0, 5) == "list8")
                {// w_t_list8、w_t_list16使用
                    if (a5wd.b_dw0.Length >= 25)
                    {
                        for (ll_i = 25; ll_i <= 32; ll_i++)
                        {
                            if (a5wd.b_dw0[ll_i])
                            {
                                a5wd.dw0[ll_i].reset();
                                a5wd.b_dw0[ll_i + 32] = true; //判断dw是否已经retrieve了 true表示没有retrieve，false表示已经retrieve了
                            }
                        }
                    }
                    else if (al_dw <= 8)
                    {// w_t_t9等模板使用
                        if (a5wd.b_dw0.Length >= 9)
                        {
                            for (ll_i = 9; ll_i <= 16; ll_i++)
                            {
                                if (a5wd.b_dw0[ll_i])
                                    a5wd.dw0[ll_i].reset();
                                a5wd.b_dw0[ll_i + 32] = true; //判断dw是否已经retrieve了 true表示没有retrieve，false表示已经retrieve了
                            }
                        }
                    }
                }
            }
        }
        public void f_constr_save(string as_username, string as_winname, DataWindow adw_dw)
        {
            //string ls_dwname;
            //ls_dwname = adw_dw.DataObject + "_" + adw_dw.Tag.ToString().Substring(0,3);
            //string ls_colwb,ls_colxb,ls_colvb,ls_colsortb,ls_colnb;
            //string[] ls_colxa,ls_colna,ls_colwa,ls_colva;
            //f_constr_getx(adw_dw,ls_colna,ls_colxa,ls_colwa,ls_colva);
            //ls_colnb=global.gu_pub1.f_s_arraytolista(ls_colna,";");
            //ls_colxb=global.gu_pub1.f_s_arraytolista(ls_colxa,";");
            //ls_colwb=global.gu_pub1.f_s_arraytolista(ls_colwa,";");
            //ls_colvb=global.gu_pub1.f_s_arraytolista(ls_colva,";");


            //string ls_colwc,ls_colxc,ls_colvc,ls_colnc,ls_colsortc,ls_colsortsetc
            //select top 1 colname,colx,colwidth,colvisible,colsort,sort_set
            //into :ls_colnc,:ls_colxc,:ls_colwc,:ls_colvc,:ls_colsortc,:ls_colsortsetc
            //    from mis_dw_argument WITH (NOLOCK)
            //    where user_name1 = :as_username and window1 = :as_winname and dataobject = :ls_dwname ;
            //if ls_colsortsetc = "Y" then // 每次打开页面时排序固定，用在设置页面设置好的排序
            //    if ls_colnc + ls_colxc + ls_colwc + ls_colvc = ls_colnb + ls_colxb + ls_colwb + ls_colvb then return
            //    update mis_dw_argument set 
            //        colname = :ls_colnb,
            //        colx = :ls_colxb,
            //        colwidth = :ls_colwb,
            //        colvisible = :ls_colvb,
            //        lrsj=getdate()
            //    where user_name1 = :as_username and window1 = :as_winname and dataobject = :ls_dwname ;
            //elseif ls_colsortsetc = "N" then // 每次打开页面时排序不固定，用每次关闭页面时的排序
            //    ls_colsortb = adw_dw.title //describe("DataWindow.Table.Sort")
            //    if ls_colnc + ls_colxc + ls_colwc + ls_colvc + ls_colsortc = ls_colnb + ls_colxb + ls_colwb + ls_colvb + ls_colsortb then return
            //    update mis_dw_argument set 
            //        colname = :ls_colnb,
            //        colx = :ls_colxb,
            //        colwidth = :ls_colwb,
            //        colvisible = :ls_colvb,
            //        colsort = :ls_colsortb,
            //        lrsj=getdate()
            //    where user_name1 = :as_username and window1 = :as_winname and dataobject = :ls_dwname ;
            //else
            //    ls_colsortb = adw_dw.title //describe("DataWindow.Table.Sort")
            //    insert into mis_dw_argument (user_name1,window1,dataobject,colname,colx,colwidth,colvisible,colsort,sort_set,lrsj)
            //    values (:as_username,:as_winname,:ls_dwname,:ls_colnb,:ls_colxb,:ls_colwb,:ls_colvb,:ls_colsortb,"N",getdate()) ;
            //end if


        }
        public void f_dddw_show(string as_col, ref DataWindow adw_dw, ref long al_dropdown_show)
        {
            //choose case adw_dw.DesCribe(as_col+'.edit.style')
            //    case 'dddw'
            //        if al_dropdown_show <= 256 then
            //            keybd_event(115, 0, 0, 0 )         //  按下F4  
            //            keybd_event(115, 0, 2, 0 )         //  释放F4 
            //        end if
            //    case 'ddlb'
            //        if al_dropdown_show <= 256 then
            //            keybd_event(115, 0, 0, 0 )         //  按下F4  
            //            al_dropdown_show = 888
            //            keybd_event(115, 0, 2, 0 )         //  释放F4 
            //        end if

            //end choose


        }
        public long f_itemchanged(ref long row, ref string dwo, ref string data, ref DataWindow adw_dw, DateTime adt_0)
        {
            //if isnull(data) or data = "" then return 0
            //long ll_data,ll_year,ll_jk
            //string ls_mess = "",ls_name
            //CHOOSE CASE dwo.ColType
            //    CASE "date","datetime"
            //        ll_data = long(left(data,4))
            //        ll_year = year(date(adt_0)) // 服务器上的当前日期
            //        if ll_data <= 1753 then
            //            ls_mess = "您输入的 " + adw_dw.describe(dwo.name+"_t.text") + "：" + data + "太小了，必须大于1753年！"
            //            goto rtend
            //        end if
            //        ls_name = trim(adw_dw.describe(dwo.name+"_t.tag"))
            //        choose case ls_name
            //            case "?",""
            //                ls_name = right(dwo.name,3)
            //        end choose
            //        choose case ls_name
            //            case "_1t"
            //                ll_jk = 10
            //            case "_2t"
            //                ll_jk = 20
            //            case "_5t"
            //                ll_jk = 50
            //            case "_1h"
            //                ll_jk = 100
            //            case "_2h"
            //                ll_jk = 200
            //            case "_5h"
            //                ll_jk = 500
            //            case "_1k"
            //                ll_jk = 1000
            //            case "_2k"
            //                ll_jk = 2000
            //            case "_5k"
            //                ll_jk = 5000
            //            case else
            //                ll_jk = 1
            //        end choose
            //        if ll_data > ll_year + ll_jk or ll_data < ll_year - ll_jk then
            //            ls_mess = "您输入的 " + adw_dw.describe(dwo.name+"_t.text") + "：" + data + "不正确，与当前日期相差太大了！"
            //            goto rtend
            //        end if
            //END CHOOSE



            //rtend:
            //if ls_mess = "" then
            //    return 0
            //else
            //    f_msg(ls_mess)
            //    return 1
            //end if
            return 0;
        }

        public long f_t_rowfocuschanged(long currentrow, long al_index1, long al_index3, ref str_win_dw9 a5wd)
        {
            switch (a5wd.l_focuschanged)
            {
                case 999: // update后导致的焦点改变，retrieve浏览页面前
                    return 0;
                case 998: // update后导致的焦点改变，retrieve浏览页面后
                    a5wd.l_focuschanged = 0;
                    break;
                case 888: // constructor后导致的焦点改变
                    return 0;
                case 777://retrieve 后导致的焦点改变
                    return 0;
                case 666: //多行删除选中行后导致的焦点改变
                    return 0;
                case 555://双击列名排序、单击列名
                    return 0;
                case 444: //在rowfocuschanging中设置，不执行rowfocuschanged中的预定代码
                    return 0;
            }
            if (a5wd.dw0[al_index1] == null)
                return 0;
            switch (a5wd.dw0[al_index1].Tag.ToString().Substring(0, 1))
            {
                case "2":
                case "3":
                    {
                        if (currentrow >= 0)
                            return 0;
                        else if (currentrow > -2147483600)  //2147483647
                            currentrow = -currentrow;
                    }
                    break;
            }


            long ll_i = 0;
            if (currentrow == -2147483647) //9 - 24
            {
                if (a5wd.b_dw0[al_index3] && a5wd.b_dw0[al_index3 + 32] && a5wd.l_idid[al_index1] >= 0)
                {
                    a5wd.dw0[al_index3].Retrieve(a5wd.l_idid[al_index1]);
                    a5wd.b_dw0[ll_i + 32] = false;
                }
            }
            else // 1 - 8
            {
                //if a5wd.dw0[al_index1].Describe(a5wd.s_id_n[al_index1]+'.coltype') <> "long" then return 0
                if (a5wd.l_selectrow[al_index1] < 0 ||
                    currentrow < 0 || currentrow > a5wd.dw0[al_index1].rowcount()
                    || a5wd.l_selectrow[al_index1] > a5wd.dw0[al_index1].rowcount())
                {
                    f_dw_l_idid(al_index1, ref a5wd, 0);

                    return 0;
                }
                else
                    if (a5wd.l_selectrow[al_index1] != currentrow)
                    {
                        //MessageBox.Show("系统发生了错误，请与 系统管理员 联系，l_selectrow:" + a5wd.l_selectrow[al_index1].ToString() + "currentrow:" + currentrow.ToString());
                        //f_dw_l_idid(al_index1, ref a5wd, 0);
                        //return 0;
                    }


                if (al_index3 < 0) return 0;

                if (a5wd.b_dw0[al_index3] && a5wd.b_dw0[al_index3 + 32])
                {
                    a5wd.dw0[al_index3].Retrieve(a5wd.l_idid[al_index1]);
                    a5wd.b_dw0[ll_i + 32] = false;
                }
            }

            return 0;
        }

        public long f_clicked(ref long al_dw, ref long row, ref string dwo, ref str_win_dw9 a5wd)
        {
            f_dw_l_idid(al_dw, ref a5wd, row);
            //if (row < 0 || row > a5wd.dw0[al_dw].RowCount() )
            //{
            //    if (a5wd.dw0[al_dw].Tag.ToString().Substring(0,1) == "3" )
            //        return 0;
            //    f_dw_l_idid(al_dw,ref a5wd,0);
            //    return 0;
            //}
            //// 更新页面需要编辑时才不选中行 开始
            //switch (a5wd.dw0[al_dw].Tag.ToString().Substring(0,1))
            //{
            //    case "2":
            //        if a5wd.dw0[al_dw].getcolumnname() <> dwo.name or a5wd.dw0[al_dw].getrow() <> row then
            //            f_dddw_original(a5wd.dw0[al_dw])
            //            a5wd.l_dropdown_show = 1
            //        end if
            //        if mid(a5wd.dw0[al_dw].tag,6,1) = "N" then return 0
            //        if dwo.type = "column" then
            //            if a5wd.dw0[al_dw].Describe(dwo.name+'.background.mode') ="0" then
            //                a5wd.dw0[al_dw].SetColumn(string(dwo.name))
            //                a5wd.dw0[al_dw].SelectRow(0,false)
            //                f_dw_l_idid(al_dw,a5wd,0)
            //                return 0
            //            end if
            //        else
            //            a5wd.dw0[al_dw].SelectRow(0,false)
            //            f_dw_l_idid(al_dw,a5wd,0)
            //            return 0
            //        end if
            //        a5wd.dw0[al_dw].setrow(row);
            //        f_t_rowfocuschanging(-22,row,al_dw,a5wd);
            //        return 0
            //    case '3'
            //        if a5wd.dw0[al_dw].getcolumnname() <> dwo.name or a5wd.dw0[al_dw].getrow() <> row then
            //            f_dddw_original(a5wd.dw0[al_dw])
            //            a5wd.l_dropdown_show = 1
            //        end if
            //        if mid(a5wd.dw0[al_dw].tag,6,1) = "N" then return 0
            //        a5wd.dw0[al_dw].SelectRow(0,false)
            //        f_dw_l_idid(al_dw,a5wd,0)
            //        return 0
            //    case else
            //        if mid(a5wd.dw0[al_dw].tag,6,1) = "N" then return 0
            //        if dwo.type = "column" then a5wd.dw0[al_dw].SetColumn(string(dwo.name))
            //}
            //// 更新页面需要编辑时才不选中行 结束

            //if a5wd.dw0[al_dw].GetRow() = row then
            //    if keydown(KeyControl!) then
            //        f_dw_l_idid(al_dw,a5wd,0)
            //        a5wd.dw0[al_dw].SelectRow(row, not a5wd.dw0[al_dw].IsSelected(row))
            //        return 0
            //    elseif keydown(KeyShift!) then
            //        f_dw_l_idid(al_dw,a5wd,0)
            //    elseif keydown(KeyAlt!) then
            //        f_dw_l_idid(al_dw,a5wd,0)
            //    else
            //        if a5wd.l_focuschanged = 998 or a5wd.l_selectrow [al_dw] = 0 then a5wd.dw0[al_dw].post event rowfocuschanged(row)
            //        f_dw_l_idid(al_dw,a5wd,row)
            //        if not a5wd.dw0[al_dw].IsSelected(row) then
            //            a5wd.dw0[al_dw].selectrow(0,false)
            //            a5wd.dw0[al_dw].SelectRow(row, true)
            //        end if
            //    end if
            //else
            //    a5wd.dw0[al_dw].ScrolltoRow(row);
            //end if

            return 0;

        }
        public long f_delt_dw_row(long al_dw, ref str_win_dw9 a5wd, long al_xuhao)
        {
            f_dw_l_idid(al_dw, ref a5wd, 0);
            return f_delt_dw_row(ref a5wd.dw0[al_dw], ref a5wd.l_focuschanged, al_xuhao);
        }
        public long f_delt_dw_row(ref DataWindow adw_dw, ref long al_focuschanged, long al_xuhao)
        {
            if (al_xuhao >= 0)
            {
                if (MessageBox.Show("您确实要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return -1;

            }
            al_focuschanged = 666; //多行删除选中行后导致的焦点改变
            long ll_i, ll_count;
            ll_count = adw_dw.rowcount();
            if (adw_dw.Tag.ToString().Substring(0, 1) == "3")  // 单行删除
            {
                if (ll_count == 1)
                {
                    if (f_delt_dw_pre_file(ref adw_dw, ll_count) == -1)
                        return -1;
                    adw_dw.deleterow(1);
                }
            }
            else // 多行删除
            {
                //for (ll_i = ll_count; ll_i >= 1; ll_i--)
                //{
                //    if (adw_dw.IsSelected(ll_i))
                //    {
                //        if (f_delt_dw_pre_file(ref adw_dw, ll_i) == -1)
                //            return -1;
                //        adw_dw.deleterow(ll_i);
                //    }
                //}
                for (int i = adw_dw.dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                {
                    if (f_delt_dw_pre_file(ref adw_dw, adw_dw.dataGridView1.SelectedRows[i].Index) == -1)
                        return -1;
                    adw_dw.deleterow(adw_dw.dataGridView1.SelectedRows[i].Index);
                }
            }
            al_focuschanged = 0;
            //al_xuhao  // 1代表有序号的需要重新更改序号  0代表没有序号的跳过 负数代表不提示直接删除
            if (al_xuhao == 1)
            {
                string ls_colname, ls_sort = "";
                //ls_sort = adw_dw.title;
                ls_colname = adw_dw.Cols[0].Name;
                f_dwsort(adw_dw, ls_colname + " A");
                for (ll_i = 0; ll_i < adw_dw.rowcount(); ll_i++)
                {
                    if (adw_dw.GetItemData(ll_i, ls_colname) != ll_i.ToString())
                        adw_dw.setitem(ll_i, ls_colname, ll_i + 1);

                }
                f_dwsort(adw_dw, ls_sort);
            }
            return 1;

        }
        public void f_dwsort(DataWindow adw_dw, string as_colname)
        {
            //if mid(adw_dw.tag,5,1) = "N" then return
            //string ls_sort
            ////f_msg("2",as_dwname+as_colname)
            //if rightw(as_colname,2) = '_t' then
            //    adw_dw.SetRedraw(false)
            //    ls_sort = f_dwsort_ctrl(adw_dw,as_colname)
            //else
            //    ls_sort = f_dwsort_sort(adw_dw,as_colname)
            //end if

            //if trim(ls_sort) = "" or isnull(ls_sort) then
            //    if rightw(as_colname,2) = '_t' then adw_dw.SetRedraw(true)
            //    return
            //end if

            //adw_dw.title = ls_sort
            //string ls_upper[],ls_col
            //long ll_i,ll_ci
            //any lll
            //gu_pub1.f_s_listtoarray(ls_sort,", ",ls_upper[])
            //ll_ci = upperbound(ls_upper[])
            //for ll_i = 1 to ll_ci
            //    ls_col = left(ls_upper[ll_i],len(ls_upper[ll_i]) - 2)
            //    if left(adw_dw.Describe(ls_col+'.coltype') , 5) = "char(" then
            //         ls_upper[ll_i] = "upper("+ls_col+") " + right(ls_upper[ll_i],1)
            //    end if
            //next
            //ls_sort = gu_pub1.f_s_arraytolists(ls_upper[],", ")

            //adw_dw.SetSort(ls_sort)
            //adw_dw.Sort()
            //adw_dw.SetSort("")
            //adw_dw.GroupCalc()//重新计算分组   
            ////	f_msg("当前排序",fdw_dw.describe("DataWindow.Table.Sort"))

            //if rightw(as_colname,2) = '_t' then adw_dw.SetRedraw(true)
            //return
        }
        public long f_delt_dw_pre_file(ref DataWindow adw_dw, long row)
        {// 数据浏览界面删除数据不做检查
            //choose case left(adw_dw.tag,1)
            //    case "0","1"
            //        return 0
            //end choose
            ////上传文件的字段后缀必须是“_7z”
            //long ll_j,ll_cj
            //string ls_data,ls_col
            //ll_cj=long(adw_dw.Object.DataWindow.Column.Count)
            //for ll_j = 1 to ll_cj
            //    if left(adw_dw.Describe("#" + string(ll_j) + ".coltype") , 5) <> "char(" then continue // 不是字符型的不判断
            //    ls_col = adw_dw.Describe("#" + string(ll_j) + ".name")
            //    if right(ls_col,3) <> "_7z" then continue // 后缀名不是_7z的不判断
            //        ls_data = adw_dw.getitemstring(row, ls_col)
            //        if isnull(ls_data) or trim(ls_data) = "" then continue
            //        f_msg("提示f_delt_dw_pre_file  请先删除，第 " + string(row) + " 行 " + adw_dw.describe(ls_col + "_t.text") + " 的上传文件 " + ls_data )
            //        return -1
            //next

            return 0;
        }
        public long f_delt_dw_pre_file(ref DataWindow adw_dw)
        {// 数据浏览界面删除数据不做检查
            //choose case left(adw_dw.tag,1)
            //    case "0","1"
            //        return 0
            //end choose	
            ////上传文件的字段后缀必须是“_7z”
            //long ll_ci,ll_i,ll_j,ll_cj
            //string ls_data,ls_col
            //ll_ci = adw_dw.rowcount()
            //ll_cj=long(adw_dw.Object.DataWindow.Column.Count)
            //for ll_j = 1 to ll_cj
            //    if left(adw_dw.Describe("#" + string(ll_j) + ".coltype") , 5) <> "char(" then continue // 不是字符型的不判断
            //    ls_col = adw_dw.Describe("#" + string(ll_j) + ".name")
            //    if right(ls_col,3) <> "_7z" then continue // 后缀名不是_7z的不判断
            //    for ll_i = 1 to ll_ci
            //        ls_data = adw_dw.getitemstring(ll_i, ls_col)
            //        if isnull(ls_data) or trim(ls_data) = "" then continue
            //        f_msg( "请先删除，第 " + string(ll_i) + " 行 " + adw_dw.describe(ls_col + "_t.text") + " 的上传文件 " + ls_data )
            //        return -1
            //    next
            //next

            return 0;
        }
        public long f_dw_col_isnull(ref long row, ref string dwo, ref string data, ref DataWindow adw_dw)
        {
            //            choose case left(dwo.coltype , 5)
            //    case "char("
            //        if isnull(data) or data = "" or left(data,1) = " " or right(data,1) = " " then
            //            f_msg( adw_dw.describe(dwo.name + "_t.text") + " 为空或第一个字符为空或最后一个字符为空！")
            //            return -1
            //        end if
            //    case "date"
            //        if isnull(data) then
            //            f_msg( adw_dw.describe(dwo.name + "_t.text") + " 不能为空！")
            //            return -1
            //        end if
            //    case "datet"
            //        if isnull(data) then
            //            f_msg( adw_dw.describe(dwo.name + "_t.text") + " 不能为空！")
            //            return -1
            //        end if
            //    case "decim","int","long","numbe","real","ulong"
            //        if isnull(data) then
            //            f_msg( adw_dw.describe(dwo.name + "_t.text") + " 不能为空！")
            //            return -1
            //        end if
            //    case "time","times"
            //        if isnull(data) then
            //            f_msg( adw_dw.describe(dwo.name + "_t.text") + " 不能为空！")
            //            return -1
            //        end if
            //    case "!"
            //        f_msg("提示dw_col_isnull 找不到相对应的字段（" + string(dwo.name) + "）！")
            //        return 0
            //    case else
            //        f_msg("提示dw_col_isnull " + string(dwo.coltype) + " 未知的数据类型，请把这条信息发送给信息管理员")
            //        return 0
            //end choose
            return 0;
        }
        public double f_rounnd(double ad_x, int ai_n)
        {
            //if ad_x < 0 then return - f_rounnd( - ad_x , ai_n)
            //string ls_x,ls_l1,ls_r1,ls_l2,ls_r2
            //long ll_i,ll_j
            //ls_x = string(ad_x)
            //if pos(ls_x,".") > 0 then
            //    ls_l1 = left(ls_x, pos(ls_x,".") - 1)
            //    ls_r1 = mid(ls_x, pos(ls_x,".") + 1)
            //else
            //    ls_l1 = ls_x
            //    ls_r1 = "0"
            //end if
            //if ai_n <= -1 then // 小数点前面四舍五入
            //    ls_l2 = ls_l1
            //    if len(ls_l2) = -ai_n then // 位数相等 如：round(125.2,-3)=0，round(525.2,-3)=1000
            //        if left(ls_l2,1) >= "5" then
            //            ls_l2 = "1"
            //        else
            //            ls_l2 = "0"
            //        end if
            //    elseif len(ls_l2) < -ai_n then //如：round(125.2,-4)=0，round(525.2,-4)=0
            //        ls_l2 = "0"
            //    else		 //如：round(125.2,-2)=100，round(555.2,-2)=600
            //        for ll_i = -1 to ai_n step -1
            //            ls_r2 = right(ls_l2, 1)
            //            ls_l2 = left(ls_l2, len(ls_l2) - 1)
            //        next
            //        if ls_r2 >= "5" then ls_l2 = string(long(ls_l2) + 1)
            //    end if
            //    if ls_l2 = "0" then
            //        return 0
            //    else
            //        for ll_i = -1 to ai_n step -1
            //            ls_l2 = ls_l2 + "0"
            //        next
            //        return double(ls_l2)
            //    end if
            //elseif ai_n = 0 then //四舍五入到整数 //如：round(125.2,0)=125，round(525.5,0)=525
            //    if left(ls_r1,1) >= "5" then
            //        return double(long(ls_l1) + 1)
            //    else
            //        return double(ls_l1)
            //    end if
            //else
            //    ls_r2 =ls_r1
            //    if len(ls_r2) > ai_n then //小数位小于四舍五入位数，不需要处理，如：round(125.2,4)=125.2000，round(525.2,2)=525.20，round(525.4,1)=525.4，round(525.5,1)=525.5
            //        ls_r2 = mid(ls_r1, ai_n + 1, 1)
            //        ls_l2 = left(ls_r1, ai_n)
            //        if ls_r2 >= "5" then ls_l2 = string(long(ls_l2) + 1)
            //        if len(ls_l2) > ai_n then //如：round(125.999,2)=126.00
            //            ls_l2 = mid(ls_l2, 2)
            //            ls_l1 = string(long(ls_l1) + 1)
            //        elseif len(ls_l2) < ai_n then//round(125.015,2)=125.02则 ls_l2 = "2"
            //            ll_j=len(ls_l2) + 1
            //            for ll_i = ll_j to ai_n
            //                ls_l2 = "0" + ls_l2
            //            next
            //        end if
            //    else
            //        return ad_x
            //    end if
            //    return double(ls_l1 + "." + ls_l2)
            //end if
            return 0;
        }
        public string f_get_id_max2(string as_tb_name, bool ab_autocommit)
        {
            if (as_tb_name.Trim() == "" || as_tb_name == null) return "";
            as_tb_name = as_tb_name.Trim().ToLower();
            string ls_id_max = string.Empty;
            // 此处声明存储过程名称
            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = new SqlParameter("@ls_id_max", SqlDbType.VarChar, 2000);
            para.Direction = ParameterDirection.Output;
            outparas.Add(para);
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@as_tb_name", as_tb_name);
            paras.Add(para);
            DBAccess.ExecSP("id_max_get2", paras, ref outparas);
            int result = 0;
            switch (as_tb_name)
            {
                case "jg_jgd_h_jgdh":
                case "jg_jgd_h_ggdh":
                case "jjg_h_pihao":
                    return ls_id_max;
                default:
                    if (Int32.TryParse(ls_id_max, out result))
                    {
                        return ls_id_max;
                    }
                    else
                    {
                        f_msg(ls_id_max);
                        return "-1";
                    }
                    break;
            }

            return ls_id_max;
        }
        public void f_msg(string as_msg)
        {
            long ll_id;
            switch (il_msg)
            {
                case 0:
                    MessageBox.Show(as_msg, "提示");
                    break;
                case 1:
                    ll_id = Convert.ToInt64(f_get_id_max2("xxzx_baoxiu", true));
                    if (ll_id <= 0)
                    {
                        MessageBox.Show(as_msg, "提示");
                        return;
                    }
                    string sql = string.Format(@"
		insert into xxzx_baoxiu (xxzx_id,tel_com,riqi_baoxiu,wtms,baoxiuren
			,ip,lrr,lrsj)
		values ( {0}, '程序修改', getdate(), '{1}', '{2}'
			, '{3}', '{4}', getdate()) ;", ll_id, as_msg, global.g5_sys.truename, global.g5_sys.ip, global.g5_sys.app_name);
                    DBAccess.ExecuteSql(sql);
                    break;
                case 2:
                    ll_id = Convert.ToInt64(f_get_id_max2("xxzx_baoxiu", true));
                    if (ll_id <= 0)
                    {
                        MessageBox.Show(as_msg, "提示");
                        return;
                    }
                    sql = string.Format(@"
		insert into xxzx_baoxiu (xxzx_id,tel_com,riqi_baoxiu,wtms,baoxiuren
			,ip,lrr,lrsj)
		values ( {0}, '程序修改', getdate(), '{1}', '{2}'
			, '{3}', '{4}', getdate()) ;", ll_id, as_msg, global.g5_sys.truename, global.g5_sys.ip, global.g5_sys.app_name);
                    DBAccess.ExecuteSql(sql);
                    MessageBox.Show(as_msg, "提示");
                    break;
            }
        }
        public void fe_encode2(ref string as_logid, ref string as_psw, string as_app_name, string as_cusername, string as_ip, string as_mac, string as_hostname)
        {
            string ls_return = string.Empty;
            long ll_pass_ts;
            bool lb_sql = false;
            List<IDbDataParameter> outparas = new List<IDbDataParameter>();
            SqlParameter para = new SqlParameter("@ls_return", SqlDbType.VarChar, 2000);
            para.Direction = ParameterDirection.Output;
            outparas.Add(para);
            List<IDbDataParameter> paras = new List<IDbDataParameter>();
            para = new SqlParameter("@app", as_app_name);
            paras.Add(para);
            para = new SqlParameter("@user_win", as_cusername);
            paras.Add(para);
            para = new SqlParameter("@ip", as_ip);
            paras.Add(para);
            para = new SqlParameter("@mac", as_mac);
            paras.Add(para);
            para = new SqlParameter("@hostname", as_hostname);
            paras.Add(para);
            Dictionary<string, string> dict = DBAccess.ExecSP("mis_log_pro", paras, ref outparas);
            ls_return = dict["@ls_return"];
            lb_sql = true;

            if (lb_sql)
            {
            }
            else
            {
                as_logid = ""; ;
                as_psw = "";
                global.gu_dw1.f_msg("返回值：" + ls_return);
                return;
            }

            switch (ls_return)
            {
                case "windows":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("2你的计算机的windows登录用户名(" + as_cusername + ")在系统中没有注册!~r~n请与信息部联系！");
                    return;
                    break;
                case "hostname":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("3你的笔记本在系统中没有注册!~r~n请与信息部联系！");
                    return;
                case "notebook":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("4你的笔记本在系统中没有注册!~r~n请与信息部联系！");
                    return;
                case "computer":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("5你的计算机在系统中没有注册!~r~n请与信息部联系！");
                    return;
                case "day200":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("6你的计算机或用户名在2天内登录超过200次了!~r~n请与信息部联系！");
                    return;
                case "day30":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("7你的计算机或用户名在30天内错误登录超过30次了!\r~n请与信息部联系！");
                    return;
                case "minute21.6":
                    as_logid = "";
                    as_psw = "";
                    global.gu_dw1.f_msg("8你的计算机或用户名已被锁定，请在20分钟后登录!");
                    return;
                default:
                    string[] strs = ls_return.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    if (ls_return.Substring(0, 3) == "异常：")
                    {
                        global.gu_dw1.f_msg("888你的计算机异常，请找信息部确认！\r\n" + ls_return);
                        return;
                    }
                    if (strs.Length <= 1)
                    {
                        string sql = string.Format(@"
			insert into mis_log_tb1 (app,user_win,ip,mac,hostname,lrsj)
			values ('{0}' + '非法1','{1}','{2}','{3}','{4}',getdate());", as_app_name, as_cusername, as_ip, as_mac, as_hostname);
                        DBAccess.ExecuteSql(sql);
                        f_msg("9你的计算机在进行非法操作，请立刻停止！");
                        return;
                    }
                    as_logid = strs[0];
                    //string str = ls_return.Substring(0, as_logid.Length + 2);
                    //ls_return = ls_return.Replace(str, "");
                    if (strs.Length<=2)
                    {
                        string sql = string.Format(@"
			insert into mis_log_tb1 (app,user_win,ip,mac,hostname,lrsj)
			values ('{0}' + '非法2','{1}','{2}','{3}','{4}',getdate());", as_app_name, as_cusername, as_ip, as_mac, as_hostname);
                        DBAccess.ExecuteSql(sql);
                        f_msg("10你的计算机在进行非法操作，请立刻停止！");
                        return;
                    }
                    as_psw = strs[1];
                    if (ls_return.Length - as_psw.Length <= 2)
                    {
                        string sql = string.Format(@"
			insert into mis_log_tb1 (app,user_win,ip,mac,hostname,lrsj)
			values ('{0}' + '非法3','{1}','{2}','{3}','{4}',getdate());", as_app_name, as_cusername, as_ip, as_mac, as_hostname);
                        DBAccess.ExecuteSql(sql);
                        f_msg("11你的计算机在进行非法操作，请立刻停止！");
                        return;
                    }
                    ls_return = strs[2];
                    if (ls_return.Length != 60)
                    {
                        string sql = string.Format(@"
			insert into mis_log_tb1 (app,user_win,ip,mac,hostname,lrsj)
			values ('{0}' + '非法4','{1}','{2}','{3}','{4}',getdate());", as_app_name, as_cusername, as_ip, as_mac, as_hostname);
                        DBAccess.ExecuteSql(sql);
                        f_msg("12你的计算机在进行非法操作，请立刻停止！");
                        return;
                    }
                    if (as_psw.Length != 60)
                    {
                        string sql = string.Format(@"
			insert into mis_log_tb1 (app,user_win,ip,mac,hostname,lrsj)
			values ('{0}' + '非法5','{1}','{2}','{3}','{4}',getdate());", as_app_name, as_cusername, as_ip, as_mac, as_hostname);
                        DBAccess.ExecuteSql(sql);
                        f_msg("13你的计算机在进行非法操作，请立刻停止！");
                        return;
                    }
                    ls_return = global.gu_pub1.fe_wf(ls_return, global.gu_pub1.is_pswkey, false);
                    as_psw = global.gu_pub1.fe_wf(as_psw, ls_return, false);
                    //global.g5_sys.connStr = string.Format(ConfigurationManager.ConnectionStrings[1].ConnectionString, as_ip, global.g5_sys., ls_loginid, ls_password);
                    break;
            }
        }
    }
}
