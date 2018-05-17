using LibraryManager.Controller;
using LibraryManager.Model;
using LibraryManager.View;
using System.Windows;

namespace LibraryManager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void OnRefreshButtonClick(object sender, RoutedEventArgs e) {
            int amountOfBooks = 0;

            foreach (var book in Book.GetAll()) {
                amountOfBooks++;
                //OutputTextBlock.Text += book.Title;
            }

            if(amountOfBooks < 1) {
                //OutputTextBlock.Text += "No books found.";
            }
        }

        private void OnNewBookButtonClick(object sender, RoutedEventArgs e) {
            CreateBookWindow bookWindow = new CreateBookWindow();
            bookWindow.Show();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            DatabaseManager.Instance().Close();
        }

    }
}
