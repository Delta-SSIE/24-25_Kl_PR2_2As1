using System.Globalization;
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

namespace _07_WPF_07_SimpleCalculator
{
    enum Operation { None, Add, Subtract, Multiply, Divide }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string decimalDot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        
        private Operation operation = Operation.None;
        private double lastNumber = 0;

        public string DisplayNumber
        {
            get { return (string)GetValue(DisplayNumberProperty); }
            set { SetValue(DisplayNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayNumberProperty =
            DependencyProperty.Register("DisplayNumber", typeof(string), typeof(MainWindow), new PropertyMetadata("0"));



        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            Button pressed = (Button)sender;
            string digit = pressed.Content.ToString();            

            if (DisplayNumber == "0")
                DisplayNumber = digit;
            else
                DisplayNumber += digit;
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber = "0";
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayNumber.StartsWith('-'))
                DisplayNumber = DisplayNumber[1..];
            else
                DisplayNumber = "-" + DisplayNumber;
        }

        private void DotBtn_Click(object sender, RoutedEventArgs e)
        {
            //přidej za to desetinnou tečku/čárku, když tam není
            if (!DisplayNumber.Contains(decimalDot))
                DisplayNumber += decimalDot;
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber = (double.Parse(DisplayNumber) / 100).ToString();
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = operation == Operation.None
                ? double.Parse(DisplayNumber)
                : Calculate();

            DisplayNumber = "0";

            if (sender == PlusBtn)
                operation = Operation.Add;
            else if (sender == MinusBtn)
                operation = Operation.Subtract;
            else if (sender == MultiplyBtn)
                operation = Operation.Multiply;
            else if (sender == DivideBtn)
                operation = Operation.Divide;
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            double result = Calculate();

            lastNumber = 0;
            DisplayNumber = result.ToString();
            operation = Operation.None;
        }

        private double Calculate()
        {
            double number = double.Parse(DisplayNumber);
            Func<double, double, double> formula = operation switch
            {
                Operation.Add => SimpleMath.Add,
                Operation.Subtract => SimpleMath.Subtract,
                Operation.Multiply => SimpleMath.Multiply,
                Operation.Divide => SimpleMath.Divide,
                _ => (double x, double y) => 0
            };
            return formula(lastNumber, number);
        }
    }
}