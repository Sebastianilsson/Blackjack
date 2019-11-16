using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class HandsTest
    {
        private Hands sut;
        private List<ICard> playerHand = new List<ICard>();
        private List<ICard> dealerHand = new List<ICard>();
        public HandsTest()
        {
            sut = new Hands(playerHand, dealerHand);
        }

        private void AddMockCardsToPlayerHand(int numberOfMockCards)
        {
            for (int i = 0; i < numberOfMockCards; i++)
            {
                var mockPlayerCard = new Mock<ICard>();
                playerHand.Add(mockPlayerCard.Object);
            }
        }

        private void AddMockCardsToDealerHand(int numberOfMockCards)
        {
            for (int i = 0; i < numberOfMockCards; i++)
            {
                var mockDealerCard = new Mock<ICard>();
                dealerHand.Add(mockDealerCard.Object);
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void PlayerCards_ShouldReturnListWithThePlayersCards(int numberOfMockCards)
        {
            AddMockCardsToPlayerHand(numberOfMockCards);
            int expected = numberOfMockCards;
            int actual = sut.PlayerCards.Count;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void DealerCards_ShouldReturnListWithTheDealersCards(int numberOfMockCards)
        {
            AddMockCardsToDealerHand(numberOfMockCards);
            int expected = numberOfMockCards;
            int actual = sut.DealerCards.Count;
            Assert.Equal(expected, actual);
        }
    }
}
