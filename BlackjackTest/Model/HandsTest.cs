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
        public HandsTest()
        {
            List<ICard> playerHand = new List<ICard>();
            var mockPlayerCard = new Mock<ICard>();
            playerHand.Add(mockPlayerCard.Object);
            List<ICard> dealerHand = new List<ICard>();
            var mockDealerCard = new Mock<ICard>();
            dealerHand.Add(mockDealerCard.Object);
            sut = new Hands(playerHand, dealerHand);
        }
        [Fact]
        public void PlayerCards_ShouldReturnListWithThePlayersCards()
        {
            int expected = 1;
            int actual = sut.PlayerCards.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DealerCards_ShouldReturnListWithTheDealersCards()
        {
            int expected = 1;
            int actual = sut.DealerCards.Count;
            Assert.Equal(expected, actual);
        }
    }
}
