using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class BlackjackGame : IBlackjackGame
    {
        private IDealer Dealer { get; set; }
        private IPlayer Player { get; set; }

        public BlackjackGame(IDealer dealer, IPlayer player)
        {
            Dealer = dealer;
            Player = player;
        }

        public void DealNewHand()
        {
            Dealer.GetNewDeck();
            Dealer.ShuffleDeck();
            Dealer.DealCard(Player);
            Dealer.TakeCard();
            Dealer.DealCard(Player);
            Dealer.TakeCard();
        }

        public bool IsGameOver()
        {
            Player.GetCurrentScore();
            return true;
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
