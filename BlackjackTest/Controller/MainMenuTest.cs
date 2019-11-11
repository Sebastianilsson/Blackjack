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
        [Fact]
        public void RunGame_ShouldCallToDisplayStartMenu()
        {
            var mockGameView = new Mock<IGameView>();
            mockGameView.Setup(view => view.RenderStartMenu());
            MainController sut = new MainController(mockGameView.Object);
            sut.RunGame();
            mockGameView.Verify(view => view.RenderStartMenu(), Times.Once());
        }
    }
}
