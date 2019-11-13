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
        private Mock<IDealer> mockDealer;

        public BlackjackGameTest()
        {
            mockDealer = new Mock<IDealer>();
        }

        [Fact]
        public void DealNewHand_ShouldMakeACallToDealerToGetANewDeck()
        {
            IBlackjackGame sut = new BlackjackGame(mockDealer.Object);
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.GetNewDeck(), Times.Once());
        }

        [Fact]
        public void DealNewHand_ShouldCallToShuffleDeck()
        {
            IBlackjackGame sut = new BlackjackGame(mockDealer.Object);
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.ShuffleDeck(), Times.Once());
        }
    }
}
