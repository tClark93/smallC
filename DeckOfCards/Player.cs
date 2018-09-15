using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        public string Name;
        public List<Card> Hand = new List<Card>();
        public Player (string name)
        {
            Name = name;
        }
        public Card Draw(Deck deck)
        {
            Card dealtCard = deck.Deal();
            Hand.Add(dealtCard);
            Console.WriteLine("Drew " + dealtCard.StringVal + " of " + dealtCard.Suit);
            return dealtCard;
        }

        public Card Discard(int index)
        {
            if(index > Hand.Count)
            {
                Console.WriteLine("You don't have that many cards");
                return null;
            }
            if(index < 0)
            {
                Console.WriteLine("Daddy don't play that way");
                return null;
            }
            Card discarded = Hand[index];
            Hand.RemoveAt(index);
            Console.WriteLine("Discarded " + discarded.StringVal + " of " + discarded.Suit);
            return discarded;
        }
    }
}