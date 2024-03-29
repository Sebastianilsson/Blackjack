﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackjack.Model
{
    public class Deck : IDeck
    {
        private List<ICard> Cards;
        private Random Random { get; set; }
        private ICardFactory CardFactory { get; set; }

        public Deck(ICardFactory cardFactory, Random random)
        {
            Random = random;
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
            int cardIndex = Cards.Count();
            while (cardIndex > 1)
            {
                cardIndex--;
                int changeIndex = Random.Next(cardIndex + 1);
                ICard card = Cards[changeIndex];
                Cards[changeIndex] = Cards[cardIndex];
                Cards[cardIndex] = card;
            }
        }

        public ICard GetACard()
        {
            ICard card = Cards.First();
            Cards.RemoveAt(0);
            return card;
        }

        public IReadOnlyList<ICard> GetCards()
        {
            return Cards.AsReadOnly();
        }
    }
}
