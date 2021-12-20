using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MatchingGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer pewaktu = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            pewaktu.Interval = TimeSpan.FromSeconds(.1);
            pewaktu.Tick += Pewaktu_Tick;

            SetUpGame();
        }

        private void Pewaktu_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.# seconds");
            if (matchesFound == 8)
            {
                pewaktu.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }

        }

        private void SetUpGame()
        {
            //throw new NotImplementedException();
            List<string> emojiBonbin = new List<string>()
            {
               "🐙", "🐙",
               "🐘","🐘",
               "🐟","🐟",
               "🐪", "🐪",
               "🐋","🐋",
               "🦕","🦕",
               "🦘","🦘",
               "🦔","🦔"
            };

            Random acak = new Random();

            foreach (TextBlock ngeteks in mainGrid.Children.OfType<TextBlock>())
            {
                if (ngeteks.Name != "timeTextBlock")
                //while (emojiBonbin.Count > 0)
                {

                //    ngeteks.Visibility = Visibility.Visible;

                    int pengindeks = acak.Next(emojiBonbin.Count);
                    string emojiNext = emojiBonbin[pengindeks]; //<------------------------ THE KEY TO GRAB TEXT from LIST
                    ngeteks.Text = emojiNext; //<------------------------ THE KEY TO LOAD TEXT TO  TextBlock 
                                              //ngeteks.Text = emojiBonbin[pengindeks];

                    emojiBonbin.RemoveAt(pengindeks);
                }
            }
            pewaktu.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock objek = sender as TextBlock;

            if (findingMatch == false)
            {
    
                objek.Visibility = Visibility.Hidden;
                lastTextBlockClicked = objek;
                findingMatch = true;

            }

            else if (objek.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                objek.Visibility = Visibility.Hidden;
                findingMatch = false;
            }

            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8) 
            {
                SetUpGame();
                    }
        }
    }
}
