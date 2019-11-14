﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Dealer : IDealer
    {
        public IReadOnlyList<ICard> Hand { get { return _hand.AsReadOnly(); } }
        private List<ICard> _hand = new List<ICard>();
        private IDeck Deck { get; set; }

        public Dealer(IDeck deck)
        {
            Deck = deck;
        }

        public void GetNewDeck()
        {
            Deck.CreateCardsForDeck();
        }

        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        public void DealCard(IPlayer player)
        {
            ICard card = Deck.GetACard();
            player.AddCardToHand(card);
            
        }

        public void TakeCard()
        {
            ICard card = Deck.GetACard();
            _hand.Add(card);

        }

        public int GetCurrentScore()
        {
            int score = 0;
            return score;
        }

        public void AddCardToHand(ICard card)
        {
            _hand.Add(card);
        }
    }
}
