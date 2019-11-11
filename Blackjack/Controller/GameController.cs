using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Controller
{
    public class GameController : IGameController
    {
        private Model.IBlackjackGame Game { get; set; }
        private View.IGameView GameView { get; set; }
        public GameController(Model.IBlackjackGame game, View.IGameView gameView)
        {
            Game = game;
            GameView = gameView;
        }
        public void PlayGame()
        {
            Game.DealNewHand();
            while (Game.IsGameOver() == false)
            {
                GameView.RenderPlayersHands();
                GameView.RenderGameActionChoices();
                Game.Hit();
                switch (GameView.GetGameAction())
                {

                }
            }
        }
    }
}
