using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.View;
using System.IO;

namespace BlackjackTest.View
{
    public class GameViewTest
    {
        [Fact]
        public void RenderStartMenu_ShouldRenderTheStartMenuInConsoleWhenCalled()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            IGameView sut = new GameView();
            string expected = "1. PlayGame\r\n2. Rules\r\n3. Exit\r\nMake a Choice (1-3): ";
            sut.RenderStartMenu();
            string actual = output.ToString();
            Assert.Equal(expected, actual);            
        }

        [Fact]
        public void GetStartMenuAction_ShouldThrowExceptionIfEmptyInput() 
        {
            var input = new StringReader(null);
            Console.SetIn(input);
            IGameView sut = new GameView();
            Assert.Throws<Exception>(() => sut.GetStartMenuAction());
        }
    }
}
