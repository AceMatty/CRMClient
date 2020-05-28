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
    /// Логика взаимодействия для TaskListPage.xaml
    /// </summary>
    public partial class TaskListPage : Page
    {
        public TaskListPage()
        {
            InitializeComponent();
        }

        public List<task> tasks = new List<task>();
        List<task> curTasks = new List<task>();
        public static List<User> UsersList;
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await GetTaskList();
            await GetUserList();
            UpdList();
        }
        public async Task GetUserList()
        {
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/user_list");
                UsersList = MainFunc.usersListHandler(responce);
            }
        }
        public async Task GetTaskList()
        {
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/task_list");
                tasks = MainFunc.taskListHandler(responce);
                if (tasks == null)
                    MessageBox.Show("Ошибка");
            }
        }
        public async Task DeleteTask(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/delete_task?task_id="+id);
                MessageBox.Show(responce);
                await GetTaskList();
                await GetUserList();
                UpdList();
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            lsTasks.Items.Clear();
            curTasks.Clear();
            if (chb1.IsChecked == true)
            {
                foreach (task item in tasks)
                {
                    if (item.status == 0 && DateTime.Parse(item.time_work) == dtP.SelectedDate)
                    {
                        string pr = "";
                        string st = "";
                        if (item.status == 1)
                            st = "Выполнено";
                        if (item.status == 0)
                            st = "Не выполнено";
                        switch (item.pr)
                        {
                            case 0:
                                pr = "Низкий";
                                break;
                            case 1:
                                pr = "Средний";
                                break;
                            case 2:
                                pr = "Высокий";
                                break;
                        }
                        ListBoxItem ls = new ListBoxItem();
                        ls.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        ls.Content = "Название: " + item.name + "\n Для кого: " + MainFunc.FindUser(item.userT, UsersList).login + " (" + MainFunc.FindUser(item.userT, UsersList).fio + ")" +
                            "\n Дата для выполнения: " + item.time_work + "\n Приотритет: " + pr + "\n Статус: " + st;
                        lsTasks.Items.Add(ls);
                        curTasks.Add(item);
                    }
                }
            }
            else
            {
                foreach (task item in tasks)
                {
                    if (DateTime.Parse(item.time_work) == dtP.SelectedDate)
                    {
                        string pr = "";
                        string st = "";
                        if (item.status == 1)
                            st = "Выполнено";
                        if (item.status == 0)
                            st = "Не выполнено";
                        switch (item.pr)
                        {
                            case 0:
                                pr = "Низкий";
                                break;
                            case 1:
                                pr = "Средний";
                                break;
                            case 2:
                                pr = "Высокий";
                                break;
                        }
                        ListBoxItem ls = new ListBoxItem();
                        ls.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        ls.Content = "Название: " + item.name + "\n Для кого: " + MainFunc.FindUser(item.userT, UsersList).login + " (" + MainFunc.FindUser(item.userT, UsersList).fio + ")" +
                            "\n Дата для выполнения: " + item.time_work + "\n Приотритет: " + pr + "\n Статус: " + st;
                        lsTasks.Items.Add(ls);
                        curTasks.Add(item);
                    }
                }
            }
        }
        void UpdList()
        {
            lsTasks.Items.Clear();
            curTasks.Clear();
            foreach (task item in tasks)
            {
                string pr = "";
                string st = "";
                if (item.status == 1)
                    st = "Выполнено";
                if (item.status == 0)
                    st = "Не выполнено";
                switch (item.pr)
                {
                    case 0:
                        pr = "Низкий";
                        break;
                    case 1:
                        pr = "Средний";
                        break;
                    case 2:
                        pr = "Высокий";
                        break;
                }
                ListBoxItem ls = new ListBoxItem();
                ls.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                ls.Content = "Название: " + item.name + "\n Для кого: " + MainFunc.FindUser(item.userT, UsersList).login + " (" + MainFunc.FindUser(item.userT, UsersList).fio + ")" +
                    "\n Дата для выполнения: " + item.time_work + "\n Приотритет: " + pr + "\n Статус: " + st;
                lsTasks.Items.Add(ls);
                curTasks.Add(item);

            }
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UpdList();
        }
        private async void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lsTasks.SelectedIndex != -1)
                {
                    AcceptForm form = new AcceptForm();
                    form.ShowDialog();
                    if (form.IsActive == false)
                    {
                        if (form.isAccepted == true)
                        {
                            await DeleteTask(curTasks[lsTasks.SelectedIndex].id);
                            form.Close();
                        }
                        else
                        {
                            form.Close();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Выберете элемент!", "Ошибка");
                }
               
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
           
        }
    }
}
