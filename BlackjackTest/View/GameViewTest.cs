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
        private IGameView sut;
        public GameViewTest()
        {
            sut = new GameView();
        }

        [Fact]
        public void RenderStartMenu_ShouldRenderTheStartMenuInConsoleWhenCalled()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            string expected = "1. PlayGame\r\n2. Rules\r\n3. Exit\r\nMake a Choice (1-3): ";
            sut.RenderStartMenu();
            string actual = output.ToString();
            Assert.Equal(expected, actual);            
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("0")]
        public void GetStartMenuAction_ShouldThrowExceptionIfInputNotIntegearOneToThree(string userinput) 
        {
            var input = new StringReader(userinput);
            Console.SetIn(input);
            Assert.Throws<Exception>(() => sut.GetStartMenuAction());
        }

        [Fact]
        public void GetStartMenuAction_ShouldThrowExceptionIfIntegerOverThree()
        {
            var input = new StringReader("4");
            Console.SetIn(input);
            Assert.Throws<Exception>(() => sut.GetStartMenuAction());
        }
    }
}
