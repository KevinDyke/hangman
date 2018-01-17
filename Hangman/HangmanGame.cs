using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGame
    {
        HangmanParts gameParts;
        
        public HangmanGame()
        {
            gameParts = new HangmanParts("hangman", 6);
            while(!gameParts.gameOver)
            {
                //string status = gameParts.gameStatus();
                gameParts.FormattedGameStatus();
                //Console.WriteLine(status);
                if (gameParts.gameOver)
                    break;

                // get the user guess
                Console.WriteLine("Enter a press");
                char key = Console.ReadKey(true).KeyChar;
                if (Char.IsLetter(key))
                    gameParts.Guess(key);
            }
            Console.WriteLine("Game Over");
            Console.WriteLine("You " + (gameParts.gameWon ? "Won" : "Lost" ));
            Console.WriteLine("The word was " + gameParts.wordToGuess);
        }
    }
}
