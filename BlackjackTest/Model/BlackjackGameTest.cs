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

        private void GoIntoWhileLoopOnce()
        {
            mockDealer.SetupSequence(dealer => dealer.GetCurrentScore())
                .Returns(16)
                .Returns(20);
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
            GoIntoWhileLoopOnce();
            sut.DealerTakeCards();
            mockDealer.Verify(dealer => dealer.GetCurrentScore(), Times.AtLeastOnce());
        }

        [Fact]
        public void DealerTakeCards_ShouldNeverCallTakeCardIfCurrentScoreSeventeenOrHigher()
        {
            mockDealer.SetupSequence(dealer => dealer.GetCurrentScore())
                .Returns(18);
            sut.DealerTakeCards();
            mockDealer.Verify(dealer => dealer.TakeCard(), Times.Never());
        }

        [Fact]
        public void DealerTakeCards_ShouldCallToDealerTakeACardIfCurrentScoreLowerThanSeventeen()
        {
            GoIntoWhileLoopOnce();
            sut.DealerTakeCards();
            mockDealer.Verify(dealer => dealer.TakeCard(), Times.Once());
        }

        [Fact]
        public void DealerTakeCards_ShouldKeepCallingTakeCardIfCurrentScoreLowerThanSeventeen()
        {
            mockDealer.SetupSequence(dealer => dealer.GetCurrentScore())
                .Returns(8)
                .Returns(12)
                .Returns(17);
            sut.DealerTakeCards();
            mockDealer.Verify(dealer => dealer.TakeCard(), Times.Exactly(2));
        }

        [Fact]
        public void GetHands_ShouldCallToGetPlayerScoreOnce()
        {
            GetCurrentPlayerScore(12);
            sut.GetHands();
            mockPlayer.Verify(player => player.GetCurrentScore(), Times.Once());
        }

        [Fact]
        public void GetHands_ShouldCallToGetDealerScoreOnce()
        {
            sut.GetHands();
            mockDealer.Verify(dealer => dealer.GetCurrentScore(), Times.Once());
        }

        [Fact]
        public void GetHands_ShouldCallToGetPlayersHand()
        {
            sut.GetHands();
            mockPlayer.Verify(player => player.Hand, Times.Once());
        }

        [Fact]
        public void GetHands_ShouldCallToGetDealersHand()
        {
            sut.GetHands();
            mockDealer.Verify(dealer => dealer.Hand, Times.Once());
        }
    }
}
