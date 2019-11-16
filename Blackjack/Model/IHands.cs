using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IHands
    {
        IReadOnlyList<ICard> PlayerCards { get; }
        int PlayerScore { get; }
        IReadOnlyList<ICard> DealerCards { get; }
        int DealerScore { get; }
    }
}
