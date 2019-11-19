using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IHandsFactory
    {
        IHands CreateNewHands(IReadOnlyList<ICard> playerCards, int playerScore, IReadOnlyList<ICard> dealerCards, int dealerScore);
    }
}
