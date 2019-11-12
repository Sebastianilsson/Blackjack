using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.View
{
    public class GameView : IGameView
    {
        public void RenderStartMenu()
        {
            throw new NotImplementedException();
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
