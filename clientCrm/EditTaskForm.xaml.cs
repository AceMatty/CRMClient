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
    /// Логика взаимодействия для EditTaskForm.xaml
    /// </summary>
    public partial class EditTaskForm : Window
    {
        task task;
        List<User> usList;
        public EditTaskForm(task t, List<User> u)
        {
            task = t;
            usList = u;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = task.name;
            txtDesc.Text = task.desc;
            lbUserInfo.Content = "Пользователь: " + MainFunc.FindUser(task.userT, usList).fio+"\nСоздал пользователь: " + MainFunc.FindUser(task.userF, usList).fio;
            if (task.pr ==0)
            {
                slider.Value = 0;
                lbPr.Content = "Низкий приоритет \n(Задача выполняется при отсутствии \nзадач высокого и среднего приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(23, 236, 81));
            }
            if (task.pr == 1)
            {
                slider.Value = 1;
                lbPr.Content = "Средний приоритет \n(Задача выполняется при отсутствии задач \nвысокого приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 197, 1));
            }
            if (task.pr==2)
            {
                slider.Value = 2;
                lbPr.Content = "Высокий приоритет \n(Задача высокого приоритета \nвыполняется впервую очередь.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 42, 42));
            }
            dateW.SelectedDate = DateTime.Parse(task.time_work);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public async Task EditTask()
        {
            using (HttpClient client = new HttpClient())
            {
                if (txtDesc.Text == "")
                    txtDesc.Text = " ";
                string d1 = DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year;
                string d2 = dateW.SelectedDate.Value.Date.Day + "." + dateW.SelectedDate.Value.Date.Month + "." + dateW.SelectedDate.Value.Date.Year;
                string responce = await client.GetStringAsync(MainFunc.ip + "/edit_task?id="+task.id+"&name=" + txtName.Text + "&des=" + txtDesc.Text + "&timeC="
                    + d1 + "&timeW=" + d2 + "&userF=" + MainFunc.auth_user.id + "&userT=" + task.userT + "&pr=" + slider.Value + "&status=0");
                if (responce == null)
                    MessageBox.Show("Ошибка");
                else
                {
                    MessageBox.Show(responce);
                }
            }
        }
        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            await EditTask();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider.Value == 0)
            {
                lbPr.Content = "Низкий приоритет \n(Задача выполняется при отсутствии \nзадач высокого и среднего приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(23, 236, 81));
            }
            if (slider.Value == 1)
            {
                lbPr.Content = "Средний приоритет \n(Задача выполняется при отсутствии задач \nвысокого приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 197, 1));
            }
            if (slider.Value == 2)
            {
                lbPr.Content = "Высокий приоритет \n(Задача высокого приоритета \nвыполняется впервую очередь.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 42, 42));
            }
        }

        private void dateW_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dateW.SelectedDate.Value.DayOfWeek == DayOfWeek.Saturday || dateW.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Вы выбрали выходной день! \n Пожалуйста выберете другой рабочий день.", "Ошибка!");
                dateW.SelectedDate = DateTime.Now.Date;
            }
        }
    }
}
