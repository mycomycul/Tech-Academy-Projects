using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Darts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Game newGame = new Game();
            newGame.PlayGame301();
            resultLabel1.Text = "Player One: " +
                newGame.PlayerOneGameScoreString.Remove(newGame.PlayerOneGameScoreString.Length-2,1);
            resultLabel2.Text = "Player Two: " +
                newGame.PlayerTwoGameScoreString.Remove(newGame.PlayerTwoGameScoreString.Length-2,1);
            resultLabel.Text = String.Format("{0} beat {1} with {2} points to {3} points ", newGame.Winner, newGame.Loser, newGame.WinnerGameScore, newGame.LoserGameScore);

        }
    }
    //public class Game301
    public class Game
    {
        public int PlayerOneScore = 301;
        public int PlayerTwoScore = 301;
        Dart dart = new Dart();

        //Use for tracking game
        public string PlayerOneGameScoreString;
        public string PlayerTwoGameScoreString;
        public string Winner;
        public string Loser;
        public int WinnerGameScore;
        public int LoserGameScore;

        //Game Variables
        string currentPlayerScoreString;
        int currentPlayer = 1;
        int currentPlayerScore;
        int currentTurn;



        public void PlayGame301()
        {
            currentPlayerScore = PlayerOneScore;
            currentTurn = 1;
            currentPlayerScoreString = PlayerOneGameScoreString;

            while (PlayerOneScore > 0 && PlayerTwoScore > 0)
            {
                for (int turns = 3; turns > 0; turns--)
                {
                    dart.Throw();
                    currentTurn = Score301(dart.ThrowValue, dart.InnerOrOuterRing);
                    currentPlayerScore -= currentTurn;
                    currentPlayerScoreString += currentPlayerScore + " , ";
                    currentTurn = 0;
                }
                switchPlayers();
            }
            checkWinner();
        }

        private int Score301(int ThrowValue, string WhichRing)
        {
            if (WhichRing == "innerring") ThrowValue *= 3;
            if (WhichRing == "outerring") ThrowValue *= 2;
            if (WhichRing == "bullseye") return 50;
            if (ThrowValue == 0) return 25;
            return ThrowValue;
        }
    


    public void switchPlayers()
        {

            if (currentPlayer == 1)
            {
                //store this round to player one
                PlayerOneScore = currentPlayerScore;
                PlayerOneGameScoreString = currentPlayerScoreString;
                //switch game variables to player two
                currentPlayerScore = PlayerTwoScore;
                currentPlayer = 2;
                currentPlayerScoreString = PlayerTwoGameScoreString;
            }
            else
            {
                //store this round to player two
                PlayerTwoScore = currentPlayerScore;
                PlayerTwoGameScoreString = currentPlayerScoreString;
                //switch game variables to player two
                currentPlayerScore = PlayerOneScore;
                currentPlayer = 1;
                currentPlayerScoreString = PlayerOneGameScoreString;
            }
        }

        private void checkWinner()
        {
            if (PlayerOneScore < PlayerTwoScore)
            {
                Winner = "Player One";
                Loser = "Player Two";
                WinnerGameScore = PlayerOneScore;
                LoserGameScore = PlayerTwoScore;

            }
            else
            {
                Winner = "Player Two";
                Loser = "Player One";
                WinnerGameScore = PlayerTwoScore;
                LoserGameScore = PlayerOneScore;
            }
        }

    }
}



