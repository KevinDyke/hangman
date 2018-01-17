﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public string gameStatus()
        {
            GameStatus status = new GameStatus();

            status.guessedWord = guessedWord;
            status.inCorrect = guesses.ToArray();
            // convert to JSON
            return JsonConvert.SerializeObject(status);
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

            int[] indexes = Enumerable.Range(0, wordToGuess.Length).Where(x => wordToGuess[x] == letter).ToArray();
            foreach (int index in indexes)
            {
                newGuessWord = guessedWord.Substring(0, index) + letter + guessedWord.Substring(index + 1);
                guessedWord = newGuessWord;
            }
            if (guessedWord == wordToGuess)
            {
                gameOver = true;
                gameWon = true;
            }
        }
    }
}
