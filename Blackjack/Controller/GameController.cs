using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Controller
{
    public class GameController : IGameController
    {
        private Model.IBlackjackGame Game { get; set; }
        public GameController(Model.IBlackjackGame game)
        {
            Game = game;
        }
        public void PlayGame()
        {
            Game.DealNewHand();
            while (Game.IsGameOver() == false)
            {

            }
        }
    }
}
