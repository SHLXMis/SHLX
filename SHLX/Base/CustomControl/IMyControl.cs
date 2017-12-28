using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redsoft
{
    public interface IMyControl
    {
        string OldText { get; set; }
        void SetText(string value);
        string GetText();
        void SetInValid();
        string AllowUpdate { get; set; }
    }
}
