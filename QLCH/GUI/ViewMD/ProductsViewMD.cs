using GUI.Model;
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
    public class ProductsViewMD:ViewModelBase
    {
        private ObservableCollection<ProductCategory> _ListCategory;
        public ObservableCollection<ProductCategory> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _ListProduct;
        public ObservableCollection<Product> ListProduct { get => _ListProduct; set { _ListProduct = value; OnPropertyChanged(); } }

        public string path;
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private string _productname;
        public string productname { get => _productname; set { _productname = value; OnPropertyChanged(); } }
        private double _price;
        public double price { get => _price; set { _price = value; OnPropertyChanged(); } }
        private string _url;
        public string url { get => _url; set { _url = value; OnPropertyChanged(); } }

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
                    price = _SelectedProduct.price;
                    SelectedCategory = _SelectedProduct.ProductCategory;
                }
            }
        }

        public ICommand AddProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public ProductsViewMD()
        {
            ListCategory = new ObservableCollection<ProductCategory>(DataProvider.Ins.DB.ProductCategories.Where(x=>x.Xoa==0));
            ListProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products.Where(x => x.Xoa == 0));


            AddCategoryCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(name))
                    return false;

                var displayList = DataProvider.Ins.DB.ProductCategories.Where(x => x.name == name && x.Xoa==0);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                System.Windows.MessageBox.Show("Tạo loại sản phẩm thành công!");
                var category = new ProductCategory() { name = name };

                DataProvider.Ins.DB.ProductCategories.Add(category);
                DataProvider.Ins.DB.SaveChanges();

                ListCategory.Add(category);
            });

            EditCategoryCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(name))
                    return false;

                var displayList = DataProvider.Ins.DB.ProductCategories.Where(x => x.name == name && x.Xoa == 0);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                System.Windows.MessageBox.Show("Sửa loại sản phẩm thành công!");
                var category = DataProvider.Ins.DB.ProductCategories.Where(x => x.id == SelectedCategory.id).SingleOrDefault();
                category.name = name;
                DataProvider.Ins.DB.SaveChanges();

                SelectedCategory.name = name;
            });

            DeleteCategoryCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedCategory == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                MessageBoxResult rs = System.Windows.MessageBox.Show("Tất cả các sản phẩm thuộc loại này sẽ bị xóa.\nBạn có chắc chắn muốn xóa loại sản phẩm này?", "Lưu ý", MessageBoxButton.OKCancel);

                if (rs == MessageBoxResult.OK)
                {
                    var category = DataProvider.Ins.DB.ProductCategories.Where(x => x.name == SelectedCategory.name).SingleOrDefault();
                    var products = DataProvider.Ins.DB.Products.Where(x => x.idCategory == category.id && x.Xoa == 0).ToList();

                    //Xóa các sản phẩm thuộc loại này
                    foreach (Product pro in products)
                    {                     
                        pro.Xoa = 1;

                        DataProvider.Ins.DB.SaveChanges();
                    }

                    //Xóa loại sản phẩm này
                    category.Xoa = 1;

                    DataProvider.Ins.DB.SaveChanges();

                    ListCategory.Remove(category);
                }
            });

            AddProductCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(productname)|| string.IsNullOrEmpty(name))
                    return false;

                var displayList = DataProvider.Ins.DB.Products.Where(x => x.name == productname && x.Xoa == 0);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    path = open.FileName;
                }
                var prod = new Product() { name = productname, idCategory = SelectedCategory.id, price = price, url = path};

                DataProvider.Ins.DB.Products.Add(prod);
                DataProvider.Ins.DB.SaveChanges();
                System.Windows.MessageBox.Show("Tạo sản phẩm thành công!");

                ListProduct.Add(prod);
            });

            EditProductCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedProduct == null || ListCategory == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Products.Where(x => x.name == productname && x.Xoa == 0);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                System.Windows.MessageBox.Show("Sửa sản phẩm thành công!");
                var prod = DataProvider.Ins.DB.Products.Where(x => x.id == SelectedProduct.id).SingleOrDefault();
                prod.name = productname;
                prod.price = price;
                prod.idCategory = SelectedCategory.id;

                DataProvider.Ins.DB.SaveChanges();

                SelectedProduct.name = productname;
            });

            DeleteProductCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedProduct == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                MessageBoxResult rs = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Thông báo", MessageBoxButton.OKCancel);

                if (rs == MessageBoxResult.OK)
                {
                    var pro = DataProvider.Ins.DB.Products.Where(x => x.name == productname && x.Xoa == 0).SingleOrDefault();

                    //Xóa nhân viên này
                    pro.Xoa = 1;

                    DataProvider.Ins.DB.SaveChanges();

                    ListProduct.Remove(pro);
                }
            });
        }
    }
}
