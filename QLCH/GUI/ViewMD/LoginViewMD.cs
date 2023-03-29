using GUI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.ViewMD
{
    class LoginViewMD:ViewModelBase
    {
        public static Account Account0 { get; set; }
        public bool IsLogin { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set;}
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewMD()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login1(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        void Login1(Window p)
        {
            if (p == null)
                return;

            var account =  DataProvider.Ins.DB.Accounts.Where(x=>x.UserName ==UserName && x.PassWord == Password && x.Xoa==0).ToArray();
            
            if(account.Count()> 0)
            {
                IsLogin = true;

                Account0 = new Account()
                {
                    UserName = account[0].UserName,
                    DisplayName = account[0].DisplayName,
                    PassWord = account[0].PassWord,
                    Avatar = account[0].Avatar,
                    idType = account[0].idType,
                    id = account[0].id
                };
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");               
            }
        }
    }
}
