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
                    ICard card = CardFactory.CreateNewCard((Color)colorIndex, (Value)valueIndex);
                    Cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public ICard GetACard()
        {
            return new Card(Color.Clubs, Value.Ace);
        }

        public IReadOnlyList<ICard> GetCards()
        {
            return Cards.AsReadOnly();
        }
    }
}
