using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Hands : IHands
    {
        public IReadOnlyList<ICard> PlayerCards { get { return _playerCards; } }
        public IReadOnlyList<ICard> DealerCards { get; }
        private IReadOnlyList<ICard> _playerCards;
        private IReadOnlyList<ICard> _dealerCards;
        public Hands (IReadOnlyList<ICard> playerCards, IReadOnlyList<ICard> dealerCards)
        {
            _playerCards = playerCards;
            _dealerCards = dealerCards;
        }
    }
}
