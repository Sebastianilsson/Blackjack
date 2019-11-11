using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Controller
{
    public class MainController
    {
        private IGameController GameController { get; set; }
        private View.IGameView GameView { get; set; }
        public MainController(IGameController gameController, View.IGameView gameView)
        {
            GameController = gameController;
            GameView = gameView;
        }
        public void RunGame()
        {
            GameView.RenderStartMenu();
            switch (GameView.GetStartMenuAction())
            {
                case View.StartMenuAction.PlayGame:
                    GameController.PlayGame();
                    break;
                case View.StartMenuAction.Rules:
                    GameView.RenderRules();
                    break;
            }
            
            
        }
    }
}
