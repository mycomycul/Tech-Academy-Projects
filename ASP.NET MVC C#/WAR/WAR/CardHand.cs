using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAR
{
    public class CardHand
    {
        public List<Card> CurrentHand = new List<Card>();
        public string FullName { get; set; }




        public CardHand(string Name)
        {
            FullName = Name;
        }

    }
}