using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.ShuffleDeck();
            foreach(Card card in deck.cards)
            {
                Console.WriteLine(card.StringVal + " of " + card.Suit);
            }
            Player Troy = new Player("Troy");
            Troy.Draw(deck);
            Troy.Draw(deck);
            Troy.Draw(deck);
            Troy.Draw(deck);
            Troy.Draw(deck);
            foreach(Card card in Troy.Hand)
            {
                Console.WriteLine("--" + card.StringVal + " of " + card.Suit);
            }
            Troy.Discard(4);
            Troy.Discard(-1);
        }
    }
}
