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
        private IPlayer sut;

        public PlayerTest()
        {
            sut = new Player();
        }

        private void AddMockCardToHand(Value value)
        {
            var mockCard1 = new Mock<ICard>();
            mockCard1.Setup(card => card.GetValue()).Returns(value);
            sut.AddCardToHand(mockCard1.Object);
        }

        [Fact]
        public void AddCardToHand_ShouldAddACardToPlayersHand()
        {
            AddMockCardToHand(Value.Ace);
            Assert.NotEmpty(sut.Hand);
        }

        [Fact]
        public void GetCurrentScore_ShouldReturnTheScoreOfACardIfOnlyOneCardOnHand()
        {
            AddMockCardToHand(Value.Ace);
            int expected = 11;
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCurrentScore_ShouldReturnTheCombindeScoreIfTwoCardsOnHand()
        {
            AddMockCardToHand(Value.Ace);
            AddMockCardToHand(Value.Two);
            int expected = 13;
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }
    }
}
