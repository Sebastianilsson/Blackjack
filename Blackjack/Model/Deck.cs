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
            for (int i = 0; i < 52; i++)
            {
                ICard card = CardFactory.CreateNewCard(Color.Clubs, Value.Ace);
                Cards.Add(card);
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
