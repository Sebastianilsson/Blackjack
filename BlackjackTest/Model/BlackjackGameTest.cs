using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class BlackjackGameTest
    {
        private IBlackjackGame sut;
        private Mock<IDealer> mockDealer;
        private Mock<IPlayer> mockPlayer;

        public BlackjackGameTest()
        {
            mockDealer = new Mock<IDealer>();
            mockPlayer = new Mock<IPlayer>();
            sut = new BlackjackGame(mockDealer.Object, mockPlayer.Object);
        }

        private void GetCurrentPlayerScore(int scoreToReturn)
        {
            mockPlayer.Setup(player => player.GetCurrentScore())
            .Returns(scoreToReturn);
        }

        [Fact]
        public void DealNewHand_ShouldMakeACallToDealerToGetANewDeck()
        {
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.GetNewDeck(), Times.Once());
        }

        [Fact]
        public void DealNewHand_ShouldCallToShuffleDeck()
        {
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.ShuffleDeck(), Times.Once());
        }

        [Fact]
        public void DealNewHand_ShouldCallDealTwoCardsToPlayer()
        {
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.DealCard(mockPlayer.Object), Times.Exactly(2));
        }

        [Fact]
        public void DealNewHand_ShouldCallDealTwoCardsToDealer()
        {
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.TakeCard(), Times.Exactly(2));
        }

        [Fact]
        public void IsGameOver_ShouldCallToCheckScoreOfPlayer()
        {
            sut.IsGameOver();
            mockPlayer.Verify(player => player.GetCurrentScore());
        }

        [Theory]
        [InlineData(21)]
        [InlineData(22)]
        public void IsGameOver_ShouldReturnTrueIfPlayerScorIsEqualOrHigherThanTwentOne(int playerScore)
        {
            GetCurrentPlayerScore(playerScore);
            bool expected = true;
            bool actual = sut.IsGameOver();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsGameOver_ShouldReturnFalseIfPlayerScoreLowerThanTwentyOne()
        {
            int playerScore = 15;
            GetCurrentPlayerScore(playerScore);
            bool expected = false;
            bool actual = sut.IsGameOver();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Hit_ShouldCallToDealACardToPlayer()
        {
            sut.Hit();
            mockDealer.Verify(dealer => dealer.DealCard(mockPlayer.Object), Times.Once());
        }

        [Fact]
        public void DealerTakeCards_ShouldCallToGetDealerCurrentScoreOnce()
        {
            sut.DealerTakeCards();
            mockDealer.Verify(dealer => dealer.GetCurrentScore(), Times.Once());
        }
    }
}
