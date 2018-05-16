using LibraryManager.Model;
using System.Windows;

namespace LibraryManager.View {
    /// <summary>
    /// Interaction logic for CreateBookWindow.xaml
    /// </summary>
    public partial class CreateBookWindow : Window {
        public CreateBookWindow() {
            InitializeComponent();
        }

        private void SaveBookButtonOnClick(object sender, RoutedEventArgs e) {
            Book book = new Book {
                Title = Title.Text,
                Subtitle = Subtitle.Text,
                Isbn = Isbn.Text,
                Author = Author.Text,
                Publisher = Publisher.Text,
                ExtraInformation = Extra.Text
            };

            book.Save();
            this.Close();
        }
    }
}
