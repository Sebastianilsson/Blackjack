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
            return (StartMenuAction)1;
        }
        public void RenderRules()
        {
            throw new NotImplementedException();
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
