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
    public class AccountViewMD : ViewModelBase
    {
        private ObservableCollection<Account> _ListAccount;
        public ObservableCollection<Account> ListAccount { get => _ListAccount; set { _ListAccount = value; OnPropertyChanged(); } }
        private ObservableCollection<Customer> _ListCustomer;
        public ObservableCollection<Customer> ListCustomer { get => _ListCustomer; set { _ListCustomer = value; OnPropertyChanged(); } }

        private ObservableCollection<TypeAcc> _ListType;
        public ObservableCollection<TypeAcc> ListType { get => _ListType; set { _ListType = value; OnPropertyChanged(); } }

        public static int idUser;
        public static string path;
        private string _displayname;
        public string displayname { get => _displayname; set { _displayname = value; OnPropertyChanged(); } }
        private string _username;
        public string username { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _password;
        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        private string _typename;
        public string typename { get => _typename; set { _typename = value; OnPropertyChanged(); } }
        private string _changepass;
        public string changepass { get => _changepass; set { _changepass = value; OnPropertyChanged(); } }
        private string _displaynamechange;
        public string displaynamechange { get => _displaynamechange; set { _displaynamechange = value; OnPropertyChanged(); } }
        private string _cusname;
        public string cusname { get => _cusname; set { _cusname = value; OnPropertyChanged(); } }
        private string _sdt;
        public string sdt { get => _sdt; set { _sdt = value; OnPropertyChanged(); } }

        private Account _SelectedAccount;
        public Account SelectedAccount
        {
            get => _SelectedAccount;
            set
            {
                _SelectedAccount = value;
                OnPropertyChanged();
                if (SelectedAccount != null)
                {
                    username = SelectedAccount.UserName;
                    displayname = SelectedAccount.DisplayName;
                    password = SelectedAccount.PassWord;
                    SelectedType = SelectedAccount.TypeAcc;
                }
            }
        }

        private TypeAcc _SelectedType;
        public TypeAcc SelectedType
        {
            get => _SelectedType;
            set
            {
                _SelectedType = value;
                OnPropertyChanged();
                if (SelectedType != null)
                {
                    typename = SelectedType.name;
                }
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddAvatarCommand { get; set; }
        public ICommand ChangePassCommand { get; set; }
        public ICommand AddCusCommand { get; set; }
        

        public AccountViewMD()
        {
            ListAccount = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts.Where(x => x.Xoa == 0));
            ListCustomer = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            ListType = new ObservableCollection<TypeAcc>(DataProvider.Ins.DB.TypeAccs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(displayname) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(typename))
                    return false;

                var displayList = DataProvider.Ins.DB.Accounts.Where(x => x.UserName == username && x.Xoa == 0);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                System.Windows.MessageBox.Show("Tạo tài khoản thành công!");
                var account = new Account() { UserName = username, DisplayName = displayname, idType = SelectedType.id, PassWord = password, Avatar = "C:/Users/84967/OneDrive/Desktop/QLCH/GUI/Img/user-286.png" };

                DataProvider.Ins.DB.Accounts.Add(account);
                DataProvider.Ins.DB.SaveChanges();

                ListAccount.Add(account);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(username))
                    return false;

                var displayList = DataProvider.Ins.DB.Accounts.Where(x => x.UserName == username && x.Xoa == 0);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                System.Windows.MessageBox.Show("Sửa tài khoản thành công!");
                var account = DataProvider.Ins.DB.Accounts.Where(x => x.id == SelectedAccount.id).SingleOrDefault();
                account.UserName = username;
                account.DisplayName = displayname;
                account.PassWord = password;
                account.idType = SelectedType.id;

                DataProvider.Ins.DB.SaveChanges();
                SelectedAccount.UserName = username;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedAccount == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                MessageBoxResult rs = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xóa account này?", "Thông báo", MessageBoxButton.OKCancel);

                if (rs == MessageBoxResult.OK)
                {
                    var ac = DataProvider.Ins.DB.Accounts.Where(x => x.UserName == username && x.Xoa == 0).SingleOrDefault();

                    //Xóa nhân viên này
                    ac.Xoa = 1;

                    DataProvider.Ins.DB.SaveChanges();

                    ListAccount.Remove(ac);
                }
            });

            AddAvatarCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    path = open.FileName;
                }
                System.Windows.MessageBox.Show("Cập nhật thành công!");
                var account = DataProvider.Ins.DB.Accounts.Where(x => x.id == idUser).SingleOrDefault();
                account.Avatar = path;
                DataProvider.Ins.DB.SaveChanges();
            });

            ChangePassCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(changepass))
                    return false;
                return true;
            }, (p) =>
            {
                System.Windows.MessageBox.Show("Cập nhật mật khẩu thành công!");
                var account = DataProvider.Ins.DB.Accounts.Where(x => x.id == idUser).SingleOrDefault();
                account.PassWord = changepass;
                account.DisplayName = displaynamechange;
                DataProvider.Ins.DB.SaveChanges();
            });

            AddCusCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(cusname) || string.IsNullOrEmpty(sdt))
                    return false;

                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.name == cusname);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                System.Windows.MessageBox.Show("Tạo thành viên thành công!");
                var cus = new Customer() { name = cusname, sdt = sdt };

                DataProvider.Ins.DB.Customers.Add(cus);
                DataProvider.Ins.DB.SaveChanges();

                ListCustomer.Add(cus);
            });
        }
    }
}

