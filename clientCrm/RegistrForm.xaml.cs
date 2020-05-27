using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для RegistrForm.xaml
    /// </summary>
    public partial class RegistrForm : Window
    {
        public RegistrForm()
        {
            InitializeComponent();
        }

        HttpClient client = new HttpClient();
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtFio.Text))
                {
                    string responce = client.GetStringAsync(MainFunc.ip + "/register?login=" + txtLogin.Text + "&password=" + txtPass.Text + "&fio=" + txtFio.Text + "&perms=" + cmbBox.SelectedIndex+"&email=" + txtEmail.Text + "&phone=" + txtPhone.Text).Result;
                    MessageBox.Show(responce);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

    }
}
