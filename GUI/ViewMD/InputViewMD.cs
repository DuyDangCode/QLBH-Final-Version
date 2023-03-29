using GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI.ViewMD
{
    class InputViewMD:MainViewModel
    {
        private ObservableCollection<ProductCategory> _ListCategory;
        public ObservableCollection<ProductCategory> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _ListProduct;
        public ObservableCollection<Product> ListProduct { get => _ListProduct; set { _ListProduct = value; OnPropertyChanged(); } }

        private ObservableCollection<NhapHang> _ListInput;
        public ObservableCollection<NhapHang> ListInput { get => _ListInput; set { _ListInput = value; OnPropertyChanged(); } }

        public NhapHang nhaphang { get; set; }

        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private string _productname;
        public string productname { get => _productname; set { _productname = value; OnPropertyChanged(); } }
        private int _count;
        public int count { get => _count; set { _count = value; OnPropertyChanged(); } }
        private double _totalprice;
        public double totalprice { get => _totalprice; set { _totalprice = value; OnPropertyChanged(); } }
        private string _Date_Input;
        public string Date_Input { get => _Date_Input; set { _Date_Input = value; OnPropertyChanged(); } }

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
                    name = _SelectedCategory.name;
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
                    productname = _SelectedProduct.name;
                    SelectedCategory = _SelectedProduct.ProductCategory;
                }
            }
        }

        private NhapHang _SelectedInput;
        public NhapHang SelectedInput
        {
            get => _SelectedInput;
            set
            {
                _SelectedInput = value;
                OnPropertyChanged();
                if (SelectedInput != null)
                {
                    Date_Input = SelectedInput.date.ToString("MM/dd/yyyy");
                    count = SelectedInput.sl;
                    totalprice = SelectedInput.totalprice;
                }
            }
        }

        public ICommand InputCommand { get; set; }

        public InputViewMD()
        {
            ListCategory = new ObservableCollection<ProductCategory>(DataProvider.Ins.DB.ProductCategories.Where(x => x.Xoa == 0));
            ListProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products.Where(x => x.Xoa == 0));
            //ListInput = new ObservableCollection<Input>(DataProvider.Ins.DB.Inputs);
            loadinput();
            void loadinput()
            {
                var db = DataProvider.Ins.DB;

                var rs = (from i in db.Inputs
                          join p in db.Products
                          on i.idProduct equals p.id
                          select new { p.name, i.idCategory, i.Date_Input, i.count, i.priceInput }).ToList();

                var list = new List<NhapHang>();
                for (int i = 0; i < rs.Count; i++)
                {
                    nhaphang = new NhapHang()
                    {
                        productname = rs[i].name,
                        idCategory = rs[i].idCategory,
                        date = rs[i].Date_Input,
                        totalprice = rs[i].priceInput,
                        sl = rs[i].count
                    };
                    list.Add(nhaphang);
                }
                ListInput = new ObservableCollection<NhapHang>(list);
            }

            InputCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(productname)|| string.IsNullOrEmpty(name))
                    return false;
                var displayList = DataProvider.Ins.DB.Products.Where(x => x.name == name);
                if (displayList == null || displayList.Count() != 0)
                    return true;

                return true;

            }, (p) =>
            {
                MessageBox.Show("Nhập hàng thành công!");
                var input = new Input() {count = count, priceInput = totalprice, Date_Input = DateTime.Now, idCategory = SelectedCategory.id, idProduct = SelectedProduct.id};

                DataProvider.Ins.DB.Inputs.Add(input);
                DataProvider.Ins.DB.SaveChanges();

                //ListInput.Add(input);
                loadinput();
            });
        }
    }
}
