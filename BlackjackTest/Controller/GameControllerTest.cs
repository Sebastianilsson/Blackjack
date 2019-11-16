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

        private void GetGameActionStay()
        {
            mockGameView.Setup(view => view.GetGameAction())
                .Returns(GameAction.Stay);
        }

        [Fact]
        public void PlayGame_ShouldCallToDealANewHand()
        {
            sut.PlayGame();
            mockBlackjackGame.Verify(controller => controller.DealNewHand(), Times.Once());
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
        public void PlayGame_ShouldCallToGetPlayersHands()
        {
            GoIntoWhileLoopOnce();
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.GetHands(), Times.Exactly(2));
        }

        [Fact]
        public void PlayGame_ShouldCallToRenderPlayersHands()
        {
            GoIntoWhileLoopOnce();
            sut.PlayGame();
            mockGameView.Verify(view => view.RenderPlayersHands(It.IsAny<IHands>()), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallToRenderGameActionChoices()
        {
            GoIntoWhileLoopOnce();
            sut.PlayGame();
            mockGameView.Verify(view => view.RenderGameActionChoices(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallToGetNextrGameAction()
        {
            GoIntoWhileLoopOnce();
            sut.PlayGame();
            mockGameView.Verify(view => view.GetGameAction(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallToHitIfGameActionReturnsHit()
        {
            GoIntoWhileLoopOnce();
            mockGameView.Setup(view => view.GetGameAction())
                .Returns(GameAction.Hit);
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.Hit(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallToDealerTakeCardsIfGameActionReturnsStay()
        {
            GoIntoWhileLoopOnce();
            GetGameActionStay();
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.DealerTakeCards(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallToToSetGameIsOverIfGameActionReturnsStay()
        {
            GoIntoWhileLoopOnce();
            GetGameActionStay();
            sut.PlayGame();
            mockBlackjackGame.Verify(game => game.SetPlayerHasStayedTrue(), Times.Once());
        }

        [Fact]
        public void PlayGame_ShouldCallToRenderTheResultOfTheGame()
        {
            sut.PlayGame();
            mockGameView.Verify(view => view.RenderResultOfGame(It.IsAny<IHands>()), Times.Once());
        }
    }
}
