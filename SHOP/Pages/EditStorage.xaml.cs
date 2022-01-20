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
    /// Логика взаимодействия для EditStorage.xaml
    /// </summary>
    public partial class EditStorage : Page
    {
        private Товар _currentProduct = new Товар();
        public EditStorage(Товар selectedProduct)
        {
            if (selectedProduct != null)
            {
                _currentProduct = selectedProduct;
            }
            InitializeComponent();
            DataContext = _currentProduct;
            ProviderComboBox.ItemsSource = ShopEntities.GetContext().Поставщик.ToList();
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentProduct.Название))
                errors.AppendLine("Поле с названием не может быть пустым");
            if (_currentProduct.Цена < 0)
                errors.AppendLine("Цена не может быть отрицательной");
            if (_currentProduct.Количество < 0)
                errors.AppendLine("Количество не может быть отрицательным");
            if (_currentProduct.Поставщик == null)
                errors.AppendLine("Выберите поставщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentProduct.КодТовара == 0)
            {
                ShopEntities.GetContext().Товар.Add(_currentProduct);
            }
            try
            {
                ShopEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\nПроверьте правильность заполнения полей", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            TitleText.Clear();
            PriceText.Clear();
            AllCountText.Clear();
            Manager.MainFrame.GoBack();
        }
    }
}
