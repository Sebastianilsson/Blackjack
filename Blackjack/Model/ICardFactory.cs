using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface ICardFactory
    {
        ICard CreateNewCard(Color color, Value value);
    }
}
