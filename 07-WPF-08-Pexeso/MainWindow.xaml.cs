using System.Reflection.Metadata;
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
using System.Windows.Threading;

namespace _07_WPF_08_Pexeso
{
    enum GameStage { Intro, GuessFirst, GuessSecond, FlipBack, Outro}

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameStage stage;
        private int dimension;
        private Card firstCard;
        private Card secondCard;
        private DispatcherTimer timer;

        public int Clicks
        {
            get { return (int)GetValue(ClicksProperty); }
            set { SetValue(ClicksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clicks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClicksProperty =
            DependencyProperty.Register("Clicks", typeof(int), typeof(MainWindow), new PropertyMetadata(0));


        public MainWindow()
        {
            InitializeComponent();
            stage = GameStage.Intro;
            TogglePanels();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1300);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            NextStage();
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
                    Clicks = 0;
                    break;
                case GameStage.GuessFirst:
                    // nech první kartu otočenou
                    stage = GameStage.GuessSecond;
                    Clicks++;
                    break;
                case GameStage.GuessSecond:
                    // porovnej a obrať zpět nebo nech otočeno
                    stage = GameStage.FlipBack;
                    timer.Start();
                    break;

                case GameStage.FlipBack:
                    timer.Stop();
                    if (firstCard.Symbol.ToString() != secondCard.Symbol.ToString())
                    {
                        firstCard.Flip();
                        secondCard.Flip();
                    }
                    else
                    {
                        Board.Children.Remove(firstCard);
                        Board.Children.Remove(secondCard);
                    }
                    // možná posuň na outro

                    if (Board.Children.Count == 0)
                    {
                        stage = GameStage.Outro;
                    }
                    else
                    {
                        stage = GameStage.GuessFirst;
                    }
                        break;
                case GameStage.Outro:
                    //vypiš výsledky
                    //nějak skonči
                    stage = GameStage.Intro;
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
                    card.MouseLeftButtonDown += Card_MouseLeftButtonDown;
                    Board.Children.Add(card);
                    Grid.SetColumn(card, x);
                    Grid.SetRow(card, y);
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

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (stage == GameStage.FlipBack)
                return;

            Card card = sender as Card;
            if (card.IsFlipped)
                return;

            card.Flip();

            if (stage == GameStage.GuessFirst)
                firstCard = card;

            else
                secondCard = card;
            
            NextStage();
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

        private void PlayAgainBtn_Click(object sender, RoutedEventArgs e)
        {
            NextStage();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}