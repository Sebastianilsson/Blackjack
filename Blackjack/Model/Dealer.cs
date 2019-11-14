using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Dealer : IDealer
    {
        public IReadOnlyList<ICard> Hand { get { return _hand.AsReadOnly(); } }
        private List<ICard> _hand = new List<ICard>();
        private IDeck Deck { get; set; }

        public Dealer(IDeck deck)
        {
            Deck = deck;
        }

        public void GetNewDeck()
        {
            Deck.CreateCardsForDeck();
        }

        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        public void DealCard(IPlayer player)
        {
            ICard card = Deck.GetACard();
            player.AddCardToHand(card);
            
        }

        public void TakeCard()
        {
            ICard card = Deck.GetACard();
            AddCardToHand(card);

        }

        public int GetCurrentScore()
        {
            int[] cardValues = new int[(int)Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;
            foreach (ICard card in Hand)
            {
                score += cardValues[(int)card.GetValue()];
            }
            if (score > 21)
            {
                foreach (ICard c in Hand)
                {
                    if (c.GetValue() == Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }
            return score;
        }

        public void AddCardToHand(ICard card)
        {
            _hand.Add(card);
        }
    }
}
