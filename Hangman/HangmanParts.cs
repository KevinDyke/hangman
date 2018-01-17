using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanParts
    {
        //private List<char> guesses;
        public List<char> guesses { get; private set; }
        public string guessedWord { get; private set; }
        public string wordToGuess { get; private set; }
        public bool gameOver { get; private set; }
        public bool gameWon { get; private set; }

        private int maxGuess;

        public HangmanParts(string wordToGuess, int maxGuess)
        {
            this.wordToGuess = wordToGuess;
            this.maxGuess = maxGuess;

            guessedWord = new string('-', this.wordToGuess.Length);
            guesses = new List<char>();
        }

        public string buildGuessesList()
        {
            return string.Join(",", guesses).TrimEnd(',').Replace(",", ", ");
        }

        public string gameStatus()
        {
            string str = string.Empty;

            str += "Word   : " + guessedWord;
            str += System.Environment.NewLine;
            str += "Guessed: [ ";
            str += buildGuessesList();
            str += " ]";
            return str;
        }

        public void FormattedGameStatus()
        {
            string str = gameStatus();
            string[] parts= str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            Console.WriteLine(parts[0]);
            ConsoleColor fg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(parts[1]);
            Console.ForegroundColor = fg;
        }

        public void Guess(char guess)
        {
            guess = Char.ToLower(guess);
            if (wordToGuess.Contains(guess))
                CorrectGuess(guess);
            else
                IncorrectGuess(guess);
        }

        public void IncorrectGuess(char letter)
        {
            if (!guesses.Contains(letter))
                guesses.Add(letter);

            gameOver = guesses.Count == maxGuess;
        }

        public void CorrectGuess(char letter)
        {
            string newGuessWord = guessedWord;
            int offset = 0;
            //int letterAt;
            while ((offset = wordToGuess.IndexOf(letter, offset)) != (-1) && (offset < newGuessWord.Length))
            {
                newGuessWord = guessedWord.Substring(0, offset) + letter + guessedWord.Substring(offset + 1);
                guessedWord = newGuessWord;
                offset++;
            }
            if (guessedWord == wordToGuess)
            {
                gameOver = true;
                gameWon = true;
            }
        }
    }
}
