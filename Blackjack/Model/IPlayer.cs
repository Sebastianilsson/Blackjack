using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IPlayer
    {
        public IReadOnlyList<ICard> Hand { get; }
        public int GetCurrentScore();
        public void AddCardToHand(ICard card);
    }
}
