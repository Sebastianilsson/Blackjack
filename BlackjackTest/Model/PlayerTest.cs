using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class PlayerTest
    {
        [Fact]
        public void AddCardToHand_ShouldAddACardToPlayersHand()
        {
            IPlayer sut = new Player();
            var mockCard = new Mock<ICard>();
            sut.AddCardToHand(mockCard.Object);
            Assert.NotEmpty(sut.Hand);
        }

        [Fact]
        public void GetCurrentScore_ShouldReturnTheScoreOfACardIfOnlyOneCardOnHand()
        {
            IPlayer sut = new Player();
            var mockCard = new Mock<ICard>();
            mockCard.Setup(card => card.GetValue()).Returns(Value.Ace);
            sut.AddCardToHand(mockCard.Object);
            int expected = 11;
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }
    }
}
