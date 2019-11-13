using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class CardFactoryTest
    {
        [Fact]
        public void CreateNewCard_ShouldReturnAnObjectOfTypeCard()
        {
            CardFactory sut = new CardFactory();
            Assert.IsType<Card>(sut.CreateNewCard(It.IsAny<Color>(), It.IsAny<Value>()));
        }
    }
}
