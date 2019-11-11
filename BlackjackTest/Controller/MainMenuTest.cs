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
        private Mock<IGameView> mockGameView;
        public MainMenuTest()
        {
            mockGameView = new Mock<IGameView>();
            sut = new MainController(mockGameView.Object);
        }

        [Fact]
        public void RunGame_ShouldCallToDisplayStartMenu()
        {
            mockGameView.Setup(view => view.RenderStartMenu());
            sut.RunGame();
            mockGameView.Verify(view => view.RenderStartMenu(), Times.Once());
        }
    }
}
