﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Deck : IDeck
    {
        private ICardFactory CardFactory { get; set; }

        public Deck(ICardFactory cardFactory)
        {
            CardFactory = cardFactory;
        }

        public void CreateCardsForDeck()
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public Card GetACard()
        {
            throw new NotImplementedException();
        }
    }
}
