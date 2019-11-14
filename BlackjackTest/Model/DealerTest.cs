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

        private void GetCardFromDeck()
        {
            mockDeck.Setup(x => x.GetACard())
                .Returns(It.IsAny<Card>());
        }

        [Fact]
        public void GetNewDeck_ShouldCallToCreateANewDeck()
        {
            sut.GetNewDeck();
            mockDeck.Verify(deck => deck.CreateCardsForDeck(), Times.Once());
        }

        [Fact]
        public void ShuffleDeck_ShouldCallToShuffleDeck()
        {
            sut.ShuffleDeck();
            mockDeck.Verify(deck => deck.Shuffle(), Times.Once());
        }

        [Fact]
        public void DealCard_ShouldCallToGetACardFromDeck()
        {
            var mockPlayer = new Mock<IPlayer>();
            sut.DealCard(mockPlayer.Object);
            mockDeck.Verify(deck => deck.GetACard(), Times.Once());
        }

        [Fact]
        public void DealCard_ShouldCallToAddCardToPlayersHand()
        {
            GetCardFromDeck();
            var mockPlayer = new Mock<IPlayer>();
            sut.DealCard(mockPlayer.Object);
            mockPlayer.Verify(player => player.AddCardToHand(It.IsAny<Card>()), Times.Once());
        }

        [Fact]
        public void TakeCard_ShouldCallToGetACardFromDeck()
        {
            sut.TakeCard();
            mockDeck.Verify(deck => deck.GetACard(), Times.Once());
        }

        [Fact]
        public void TakeCard_ShouldAddCardToDealersHand()
        {
            GetCardFromDeck();
            sut.TakeCard();
            Assert.NotEmpty(sut.Hand);
        }

        [Fact]
        public void GetCurrentScore_ShouldReturnZeroIfNoCardsOnHand()
        {
            int expected = 0;
            int actual = sut.GetCurrentScore();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddCardToHand_ShouldAddCardToDealersHand()
        {
            GetCardFromDeck();
            sut.AddCardToHand(It.IsAny<ICard>());
            Assert.NotEmpty(sut.Hand);
        }
    }
}
