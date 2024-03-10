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
    /// Define a card class.
    /// </summary>
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Define a method for comparing two cards.
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >(Card card1, Card card2)
        {
            return card1.GetCardValue() > card2.GetCardValue();
        }

        /// <summary>
        /// Define a method for comparing two cards.
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>

        public static bool operator <(Card card1, Card card2)
        {
            return card1.GetCardValue() < card2.GetCardValue();
        }

        /// <summary>
        /// Convert the card rank into a value for comparison.
        /// </summary>
        /// <returns>Rank</returns>
        public int GetCardValue()
        {
            switch (Rank)
            {
                case "A":
                    return 14;
                case "K":
                    return 13;
                case "Q":
                    return 12;
                case "J":
                    return 11;
                default:
                    return int.Parse(Rank);
            }
        }
    }
}
