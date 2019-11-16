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

        [Theory]
        [InlineData(11, Value.Ace)]
        [InlineData(13, Value.Ace, Value.Two)]
        [InlineData(20, Value.Ace, Value.Five, Value.Two, Value.Two)]
        [InlineData(0)]
        public void GetCurrentScore_ShouldReturnTheCombinedScoreOfAllCardsOnHand(int expected, params Value[] cardValues)
        {
            foreach (Value cardValue in cardValues)
            {
                AddMockCardToHand(cardValue);
            }
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCurrentScore_ShouldReturnScoreMinusTenIfOverTwentyOneAndAAceOnHand()
        {
            AddMockCardToHand(Value.Nine);
            AddMockCardToHand(Value.Nine);
            AddMockCardToHand(Value.Ace);
            int expected = 19;
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }
    }
}
