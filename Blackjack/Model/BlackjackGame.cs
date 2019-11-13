using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class BlackjackGame : IBlackjackGame
    {
        private IDealer Dealer { get; set; }

        public BlackjackGame(IDealer dealer)
        {
            Dealer = dealer;
        }

        public void DealNewHand()
        {
            Dealer.GetNewDeck();
            Dealer.ShuffleDeck();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public void DealerTakeCards()
        {
            throw new NotImplementedException();
        }
    }
}
