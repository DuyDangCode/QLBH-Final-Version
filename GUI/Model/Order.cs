using GUI.ViewMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    public class Order:ViewModelBase
    {
        public string name { get; set; }
        public int sl { get; set; }
        public double totalprice { get; set; }
    }
}
