using GUI.ViewMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            tbName.Text = LoginViewMD.Account0.DisplayName;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(LoginViewMD.Account0.Avatar);
            bitmap.EndInit();
            imgAvatar.Source = bitmap;
            AccountViewMD.idUser = LoginViewMD.Account0.id;
        }
    }
}
