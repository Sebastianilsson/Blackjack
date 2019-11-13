using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IDealer
    {
        void GetNewDeck();
        void ShuffleDeck();
        void DealCard(IPlayer player);
    }
}
