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
    /// Логика взаимодействия для CreateTaskForm.xaml
    /// </summary>
    public partial class CreateTaskForm : Window
    {
        User auth_user = new User();
        User userS = new User();
        public CreateTaskForm(User usA, User usC)
        {
            auth_user = usA;
            userS = usC;
            InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await CreateTask();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Создание задачи";
            lbUserInfo.Content = "Выбранный пользователь: \n" + userS.fio;
            if (slider.Value == 0)
            {
                lbPr.Content = "Низкий приоритет \n(Задача выполняется при отсутствии \nзадач высокого и среднего приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(23, 236, 81));
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider.Value == 0)
            {
                lbPr.Content= "Низкий приоритет \n(Задача выполняется при отсутствии \nзадач высокого и среднего приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(23, 236, 81)); 
            }
            if (slider.Value == 1)
            {
                lbPr.Content = "Средний приоритет \n(Задача выполняется при отсутствии задач \nвысокого приоритета.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 197, 1));
            }
            if(slider.Value == 2)
            {
                lbPr.Content = "Высокий приоритет \n(Задача высокого приоритета \nвыполняется впервую очередь.)";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 42, 42));
            }
        }
        public async Task CreateTask()
        {
            using (HttpClient client = new HttpClient())
            {
                if (txtDesc.Text == "")
                    txtDesc.Text = " ";
                string d1 = DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year;
                string d2 = dateW.SelectedDate.Value.Date.Day + "." + dateW.SelectedDate.Value.Date.Month+"." + dateW.SelectedDate.Value.Date.Year;
                string responce = await client.GetStringAsync(MainFunc.ip + "/create_task?name=" + txtName.Text + "&des=" + txtDesc.Text + "&timeC=" 
                    +d1 +"&timeW=" +d2+ "&userF=" + auth_user.id + "&userT=" + userS.id + "&pr="+slider.Value+"&status=0");
                if (responce == null)
                    MessageBox.Show("Ошибка");
                else
                {
                    MessageBox.Show(responce);
                }
            }
        }
    }
}
