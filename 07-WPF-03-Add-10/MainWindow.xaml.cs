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

namespace _07_WPF_03_Add_10;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void inputTB_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (outputTB == null)
            return;

        if (double.TryParse(inputTB.Text, out double inputNum))
        { 
            double outputNum = inputNum + 10;
            outputTB.Text = outputNum.ToString();

            outputTB.Background = Brushes.Transparent;
            outputTB.Foreground = Brushes.Black;
            outputTB.FontWeight = FontWeights.Normal;

        }
        else
        {
            outputTB.Text = "NaN";
            outputTB.Background = Brushes.Red;
            outputTB.Foreground = Brushes.White;
            outputTB.FontWeight = FontWeights.Bold;
        }
    }
}