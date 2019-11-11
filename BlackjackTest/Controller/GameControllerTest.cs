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
            mockBlackjackGame.Setup(game => game.IsGameOver())
                .Returns(true);
        }
        private void ReturnFalseXTimes(int nrOfFalseToReturn)
        {
            int counter = 0;
            bool isGameOver = false;
            mockBlackjackGame.Setup(game => game.IsGameOver())
                .Callback(() =>
                {
                    if (counter == nrOfFalseToReturn)
                    {
                        isGameOver = true;
                    }
                })
                .Returns(isGameOver);

        }
        [Fact]
        public void PlayGame_ShouldCallToDealANewHand()
        {
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.DealNewHand(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallIsGameOverOnceIfReturnsTrue()
        {
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.IsGameOver(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallIsGameOverUntilReturnsTrue()
        {
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.IsGameOver(), Times.Exactly(2));
        }
    }
}
