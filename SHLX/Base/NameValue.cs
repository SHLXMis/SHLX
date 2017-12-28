using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public class NameValue
    {
        public NameValue()
        {
        }
        public NameValue(string name, string value)
        {
            this._name = name;
            this._value = value;
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
    }
}
