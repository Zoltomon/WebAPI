using AutoZolto.Classes;
using AutoZolto.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.navigate.GoBack();
        }

        private async void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string log = TxbLog.Text;
                string pass = TxbPass.Text;
                string copyPass = TxbCopyPass.Text;
                if (pass !="" || log !="")
                {
                    if(pass == copyPass)
                    {
                        if(pass.Length >= 5)
                        {
                            string hashPass = BCrypt.Net.BCrypt.HashPassword(pass);
                            bool logVerif = Regex.IsMatch(log, @"^[a-zA-Z0-9]+$");
                            if(logVerif)
                            {
                                User newUser = new User()
                                {
                                    Password = hashPass,
                                    StatusId = 1,
                                    RoleId = 1
                                };
                                ConnectDB.connect.Users.Add(newUser);
                                ConnectDB.connect.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Ваш логин неправильный");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ваш пароль слишком короткий");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ошибка сервера");
            }
        }

        private void PassStrength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string password = TxbPass.Text;
            int passwordStrength = GetPasswordStrength(password);
            PassStrength.Value = passwordStrength;
        }
        private int GetPasswordStrength(string password)
        {
            int passwordStrength = 0;

            // Проверяем длину пароля
            if (password.Length >= 8)
            {
                passwordStrength += 20;
            }

            // Проверяем наличие цифр
            if (Regex.IsMatch(password, @"\d"))
            {
                passwordStrength += 20;
            }

            // Проверяем наличие букв в верхнем регистре
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                passwordStrength += 20;
            }

            // Проверяем наличие букв в нижнем регистре
            if (Regex.IsMatch(password, @"[a-z]"))
            {
                passwordStrength += 20;
            }

            // Проверяем наличие специальных символов
            if (Regex.IsMatch(password, @"[^\w\s]"))
            {
                passwordStrength += 20;
            }

            return passwordStrength;
        }

        private void TxbPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = TxbPass.Text;

            // Проверяем сложность пароля
            int passwordStrength = GetPasswordStrength(password);

            // Устанавливаем значение слайдера
            PassStrength.Value = passwordStrength;
            if (string.IsNullOrEmpty(TxbPass.Text))
            {
                PassStrength.Visibility = Visibility.Collapsed;
            }
            else
            {
                PassStrength.Visibility = Visibility.Visible;
                TxbBlcPassStrength.Visibility = Visibility.Visible;
                if (passwordStrength >= 70)
                {
                    PassStrength.Background = new SolidColorBrush(Colors.Green);
                    TxbBlcPassStrength.Text = "Легкий пароль";
                }
                else if (passwordStrength >= 30)
                {
                    PassStrength.Background = new SolidColorBrush(Colors.Orange);
                    TxbBlcPassStrength.Text = "Средний пароль";
                }
                else
                {
                    PassStrength.Background = new SolidColorBrush(Colors.Red);
                    TxbBlcPassStrength.Text = "Сложный пароль";
                }
            }
        }
    }
}
