using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class DeckTest
    {
        [Fact]
        public void CreateCardsForDeck_ShouldCallFiftyTwoTimesToCreateANewCard()
        {
            var mockCardFactory = new Mock<ICardFactory>();
            IDeck sut = new Deck(mockCardFactory.Object);
            sut.CreateCardsForDeck();
            mockCardFactory.Verify(factory => factory.CreateNewCard(It.IsAny<Color>(), It.IsAny<Value>()), Times.Exactly(52));
        }
    }
}
