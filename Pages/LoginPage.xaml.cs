using AutoZolto.Classes;
using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
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

namespace AutoZolto.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navigate.Navigate(new RegPage());
        }

        private async void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// <summary> 
                /// Соединение с базой данных, реализация возможности авторизации
                /// </summary>
                bool verif = BCrypt.Net.BCrypt.Verify(TxbPass.Text, )
                var _signIn = JsonConvert.DeserializeObject<SignIn>(responseContent);
                string url = $"https://localhost:7008/api/User?UserLogin={TxbLog.Text}&UserPassword={TxbPass.Text}";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                //if _signIn == null - такого пользователя нет, данные введены неверно

                if (TxbLog.Text == "" || TxbPass.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        NavigationClass.navigate.Navigate(new MainPage());
                    }
                    else
                    {
                        MessageBox.Show("Данные введены неверно!");
                    }
                }
            }
            catch (Exception er)
            {
                er.Message.ToString();
            }


        }
    }
}
