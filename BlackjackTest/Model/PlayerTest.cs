using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class PlayerTest
    {
        [Fact]
        public void AddCardToHand_ShouldAddACardToPlayersHand()
        {
            IPlayer sut = new Player();
            var mockCard = new Mock<ICard>();
            sut.AddCardToHand(mockCard.Object);
            Assert.NotEmpty(sut.Hand);
        }
    }
}
