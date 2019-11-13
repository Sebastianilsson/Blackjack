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
        private Mock<IDeckAndCardFactory> mockDeckAndCardFactory;
        public DealerTest()
        {
            mockDeckAndCardFactory = new Mock<IDeckAndCardFactory>();
        }
        [Fact]
        public void GetNewDeck_ShouldCallToCreateANewDeckIfNoDeckExists()
        {
            Dealer sut = new Dealer(mockDeckAndCardFactory.Object);
            sut.GetNewDeck();
            mockDeckAndCardFactory.Verify(factory => factory.CreateNewDeck(), Times.Once());
        }
    }
}
