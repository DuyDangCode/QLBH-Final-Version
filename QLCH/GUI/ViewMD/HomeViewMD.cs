using GUI.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Documents;


namespace GUI.ViewMD
{
    public class HomeViewMD:ViewModelBase
    {
        private int _amCus;
        public int amCus { get { return _amCus; } set { _amCus = value; OnPropertyChanged(nameof(amCus)); } }


        private int _amOder;
        public int amOder { get { return _amOder; } set { _amOder = value; OnPropertyChanged(nameof(amOder)); } }


        private double _amRev;
        public double amRev { get { return _amRev; } set { _amRev = value; OnPropertyChanged(nameof(amRev)); } }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public HomeViewMD() {

            DateTime dt = DateTime.Now;
            int month = dt.Month;
            int year = dt.Year;
            int n;
            Labels= new List<string>();
            if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                n = 31;
                
                

            }
            else if(month == 2)
            {
                if (year % 4 == 0)
                {
                    n = 29;
                }
                else
                    n = 28;

            }
            else
            {
                n = 30;
            }

            for(int i = 1; i <= n; i++)
            {
                Labels.Add(i.ToString());
            }

            double[] a = new double[n];
            //double[] b = new double[n];
            

            for (int i = 0; i < n; i++)
            {
                //a[i] = DataProvider.Ins.DB.Bills.Where(x => x.Date_.Month == DateTime.Now.Month).;
                
                

                try
                { a[i] = DataProvider.Ins.DB.Bills.Where(x => x.Date_.Month == dt.Month && x.Date_.Year == dt.Year && x.Date_.Day == (i + 1)).Sum(t => t.totalbill); }
                catch { a[i] = 0; }

                //try
                //{ b[i] = DataProvider.Ins.DB.Bills.Where(x => x.Date_.Month == dt.Month && x.Date_.Year == dt.Year && x.Date_.Day == (i + 1)).Count(); }
                //catch { b[i] = 0; }
               

            }

              

            amCus = DataProvider.Ins.DB.Customers.Count();
            amOder = DataProvider.Ins.DB.Bills.Where(x => EntityFunctions.TruncateTime(x.Date_) == EntityFunctions.TruncateTime(DateTime.UtcNow)).Count();
            amRev = DataProvider.Ins.DB.Bills.Where(x => EntityFunctions.TruncateTime(x.Date_) == EntityFunctions.TruncateTime(DateTime.UtcNow)).Sum(t => t.totalbill);

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<double> { a[0] }
                },
                //new ColumnSeries
                //{
                //    Title = "Số hóa đơn",
                //    Values = new ChartValues<double> { b[0] }
                //}
            };

            for(int i = 1; i < n; i++)
            {
                SeriesCollection[0].Values.Add(a[i]);
                //SeriesCollection[1].Values.Add(b[i]);
            }

            
            

            
            Formatter = value => value.ToString("N0");

        }
    }
}
