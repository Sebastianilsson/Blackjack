using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.View
{
    public class GameView : IGameView
    {
        internal string rules = "RULES\n\nThis is a simple game of Blackjack. \nWhen the game starts both you and the dealer get two open cards each. \nThe goal of the game is to get a score of 21. \nWhen the cards are dealt you will get the choose between 'hit' or 'stay'. \nIf you choose 'hit' then you will get another card. \nIf your score gets higher than 21 then you are busted and you lose. \nIf you choose to 'stay' on a score lower than 21 it's the dealers turn to draw cards. \nThe dealer needs to keep taking new cards until he has a scor of at least 17. \nIf you have a score higher than 17 the dealer will continue to take cards until he has a score higher than yours. \nThe dealer wins all ties. \n\nGood luck! \n\nPress 'enter' to continue: ";
        internal string exitMessage = "Bye bye!\nThank you for playing!";
        internal int minimumMenuChoice = 1;
        internal int firstMenuNumber = 1;

        // If you add actions to the StartMenu remember to update test 
        // RenderStartMenu_ShouldRenderTheStartMenuInConsoleWhenCalled()
        public void RenderStartMenu()
        {
            Array startMenuActions = typeof(StartMenuAction).GetEnumValues();
            int itemListNumber = firstMenuNumber;
            foreach (StartMenuAction action in startMenuActions)
            {
                Console.WriteLine($"{itemListNumber++}. {action}");
            }
            Console.Write("Make a Choice (1-3): ");
        }
        public StartMenuAction GetStartMenuAction()
        {
            int actionChoice = CheckIfValidMenuChoice(3);
            return (StartMenuAction)actionChoice;
        }
        public void RenderRules()
        {
            Console.Write(rules);
        }
        public string PressEnterToContinue()
        {
            return Console.ReadLine();
        }
        public void RenderExitMessage()
        {
            Console.Write(exitMessage);
        }
        public void RenderPlayersHands(Model.IHands hands)
        {
            Console.Write("Player: ");
            RenderHand(hands.PlayerCards, hands.PlayerScore);
            Console.Write("Dealer: ");
            RenderHand(hands.DealerCards, hands.DealerScore);
        }
        public void RenderGameActionChoices()
        {
            Array gameActions = typeof(GameAction).GetEnumValues();
            int itemListNumber = minimumMenuChoice;
            foreach (GameAction action in gameActions)
            {
                Console.WriteLine($"{itemListNumber++}. {action}");
            }
            Console.Write("Make a Choice (1-2): ");
        }
        public GameAction GetGameAction()
        {
            int actionChoice = CheckIfValidMenuChoice(2);
            return (GameAction)actionChoice;
        }
        public void RenderResultOfGame(Model.IHands hands)
        {
            throw new NotImplementedException();
        }

        private int CheckIfValidMenuChoice(int numberOfChoicesInMenu)
        {
            int input;
            bool isInt = int.TryParse(Console.ReadLine(), out input);
            if (!isInt || input < minimumMenuChoice || input > numberOfChoicesInMenu)
            {
                throw new Exception();
            }
            return input;
        }

        private void RenderHand(IReadOnlyList<Model.ICard> cards, int score )
        {
            foreach (var card in cards)
            {
                Console.Write(card.GetColor() + " " + card.GetValue() + " ");
            }
            Console.WriteLine("(" + score + ")\r\n");
        }
    }
    public enum StartMenuAction
    {
        PlayGame = 1,
        Rules,
        Exit
    }

    public enum GameAction
    {
        Hit = 1,
        Stay
    }
}
