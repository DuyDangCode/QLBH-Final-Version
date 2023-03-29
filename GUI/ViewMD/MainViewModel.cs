using FontAwesome.Sharp;
using GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.ViewMD
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        public Account account;
        public string DisplayedImage
        {
            get { return @"C:\Users\84967\OneDrive\Desktop\QLCH\GUI\Img\3901287.jpg"; }
        }
        public string DisplayedName
        {
            get { return "";}
        }
        //Properties
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowProductsViewCommand { get; }
        public ICommand ShowOrderViewCommand { get; }
        public ICommand ShowAccountViewCommand { get; }
        public ICommand ShowInputViewCommand { get; }
        public ICommand ShowRevenueViewCommand { get; }


        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                Login loginWindow = new Login();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewMD;

                if (loginVM.IsLogin)
                {
                    account = LoginViewMD.Account0;
                    p.Show();
                }
                else
                { 
                    p.Close();
                }
            });
            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowProductsViewCommand = new ViewModelCommand(ExecuteShowProductsViewCommand);
            ShowOrderViewCommand = new ViewModelCommand(ExecuteShowOrderViewCommand);
            ShowAccountViewCommand = new ViewModelCommand(ExecuteShowAccountViewCommand);
            ShowInputViewCommand = new ViewModelCommand(ExecuteShowInputViewCommand);
            ShowRevenueViewCommand = new ViewModelCommand(ExecuteShowRevenueViewCommand);
            //Default view
            ExecuteShowHomeViewCommand(null);
        }
        private void ExecuteShowProductsViewCommand(object obj)
        {
            CurrentChildView = new ProductsViewMD();
            Caption = "Sản phẩm";
            Icon = IconChar.Burger;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewMD();
            Caption = "Trang chủ";
            Icon = IconChar.Home;
        }
        private void ExecuteShowOrderViewCommand(object obj)
        {
            CurrentChildView = new OrderViewMD();
            Caption = "Đặt hàng";
            Icon = IconChar.Truck;
        }
        private void ExecuteShowAccountViewCommand(object obj)
        {
            CurrentChildView = new AccountViewMD();
            Caption = "Tài khoản";
            Icon = IconChar.User;
        }
        private void ExecuteShowInputViewCommand(object obj)
        {
            CurrentChildView = new InputViewMD();
            Caption = "Nhập hàng";
            Icon = IconChar.Truck;
        }
        private void ExecuteShowRevenueViewCommand(object obj)
        {
            CurrentChildView = new RevenueViewMD();
            Caption = "Doanh thu";
            Icon = IconChar.ChartColumn;
        }
    }
}
