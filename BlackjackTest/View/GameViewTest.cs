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

        private void SetUserInput(string userInput)
        {
            var input = new StringReader(userInput);
            Console.SetIn(input);
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
        [InlineData("4")]
        public void GetStartMenuAction_ShouldThrowExceptionIfInputNotIntegearOneToThree(string userInput) 
        {
            SetUserInput(userInput);
            Assert.Throws<Exception>(() => sut.GetStartMenuAction());
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void GetStartMenuAction_ShouldReturnPlayGameIfInputIsOne(string userInput)
        {
            SetUserInput(userInput);
            int menuChoice;
            int.TryParse(userInput, out menuChoice);
            StartMenuAction expected = (StartMenuAction)menuChoice;
            StartMenuAction actual = sut.GetStartMenuAction();
            Assert.Equal(expected, actual);
        }
    }
}
