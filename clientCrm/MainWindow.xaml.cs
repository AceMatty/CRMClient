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
using System.Net.Http;

namespace clientCrm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        HttpClient client = new HttpClient();
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtPass.Password))
                {
                    await LoginRequest();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               
            }
        }
        public async Task LoginRequest()
        {
            string responce = await client.GetStringAsync(MainFunc.ip + "/login?login=" + txtLogin.Text + "&password=" + txtPass.Password);
            MainFunc.auth_user = MainFunc.userMsgHandler(responce);
            if (MainFunc.auth_user.login != null)
            {
                //MessageBox.Show("Добро пожаловать, " + auth_user.fio);
                this.Hide();
                if (MainFunc.auth_user.perms == 1)
                {
                    AdminsForm form = new AdminsForm();
                    form.Show();
                    Close();
                }
                else
                {
                    DefForm form = new DefForm();
                    form.Show();
                    Close();
                }
                    
            }
            else
            {
                MessageBox.Show("ошибка, проверте правильность введенных данных!!!!");
            }
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrForm form = new RegistrForm();
            form.ShowDialog();
        }

        private void btnReg_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrForm form = new RegistrForm();
            form.ShowDialog();
        }
    }
}
