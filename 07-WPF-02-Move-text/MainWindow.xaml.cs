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

namespace _07_WPF_02_Move_text;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void moveBtn_Click(object sender, RoutedEventArgs e)
    {
        MoveTextAndFocus();
    }

    private void MoveTextAndFocus()
    {
        outputTB.Text = inputTB.Text;
        inputTB.Text = string.Empty;
        inputTB.Focus();
    }

    private void inputTB_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            MoveTextAndFocus();

    }
}