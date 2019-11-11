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
            sut.RunGame();
            mockGameView.Verify(view => view.RenderStartMenu(), Times.Once());
        }

        [Fact]
        public void RunGame_ShouldCallToGetNextStartMenuAction()
        {
            sut.RunGame();
            mockGameView.Verify(view => view.GetStartMenuAction(), Times.Once());
        }

        [Fact]
        public void RunGame_ShouldCallToPlayGameIfStartMenuActionIsPlayGame()
        {
            mockGameView.Setup(view => view.GetStartMenuAction())
                .Returns(StartMenuAction.PlayGame);
            sut.RunGame();
            mockGameController.Verify(controller => controller.PlayGame(), Times.Once());
        }

        [Fact]
        public void RunGame_ShouldCallToRenderRulesIfStartMenuActionIsRules()
        {
            mockGameView.Setup(view => view.GetStartMenuAction())
                .Returns(StartMenuAction.Rules);
            sut.RunGame();
            mockGameView.Verify(view => view.RenderRules(), Times.Once());
        }
    }
}
