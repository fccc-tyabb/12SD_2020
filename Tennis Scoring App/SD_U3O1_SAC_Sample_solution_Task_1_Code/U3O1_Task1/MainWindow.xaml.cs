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

namespace U3O1_Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Data dictionary
        // Players scores stored as integers incrementing by 1 each time.  Display converts this to tennis scores
        // The score will be advanced by 2 if one player is ahead of the other
        int player1Score = 0;
        int player2Score = 0;
        // The scoretranslator allow the player score to be the index for the lookup.  Zero based array
        string[] scoreTranslator = { "0", "15", "30", "40", "ADV", "GAME" };

        // I would prefer to make this a class with properties.  I have done thie by as of now, not used it
        //struct ScoreItem
        //{
        //    public string player1Score;
        //    public string player2Score;

        //    public ScoreItem(string p1, string p2)
        //    {
        //        player1Score = p1;
        //        player2Score = p2;
        //    }
        //}
        List<ScoreRecord> scoreHistory;

        public MainWindow()
        {
            InitializeComponent();
            scoreHistory = new List<ScoreRecord>();
            RefreshDisplay();
        }

        private void ScorePlayerOneButton_Click(object sender, RoutedEventArgs e)
        {
            // UpdateScores can be used twice by reversing the elements
            // It is important to pass the parameter as references!
            // Including the name is important for display
            UpdateScores(ref player1Score, ref player2Score, "PLAYER 1");
        }

        private void ScorePlayerTwoButton_Click(object sender, RoutedEventArgs e)
        {
            // Because the code is identical for both event handlers,
            // UpdateScores can be used twice by reversing the elements
            // ensuring that they are passed by reference
            // Including the name is important for display
            UpdateScores(ref player2Score, ref player1Score, "PLAYER 2");
        }

        /// <summary>
        /// method is used by both button event handlers
        /// reversing the scores which are passed in by reference
        /// </summary>
        /// <param name="scoreA">by ref</param>
        /// <param name="scoreB">by ref</param>
        /// <param name="playerID"></param>
        private void UpdateScores(ref int scoreA, ref int scoreB, string playerID)
        {
            // In this case we go through ADV, so only increment once
            if (scoreA == 3 && scoreB == 3)
            {
                scoreA++;
                RefreshDisplay("ADV: " + playerID);
            }

            // In this case, the other player had the advantage, but now it is back to deuce
            else if (scoreA == 3 && scoreB == 4)
            {
                scoreB--;
                RefreshDisplay("DEUCE");
            }
            // Remembering that 4 is the ADV score, we skip ahead two points because this player has won
            else if (scoreA == 4 || scoreA == 3 && scoreB < 3)
            {
                scoreA++;
                RefreshDisplay("GAME: " + playerID);
                ScorePlayerOneButton.IsEnabled = false;
                ScorePlayerTwoButton.IsEnabled = false;
            }
            // After all that, this is normal scoring!
            else
            {
                scoreA++;
                RefreshDisplay();
            }
        }

        /// <summary>
        /// This event handler resets the scores to zero and sets the display accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            player1Score = 0;
            player2Score = 0;
            RefreshDisplay();
            // Reenable the score buttons
            ScorePlayerOneButton.IsEnabled = true;
            ScorePlayerTwoButton.IsEnabled = true;
        }

        /// <summary>
        /// This overload of RefreshDisplay with no parameters is for normal scoring
        /// </summary>
        private void RefreshDisplay()
        {
            if (player1Score == 3 && player2Score == 3)
            {
                ScoreTextBox.Text = "DEUCE";
            }
            else
            {
                // Normal scoring - translate using display array
                ScoreTextBox.Text = scoreTranslator[player1Score] + " : " + scoreTranslator[player2Score];
            }
            ScoreRecord entry = new ScoreRecord(scoreTranslator[player1Score], scoreTranslator[player2Score]);
            scoreHistory.Add(entry);
        }

        /// <summary>
        /// This overload of RefreshDisplay takes the display value directly
        /// </summary>
        /// <param name="displayString"></param>
        private void RefreshDisplay(string displayString)
        {
            // Special display
            ScoreTextBox.Text = displayString;
        }
    }
}
