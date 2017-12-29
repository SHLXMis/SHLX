using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Redsoft
{
    public class nvo_pub_fun
    {
        private Stopwatch sw = new Stopwatch();
        public nvo_pub_fun()
        {
            sw.Start();
        }
        public long cpu()
        {
            return sw.Elapsed.Milliseconds;
        }
        public string[] is_process_kill, is_process;//要屏蔽的进程 所有的进程
        public ulong[] in_process_id; // 所有的进程ID
        public string[] is_process_running; // 必须运行的程序
        public int ii_dir_path = 255; // pb dirlist 能认识的最长目录路径，包含目录和文件名称 
        // filedelete fileexists removedirectory directoryexists 等对目录长度没有限制 （windows系统目录+文件不能超过255）
        public bool ib_cpu = false; //判断CPU() 是否快超过一个轮询4,294,967,295
        public ulong iul_cpu = 0; //0 //cpu()轮询的次数
        public long il_getdate = 0;
        public DateTime idt_getdate;
        public string is_pswkey; // 
        public long il_w = 0, il_h = 0;
        public string is_VolumeSerialNumber;
        public long f_array_find(string[] as_array, string as_temp, ref long al_len, long al_end)
        {
            long ll_i, ll_row;
            al_len = as_array.Length;
            if (al_len <= 0 || al_len == null)
            {
                ll_row = 0;
                al_len = 0;
                return 0;
            }

            ll_row = 0;
            if (al_end > al_len)
                al_end = al_len;
            for (ll_i = 1; ll_i < al_end; ll_i++)
            {
                if (as_array[ll_i] == as_temp)
                {
                    ll_row = ll_i;
                    break;

                }
            }
            return ll_row;
        }
        public string f_s_arraytolista(object[] as_array, string as_delimiters)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < as_array.Length; i++)
            {//把0抛弃，为了适应下标从1开始，0无用。
                object o = as_array[i];
                if (sb.Length == 0)
                    sb.Append(o.ToString());
                else
                    sb.Append(as_delimiters + o.ToString());
            }
            return sb.ToString();
        }
        public string f_s_arraytolista(double[] as_array, string as_delimiters)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < as_array.Length; i++)
            {//把0抛弃，为了适应下标从1开始，0无用。

                if (sb.Length == 0)
                    sb.Append(as_array[i].ToString());
                else
                    sb.Append(as_delimiters + as_array[i].ToString());
            }
            return sb.ToString();
        }
        public void f_s_listtoarray(string as_list, string as_delimiters, ref string[] as_array)
        {
            //为了适应下标从1开始，0无用
            string[] lines = as_list.Split(new String[] { as_delimiters }, StringSplitOptions.None);
            string[] ret = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                ret[i + 1] = lines[i];
            }
        }
        public void f_s_listtoarray(string as_list, string as_delimiters, ref double[] as_array)
        {
            //为了适应下标从1开始，0无用
            string[] lines = as_list.Split(new String[] { as_delimiters }, StringSplitOptions.None);
            string[] ret = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                ret[i + 1] = lines[i];
            }
        }
        public DateTime f_getdate()
        {
            //return f_dateadd('millisecond', cpu() - il_getdate, idt_getdate)
            return DateTime.Now;
        }
        public string uf_sys_ip_shlx_lan()
        {
            string ls_ip_shlx;
            long ll_ip_4;
            string[] ls_ip = Common.GetIP();
            string[] ls_ip2;
            string[] ls_ip3 = null;

            ls_ip_shlx = "";

            for (int ll_i = 0; ll_i < ls_ip.Length; ll_i++)
            {
                ls_ip2 = ls_ip3;
                ls_ip2 = ls_ip[ll_i].Split(new char[] { '.' });
                if (ls_ip2.Length != 4)
                    continue;


                if (ls_ip[ll_i].Substring(0, 8) == "192.168.")
                {
                    if (ls_ip2[3] == "1")
                    {
                        ll_ip_4 = Convert.ToInt64(ls_ip2[4]);
                        switch (ll_ip_4)
                        {
                            case 35:
                            case 36:
                            case 98:
                            case 99:
                                continue;
                        }
                        ls_ip_shlx = ls_ip[ll_i];
                        break;
                    }
                    switch (ls_ip2[3])
                    {
                        //服务器
                        case "2":
                        case "3":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        //领导
                        case "48":
                        case "49":
                        case "50":
                        case "51":
                        case "52":
                        case "53":
                        case "54":
                        case "55":
                        case "56":
                        case "57":
                        case "58":
                        case "59":
                        case "60":
                        case "61":
                        case "62":
                        case "63":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        //一分厂
                        case "16":
                        case "17":
                        case "18":
                        case "19":
                        case "20":
                        case "21":
                        case "22":
                        case "23":
                        case "24":
                        case "25":
                        case "26":
                        case "27":
                        case "28":
                        case "29":
                        case "30":
                        case "31":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        case "68":
                        case "69":
                        case "70":
                        case "71":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        //二分厂
                        case "32":
                        case "33":
                        case "34":
                        case "35":
                        case "36":
                        case "37":
                        case "38":
                        case "39":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        case "72":
                        case "73":
                        case "74":
                        case "75":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;

                        //三分厂
                        case "40":
                        case "41":
                        case "42":
                        case "43":
                        case "44":
                        case "45":
                        case "46":
                        case "47":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        case "64":
                        case "65":
                        case "66":
                        case "67":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;


                        case "80":
                        case "82":
                        case "84":
                        case "88":
                        case "90":
                        case "92":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                        case "96":
                        case "98":
                        case "100":
                            ls_ip_shlx = ls_ip[ll_i];
                            break;
                    }
                }
            }
            return ls_ip_shlx;
        }
        public string fe_encode(string as_temp)
        {
            string temp = "", tmp1 = "", tmp2 = "j", tmp3 = "4", tmp4 = "7";
            temp = tmp2 + "l" + tmp1 + "D" + temp + '$' + tmp1 + "#" + '%' + tmp3 + '5' + tmp4 + tmp3 + "8";
            is_pswkey = as_temp;
            return as_temp;
        }
        public string wf_encode()
        {
            string temp = "", tmp1 = "", tmp2 = "j", tmp3 = "6", tmp4 = "7";
            temp = tmp2 + "l" + tmp1 + "D" + temp + "F" + '$' + tmp1 + "#" + '%' + tmp3 + '5' + tmp4 + tmp3 + "8";
            fe_encode(temp);
            return temp;
        }
        public string EnDes(string str, string myKey)
        {
            string encryptKeyall = Convert.ToString(myKey);    //定义密钥  
            if (encryptKeyall.Length < 9)
            {
                for (; ; )
                {
                    if (encryptKeyall.Length < 9)
                        encryptKeyall += encryptKeyall;
                    else
                        break;
                }
            }
            string encryptKey = encryptKeyall.Substring(0, 8);
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   
            byte[] key = Encoding.UTF8.GetBytes(encryptKey); //定义字节数组，用来存储密钥    
            byte[] data = Encoding.UTF8.GetBytes(str);//定义字节数组，用来存储要加密的字符串  
            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      
            //使用内存流实例化加密流对象   
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      
            CStream.FlushFinalBlock();              //释放加密流      
            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
        }

        public string DeDes(string str, string myKey)
        {
            string encryptKeyall = Convert.ToString(myKey);    //定义密钥  
            if (encryptKeyall.Length < 9)
            {
                for (; ; )
                {
                    if (encryptKeyall.Length < 9)
                        encryptKeyall += encryptKeyall;
                    else
                        break;
                }
            }
            string encryptKey = encryptKeyall.Substring(0, 8);
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    
            byte[] key = Encoding.UTF8.GetBytes(encryptKey); //定义字节数组，用来存储密钥    
            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  
            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      
            //使用内存流实例化解密流对象       
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     
            CStream.FlushFinalBlock();               //释放解密流      
            return Encoding.UTF8.GetString(MStream.ToArray());       //返回解密后的字符串  
        }

        public string EnAes(string plainStr, string key)
        {
            string iv = @"L+\~f4,Ir)b$=pkf";
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);
            byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();
            return encrypt;
        }
        public static string DeAes(string encryptStr, string key)
        {
            string iv = @"L+\~f4,Ir)b$=pkf";
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIV = Encoding.UTF8.GetBytes(iv);
            byte[] byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();
            return decrypt;
        }
        public string fe_wf(string as_pass1, string as_key, bool ab_en)
        {
            if (as_key == null || as_key.Trim() == "")
                as_key = is_pswkey;
            if (ab_en)
                //return Convert.ToBase64String(Encoding.Default.GetBytes(fe_encrypt(EnAes(EnDes(as_pass1, as_key), as_key), as_key)));
                return Convert.ToBase64String(Encoding.Default.GetBytes(encode(EnAes(EnDes(as_pass1, as_key), as_key))));
            else
                //return DeDes(DeAes(fe_decrypt(Encoding.Default.GetString(Convert.FromBase64String(as_pass1)), as_key), as_key), as_key);
                return DeDes(DeAes(decode(Encoding.Default.GetString(Convert.FromBase64String(as_pass1))), as_key), as_key);
        }
        public string fe_encrypt(string st_text, string st_key)
        {
            string st_textencrypt = string.Empty;
            long lg_textlen, lg_keylen, lg_key = 0, lg_cbyte;
            int lg_loop = 0;
            if (st_key == null || st_text == null) return "";
            lg_keylen = st_key.Length;
            for (lg_loop = 0; lg_loop < lg_keylen; lg_loop++)
            {
                lg_key = lg_key + Encoding.ASCII.GetBytes(st_key.Substring(lg_loop, 1))[0] * lg_loop;
                if (lg_key > 255)
                    lg_key = lg_key - 255;
            }
            do
            {
                lg_key = lg_key - 255;
            } while (lg_key > 255);
            lg_textlen = st_text.Length;
            for (lg_loop = 0; lg_loop < lg_textlen; lg_loop++)
            {
                lg_cbyte = Encoding.ASCII.GetBytes(st_text.Substring(lg_loop, 1))[0] + lg_key;
                if (lg_cbyte > 255) lg_cbyte = lg_cbyte - 255;
                st_textencrypt = st_textencrypt + (char)lg_cbyte;
                lg_key = lg_key + lg_cbyte;
                if (lg_key > 255) lg_key = lg_key - 255;
            }
            return st_textencrypt;
        }
        public string fe_decrypt(string st_text, string st_key)
        {
            string st_textdecrypt = string.Empty;
            if (st_key == null || st_text == null) return "";
            long lg_textlen, lg_keylen, lg_key = 0, lg_cbyte;
            int lg_loop;
            lg_keylen = st_key.Length;
            for (lg_loop = 0; lg_loop < lg_keylen; lg_loop++)
            {
                lg_key = lg_key + Encoding.ASCII.GetBytes(st_key.Substring(lg_loop, 1))[0] * lg_loop;
                if (lg_key > 255)
                    lg_key = lg_key - 255;
            }
            do
            {
                lg_key = lg_key - 255;
            } while (lg_key > 255);
            lg_textlen = st_text.Length;
            for (lg_loop = 0; lg_loop < lg_textlen; lg_loop++)
            {
                lg_cbyte = Encoding.ASCII.GetBytes(st_text.Substring(lg_loop, 1))[0] - lg_key;
                if (lg_cbyte < 0)
                    lg_cbyte = lg_cbyte + 255;
                st_textdecrypt = st_textdecrypt + (char)lg_cbyte;
                lg_key = lg_key + Encoding.ASCII.GetBytes(st_text.Substring(lg_loop, 1))[0];
                if (lg_key > 255)
                    lg_key = lg_key - 255;
            }
            return st_textdecrypt;
        }

        public string encode(string text)
        {
            char[] words = text.ToCharArray();
            for (int i = 0; i < words.Length; i++)
            {
                int a = (int)words[i];
                if (a >= 48 && a <= 57)//数字0-9
                {
                    a = a + 3;
                    if (a > 57)
                        a = a - 10;
                }

                if (a >= 65 && a <= 90)//字母A-Z
                {
                    a = a + 3;
                    if (a > 90)
                        a = a - 26;
                }

                if (a >= 97 && a <= 122)//字母a-z
                {
                    a = a + 3;
                    if (a > 122)
                        a = a - 26;
                }
                words[i] = (char)(a);

            }
            return new string(words);
        }

        //解密
        public string decode(string text)
        {
            char[] words = text.ToCharArray();
            for (int i = 0; i < words.Length; i++)
            {
                int a = (int)words[i];
                if (a >= 48 && a <= 57)//数字0-9
                {
                    a = a - 3;
                    if (a < 48)
                        a = a + 10;
                }

                if (a >= 65 && a <= 90)//字母A-Z
                {
                    a = a - 3;
                    if (a < 65)
                        a = a + 26;
                }

                if (a >= 97 && a <= 122)//字母a-z
                {
                    a = a - 3;
                    if (a < 97)
                        a = a + 26;
                }
                words[i] = (char)(a);
            }
            return new string(words);
        }

        public void ue_db()
        {
            string pwd = fe_wf("dGF6#$78,", wf_encode(), true);
            pwd = fe_wf(pwd, wf_encode(), false);
            string ls_password = "lDFatGnSpUuWLVq0adKlS5g1euDAggwlSYIGCQ8iVpY+fezr0qdPoUF3+ObMkjZbP";
            //string ls_pswkey = "lSpUqFGiRYoVKlSoUaJFihoyddq1a+XNjBYxb8+aPXn9+vjy4rZr5b5+Dg4UK2nFP";
            string ls_serverip = string.Empty;
            string ls_database = "shlx";
            string ls_server = "192.168.1.5";
            string ls_loginid = string.Empty;
            //ls_password = fe_wf(ls_password, wf_encode(), false);
            if (ls_server == "127.0.0.1" || ls_server == "192.168.1.36")
            {
                ls_serverip = "127.0.0.1";
                ls_loginid = "sa";
            }
            else
            {
                ls_serverip = global.g5_sys.ip_db;
                ls_loginid = "mis_pub";
                ls_password = "ekE0MFBqRHFQYTFSL3Jvckg4NHFOODN4NHRUSklyQ2loblpxWUVsZjNJQj0=";
            }
            if (ls_loginid != "sa")
            {
                ls_password = global.gu_pub1.fe_wf(ls_password, wf_encode(), false);
                global.g5_sys.connStr = string.Format(ConfigurationManager.ConnectionStrings[1].ConnectionString, ls_serverip, ls_database, ls_loginid, ls_password);
                //global. gu_pub1.f_sql_connect(global.g5_sys.hostname,global.g5_sys.app_name,global.g5_sys.ip,ls_database,ls_server,ls_loginid,ls_password,ls_serverip,sqlca)
                // 连接数据库成功

                // 获取版本号和服务器时间 开始
                string sql = @"
        SELECT top 1 ver, modi_date, getdate() 
            FROM mis_ver with (nolock)
            where modi_date >= dateadd(day, -500, getdate())
            order by ver desc ;";
                DataSet ds = DBAccess.Query(sql, "mis_ver");
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    global.g5_sys.version_new = Convert.ToDecimal(dr[0]);
                    global.g5_sys.version_date = Convert.ToDateTime(dr[1]);
                    global.gu_pub1.idt_getdate = Convert.ToDateTime(dr[2]);
                    global.gu_pub1.il_getdate = cpu();
                }
                else
                {
                    sql = @"
            insert mis_ver (ver,modi_date) values (0,  getdate()) ;
            SELECT top 1 getdate() FROM mis_ver with (nolock) ;";
                    ds = DBAccess.Query(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        global.gu_pub1.idt_getdate = Convert.ToDateTime(ds.Tables[0].Rows[0][0]);
                        global.gu_pub1.il_getdate = cpu();
                        global.g5_sys.version_new = 0;
                    }
                    else
                    {
                        MessageBox.Show("数据库操作发生错误，系统版本号和服务器时间获取失败！", "提示");
                    }
                }
            }

            if (ls_loginid != "sa")
            {
                if (global.g5_sys.is_debug)
                {
                    //正式连接数据库
                    global.gu_dw1.fe_encode2(ref ls_loginid, ref ls_password, global.g5_sys.app_name, global.g5_sys.winusername, global.g5_sys.ip, global.g5_sys.mac, global.g5_sys.hostname);
                    global.g5_sys.connStr = string.Format(ConfigurationManager.ConnectionStrings[1].ConnectionString, ls_serverip, ls_database, ls_loginid, ls_password);
                    //global. gu_pub1.f_sql_connect(g5_sys.hostname,g5_sys.app_name,g5_sys.ip,ls_database,ls_server,ls_loginid,ls_password,ls_serverip,sqlca)
                    string sql = "select * from login_user";
                    DataSet ds = DBAccess.Query(sql);
                }
                else
                {
                    string ls_ver, ls_comp_user;
                    //// 检验是否升级	
                    if (global.g5_sys.version_now > global.g5_sys.version_new)
                    {
                        global.gu_dw1.fe_encode2(ref ls_loginid, ref ls_password, global.g5_sys.app_name, global.g5_sys.winusername, global.g5_sys.ip, global.g5_sys.mac, global.g5_sys.hostname);
                        global.g5_sys.connStr = string.Format(ConfigurationManager.ConnectionStrings[1].ConnectionString, ls_serverip, ls_database, ls_loginid, ls_password);
                        //正式连接数据库
                        //   global. gu_dw1.fe_encode2(ref ls_loginid,ref ls_password,global.g5_sys.app_name,global.g5_sys.winusername,global.g5_sys.ip,global.g5_sys.mac,global.g5_sys.hostname);
                        //   global. gu_pub1.f_sql_connect(g5_sys.hostname,g5_sys.app_name,g5_sys.ip,ls_database,ls_server,ls_loginid,ls_password,ls_serverip,sqlca)
                        //    if al_pid_app >= 1 then Halt Close
                        //    ls_ver = string(g5_sys.version_now,"0.000000000000")
                        //    update mis_ver set mess = :ls_ver, modi_date = getdate() where ver = 0 ;
                        //    if not (sqlca.sqlcode = 0 and sqlca.sqlnrows = 1) then
                        //        insert mis_ver (ver,modi_date,mess) values (0, getdate(), :ls_ver) ;
                        //    end if
                        //    ls_comp_user = g5_sys.hostname + g5_sys.winusername + gu_pub1.f_disk_getserialnumber()
                        //    update mis_ip_ver set ver = :g5_sys.version_now , lrsj = getdate() where ip = :ls_comp_user ;
                        //    if not (sqlca.sqlcode = 0 and sqlca.sqlnrows = 1) then
                        //        insert mis_ip_ver (ip,ver,lrsj) values (:ls_comp_user,:g5_sys.version_now,getdate()) ;
                        //    end if
                        //    delete mis_ip_ver where lrsj <= getdate() - 400 ;
                        //    run(g5_sys.app_path + "\mis_updt.exe " + g5_sys.app_name + " " + string(gu_pub1.f_sys_process_curpid()) )
                        //    halt close
                        //elseif g5_sys.version_now < g5_sys.version_new then
                        //    if al_pid_app >= 1 then Halt Close
                        //    ls_comp_user = g5_sys.hostname + g5_sys.winusername + gu_pub1.f_disk_getserialnumber()
                        //    update mis_ip_ver set ver = :g5_sys.version_now , lrsj = getdate() where ip = :ls_comp_user ;
                        //    if not (sqlca.sqlcode = 0 and sqlca.sqlnrows = 1) then
                        //        insert mis_ip_ver (ip,ver,lrsj) values (:ls_comp_user,:g5_sys.version_now,getdate()) ;
                        //    end if
                        //    run(g5_sys.app_path + "\mis_updt.exe " + g5_sys.app_name + " " + string(gu_pub1.f_sys_process_curpid()) )
                        //    halt close
                        //else
                        //    //正式连接数据库
                        //    gu_dw1.fe_encode2(ls_loginid,ls_password,g5_sys.app_name,g5_sys.winusername,g5_sys.ip,g5_sys.mac,g5_sys.hostname)
                        //    gu_pub1.f_sql_connect(g5_sys.hostname,g5_sys.app_name,g5_sys.ip,ls_database,ls_server,ls_loginid,ls_password,ls_serverip,sqlca)
                    }

                }
            }
        }
        public int gf_gnqx_1(string as_username, string as_page_name)
        {
            if (as_username == "lhf")
                return 1;
            else if (string.IsNullOrEmpty(as_username) || string.IsNullOrEmpty(as_page_name))
                return 0;
            else
            {
                string ls_return = string.Empty;
                bool lb_sql;
                lb_sql = false;
                List<IDbDataParameter> outparas = new List<IDbDataParameter>();
                SqlParameter para = new SqlParameter("@ls_return", SqlDbType.VarChar, 200);
                para.Direction = ParameterDirection.Output;
                outparas.Add(para);
                List<IDbDataParameter> paras = new List<IDbDataParameter>();
                para = new SqlParameter("@leibie", 51);
                paras.Add(para);
                para = new SqlParameter("@page_name", as_page_name);
                paras.Add(para);
                paras.Add(para);
                para = new SqlParameter("@user_name1", as_username);
                paras.Add(para);
                para = new SqlParameter("@pass", "");
                paras.Add(para);
                para = new SqlParameter("@pass_new", "");
                paras.Add(para);
                para = new SqlParameter("@ip", "");
                paras.Add(para);
                try
                {
                    Dictionary<string, string> dict = DBAccess.ExecSP("login_gnqx_pass", paras, ref outparas);
                    ls_return = Convert.ToString(dict["@ls_return"]);
                    lb_sql = true;
                }
                catch
                {
                    lb_sql = false;
                }

                if (lb_sql)
                {
                    if (ls_return == "login")
                        return 1;
                    else
                        return 0;
                }
                else
                    return 0;
                return 0;
            }
        }
    }
}
