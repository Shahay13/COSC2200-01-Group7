/* Project: Hearts
 * Author: Takirul
 * Date: February 26, 2024
 * Description: In this project, I have created a C# application that includes 
 * game-play logic, computer players, a graphical user interface, object-oriented 
 * programming concepts, internal documentation, and a user guide. It also includes 
 * alternative play and the number of cards. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDeliverable
{
    /// <summary>
    /// Define a game class.
    /// </summary>
    public class Game
    {
        private Deck deck;
        private List<Player> players;
        private List<Card> currentTrick;
        private Player currentPlayer;
        private bool heartsBroken;

        public Game()
        {
            deck = new Deck();
            players = new List<Player>
        {
            new Player("Player 1"),
            new Player("Player 2"),
            new Player("CPU 1"),
            new Player("CPU 2")
        };
            currentTrick = new List<Card>();
            heartsBroken = false;
        }

        public void Setup()
        {
            deck.Shuffle();
            foreach (var player in players)
            {
                player.ReceiveCards(deck.Deal(13));
            }

            // The player on the left of the dealer starts to play.
            currentPlayer = players[0]; 
        }

        /// <summary>
        /// Start a game round.
        /// </summary>
        public void StartRound()
        {
            // Each player plays in 13 rounds.
            for (int i = 0; i < 13; i++) 
            {
                PlayTrick();
            }
        }

        /// <summary>
        /// Play a trick.
        /// </summary>
        private void PlayTrick()
        {
            currentTrick.Clear();
            Card leadCard = null;

            foreach (var player in players)
            {
                Card playedCard = player.ChooseCardToPlay(leadCard);
                if (leadCard == null)
                {
                    leadCard = playedCard;
                }
                currentTrick.Add(playedCard);

                // Logic to find out if hearts were broken.
                if (playedCard.Suit == "Hearts")
                {
                    heartsBroken = true;
                }
            }

            // Determine who won the trick.
            Card winningCard = currentTrick[0];
            foreach (var card in currentTrick)
            {
                if (card.Suit == leadCard.Suit && card > winningCard)
                {
                    winningCard = card;
                }
            }

            // The player who played the winning card will lead to the next trick.
            currentPlayer = players[currentTrick.IndexOf(winningCard)];
        }
    }
}
