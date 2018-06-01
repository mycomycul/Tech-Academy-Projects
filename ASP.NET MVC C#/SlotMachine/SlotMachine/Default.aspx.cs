using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlotMachine
{
    public partial class Default : System.Web.UI.Page
    {
        string[] imageList = {"Cherry" ,"Bar", "Seven", "Bell",  "Clover", "HorseShoe", "Lemon"
                    ,"Orange", "Plum",  "Strawberry", "Watermelon" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                
                double playerMoney = 100;
                ViewState["PlayerMoney"] = playerMoney;
                RollRandomNumbers(out int Roll1, out int Roll2, out int Roll3);
                DisplayImages(Roll1, Roll2, Roll3);
                moneyLabel.Text = String.Format("Players Money: {0:C}", playerMoney);
            }
        }


        //Check Outcome of spin
        //Update Money
        //Print results



        protected void leverButton_Click(object sender, EventArgs e)
        {
            
            double playerMoney = (double)ViewState["PlayerMoney"];
            if (playerMoney == 0) playerMoney = ResetGame(playerMoney);
            if (!CheckForANumberBet(out double bet))
            {
                resultLabel.Text = "That's not a proper bet. Please enter a number";
                return;
            }
            if (!CheckForSufficientFunds(playerMoney, bet))
            {
                resultLabel.Text = "Sorry that's more than you have,<br/> enter a smaller number";
                return;
            }

            RollRandomNumbers(out int Roll1, out int Roll2, out int Roll3);
            //For debugging roles
            //int Roll1 = 0; int Roll2 = 0; int Roll3 = 2;
            CalculateWinnings(playerMoney, bet, Roll1, Roll2, Roll3, out double newPlayerMoney);
            DisplayImages(Roll1, Roll2, Roll3);
            DisplayResult(playerMoney, newPlayerMoney, bet);
            if (playerMoney == 0) leverButton.Text = "You're out of Money, Click to Play Aagain!";
            ViewState["PlayerMoney"] = newPlayerMoney;
        }



        private bool CheckForANumberBet(out double bet)
        {
            if (!double.TryParse(TextBox1.Text, out bet)) return false;
            else return true;
        }

        private bool CheckForSufficientFunds(double playerMoney, double bet)
        {

            if (playerMoney < bet) return false;
            if (playerMoney == 0)
            {
             
               
                resultLabel.Text = "Sorry you're out of money. Click to start over";
            }
            return true;

        }
        private void RollRandomNumbers(out int roll1, out int roll2, out int roll3)
        {

            Random spin = new Random();
            roll3 = spin.Next(0, imageList.Length - 1);
            roll2 = spin.Next(0, imageList.Length - 1);
            roll1 = spin.Next(0, imageList.Length - 1);
        }

        private void CalculateWinnings(double playerMoney, double bet, int roll1, int roll2, int roll3, out double newPlayerMoney)
        {

            double winningsMultiplier = 0;


            if (roll1 == 0 || roll2 == 0 || roll2 == 0) winningsMultiplier = 2; //1 Cherry  
            if ((roll1 == 0 && roll2 == 0) || (roll2 == 0 && roll3 == 0) || (roll1 == 0 && roll3 == 0)) winningsMultiplier = 3; //2Cherries
            if (roll1 == 0 && roll2 == 0 && roll3 == 0) winningsMultiplier = 4; //3 Cherries
            if (roll1 == 1 || roll2 == 1 || roll3 == 1) winningsMultiplier = 0; //Any Bars = no money
            if (roll1 == 2 && roll2 == 2 && roll3 == 2) winningsMultiplier = 100;
            if (winningsMultiplier == 0)
            {
                newPlayerMoney = playerMoney - bet;
                return;
            }
            else newPlayerMoney = (bet * winningsMultiplier) + playerMoney;
        }
        private void DisplayImages(int roll1, int roll2, int roll3)
        {
            slotImageOne.ImageUrl = "images/" + imageList[roll1] + ".png";
            slotImageTwo.ImageUrl = "images/" + imageList[roll2] + ".png";
            slotImageThree.ImageUrl = "images/" + imageList[roll3] + ".png";
        }

        private void DisplayResult(double playerMoney, double newPlayerMoney, double bet)
        {
            if (playerMoney > newPlayerMoney)
            {
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", (playerMoney - newPlayerMoney));
            }
            else
            {
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, newPlayerMoney - playerMoney);
            }
            moneyLabel.Text = String.Format("Players Money: {0:C}", newPlayerMoney);
        }

        private double ResetGame(double playerMoney)
        {
            throw new NotImplementedException();
        }









    }
}