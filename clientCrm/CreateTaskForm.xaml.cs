﻿using System;
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
        User userS = new User();
        public CreateTaskForm(User usC)
        {
            userS = usC;
            InitializeComponent();
        }
        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                try
                {
                    await CreateTask();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Введите название задачи", "Ошибка!");
                txtName.Focus();
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
            dateW.DisplayDateStart = dateW.DisplayDate;
            dateW.SelectedDate = DateTime.Now.Date;
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
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (txtDesc.Text == "")
                        txtDesc.Text = " ";
                    string d1 = DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year;
                    string d2 = dateW.SelectedDate.Value.Date.Day + "." + dateW.SelectedDate.Value.Date.Month + "." + dateW.SelectedDate.Value.Date.Year;
                    string responce = await client.GetStringAsync(MainFunc.ip + "/create_task?name=" + txtName.Text + "&des=" + txtDesc.Text + "&timeC="
                        + d1 + "&timeW=" + d2 + "&userF=" + MainFunc.auth_user.id + "&userT=" + userS.id + "&pr=" + slider.Value + "&status=0");
                    if (responce == null)
                        MessageBox.Show("Ошибка");
                    else
                    {
                        MessageBox.Show(responce);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
            
        }
        private void dateW_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dateW.SelectedDate.Value.DayOfWeek == DayOfWeek.Saturday || dateW.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Вы выбрали выходной день! \n Пожалуйста выберете другой рабочий день.","Ошибка!");
                dateW.SelectedDate = DateTime.Now.Date;
            }
        }
    }
}
