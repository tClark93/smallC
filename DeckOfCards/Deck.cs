using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        string[] CardName = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
        string[] SuitName = {"Clubs","Spades","Diamonds","Hearts"};
        public Deck()
        {
            BuildDeck();
        }
        public void BuildDeck()
        {
            for(int i = 0; i < SuitName.Length; i++)
            {
                for(int j = 0; j < CardName.Length; j++)
                {
                    cards.Add(new Card(CardName[j], SuitName[i], j+1));
                }
            }
        }
        public Card Deal()
        {
            Card dealt = cards[0];
            cards.RemoveAt(0);
            return dealt;
        }
        public void ResetDeck()
        {
            cards.Clear();
            BuildDeck();
        }
        public void ShuffleDeck()
        {
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++)
            {
                int swap = rand.Next(0,cards.Count);
                Card temp = cards[i];
                cards[i] = cards[swap];
                cards[swap] = temp;
            }
        }
    }
}