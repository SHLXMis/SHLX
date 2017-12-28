using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public class nvo_pub_fun
    {
        public string[] is_process_kill,is_process ;//要屏蔽的进程 所有的进程
        public ulong[] in_process_id; // 所有的进程ID
        public string[] is_process_running; // 必须运行的程序
        public int ii_dir_path = 255; // pb dirlist 能认识的最长目录路径，包含目录和文件名称 
        // filedelete fileexists removedirectory directoryexists 等对目录长度没有限制 （windows系统目录+文件不能超过255）
        public bool ib_cpu = false; //判断CPU() 是否快超过一个轮询4,294,967,295
        public ulong iul_cpu = 0; //0 //cpu()轮询的次数
        public DateTime il_getdate = DateTime.MinValue;
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
            for (int i = 1; i < as_array.Length;i++ )
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
            for (int i = 0; i < lines.Length;i++ )
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
        public  DateTime f_getdate ()
        {
            //return f_dateadd('millisecond', cpu() - il_getdate, idt_getdate)
            return DateTime.Now;
        }
    }
}
