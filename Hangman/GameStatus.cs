using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class GameStatus
    {
        public string guessedWord {get;set;} // word with - and guessed letters
        public char[] inCorrect { get; set;} // list of incorrect guesses
    }
}
