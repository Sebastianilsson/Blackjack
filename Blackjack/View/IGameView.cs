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
        void RenderExitMessage();
    }
}
