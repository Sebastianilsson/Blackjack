using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IDeck
    {
        void CreateCardsForDeck();
        void Shuffle();
        ICard GetACard();
        IReadOnlyList<ICard> GetCards();
    }
}
