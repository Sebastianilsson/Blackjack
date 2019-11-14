using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Deck : IDeck
    {
        private List<ICard> Cards;
        private ICardFactory CardFactory { get; set; }

        public Deck(ICardFactory cardFactory)
        {
            CardFactory = cardFactory;
        }

        public void CreateCardsForDeck()
        {
            Cards = new List<ICard>();
            for (int colorIndex = 0; colorIndex < (int)Color.Count; colorIndex++)
            {
                for (int valueIndex = 0; valueIndex < (int)Value.Count; valueIndex++)
                {
                    CardFactory.CreateNewCard((Color)colorIndex, (Value)valueIndex);
                }
            }
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public Card GetACard()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ICard> GetCards()
        {
            return Cards.AsReadOnly();
        }
    }
}
