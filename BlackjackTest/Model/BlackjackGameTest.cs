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
        [Fact]
        public void DealNewHand_ShouldMakeACallToDealerToGetANewDeck()
        {
            var mockDealer = new Mock<IDealer>();
            IBlackjackGame sut = new BlackjackGame(mockDealer.Object);
            sut.DealNewHand();
            mockDealer.Verify(dealer => dealer.GetNewDeck(), Times.Once());

        }
    }
}
