﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class CardFactory
    {
        public Card CreateNewCard(Color color, Value value)
        {
            return new Card(color, value);
        }
    }
}