using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class HandsFactory
    {
        public IHands CreateNewHands(IReadOnlyList<ICard> playerCards, int playerScore, IReadOnlyList<ICard> dealerCards, int dealerScore)
        {

            return new Hands(playerCards, playerScore, dealerCards, dealerScore);
        }
    }
}
