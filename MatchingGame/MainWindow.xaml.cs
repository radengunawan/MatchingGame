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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
                int pengindeks = acak.Next(emojiBonbin.Count);
                string emojiNext = emojiBonbin[pengindeks];
                ngeteks.Text = emojiNext;
                emojiBonbin.RemoveAt(pengindeks);
            }
        }
    }
}
