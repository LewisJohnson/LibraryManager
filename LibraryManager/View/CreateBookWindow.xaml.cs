using LibraryManager.Model;
using System.Windows;
using Microsoft.Win32;

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

        private void UploadImageButtonOnClick(object sender, RoutedEventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog {
                FileName = "Image", // Default file name
                DefaultExt = ".jpg|.jpeg|.png|.bmp", // Default file extension
                Filter = "Image files (*.bmp, *.jpg)|*.bmp;*.jpg" // Filter files by extension
            };

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true) {
                // Open document
                string filename = dlg.FileName;
            }
        }
    }
}
