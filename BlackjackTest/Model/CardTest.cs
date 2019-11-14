using Blackjack.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlackjackTest.Model
{
    public class CardTest
    {
        private Card sut;

        public CardTest()
        {
            sut = new Card(Color.Clubs, Value.Ace);
        }

        [Fact]
        public void GetColor_ShouldReturnTehColorOfTheCard()
        {
            Color expected = Color.Clubs;
            Color actual = sut.GetColor();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GetValue_ShouldReturnTehValueOfTheCard()
        {
            Value expected = Value.Ace;
            Value actual = sut.GetValue();
            Assert.Equal(expected, actual);

        }
    }
}
