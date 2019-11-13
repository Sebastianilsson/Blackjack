using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IDealer : IPlayer
    {
        void GetNewDeck();
        void ShuffleDeck();
        void DealCard(IPlayer player);
        void TakeCard();
    }
}
