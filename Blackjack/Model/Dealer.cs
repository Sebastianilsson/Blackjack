using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Dealer : IDealer, IPlayer
    {
        public void GetNewDeck()
        {
            throw new NotImplementedException();
        }

        public void ShuffleDeck()
        {
            throw new NotImplementedException();
        }

        public void DealCard(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void TakeCard()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentScore()
        {
            throw new NotImplementedException();
        }
    }
}
