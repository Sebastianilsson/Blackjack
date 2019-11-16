using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.View
{
    public interface IGameView
    {
        void RenderStartMenu();
        StartMenuAction GetStartMenuAction();
        void RenderRules();
        string PressEnterToContinue();
        void RenderExitMessage();
        void RenderPlayersHands(Model.IHands hands);
        void RenderGameActionChoices();
        GameAction GetGameAction();
        void RenderResultOfGame();
    }
}
