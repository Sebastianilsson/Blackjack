using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Model;

namespace BlackjackTest.Model
{
    public class HandsFactoryTest
    {
        [Fact]
        public void CreateNewHands_ShouldReturnANewHandsObject()
        {
            HandsFactory sut = new HandsFactory();
            Assert.IsType<Hands>(sut.CreateNewHands(It.IsAny<List<ICard>>(), It.IsAny<int>(), It.IsAny<List<ICard>>(), It.IsAny<int>()));
        }
    }
}
