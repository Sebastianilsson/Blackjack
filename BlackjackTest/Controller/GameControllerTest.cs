using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.Controller;
using Blackjack.Model;
using Blackjack.View;

namespace BlackjackTest.Controller
{
    public class GameControllerTest
    {
        [Fact]
        public void PlayGame_ShouldCallToDealANewHand()
        {
            var mockBlackjackGame = new Mock<IBlackjackGame>();
            GameController sut = new GameController(mockBlackjackGame.Object);
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.DealNewHand(), Times.Once());
        }
    }
}
