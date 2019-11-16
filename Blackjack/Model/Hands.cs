using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Hands : IHands
    {
        public IReadOnlyList<ICard> PlayerCards { get { return _playerCards; } }
        public int PlayerScore { get { return _playerScore; } }
        public IReadOnlyList<ICard> DealerCards { get { return _dealerCards; } }
        public int DealerScore { get; }
        private IReadOnlyList<ICard> _playerCards;
        private int _playerScore;
        private IReadOnlyList<ICard> _dealerCards;
        private int _dealerScore;
        public Hands (IReadOnlyList<ICard> playerCards, int playerScore, IReadOnlyList<ICard> dealerCards, int dealerScore)
        {
            _playerCards = playerCards;
            _playerScore = playerScore;
            _dealerCards = dealerCards;
            _dealerScore = dealerScore;
        }
    }
}
