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
        public void GetNewDeck_ShouldCallToCreateANewDeckIfNoDeckExists()
        {
            var mockDeckAndCardFactory = new Mock<IDeckAndCardFactory>();
            Dealer sut = new Dealer(mockDeckAndCardFactory.Object);
            sut.GetNewDeck();
            mockDeckAndCardFactory.Verify(factory => factory.CreateNewDeck(), Times.Once());
        }
    }
}
