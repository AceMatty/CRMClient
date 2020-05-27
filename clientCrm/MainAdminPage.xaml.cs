using System;
using System.Collections.Generic;
using System.Globalization;
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
namespace clientCrm
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        User user;
        public MainAdminPage(User u)
        {
            user = u;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string name = user.fio.Substring(user.fio.IndexOf(' '));
            lb1.Text = "Добро пожаловать, " + name + "! \n" + "Сегодня " + DateTime.Now.ToString("dddd, d MMMM yyyy г.", CultureInfo.GetCultureInfo("ru-ru"));
        }
    }
}
