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

namespace SHOP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass_2 = PassBox2.Password.Trim();
            string email = TextBoxEmail.Text.Trim().ToLower();


            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Упс!Введите больше 5 символов";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 5)
            {
                PassBox.ToolTip = "Упс!Пароль должен содержать больше 5 символов";
                PassBox.Background = Brushes.Red;
            }
            else if (pass != pass_2)
            {
                PassBox2.ToolTip = "Пароли не совпадают!";
                PassBox2.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Поле введено не корректно!";
                TextBoxEmail.Background = Brushes.Red;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                PassBox2.Background = Brushes.Transparent;
                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;
            }



            var userContex = ShopEntities.GetContext();
            try
            {
                Пользователи users = new Пользователи
                {
                    Логин = login,
                    Пароль = pass
                };
                userContex.Пользователи.Add(users);
                userContex.SaveChanges();
                MessageBox.Show("Успешная регистрация", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность ввода данных","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                throw;
            }
            //User user = new User(login, email, pass);

            //db.Users.Add(user);
            //db.SaveChanges();

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();

        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        private void Obhod_Click(object sender, RoutedEventArgs e)
        {
            UserPageWindow userPageWindow = new UserPageWindow();
            userPageWindow.Show();
            Close();
        }
    }
}

