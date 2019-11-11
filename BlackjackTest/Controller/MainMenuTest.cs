using System;
using System.Collections.Generic;
using System.Text;
using Blackjack.Controller;
using Blackjack.View;
using Xunit;
using Moq;

namespace BlackjackTest.Controller
{
    public class MainMenuTest
    {
        private MainController sut;
        private Mock<IGameController> mockGameController;
        private Mock<IGameView> mockGameView;
        public MainMenuTest()
        {
            mockGameController = new Mock<IGameController>();
            mockGameView = new Mock<IGameView>();
            sut = new MainController(mockGameController.Object, mockGameView.Object);
        }

        [Fact]
        public void RunGame_ShouldCallToDisplayStartMenu()
        {
            mockGameView.Setup(view => view.RenderStartMenu());
            sut.RunGame();
            mockGameView.Verify(view => view.RenderStartMenu(), Times.Once());
        }

        [Fact]
        public void RunGame_ShouldCallToGetNextStartMenuAction()
        {
            mockGameView.Setup(view => view.GetStartMenuAction());
            sut.RunGame();
            mockGameView.Verify(view => view.GetStartMenuAction(), Times.Once());
        }

        [Fact]
        public void RunGame_ShouldCallToPlayGameIfStartMenuActionIsPlayGame()
        {
            mockGameView.Setup(view => view.GetStartMenuAction())
                .Returns(StartMenuAction.PlayGame);
            mockGameController.Setup(controller => controller.PlayGame());
            sut.RunGame();
            mockGameController.Verify(controller => controller.PlayGame(), Times.Once());
        }
    }
}
