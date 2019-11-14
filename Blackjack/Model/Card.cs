﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Card
    {
        private Color Color { get;  set; }
        private Value Value { get; set; }
        public Card(Color color, Value value)
        {
            Color = color;
            Value = value;
        }

        public Color GetColor()
        {
            return Color;
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
