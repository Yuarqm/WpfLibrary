using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfBook
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public ObservableCollection<List<string>> books;
        public List<string> selectedBook;
        public AddBookWindow(ObservableCollection<List<string>> books, List<string> selectedBook = null)
        {
            InitializeComponent();
            this.books = books;
            this.selectedBook = selectedBook;
            if(selectedBook != null)
            {
                NameBookText.Text = selectedBook[0];
                AuthorText.Text = selectedBook[1];
                YearText.Text = selectedBook[2];
                StyleBookText.Text = selectedBook[3];
                PageCountText.Text = selectedBook[4];
            }
            
        }
        
      
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {         
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBookText.Text) || string.IsNullOrEmpty(AuthorText.Text) ||
                 string.IsNullOrEmpty(YearText.Text) || string.IsNullOrEmpty(StyleBookText.Text) ||
                  string.IsNullOrEmpty(PageCountText.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (selectedBook == null)
            {
                    
                books.Add(new List<string>{NameBookText.Text, AuthorText.Text,YearText.Text,StyleBookText.Text,PageCountText.Text});
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (selectedBook != null)
            {

                books.Remove(selectedBook);

                selectedBook[0] = NameBookText.Text;
                selectedBook[1] = AuthorText.Text;
                selectedBook[2] = YearText.Text;
                selectedBook[3] = StyleBookText.Text;
                selectedBook[4] = PageCountText.Text;

                books.Add(selectedBook);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

        }
            
    }
}
