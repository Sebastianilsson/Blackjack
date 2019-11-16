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
        [Fact]
        public void PlayerCards_ShouldReturnListWithThePlayersCards()
        {
            List<ICard> playerHand = new List<ICard>();
            var mockCard = new Mock<ICard>();
            playerHand.Add(mockCard.Object);
            Hands sut = new Hands(playerHand);
            int expected = 1;
            int actual = sut.PlayerCards.Count;
            Assert.Equal(expected, actual);
        }
    }
}
