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
        private Mock<IGameView> mockGameView;
        public GameControllerTest()
        {
            mockBlackjackGame = new Mock<IBlackjackGame>();
            mockGameView = new Mock<IGameView>();
            sut = new GameController(mockBlackjackGame.Object, mockGameView.Object);
            mockBlackjackGame.Setup(game => game.IsGameOver())
                .Returns(true);
        }

        private void GoIntoWhileLoopOnce()
        {
            mockBlackjackGame.SetupSequence(game => game.IsGameOver())
                .Returns(false)
                .Returns(true);
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
        public void PlayGame_ShouldCallIsGameOverAgainIfFirstReturnWasntTrue()
        {
            GoIntoWhileLoopOnce();
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.IsGameOver(), Times.Exactly(2));
        }

        [Fact]
        public void PlayGame_ShouldCallToRenderPlayersHands()
        {
            GoIntoWhileLoopOnce();
            sut.PlayGame();
            mockGameView.Verify(view => view.RenderPlayersHands(), Times.Once());
        }
    }
}
