using GUI.ViewMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    public class NhapHang:ViewModelBase
    {
        public string productname { get; set; }
        public int idCategory { get; set; }
        public DateTime date { get; set; }
        public int sl { get; set; }
        public double totalprice { get; set; }
    }
}
