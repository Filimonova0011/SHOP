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
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        public NotePage()
        {
            InitializeComponent();
            LViewNote.ItemsSource = ShopEntities.GetContext().Заметки.ToList();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditNotePage(null));
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var notesForRemoving = LViewNote.SelectedItems.Cast<Заметки>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {notesForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    ShopEntities.GetContext().Заметки.RemoveRange(notesForRemoving);
                    ShopEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    LViewNote.ItemsSource = ShopEntities.GetContext().Товар.ToList();
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
                LViewNote.ItemsSource = ShopEntities.GetContext().Заметки.ToList();
            }
        }

        private void MoreBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditNotePage((sender as Button).DataContext as Заметки));
        }
    }
}
