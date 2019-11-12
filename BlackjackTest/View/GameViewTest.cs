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

        [Fact]
        public void RenderRules_ShouldRenderRulseInConsole()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            string expected = "This is a simple game of black. When the game starts both you and the dealer get two open cards each. The goal of the game is to get a score of 21. When the cards are dealt you will get the choose between 'hit' or 'stay'. If you choose 'hit' then you will get another card. If your score gets higher than 21 then you are busted and you lose. If you choose to 'stay' on a score lower than 21 it's the dealers turn to draw cards. The dealer needs to keep taking new cards until he has a scor of at least 17. If you have a score higher than 17 the dealer will continue to take cards until he has a score higher than yours. The dealer wins all ties. Good luck!";
            sut.RenderStartMenu();
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
