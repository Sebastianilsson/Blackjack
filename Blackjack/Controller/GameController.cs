using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Controller
{
    public class GameController : IGameController
    {
        private IActionController ActionController { get; set; }
        private Model.IBlackjackGame Game { get; set; }
        private View.IGameView GameView { get; set; }
        public GameController(IActionController actionController, Model.IBlackjackGame game, View.IGameView gameView)
        {
            ActionController = actionController;
            Game = game;
            GameView = gameView;
        }
        public void PlayGame()
        {
            ActionController.DealNewHand();
            Game.DealNewHand();
            while (Game.IsGameOver() == false)
            {
                GameView.RenderPlayersHands();
                GameView.RenderGameActionChoices();
                switch (GameView.GetGameAction())
                {
                    case View.GameAction.Hit:
                        Game.Hit();
                        break;
                    case View.GameAction.Stay:
                        Game.DealerTakeCards();
                        break;
                }
            }
            GameView.RenderResultOfGame();
        }
    }
}
