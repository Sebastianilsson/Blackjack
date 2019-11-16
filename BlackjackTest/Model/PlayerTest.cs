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

        [Theory]
        [InlineData(19, Value.Ace, Value.Nine, Value.Nine)]
        [InlineData(12, Value.Ace, Value.Ace)]
        [InlineData(13, Value.Ace, Value.Ace, Value.Ace)]
        [InlineData(14, Value.Ace, Value.Ace, Value.Ace, Value.Ace)]
        public void GetCurrentScore_ShouldReturnScoreMinusTenIfOverTwentyOneAndOneOrMoreAceOnHand(int expected, params Value[] cardValues)
        {
            foreach (Value cardValue in cardValues)
            {
                AddMockCardToHand(cardValue);
            }
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCurrentScore_ShouldReturnScoreMinusTenIfOverTwentyOneAndTwoAcesOnHand()
        {
            AddMockCardToHand(Value.Ace);
            AddMockCardToHand(Value.Ace);
            int expected = 12;
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }
    }
}
