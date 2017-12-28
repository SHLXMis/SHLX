using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public class ItemChangedEventArgs:EventArgs 
    {
        private int row;

        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        private int columnNumber;

        public int ColumnNumber
        {
            get { return columnNumber; }
            set { columnNumber = value; }
        }
        private string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
