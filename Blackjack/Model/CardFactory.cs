using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateNewCard(Color color, Value value)
        {
            return new Card(color, value);
        }
    }
}
