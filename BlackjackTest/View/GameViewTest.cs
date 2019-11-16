using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Blackjack.View;
using Blackjack.Model;
using System.IO;

namespace BlackjackTest.View
{
    public class GameViewTest
    {
        private Mock<IHands> mockHands;
        private IGameView sut;
        private StringWriter output;

        public GameViewTest()
        {
            sut = new GameView();
        }

        private void SetUserInput(string userInput)
        {
            var input = new StringReader(userInput);
            Console.SetIn(input);
        }

        private void CollectConsoleOutput()
        {
            output = new StringWriter();
            Console.SetOut(output);
        }

        private void MockHands(Value playerCardValue, int playerScore, Value dealerCardValue, int dealerScore)
        {
            var mockCard = new Mock<ICard>();
            mockCard.SetupSequence(card => card.GetColor()).Returns(Color.Clubs).Returns(Color.Clubs);
            mockCard.SetupSequence(card => card.GetValue()).Returns(playerCardValue).Returns(dealerCardValue);
            var hand = new List<ICard>();
            hand.Add(mockCard.Object);
            mockHands = new Mock<IHands>();
            mockHands.Setup(hands => hands.PlayerCards).Returns(hand);
            mockHands.Setup(hands => hands.DealerCards).Returns(hand);
            mockHands.Setup(hands => hands.PlayerScore).Returns(playerScore);
            mockHands.Setup(hands => hands.DealerScore).Returns(dealerScore);
        }

        [Fact]
        public void RenderStartMenu_ShouldRenderTheStartMenuInConsoleWhenCalled()
        {
            CollectConsoleOutput();
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
            CollectConsoleOutput();
            string expected = "RULES\n\nThis is a simple game of Blackjack. \nWhen the game starts both you and the dealer get two open cards each. \nThe goal of the game is to get a score of 21. \nWhen the cards are dealt you will get the choose between 'hit' or 'stay'. \nIf you choose 'hit' then you will get another card. \nIf your score gets higher than 21 then you are busted and you lose. \nIf you choose to 'stay' on a score lower than 21 it's the dealers turn to draw cards. \nThe dealer needs to keep taking new cards until he has a scor of at least 17. \nIf you have a score higher than 17 the dealer will continue to take cards until he has a score higher than yours. \nThe dealer wins all ties. \n\nGood luck! \n\nPress 'enter' to continue: ";
            sut.RenderRules();
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PressEnterToContinue_ShouldLetTheUserContinueWhenEnterIsPressed()
        {
            SetUserInput("");
            string expected = null;
            string actual = sut.PressEnterToContinue();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RenderExitMessage_ShouldRenderExitMessage()
        {
            CollectConsoleOutput();
            string expected = "Bye bye!\nThank you for playing!";
            sut.RenderExitMessage();
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RenderGameActionChoices_ShouldRenderGameChoises()
        {
            CollectConsoleOutput();
            string expected = "1. Hit\r\n2. Stay\r\nMake a Choice (1-2): ";
            sut.RenderGameActionChoices();
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("0")]
        [InlineData("3")]
        public void GetGameAction_ShouldThrowExceptionIfNotIntegerOneOrTwo(string userInput)
        {
            SetUserInput(userInput);
            Assert.Throws<Exception>(() => sut.GetGameAction());
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void GetGameAction_ShouldReturnMatchingGameActionIfOneOrTwo(string userInput)
        {
            SetUserInput(userInput);
            int menuChoice;
            int.TryParse(userInput, out menuChoice);
            GameAction expected = (GameAction)menuChoice;
            GameAction actual = sut.GetGameAction();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Value.Ace, 11, Value.Ace, 11)]
        public void RenderPlayersHands_ShouldRenderPlayerAndDealersHandsAndCurrentScoreWhenCalled(Value playerCardValue, int playerScore, Value dealerCardValue, int dealerScore)
        {
            CollectConsoleOutput();
            MockHands(playerCardValue, playerScore, dealerCardValue, dealerScore);
            string expected = "Player: Clubs Ace (11)\r\n\r\nDealer: Clubs Ace (11)\r\n\r\n";
            sut.RenderPlayersHands(mockHands.Object);
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Value.Ace, 11, Value.Five, 5)]
        public void RenderResultOfGame_ShouldRenderBothHandsAndPlayerWinnerIfScoreHigherThanDealerAndUnder21(Value playerCardValue, int playerScore, Value dealerCardValue, int dealerScore)
        {
            CollectConsoleOutput();
            MockHands(playerCardValue, playerScore, dealerCardValue, dealerScore);
            string expected = "Player: Clubs Ace (11)\r\n\r\nDealer: Clubs Five (5)\r\n\r\nPlayer wins!!\r\n";
            sut.RenderResultOfGame(mockHands.Object);
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Value.Five, 5, Value.Ace, 11)]
        public void RenderResultOfGame_ShouldRenderBothHandsAndDealerWinnerIfScoreEqualOrHigherThanPlayerAndUnder21(Value playerCardValue, int playerScore, Value dealerCardValue, int dealerScore)
        {
            CollectConsoleOutput();
            MockHands(playerCardValue, playerScore, dealerCardValue, dealerScore);
            string expected = "Player: Clubs Five (5)\r\n\r\nDealer: Clubs Ace (11)\r\n\r\nDealer wins!!\r\n";
            sut.RenderResultOfGame(mockHands.Object);
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Value.Five, 22, Value.Ace, 11)]
        public void RenderResultOfGame_ShouldRenderBustedAfterPlayerIfPlayerScoreOver21(Value playerCardValue, int playerScore, Value dealerCardValue, int dealerScore)
        {
            CollectConsoleOutput();
            MockHands(playerCardValue, playerScore, dealerCardValue, dealerScore);
            string expected = "Player: Clubs Five (22) BUSTED!\r\n\r\nDealer: Clubs Ace (11)\r\n\r\nDealer wins!!\r\n";
            sut.RenderResultOfGame(mockHands.Object);
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Value.Five, 11, Value.Ace, 22)]
        public void RenderResultOfGame_ShouldRenderBustedAfterDealerIfDealerScoreOver21(Value playerCardValue, int playerScore, Value dealerCardValue, int dealerScore)
        {
            CollectConsoleOutput();
            MockHands(playerCardValue, playerScore, dealerCardValue, dealerScore);
            string expected = "Player: Clubs Five (11)\r\n\r\nDealer: Clubs Ace (22) BUSTED!\r\n\r\nDealer wins!!\r\n";
            sut.RenderResultOfGame(mockHands.Object);
            string actual = output.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
