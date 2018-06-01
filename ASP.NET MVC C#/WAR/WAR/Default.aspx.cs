using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WAR
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GamePlayButton_Click(object sender, EventArgs e)
        {
            //Need: add time taken
            CardDeck newDeck = new CardDeck();
            CardHand PlayerOneHand = new CardHand(Player1Name.Text);
            CardHand PlayerTwoHand = new CardHand(Player2Name.Text);

            WarGame.Deal(newDeck, PlayerOneHand, PlayerTwoHand);
            WarGame.PlayGame(PlayerOneHand, PlayerTwoHand);
            WarGame.GamePlay += String.Format("<br/><strong> {0} has won the game!</strong> <br/> Rounds played: {1} <br/>", WarGame.Winner, WarGame.RoundCount-1);
           
            WarGame.GamePlay += "This Game Took " + WarGame.GameEndTime.Subtract(WarGame.GameStartTime).ToString(@"ss\.ffff") + " seconds";
            GameResultsLabel.Text = WarGame.GamePlay;
            WarGame.ResetGamePlay();
            GamePlay20Button.Focus();

        }

        protected void GamePlay20Button_Click(object sender, EventArgs e)
        {
            int roundCount = 20;
            CardDeck newDeck = new CardDeck();
            CardHand PlayerOneHand = new CardHand(Player1Name.Text);
            CardHand PlayerTwoHand = new CardHand(Player2Name.Text);
            WarGame.Deal(newDeck, PlayerOneHand, PlayerTwoHand);
            WarGame.PlayThisManyRounds(PlayerOneHand, PlayerTwoHand, roundCount);
            GameResultsLabel.Text = WarGame.GamePlay;
            WarGame.GamePlay = "";
            GamePlay20Button.Focus();
        }
    }
}