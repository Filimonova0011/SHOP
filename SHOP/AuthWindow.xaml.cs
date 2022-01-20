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
using System.Windows.Shapes;

namespace SHOP
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

    

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();


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
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;

                var userCurrent = ShopEntities.GetContext().Пользователи.First(p=>p.Логин == login && p.Пароль == pass);
                if (userCurrent != null)
                {
                    MessageBox.Show("Успешно","Сообщение",MessageBoxButton.OK,MessageBoxImage.Information);
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели некорректные данные","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                }  
            }

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
