using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class BlackjackGame : IBlackjackGame
    {
        private IDealer Dealer { get; set; }
        private IPlayer Player { get; set; }

        internal int blackjackScore = 21;
        internal bool gameIsOver = true;
        internal bool gameIsNotOver = false;

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
            if (Player.GetCurrentScore() >= blackjackScore)
            {
                return gameIsOver;
            }
            
            return gameIsNotOver;
        }

        public IHands GetHands()
        {
            IReadOnlyList<ICard> playerHand = Player.Hand;
            int playerScore = Player.GetCurrentScore();
            int dealerScore = Dealer.GetCurrentScore();

            return new Hands(playerHand, playerScore, new List<ICard>(), dealerScore);
        }

        public void Hit()
        {
            Dealer.DealCard(Player);
        }

        public void DealerTakeCards()
        {
            while (Dealer.GetCurrentScore() < 17)
            {
                Dealer.TakeCard();
            }
        }
    }
}
