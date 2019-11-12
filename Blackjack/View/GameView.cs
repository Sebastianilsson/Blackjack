using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.View
{
    public class GameView : IGameView
    {
        public void RenderStartMenu()
        {
            Console.Write(@"1. Play Game
2. Show Rules
3. Exit
Make a Choice (1-3): ");
        }
        public StartMenuAction GetStartMenuAction()
        {
            throw new NotImplementedException();
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
        PlayGame,
        Rules,
        Exit
    }

    public enum GameAction
    {
        Hit,
        Stay
    }
}
