using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Player : IPlayer
    {
        public IReadOnlyList<ICard> Hand { get { return _hand; } }
        private List<ICard> _hand = new List<ICard>();

        public int GetCurrentScore()
        {
            throw new NotImplementedException();
        }

        public void AddCardToHand(ICard card)
        {
            _hand.Add(card);
        }
    }
}
