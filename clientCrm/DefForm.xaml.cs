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
using System.Windows.Shapes;

namespace clientCrm
{
    /// <summary>
    /// Логика взаимодействия для DefForm.xaml
    /// </summary>
    public partial class DefForm : Window
    {
        User auth_user;

        public DefForm(User u)
        {
            auth_user = u;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFunc.mainForm = this;
            frm1.Content = new MainAdminPage(auth_user);
            lbUserInfo.Content = "Вы вошли как:" + auth_user.login;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            Close();
        }

        private void btnOpenTasks_Click(object sender, RoutedEventArgs e)
        {
            frm1.Content = new UserTaskList(auth_user);

        }

        private void btnOpenMain_Click(object sender, RoutedEventArgs e)
        {
            frm1.Content = new MainAdminPage(auth_user);

        }
    }
}
