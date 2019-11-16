using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public class Player : IPlayer
    {
        public IReadOnlyList<ICard> Hand { get { return _hand.AsReadOnly(); } }
        private List<ICard> _hand = new List<ICard>();

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
