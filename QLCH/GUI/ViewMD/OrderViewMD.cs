using GUI.Model;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace GUI.ViewMD
{
    public class OrderViewMD:ViewModelBase
    {
        private ObservableCollection<ProductCategory> _ListCategory;
        public ObservableCollection<ProductCategory> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _ListProduct;
        public ObservableCollection<Product> ListProduct { get => _ListProduct; set { _ListProduct = value; OnPropertyChanged(); } }

        private ObservableCollection<Bill> _ListBill;
        public ObservableCollection<Bill> ListBill { get => _ListBill; set { _ListBill = value; OnPropertyChanged(); } }

        private ObservableCollection<Order> _ListBillInfo;
        public ObservableCollection<Order> ListBillInfo { get => _ListBillInfo; set { _ListBillInfo = value; OnPropertyChanged(); } }


        public static int idbill;
        public static double rs = 0;
        public static Order order { get; set; }

        private string _count;
        public string count { get => _count; set { _count = value; OnPropertyChanged(); } }
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private string _productname;
        public string productname { get => _productname; set { _productname = value; OnPropertyChanged(); } }
        private double _price;
        public double price { get => _price; set { _price = value; OnPropertyChanged(); } }
        private string _url;
        public string url { get => _url; set { _url = value; OnPropertyChanged(); } }
        private string _SearchName;
        public string SearchName { get => _SearchName; set { _SearchName = value; OnPropertyChanged(); } }
        private string _customer;
        public string customer { get => _customer; set { _customer = value; OnPropertyChanged(); } }

        private ProductCategory _SelectedCategory;
        public ProductCategory SelectedCategory
        {
            get => _SelectedCategory;
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
                if (SelectedCategory != null)
                {
                    name = SelectedCategory.name;
                }
            }
        }

        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get => _SelectedProduct;
            set
            {
                _SelectedProduct = value;
                OnPropertyChanged();
                if (SelectedProduct != null)
                {
                    productname = SelectedProduct.name;
                }
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand ViewListCommand { get; set; }
        public ICommand TTCommand { get; set; }
        public ICommand OrderCommand { get; set; }

        public OrderViewMD()
        {
            ListCategory = new ObservableCollection<ProductCategory>(DataProvider.Ins.DB.ProductCategories.Where(x=>x.Xoa==0));
            ListProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products.Where(x => x.Xoa == 0));
            ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.Where(x => x.status == 0));
            idbill = ListBill.First().id;
            var db = DataProvider.Ins.DB;
            loadorderlist();
            //Hàm load danh sách order
            void loadorderlist()
            {
                var result = (from bi in db.BillInfoes
                              where bi.idBill == idbill
                              join p in db.Products
                              on bi.idProduct equals p.id
                              select new { p.name, bi.count, bi.totalbillinfo }).ToList();

                var list = new List<Order>();
                for (int i = 0; i < result.Count; i++)
                {
                    order = new Order()
                    {
                        name = result[i].name,
                        sl = result[i].count,
                        totalprice = result[i].totalbillinfo
                    };
                    list.Add(order);
                }

                ListBillInfo = new ObservableCollection<Order>(list);
            };
            //Tìm kiếm
            SearchCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SearchName))
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                ListProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products.Where(x => x.name.Contains(SearchName) && x.Xoa==0));
            });
            //Show all
            ViewListCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products.Where(x => x.Xoa == 0));
            });
            //Thanh toán
            TTCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //Thanh toán
                System.Windows.MessageBox.Show("Đã thanh toán!");
                var bill = DataProvider.Ins.DB.Bills.Where(x => x.id == idbill).SingleOrDefault();
                bill.status = 1;

                //Tạo bill mới
                var newbill = new Bill() {idCustomer = 1, Date_ = DateTime.Now};

                DataProvider.Ins.DB.Bills.Add(newbill);
 
                DataProvider.Ins.DB.SaveChanges();

                ListBillInfo.Clear();
                ListBill.Clear();
                ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.Where(x => x.status == 0));
                idbill = ListBill.First().id;
                rs = 0;
            });
            //Order sản phẩm
            OrderCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(count))
                    return false;
                return true;
            }, (p) =>
            {
                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.sdt == customer).ToList();
                if (displayList == null || displayList.Count() != 0)
                {
                    System.Windows.MessageBox.Show("Thêm thành công!");
                    var bill = DataProvider.Ins.DB.Bills.Where(x => x.id == idbill).SingleOrDefault();
                    bill.idCustomer = displayList[0].id;
                    DataProvider.Ins.DB.SaveChanges();

                    var billinfo = new BillInfo() { count = Int32.Parse(count), idBill = idbill, idProduct = SelectedProduct.id, totalbillinfo = Int32.Parse(count) * SelectedProduct.price };

                    DataProvider.Ins.DB.BillInfoes.Add(billinfo);
                    DataProvider.Ins.DB.SaveChanges();

                    loadorderlist();

                    //Tổng tiền
                    rs = rs + Int32.Parse(count) * SelectedProduct.price;
                    var billrs = DataProvider.Ins.DB.Bills.Where(x => x.id == idbill).SingleOrDefault();
                    billrs.totalbill = rs;
                    DataProvider.Ins.DB.SaveChanges();
                }
                //else if(customer != null && displayList.Count() == 0)
                //{
                //    System.Windows.MessageBox.Show("Chưa đăng ký thành viên!");
                //}    
                else
                {
                    System.Windows.MessageBox.Show("Thêm thành công!");
                    var billinfo = new BillInfo() { count = Int32.Parse(count), idBill = idbill, idProduct = SelectedProduct.id, totalbillinfo = Int32.Parse(count) * SelectedProduct.price };

                    DataProvider.Ins.DB.BillInfoes.Add(billinfo);
                    DataProvider.Ins.DB.SaveChanges();

                    loadorderlist();

                    //Tổng tiền
                    rs = rs + Int32.Parse(count) * SelectedProduct.price;
                    var billrs = DataProvider.Ins.DB.Bills.Where(x => x.id == idbill).SingleOrDefault();
                    billrs.totalbill = rs;
                    DataProvider.Ins.DB.SaveChanges();
                }    
            });
        }
    }
}
