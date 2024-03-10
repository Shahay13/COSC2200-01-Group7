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
    /// Define a player class.
    /// </summary>
    public class Player
    {
        public List<Card> Hand { get; private set; }
        public string Name { get; private set; }

        public Player(string name)
        {
            Hand = new List<Card>();
            Name = name;
        }

        public void ReceiveCards(IEnumerable<Card> dealtCards)
        {
            Hand.AddRange(dealtCards);
            Hand = Hand.OrderBy(card => card.Suit).ThenBy(card => card.GetCardValue()).ToList();
        }

        /// <summary>
        /// The player chooses which card to play.
        /// </summary>
        /// <param name="leadCard"></param>
        /// <returns>chosenCard</returns>
        public Card ChooseCardToPlay(Card leadCard)
        {
            Card chosenCard;
            if (leadCard != null)
            {
                // If the player has any cards of the same suit, they should play them.
                chosenCard = Hand.FirstOrDefault(card => card.Suit == leadCard.Suit);
                if (chosenCard != null)
                {
                    Hand.Remove(chosenCard);
                    return chosenCard;
                }
            }

            // Or select any card.
            chosenCard = Hand.First();
            Hand.Remove(chosenCard);
            return chosenCard;
        }
    }
}
