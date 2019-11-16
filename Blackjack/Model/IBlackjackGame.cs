using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IBlackjackGame
    {
        void DealNewHand();
        bool IsGameOver();
        IHands GetHands();
        void Hit();
        void DealerTakeCards();
        void SetPlayerHasStayedTrue();
    }
}
