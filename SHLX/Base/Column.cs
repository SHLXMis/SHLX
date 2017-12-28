using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public class Column
    {
        public Column()
        {
        }
        public Column(string id,string name,string text,bool visible,
            int width, int x, string alignment, string colType,
            bool keyCol, string expression, string format,
            bool computeCol,string dddwName,string dddwDisplayCol,
            string dddwValueCol,EditType editType,string allowUpdate)
        {
            _id = id;
            _name = name;
            _text = text;
            _visible = visible;
            _width = width;
            _x = x;
            _alignment = alignment;
            _colType = colType;
            _keyCol = keyCol;
            _expression = expression;
            _format = format;
            _computeCol = computeCol;
            _dddwName = dddwName;
            _dddwDisplayCol = dddwDisplayCol;
            _dddwValueCol = dddwValueCol;
            _editType = editType;
            _allowUpdate = allowUpdate;
        }
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private bool _visible;

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        private string _alignment;

        public string Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }
        private string _colType;

        public string ColType
        {
            get { return _colType; }
            set { _colType = value; }
        }
        private bool _keyCol;

        public bool KeyCol
        {
            get { return _keyCol; }
            set { _keyCol = value; }
        }
        private string _expression;
        /// <summary>
        /// 计算列表达式
        /// </summary>
        public string Expression
        {
            get { return _expression; }
            set { _expression = value; }
        }
        private string _format;

        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }
        private bool _computeCol;

        public bool ComputeCol
        {
            get { return _computeCol; }
            set { _computeCol = value; }
        }
        private string _dddwName;

        public string DddwName
        {
            get { return _dddwName; }
            set { _dddwName = value; }
        }
        private string _dddwDisplayCol;

        public string DddwDisplayCol
        {
            get { return _dddwDisplayCol; }
            set { _dddwDisplayCol = value; }
        }
        private string _dddwValueCol;

        public string DddwValueCol
        {
            get { return _dddwValueCol; }
            set { _dddwValueCol = value; }
        }
        private EditType _editType;

        public EditType EditType
        {
            get { return _editType; }
            set { _editType = value; }
        }
        private string _allowUpdate;

        public string AllowUpdate
        {
            get { return _allowUpdate; }
            set { _allowUpdate = value; }
        }

    }
}
