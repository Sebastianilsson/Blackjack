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
            mockBlackjackGame.Setup(game => game.IsGameOver())
                .Returns(true);
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.DealNewHand(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallIsGameOverOnceIfReturnsTrue()
        {
            mockBlackjackGame.Setup(game => game.IsGameOver())
                .Returns(true);
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.IsGameOver(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallIsGameOverAgainIfFirstReturnWasntTrue()
        {
            mockBlackjackGame.SetupSequence(game => game.IsGameOver())
                .Returns(false)
                .Returns(true);
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.IsGameOver(), Times.Exactly(2));
        }
    }
}
