using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Hands : IHands
    {
        public IReadOnlyList<ICard> PlayerCards { get; }
        private IReadOnlyList<ICard> _playerCards;
        public Hands (IReadOnlyList<ICard> playerCards)
        {
            _playerCards = playerCards;
        }
    }
}
