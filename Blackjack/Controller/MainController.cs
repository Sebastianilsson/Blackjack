using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Controller
{
    public class MainController
    {
        private View.IGameView GameView { get; set; }
        public MainController(View.IGameView gameView)
        {
            GameView = gameView;
        }
        public void RunGame()
        {
            GameView.RenderStartMenu();
            GameView.GetStartMenuAction();
        }
    }
}
