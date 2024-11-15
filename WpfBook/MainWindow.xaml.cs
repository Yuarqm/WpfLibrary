using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace WpfBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            BooksList.ItemsSource = Books;
        }

     public static ObservableCollection<List<string>> Books = new ObservableCollection<List<string>>();



    private void GoToAddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow(Books);
            addBookWindow.Show();         
            this.Close();

            
        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            List<string> selectedBook = (List<string>)BooksList.SelectedItem;
            Books.Remove(selectedBook);

        }

        private void GoToEditBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem != null)
            {
               
                List<string> selectedBook = (List<string>)BooksList.SelectedItem;

                
                AddBookWindow addBookWindow = new AddBookWindow(Books, selectedBook);
                addBookWindow.Show();
                this.Close();
            }
            
        }
    }
}
