using Desktop.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
using System.Windows.Shapes;

namespace Desktop
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            string usernameError = username.ValidateUsername();
            string emailError = email.ValidateEmail();
            string passwordError = password.ValidatePassword();

            string confirmPassword = ConfirmPasswordTextBox.Text;

            if (usernameError != null)
            {
                MessageBox.Show(usernameError, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (emailError != null)
            {
                MessageBox.Show(emailError, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (passwordError != null)
            {
                MessageBox.Show(passwordError, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают. Пожалуйста, попробуйте снова.", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            string userData = $"{username},{email},{password}\n";
            File.AppendAllText("users.txt", userData);

            MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            MainWindow w1 = new MainWindow();
            Hide();
            w1.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = new MainWindow();
            Hide();
            w1.Show();
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
