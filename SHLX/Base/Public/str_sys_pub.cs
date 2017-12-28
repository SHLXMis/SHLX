using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public class str_sys_pub
    {
        public str_sys_pub()
        {
#if DEBUG
            is_debug = true;
#endif
        }
        public bool is_debug = false;
        public decimal version_new;
        public decimal version_now;
        public DateTime version_date;
        public string app_path;
        public string app_name;
        public long app_handle;
        public string sysname;
        public string corporation;
        public string ip;
        public string mac;
        public string ip_db = "192.168.2.5";
        public string hostname;
        public string winusername;
        public int jiesuanri;
        public long row_max;
        public string username;
        public string truename;
        public string bumen;
        public string chejian;
        public bool export;
        public string s_object;
        public string win_ver;
        public string connStr;
    }
}
