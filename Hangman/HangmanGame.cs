using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hangman
{
    public class HangmanGame
    {
        HangmanParts gameParts;

        public string getGameStatus()
        {
            // get parts of word guessed so far and the list of incorrect guesses
            string status = gameParts.gameStatus();

            GameStatus gameStatus = JsonConvert.DeserializeObject<GameStatus>(status);
            string guessedWord = gameStatus.guessedWord;
            List<char> guesses = gameStatus.inCorrect.ToList();

            StringBuilder str = new StringBuilder();

            str.Append("Word   : ");
            str.Append(guessedWord);
            str.Append(System.Environment.NewLine);
            str.Append("Guessed: [ ");
            str.Append(string.Join(",", guesses).TrimEnd(',').Replace(",", ", "));
            str.Append(" ]");
            return str.ToString();
        }

        public void FormattedGameStatus()
        {
            string str = getGameStatus();
            string[] parts = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Console.WriteLine(parts[0]);
            ConsoleColor fg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(parts[1]);
            Console.ForegroundColor = fg;
        }
        
        public HangmanGame()
        {
            gameParts = new HangmanParts("hangman", 6);
            while(!gameParts.gameOver)
            {
                FormattedGameStatus();
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
