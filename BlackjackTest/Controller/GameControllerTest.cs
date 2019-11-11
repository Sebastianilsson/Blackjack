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
        private GameController sut;
        private Mock<IBlackjackGame> mockBlackjackGame;
        public GameControllerTest()
        {
            mockBlackjackGame = new Mock<IBlackjackGame>();
            sut = new GameController(mockBlackjackGame.Object);
        }
        [Fact]
        public void PlayGame_ShouldCallToDealANewHand()
        {
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.DealNewHand(), Times.Once());
        }
    }
}
