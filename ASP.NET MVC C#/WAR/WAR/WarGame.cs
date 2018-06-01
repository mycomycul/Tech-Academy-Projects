using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WAR
{
    public static class WarGame
    {
        private static Random random = new Random();
        private static List<Card> currentBounty = new List<Card>();
        public static string GamePlay;
        public static int RoundCount = 0;
        public static string Winner = null;
        public static DateTime GameStartTime;
        public static DateTime GameEndTime;


        public static void Deal(CardDeck currentDeck, CardHand PlayerOne, CardHand PlayerTwo)
        {
            int _randomCard = random.Next(0, currentDeck.Deck.Count);


            CardHand _currentHandToDeal = PlayerOne;

            for (int _cardsRemaining = currentDeck.Deck.Count; _cardsRemaining > 0; _cardsRemaining--)
            {

                _currentHandToDeal.CurrentHand.Add(currentDeck.Deck[_randomCard]);
                GamePlay += String.Format("{0} was dealt a {1} of {2} <br/>", _currentHandToDeal.FullName, currentDeck.Deck[_randomCard].CardName, currentDeck.Deck[_randomCard].Suit);
                currentDeck.Deck.RemoveAt(_randomCard);
                _currentHandToDeal = (_currentHandToDeal == PlayerOne) ? PlayerTwo : PlayerOne;
                _randomCard = random.Next(0, currentDeck.Deck.Count);
            }
            GamePlay += "<br/>";
        }

        internal static void ResetGamePlay()
        {
            GamePlay = "";
        }

        public static void PlayGame(CardHand playerOneHand, CardHand playerTwoHand)
        {
            GameStartTime = DateTime.Now;
            Winner = null;
            RoundCount = 1;
            while (Winner == null)
            {
                PlayRound(playerOneHand, playerTwoHand);
                CheckForGameWinner(playerOneHand, playerTwoHand);
            }
            GameEndTime = DateTime.Now;
        }
        //OR
        internal static void PlayThisManyRounds(CardHand playerOneHand, CardHand playerTwoHand, int roundsToPlay)
        {
            Winner = null;
            RoundCount = 1;

            while (RoundCount <= roundsToPlay && Winner == null)
            {
                PlayRound(playerOneHand, playerTwoHand);
                CheckForGameWinner(playerOneHand, playerTwoHand);

            }
            CheckShortGameWinner(playerOneHand, playerTwoHand);
        }



        private static void PlayRound(CardHand playerOne, CardHand playerTwo)
        {

            //Anti Up
            PlayCard(playerOne, playerTwo);
            CompareCards(playerOne, playerTwo);

        }



        private static void PlayCard(CardHand playerOne, CardHand playerTwo)
        {
            if (playerOne.CurrentHand.Count > 0 && playerTwo.CurrentHand.Count > 0)
            {
                DisplayGame(playerOne, playerTwo);
                currentBounty.Add(playerOne.CurrentHand[0]);
                currentBounty.Add(playerTwo.CurrentHand[0]);
                playerOne.CurrentHand.RemoveAt(0);
                playerTwo.CurrentHand.RemoveAt(0);
                DisplayBounty();
                RoundCount += 1;
            }
            else CheckForGameWinner(playerOne, playerTwo); ;
        }

        private static void DisplayGame(CardHand playerOneHand, CardHand playerTwoHand)
        {
            GamePlay += String.Format("Round: {2} <br/> Player one has {0} cards and Player two has {1} cards <br />", playerOneHand.CurrentHand.Count, playerTwoHand.CurrentHand.Count, RoundCount);
            GamePlay += String.Format("Battle Cards: {0} of {1} versus {2} of {3} <br />",
                playerOneHand.CurrentHand[0].CardName, playerOneHand.CurrentHand[0].Suit,
                playerTwoHand.CurrentHand[0].CardName, playerTwoHand.CurrentHand[0].Suit);



        }
        private static void DisplayBounty()
        {
            GamePlay += "Bounty... <br /> ";
            foreach (var card in currentBounty)
            {
                GamePlay += String.Format("&nbsp &nbsp {0} of {1} <br />", card.CardName, card.Suit);
            }
        }

        private static void CompareCards(CardHand playerOne, CardHand playerTwo)
        {
            if (currentBounty[currentBounty.Count - 2].Value > currentBounty[currentBounty.Count - 1].Value)
                PlayerWonRound(playerOne, playerTwo);
            else if (currentBounty[currentBounty.Count - 1].Value > currentBounty[currentBounty.Count - 2].Value)
                PlayerWonRound(playerTwo, playerOne);
            else War(playerOne, playerTwo);
        }

        private static void PlayerWonRound(CardHand Winner, CardHand Loser)
        {
            Winner.CurrentHand.AddRange(currentBounty);
            DisplayHandWinner(Winner.FullName);
            currentBounty.Clear();
        }

        private static void DisplayHandWinner(string v)
        {
            GamePlay += "<strong>" + v + " Wins! </strong><br /> <br />";
        }




        private static void War(CardHand playerOne, CardHand playerTwo)
        {

            GamePlay += "<h3><strong> WAR!!! </strong> </h3><br/>";
            if (playerOne.CurrentHand.Count > 0 && playerTwo.CurrentHand.Count > 0)
            {

                AddWarCardsToBounty(playerOne);
                AddWarCardsToBounty(playerTwo);
                PlayCard(playerOne, playerTwo);
                CompareCards(playerOne, playerTwo);
            }
            else CheckForGameWinner(playerOne, playerTwo);

        }

        private static void AddWarCardsToBounty(CardHand playerHand)
        {

            for (int addToBounty = 0; addToBounty < 3; addToBounty++)
            {
                if (playerHand.CurrentHand.Count > 1)
                {
                    currentBounty.Add(playerHand.CurrentHand[0]);
                    playerHand.CurrentHand.RemoveAt(0);
                }
            }
        }



        private static void CheckForGameWinner(CardHand playerOne, CardHand playerTwo)
        {
            Winner = null;
            if (playerOne.CurrentHand.Count == 0) Winner = playerTwo.FullName;
            if (playerTwo.CurrentHand.Count == 0) Winner = playerOne.FullName;

        }

        //If playing a round count based game. Check at the end of the last round
        private static void CheckShortGameWinner(CardHand playerOneHand, CardHand playerTwoHand)
        {
            if (playerOneHand.CurrentHand.Count > playerTwoHand.CurrentHand.Count)
                GamePlay += String.Format("{0} won with {1} card to {2}'s {3} cards", playerOneHand.FullName, playerOneHand.CurrentHand.Count, playerTwoHand.FullName, playerTwoHand.CurrentHand.Count);
            else if (playerTwoHand.CurrentHand.Count > playerOneHand.CurrentHand.Count)
                GamePlay += String.Format("<strong>{0} won with {1} cards to {2}'s {3} cards</strong>", playerTwoHand.FullName, playerTwoHand.CurrentHand.Count, playerOneHand.FullName, playerOneHand.CurrentHand.Count);
            else
                GamePlay += "<strong>Nobody Won. It was a tie. :( </strong>";

        }
    }
}
