using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public enum DataWindowTypes
    {
        Grid = 0,               
        FreeForm = 1               
        
    }
    public enum RowStatus
    {
        Add=0,
        Edit=1,
        Query=2
    }
    public enum EditType
    {
        Edit=0,
        DDDW=1,
        DDLB=2,
        RadioButtons=3,
        Checkbox=4
    }
}
