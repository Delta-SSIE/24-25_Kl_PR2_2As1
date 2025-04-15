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

namespace _07_WPF_08_Pexeso
{
    enum GameStage { Intro, GuessFirst, GuessSecond, Outro}

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameStage stage;
        private int dimension;

        public MainWindow()
        {
            InitializeComponent();
            stage = GameStage.Intro;
            TogglePanels();
        }

        private void NextStage()
        {
            switch (stage)
            {
                case GameStage.Intro:
                    //ukončí se klikem na tlačítko s počtem kartiček
                    //připrav hru (rozdej)
                    SetUpBoard();
                    stage = GameStage.GuessFirst;
                    break;
                case GameStage.GuessFirst:
                    // nech první kartu otočenou                    
                    break;
                case GameStage.GuessSecond:
                    // porovnej a obrať zpět nebo nech otočeno
                    // možná posuň na outro
                    break;
                case GameStage.Outro:
                    //vypiš výsledky
                    //nějak skonči
                    break;

            }
            TogglePanels();
        }

        private void SetUpBoard()
        {
            //vyčisti starou hru
            Board.ColumnDefinitions.Clear();
            Board.RowDefinitions.Clear();
            Board.Children.Clear();

            // generuj mřížku
            for (int i = 0; i < dimension; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < dimension; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
            }

            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    Card card = new();
                    Board.Children.Add(card);
                    Grid.SetColumn(card, x);
                    Grid.SetRow(card, y);
                    card.Flip();
                }
            }

            int[] symbols = new int[dimension * dimension];
            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = i / 2 + 1;
            }

            Random rnd = new Random();
            symbols = symbols.OrderBy(x => rnd.NextDouble()).ToArray();

            for (int i = 0; i < symbols.Length; i++)
            {
                ((Card)Board.Children[i]).Symbol = symbols[i].ToString();
            }
        }

        private void TogglePanels()
        {
            ConfigPanel.Visibility = stage == GameStage.Intro 
                    ? Visibility.Visible 
                    : Visibility.Hidden;

            GamePanel.Visibility = (stage != GameStage.Intro && stage != GameStage.Outro)
                ? Visibility.Visible
                : Visibility.Hidden;

            ResultsPanel.Visibility = stage == GameStage.Outro
                    ? Visibility.Visible
                    : Visibility.Hidden;
        }

        private void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            //zapíšu si rozměr hry
            switch (((Button)sender).Content.ToString()){
                case "2x2":
                    dimension = 2;
                    break;
                case "4x4":
                    dimension = 4;
                    break;
                case "6x6":
                    dimension = 6;
                    break;
            }
            NextStage();
        }
    }
}