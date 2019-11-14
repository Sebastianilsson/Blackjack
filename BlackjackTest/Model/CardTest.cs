using Blackjack.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlackjackTest.Model
{
    public class CardTest
    {
        [Theory]
        [InlineData(Color.Clubs, Value.Ace)]
        public void GetColor_ShouldReturnTehColorOfTheCard(Color color, Value value)
        {
            Card sut = new Card(color, value);
            Color expected = color;
            Color actual = sut.GetColor();
            Assert.Equal(expected, actual);

        }
    }
}
