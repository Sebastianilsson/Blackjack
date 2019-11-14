using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Dealer : IDealer
    {
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
        }

        public int GetCurrentScore()
        {
            throw new NotImplementedException();
        }

        public void AddCardToHand(ICard card)
        {
            throw new NotImplementedException();
        }
    }
}
