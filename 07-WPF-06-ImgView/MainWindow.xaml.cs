using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _07_WPF_06_ImgView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            //vyvolat dialog
            OpenFileDialog ofd = new();
            ofd.Title = "Select picture";
            ofd.Filter =
                "All files|*.*|"
                + "All supported graphics|*.jpeg;*.jpg;*.png;*.gif;*.bmp|"
                + "JPEG (*.jpeg; *.jpg)|*.jpeg;*.jpg|"
                + "PNG (*.png)|*.png|"
                + "GIF (*.gif)|*.gif"
                ;

            if (ofd.ShowDialog() != true)
                return; //uživatel zrušil

            //zjistím výsledek
            string filename = ofd.FileName;

            FileNameTB.Text = filename;

            try {
                Uri uri = new(filename);
                BitmapImage img = new BitmapImage(uri);
                ImageCtrl.Source = img;
            }
            catch
            {
                MessageBox.Show("Error opening file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}