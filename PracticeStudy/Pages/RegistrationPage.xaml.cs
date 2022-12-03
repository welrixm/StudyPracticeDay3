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
using PracticeStudy.Components;

namespace PracticeStudy.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            string firstname = FirstNameTb.Text.Trim();
            string lastname = LastNameTb.Text.Trim();
            string patronymic = PatronymicTb.Text.Trim();
            string email = EmailTb.Text.Trim();
            if (login.Length > 0 && password.Length > 0 && firstname.Length > 0 && lastname.Length > 0 && patronymic.Length > 0 && email.Length > 0)
            {
                DBConnect.db.User.Add(new User
                {
                    Login = login,
                    Password = password,
                    FirstName = firstname,
                    LastName = lastname,
                    Patronymic = patronymic,
                    Email = email,
                    RoleId = 2
                });


                if (password.Length >= 6)
                {
                    bool ru = true;
                    bool symbol = false;
                    bool number = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (password[i] >= 'А' && password[i] <= 'Я') ru = false;
                        if (password[i] >= '0' && password[i] <= '9') number = true;
                        if (password[i] == '!' || password[i] == '@' || password[i] == '#' || password[i] == '$' || password[i] == '%' || password[i] == '^') symbol = true;
                    }
                    if (!ru)
                        MessageBox.Show("Доступна только русская раскладка");
                    else if (!symbol)
                        MessageBox.Show("Добавьте один из следующих символов: ! @ # $ % ^");
                    else if (!number)
                        MessageBox.Show("Добавьте хотя бы одну цифру");
                    if (ru && symbol && number)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Пароль слишком короткий, требуется минимум 6 символов!");
                }
                DBConnect.db.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегестрирован!");
                Navigation.BackPage();
            }
            else
            {
                MessageBox.Show("Пусто!Пожалуйста, заполните поля");
            }

        }


        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "";
            PasswordTb.Password = "";
            FirstNameTb.Text = "";
            LastNameTb.Text = "";
            PatronymicTb.Text = "";
            EmailTb.Text = "";
        }
    }
}
