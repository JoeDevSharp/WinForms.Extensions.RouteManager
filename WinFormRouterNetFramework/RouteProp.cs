using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformRouter
{
    public class RouteProp
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; } = null;
    }
}
