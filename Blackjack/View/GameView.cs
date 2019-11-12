using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.View
{
    public class GameView : IGameView
    {
        // If you add actions to the StartMenu remember to update test 
        // RenderStartMenu_ShouldRenderTheStartMenuInConsoleWhenCalled()
        public void RenderStartMenu()
        {
            Array startMenuActions = typeof(StartMenuAction).GetEnumValues();
            int itemListNumber = 1;
            foreach (StartMenuAction loginType in startMenuActions)
            {
                Console.WriteLine($"{itemListNumber++}. {loginType}");
            }
            Console.Write("Make a Choice (1-3): ");
        }
        public StartMenuAction GetStartMenuAction()
        {
            int input;
            bool isInt = int.TryParse(Console.ReadLine(), out input);
            if (!isInt || input < 1 || input > 3)
            {
                throw new Exception();
            }
            return (StartMenuAction)input;
        }
        public void RenderRules()
        {
            Console.Write("RULES\n\nThis is a simple game of Blackjack. \nWhen the game starts both you and the dealer get two open cards each. \nThe goal of the game is to get a score of 21. \nWhen the cards are dealt you will get the choose between 'hit' or 'stay'. \nIf you choose 'hit' then you will get another card. \nIf your score gets higher than 21 then you are busted and you lose. \nIf you choose to 'stay' on a score lower than 21 it's the dealers turn to draw cards. \nThe dealer needs to keep taking new cards until he has a scor of at least 17. \nIf you have a score higher than 17 the dealer will continue to take cards until he has a score higher than yours. \nThe dealer wins all ties. \n\nGood luck! \n\nPress 'enter' to continue: ");
        }
        public void RenderExitMessage()
        {
            throw new NotImplementedException();
        }
        public void RenderPlayersHands()
        {
            throw new NotImplementedException();
        }
        public void RenderGameActionChoices()
        {
            throw new NotImplementedException();
        }
        public GameAction GetGameAction()
        {
            throw new NotImplementedException();
        }
        public void RenderResultOfGame()
        {
            throw new NotImplementedException();
        }
    }
    public enum StartMenuAction
    {
        PlayGame = 1,
        Rules,
        Exit
    }

    public enum GameAction
    {
        Hit,
        Stay
    }
}
