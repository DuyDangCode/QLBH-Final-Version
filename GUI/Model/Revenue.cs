using GUI.ViewMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    class Revenue:ViewModelBase
    {
        public string name { get; set; }
        public double totalprice { get; set; }
        public DateTime date { get; set; }
    }
}
