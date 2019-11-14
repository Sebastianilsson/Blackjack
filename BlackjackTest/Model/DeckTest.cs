using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;
using System.Linq;

namespace BlackjackTest.Model
{
    public class DeckTest
    {
        private Mock<ICardFactory> mockCardFactory;
        private Deck sut;
        public DeckTest()
        {
            mockCardFactory = new Mock<ICardFactory>();
            sut = new Deck(mockCardFactory.Object);
        }

        [Fact]
        public void CreateCardsForDeck_ShouldCallFiftyTwoTimesToCreateANewCard()
        {
            sut.CreateCardsForDeck();
            mockCardFactory.Verify(factory => factory.CreateNewCard(It.IsAny<Color>(), It.IsAny<Value>()), Times.Exactly(52));
        }

        [Fact]
        public void GetCards_ShouldReturnAReadOnlyListWithCards()
        {
            sut.CreateCardsForDeck();
            Assert.IsNotType<IReadOnlyList<ICard>>(sut.GetCards());
        }

        [Fact]
        public void CreateCardsForDeck_ShouldCreateFiftyTwoCards()
        {
            int expected = 52;
            sut.CreateCardsForDeck();
            var cards = sut.GetCards();
            int actual = cards.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateCardsForDeck_ShouldCreateFiftyTwoDifferentCards()
        {
            int expected = 52;
            sut.CreateCardsForDeck();
            var cards = sut.GetCards();
            IEnumerable<ICard> uniqueCards = cards.Distinct();
            int actual = uniqueCards.Count();
            Assert.Equal(expected, actual);
        }
    }
}
