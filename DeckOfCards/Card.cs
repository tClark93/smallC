namespace DeckOfCards
{
    public class Card
    {
        public string StringVal;
        public string Suit;
        public int Value;
        public Card(string sVal, string suit, int val)
        {
            StringVal = sVal;
            Suit = suit;
            Value = val;
        }
    }
}