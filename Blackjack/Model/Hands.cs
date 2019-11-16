using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Hands : IHands
    {
        public IReadOnlyList<ICard> PlayerCards { get { return _playerCards; } }
        public int PlayerScore { get; }
        public IReadOnlyList<ICard> DealerCards { get { return _dealerCards; } }
        private IReadOnlyList<ICard> _playerCards;
        private int _playerScore;
        private IReadOnlyList<ICard> _dealerCards;
        public Hands (IReadOnlyList<ICard> playerCards, int playerScore, IReadOnlyList<ICard> dealerCards)
        {
            _playerCards = playerCards;
            _playerScore = playerScore;
            _dealerCards = dealerCards;
        }
    }
}
