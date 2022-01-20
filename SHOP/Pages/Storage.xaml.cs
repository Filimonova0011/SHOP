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

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Storage.xaml
    /// </summary>
    public partial class Storage : Page
    {
        public Storage()
        {
            InitializeComponent();
            var currentProduct = ShopEntities.GetContext().Товар.ToList();
            DGridPage.ItemsSource = currentProduct;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditStorage((sender as Button).DataContext as Товар));
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditStorage(null));
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DGridPage.SelectedItems.Cast<Товар>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    ShopEntities.GetContext().Товар.RemoveRange(productForRemoving);
                    ShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    DGridPage.ItemsSource = ShopEntities.GetContext().Товар.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPage.ItemsSource = ShopEntities.GetContext().Товар.ToList();
            }
        }
    }
}
