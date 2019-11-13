﻿using System;
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
        public void DealNewHand_ShouldDealTwoCardsToPlayer()
        {
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.DealCard(mockPlayer.Object), Times.Exactly(2));
        }

        [Fact]
        public void DealNewHand_ShouldDealTwoCardsToDealer()
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

        [Fact]
        public void IsGameOver_ShouldReturnTrueIfPlayerScorIsTwentOne()
        {
            mockPlayer.Setup(player => player.GetCurrentScore())
                .Returns(21);
            bool expected = true;
            bool actual = sut.IsGameOver();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsGameOver_ShouldReturnTrueIfPlayerScorIsHigherThanTwentOne()
        {
            mockPlayer.Setup(player => player.GetCurrentScore())
                .Returns(22);
            bool expected = true;
            bool actual = sut.IsGameOver();
            Assert.Equal(expected, actual);
        }
    }
}
