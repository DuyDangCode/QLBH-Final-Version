using GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewMD
{
    class RevenueViewMD:MainViewModel
    {
        private ObservableCollection<Revenue> _ListBill;
        public ObservableCollection<Revenue> ListBill { get => _ListBill; set { _ListBill = value; OnPropertyChanged(); } }
        public static Revenue revenue { get; set; }
        public RevenueViewMD()
        {
            var db = DataProvider.Ins.DB;

            var rs = (from b in db.Bills
                      join c in db.Customers
                      on b.idCustomer equals c.id
                      select new { c.name, b.Date_, b.totalbill }).ToList();

            var list = new List<Revenue>();
            for(int i =0 ; i< rs.Count;i++)
            {
                revenue = new Revenue()
                {
                    name = rs[i].name,
                    date = rs[i].Date_,
                    totalprice = rs[i].totalbill
                };
                list.Add(revenue);
            }
            ListBill = new ObservableCollection<Revenue>(list);
        }
    }
}
