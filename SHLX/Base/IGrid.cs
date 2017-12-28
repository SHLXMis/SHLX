using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redsoft
{
    public interface IGrid
    {
        IList<Column> GetCols();
        string Sql { get; }
        DataGridView GetGrid();
        IList<NameValue> GetArguments();
        string Updatewhere { get;  }
        string Updatekeyinplace { get;  }
        string IdCol { get; }
        string TableName { get; }
        string SqlName { get; }
        string IdDataType { get; }
    }
}
