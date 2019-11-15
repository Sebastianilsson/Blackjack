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

        private void CreateDeckWithMockedCards()
        {
            SetupToGetMockedCards();
            sut.CreateCardsForDeck();
        }

        private void SetupToGetMockedCards()
        {
            mockCardFactory.SetupSequence(x => x.CreateNewCard(It.IsAny<Color>(), It.IsAny<Value>()))
                .Returns(new Card(Color.Hearts, Value.Two))
                .Returns(new Card(Color.Hearts, Value.Three))
                .Returns(new Card(Color.Hearts, Value.Four))
                .Returns(new Card(Color.Hearts, Value.Five))
                .Returns(new Card(Color.Hearts, Value.Six))
                .Returns(new Card(Color.Hearts, Value.Seven))
                .Returns(new Card(Color.Hearts, Value.Eight))
                .Returns(new Card(Color.Hearts, Value.Nine))
                .Returns(new Card(Color.Hearts, Value.Ten))
                .Returns(new Card(Color.Hearts, Value.Jack))
                .Returns(new Card(Color.Hearts, Value.Queen))
                .Returns(new Card(Color.Hearts, Value.King))
                .Returns(new Card(Color.Hearts, Value.Ace))
                .Returns(new Card(Color.Clubs, Value.Two))
                .Returns(new Card(Color.Clubs, Value.Three))
                .Returns(new Card(Color.Clubs, Value.Four))
                .Returns(new Card(Color.Clubs, Value.Five))
                .Returns(new Card(Color.Clubs, Value.Six))
                .Returns(new Card(Color.Clubs, Value.Seven))
                .Returns(new Card(Color.Clubs, Value.Eight))
                .Returns(new Card(Color.Clubs, Value.Nine))
                .Returns(new Card(Color.Clubs, Value.Ten))
                .Returns(new Card(Color.Clubs, Value.Jack))
                .Returns(new Card(Color.Clubs, Value.Queen))
                .Returns(new Card(Color.Clubs, Value.King))
                .Returns(new Card(Color.Clubs, Value.Ace))
                .Returns(new Card(Color.Spades, Value.Two))
                .Returns(new Card(Color.Spades, Value.Three))
                .Returns(new Card(Color.Spades, Value.Four))
                .Returns(new Card(Color.Spades, Value.Five))
                .Returns(new Card(Color.Spades, Value.Six))
                .Returns(new Card(Color.Spades, Value.Seven))
                .Returns(new Card(Color.Spades, Value.Eight))
                .Returns(new Card(Color.Spades, Value.Nine))
                .Returns(new Card(Color.Spades, Value.Ten))
                .Returns(new Card(Color.Spades, Value.Jack))
                .Returns(new Card(Color.Spades, Value.Queen))
                .Returns(new Card(Color.Spades, Value.King))
                .Returns(new Card(Color.Spades, Value.Ace))
                .Returns(new Card(Color.Diamonds, Value.Two))
                .Returns(new Card(Color.Diamonds, Value.Three))
                .Returns(new Card(Color.Diamonds, Value.Four))
                .Returns(new Card(Color.Diamonds, Value.Five))
                .Returns(new Card(Color.Diamonds, Value.Six))
                .Returns(new Card(Color.Diamonds, Value.Seven))
                .Returns(new Card(Color.Diamonds, Value.Eight))
                .Returns(new Card(Color.Diamonds, Value.Nine))
                .Returns(new Card(Color.Diamonds, Value.Ten))
                .Returns(new Card(Color.Diamonds, Value.Jack))
                .Returns(new Card(Color.Diamonds, Value.Queen))
                .Returns(new Card(Color.Diamonds, Value.King))
                .Returns(new Card(Color.Diamonds, Value.Ace));
        }

        [Fact]
        public void CreateCardsForDeck_ShouldCallFiftyTwoTimesToCreateANewCard()
        {
            sut.CreateCardsForDeck();
            mockCardFactory.Verify(factory => factory.CreateNewCard(It.IsAny<Color>(), It.IsAny<Value>()), Times.Exactly(52));
        }

        [Fact]
        public void CreateCardsForDeck_ShouldCreateFiftyTwoCards()
        {
            mockCardFactory.Setup(x => x.CreateNewCard(It.IsAny<Color>(), It.IsAny<Value>()))
                .Returns(It.IsAny<Card>());
            int expected = 52;
            sut.CreateCardsForDeck();
            var cards = sut.GetCards();
            int actual = cards.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateCardsForDeck_ShouldCreateFiftyTwoDifferentCards()
        {
            CreateDeckWithMockedCards();
            int expected = 52;
            var cards = sut.GetCards();
            var uniqueCards = cards.Distinct();
            int actual = uniqueCards.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetACard_ShouldReturnACardObjectFromTheDeck()
        {
            CreateDeckWithMockedCards();
            Assert.IsType<Card>(sut.GetACard());
        }

        [Fact]
        public void GetACard_ShouldRemoveACardFromTheDeck()
        {
            CreateDeckWithMockedCards();
            int expected = 51;
            sut.GetACard();
            int actual = sut.GetCards().Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetACard_ShouldRemoveTheCardTakenFromTheDeck()
        {
            CreateDeckWithMockedCards();
            ICard card = sut.GetACard();
            bool exists = sut.GetCards().Any(x => x.GetColor() == card.GetColor() && 
                x.GetValue() == card.GetValue());
            Assert.False(exists);
        }

        [Fact]
        public void Shuffle_ShouldTakeACardAndPutItSomeWhereElseInTheDeck()
        {
            CreateDeckWithMockedCards();
            Deck compareDeck = new Deck(mockCardFactory.Object);
            SetupToGetMockedCards();
            compareDeck.CreateCardsForDeck();
            sut.Shuffle();
            bool sameOrder = Enumerable.SequenceEqual(sut.GetCards(), compareDeck.GetCards(), new DeckComparer());
             //sut.GetCards().SequenceEqual(compareDeck.GetCards());
            Assert.False(sameOrder);
        }

        class DeckComparer : IEqualityComparer<ICard>
        {
            public bool Equals(ICard sutCard, ICard compareCard)
            {
                return sutCard.GetColor() == compareCard.GetColor() &&
                     sutCard.GetValue() == compareCard.GetValue();
            }

            public int GetHashCode(ICard card)
            {
                return card.GetHashCode();
            }
        }

    }

    
}
