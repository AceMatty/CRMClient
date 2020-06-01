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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace clientCrm
{
    /// <summary>
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
        }
        public static List<User> UsersList;
        public async Task GetUserList()
        {
            usList.Items.Clear();
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/user_list");
                UsersList = MainFunc.usersListHandler(responce);
                if (UsersList == null)
                    MessageBox.Show("Ошибка");
                else
                {
                    foreach (User item in UsersList)
                    {
                        string usType = "";
                        if (item.perms == 0)
                            usType = "обычный пользователь";
                        if (item.perms == 1)
                            usType = "администратор";
                        usList.Items.Add("ФИО: "+item.fio + "  \n Email: " + item.email+ "  \n Телефон: " + item.phone + " \n Тип пользователя: " +usType+"");
                    }
                }
            }
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await GetUserList();
                usList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCreateuser_Click(object sender, RoutedEventArgs e)
        {
            RegistrForm form = new RegistrForm();
            form.ShowDialog();
            await GetUserList();
        }

        private void btnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            User us = UsersList[usList.SelectedIndex];
            CreateTaskForm form = new CreateTaskForm(us);
            form.ShowDialog();
        }
    }
}
