using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAR
{
    public class CardDeck
    {
        private List<string> cardNames = new List<string> {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        private List<string> cardSuits = new List<string> { "Spades", "Hearts", "Diamonds", "Clubs" };
        public List<Card> Deck = new List<Card>();
        Random random = new Random();

        public CardDeck()
        {
            for (int suit = 0; suit < cardSuits.Count; suit++)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Deck.Add(new Card() { Value = i+1, CardName = cardNames[i - 1], Suit = cardSuits[suit]});
                }
            }
        }
       
    }


}