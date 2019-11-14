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
        private Dealer sut;
        private Mock<IDeck> mockDeck;

        public DealerTest()
        {
            mockDeck = new Mock<IDeck>();
            sut = new Dealer(mockDeck.Object);
        }

        [Fact]
        public void GetNewDeck_ShouldCallToCreateANewDeck()
        {
            sut.GetNewDeck();
            mockDeck.Verify(deck => deck.CreateCardsForDeck(), Times.Once());
        }

        [Fact]
        public void GetNewDeck_ShouldCallToShuffleDeck()
        {
            sut.ShuffleDeck();
            mockDeck.Verify(deck => deck.Shuffle(), Times.Once());
        }
    }
}
