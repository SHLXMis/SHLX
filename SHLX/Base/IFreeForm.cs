using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redsoft
{
    public interface IFreeForm
    {
        IList<Column> GetCols();
        Panel GetPanel { get; set; }
        string Sql { get; }
        IList<NameValue> GetArguments();
        string Updatewhere { get;  }
        string Updatekeyinplace { get;  }
        string IdCol { get; }
        string TableName { get; }
        string SqlName { get; }
        string IdDataType { get; }
    }
}
