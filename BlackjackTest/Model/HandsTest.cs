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
            var mockCard = new Mock<ICard>();
            playerHand.Add(mockCard.Object);
            sut = new Hands(playerHand);
        }
        [Fact]
        public void PlayerCards_ShouldReturnListWithThePlayersCards()
        {
            int expected = 1;
            int actual = sut.PlayerCards.Count;
            Assert.Equal(expected, actual);
        }
    }
}
