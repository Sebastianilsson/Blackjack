using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class DealerTest
    {
        [Fact]
        public void GetNewDeck_ShouldCallToCreateANewDeck()
        {
            var mockDeck = new Mock<IDeck>();
            Dealer sut = new Dealer(mockDeck.Object);
            sut.GetNewDeck();
            mockDeck.Verify(deck => deck.CreateCardsForDeck(), Times.Once());
        }
    }
}
