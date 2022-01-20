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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Storage());
            Manager.MainFrame = MainFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Storage());
        }

        private void Provider_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Provider());
        }

        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.StatisticsPage());
        }

        private void Note_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.NotePage());
        }
    }
}
