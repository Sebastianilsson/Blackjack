using System;
using System.Diagnostics.CodeAnalysis;
using Blackjack.Controller;
using Blackjack.Model;
using Blackjack.View;

namespace Blackjack
{
    //[ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            CardFactory cardFactory = new CardFactory();
            Deck deck = new Deck(cardFactory, random);
            Player player = new Player();
            Dealer dealer = new Dealer(deck);
            BlackjackGame game = new BlackjackGame(dealer,player);
            GameView gameView = new GameView();
            GameController gameController = new GameController(game, gameView);
            MainController mainController = new MainController(gameController, gameView);
            mainController.RunGame();
        }
    }
}
