using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Card
    {
        public Card(Color color, Value value)
        {

        }
    }

    public enum Color
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds,
        Count
    }

    public enum Value
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
        Count
    }
}
