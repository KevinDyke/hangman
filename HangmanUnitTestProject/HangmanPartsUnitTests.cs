using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Collections.Generic;

namespace HangmanUnitTestProject
{
    [TestClass]
    public class HangmanPartsUnitTests
    {
        [TestMethod]
        public void FirstTimeReturnsAllDatches()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman",6);
            Assert.AreEqual(game.guessedWord, "-------");
        }

        [TestMethod]
        public void ConfirmGuessedWordHasSameLengthAsWordToGuess()
        {
            string word = "hangingman";
            Hangman.HangmanParts game = new Hangman.HangmanParts(word, 6);
            Assert.IsTrue(word.Length == game.guessedWord.Length);
        }

        [TestMethod]
        public void FirstTimeReturnsZeroEmptyIncorrectGuessesList()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            Assert.IsTrue(game.guesses.Count == 0);
        }

        [TestMethod]
        public void FirstTimeReturnsIncorrectCounterAsZero()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            Assert.IsTrue(game.guesses.Count == 0);
        }

        [TestMethod]
        public void IncorrectGussesAddedToListOfIncorrectGuesses()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('z');
            Assert.IsTrue(game.guesses.Contains('z'));
        }

        [TestMethod]
        public void IncorrectGussesIncreasesIncorrectGuessCounterByOne()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('z');
            Assert.IsTrue(game.guesses.Count == 1);
        }

        [TestMethod]
        public void AlreadyIncorrectGuessDoesNotAddedToListOfIncorrectGuesses()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('z');
            game.Guess('z');
            Assert.IsTrue(game.guesses.Count == 1);
        }

        [TestMethod]
        public void AlreadyIncorrectGuessDoesNotIncreaseCountOfIncorrectGuesses()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('z');
            game.Guess('z');
            Assert.IsTrue(game.guesses.Count == 1);
        }

        [TestMethod]
        public void CorrectGuessAddedToGuessWord()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('h');
            Assert.AreEqual(game.guessedWord, "h------");
        }

        [TestMethod]
        public void CorrectGuessNotAddedToListOfIncorrectGuesses()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('h');
            Assert.IsTrue(game.guesses.Count == 0);
        }

        [TestMethod]
        public void CorrectGuessDoesNotIncreaseCountOfIncorrectGuesses()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('h');
            Assert.IsTrue(game.guesses.Count == 0);
        }

        [TestMethod]
        public void CaseOfGuessIgnorned()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('H');
            Assert.AreEqual(game.guessedWord, "h------");
        }

        [TestMethod]
        public void CorrectGuessAtCorrectPlace()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('m');
            Assert.AreEqual(game.guessedWord, "----m--");
        }

        [TestMethod]
        public void RepeatingGuessedLettersAreAddedAtCorrectPlaces()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('a');
            Assert.AreEqual(game.guessedWord, "-a---a-");
        }

        [TestMethod]
        public void GuessesUpdatedCorrectly()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('a');
            game.Guess('h');
            Assert.AreEqual(game.guessedWord, "ha---a-");
        }

        [TestMethod]
        public void gameOverFlagReturnedAsFalseWhenGameInPlay()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            Assert.IsFalse(game.gameOver);
        }

        [TestMethod]
        public void gameOverFlagReturnedAsFalseWhenGameIsWon()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('h');
            game.Guess('a');
            game.Guess('n');
            game.Guess('g');
            game.Guess('m');
            Assert.IsTrue(game.gameOver);
        }

        [TestMethod]
        public void gameOverFlagReturnedAsFalseWhenNumIncorrectGuessIsLessThanMax()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('z');
            Assert.IsFalse(game.gameOver);
        }

        [TestMethod]
        public void gameOverFlagReturnedAsTrueWhenNumIncorrectGuessReachesMax()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 1);
            game.Guess('z');
            Assert.IsTrue(game.gameOver);
        }

        [TestMethod]
        public void gameWonReturnedAsFalseWhenGameInPlay()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 1);
            Assert.IsFalse(game.gameWon);
        }

        [TestMethod]
        public void gameWonReturnedAsTrueWhenWordIsCorrectlyGuessed()
        {
            Hangman.HangmanParts game = new Hangman.HangmanParts("hangman", 6);
            game.Guess('h');
            game.Guess('a');
            game.Guess('n');
            game.Guess('g');
            game.Guess('m');
            Assert.IsTrue(game.gameWon);
        }
    }
}
