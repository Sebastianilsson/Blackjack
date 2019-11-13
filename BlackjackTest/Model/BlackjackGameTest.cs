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
            sut = new BlackjackGame(mockDealer.Object);
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
    }
}
