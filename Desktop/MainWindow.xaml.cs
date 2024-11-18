using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Desktop.Scripts;

namespace Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text; // Поле для ввода почты
            string password = PasswordTextBox.Text; // Поле для ввода пароля

            string emailError = email.ValidateEmail();
            string passwordError = password.ValidatePassword();

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите почту и пароль.");
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

            // Проверка данных в текстовом файле
            var users = File.ReadAllLines("users.txt")
                            .Select(line => line.Split(','))
                            .ToList();

            // Проверка на валидность пользователя по почте и паролю
            bool isValidUser = users.Any(user => user[1] == email && user[2] == password);

            if (isValidUser)
            {
                MessageBox.Show("Вход успешен!");
                Window w3 = new MainEmpty();
                Hide();
                w3.Show();
            }

            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window w2 = new Window1();
            Hide();
            w2.Show();
        }
    }
}