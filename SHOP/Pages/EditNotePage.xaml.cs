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
    /// Логика взаимодействия для EditNotePage.xaml
    /// </summary>
    public partial class EditNotePage : Page
    {
        private Заметки _notes = new Заметки();
        public EditNotePage(Заметки selectedNote)
        {
            InitializeComponent();
            if (selectedNote != null)
            {
                _notes = selectedNote;
            }
            DataContext = _notes;
            NoteComboBox.ItemsSource = ShopEntities.GetContext().СтепеньВажности.ToList();
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_notes.Заголовок))
                errors.AppendLine("Поле заголовок не может быть пустым");
            if (_notes.СтепеньВажности == null)
                errors.AppendLine("Выберите степень важности");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_notes.IdЗаметки == 0)
            {
                ShopEntities.GetContext().Заметки.Add(_notes);
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
            DescriptionText.Clear();
            Manager.MainFrame.GoBack();
        }
    }
}
