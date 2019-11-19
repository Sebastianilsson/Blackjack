using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class BlackjackGame : IBlackjackGame
    {
        private IDealer Dealer { get; set; }
        private IPlayer Player { get; set; }
        private IHandsFactory Factory {get; set;}

        internal int blackjackScore = 21;
        internal bool gameIsOver = true;
        internal bool gameIsNotOver = false;
        internal bool playerHasStayed = false;

        public BlackjackGame(IDealer dealer, IPlayer player, IHandsFactory factory)
        {
            Dealer = dealer;
            Player = player;
            Factory = factory;
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
            if (Player.GetCurrentScore() >= blackjackScore || playerHasStayed)
            {
                return gameIsOver;
            }
            
            return gameIsNotOver;
        }

        public IHands GetHands()
        {
            IReadOnlyList<ICard> playerHand = Player.Hand;
            IReadOnlyList<ICard> dealerHand = Dealer.Hand;
            int playerScore = Player.GetCurrentScore();
            int dealerScore = Dealer.GetCurrentScore();

            return Factory.CreateNewHands(playerHand, playerScore, dealerHand, dealerScore);
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

        public void SetPlayerHasStayedTrue()
        {
            playerHasStayed = true;
        }
    }
}
