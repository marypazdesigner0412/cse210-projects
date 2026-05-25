using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizerWithHints
{
    // =========================================================================
    // I implemented a "Hint Feature" 
     
    // Architectural Modifications:
    // 1. Word Class: Added an internal `_isHint` boolean flag state and a `ShowHint()` 
    //    method. The `GetDisplayText()` method was updated to evaluate if a word 
    //    is in hint mode. If true, it returns the first character followed by 
    //    underscores.
    // 2. Scripture Class: Implemented a new `RevealRandomHints(int numberToHint)` 
    //    method. It leverages LINQ to filter out words that are already hidden 
    //    or already hints, ensuring only pristine, visible words are modified.
    // 3. Program Class: Added an interactive console menu UI branch. The program 
    //    now tracks user commands, executing a standard word wipeout on [Enter], 
    //    while opening up an alternative pathway if the user types 'h'.
    // =========================================================================

    // =========================================================================
    // 1. WORD CLASS
    // =========================================================================
    public class Word
    {
        private string _text;
        private bool _isHidden;
        private bool _isHint; // Tracks if the word is currently in "hint mode"

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
            _isHint = false;
        }

        public void Hide()
        {
            _isHidden = true;
            _isHint = false; // If forced to hide, it overrides hint status
        }

        public void ShowHint()
        {
            // Only give a hint if the word isn't already fully hidden
            if (!_isHidden)
            {
                _isHint = true;
            }
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public bool IsHint()
        {
            return _isHint;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            else if (_isHint && _text.Length > 0)
            {
                // Shows the first character, and replaces the rest with underscores
                char firstChar = _text[0];
                string underscores = new string('_', _text.Length - 1);
                return firstChar + underscores;
            }

            return _text;
        }
    }

    // =========================================================================
    // 2. REFERENCE CLASS
    // =========================================================================
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse;

        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = verse;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_verse == _endVerse)
            {
                return $"{_book} {_chapter}:{_verse}";
            }
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    // =========================================================================
    // 3. SCRIPTURE CLASS
    // =========================================================================
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] splitWords = text.Split(' ');
            foreach (string wordText in splitWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();

            // STRETCH CHALLENGE: Select only from words that are not already hidden
            List<Word> targetWords = _words.Where(w => !w.IsHidden()).ToList();
            int actualToHide = Math.Min(numberToHide, targetWords.Count);

            for (int i = 0; i < actualToHide; i++)
            {
                int randomIndex = random.Next(targetWords.Count);
                targetWords[randomIndex].Hide();
                targetWords.RemoveAt(randomIndex);
            }
        }

        // CREATIVE EXTRA: Turns visible words into hints (revealing first letter)
        public void RevealRandomHints(int numberToHint)
        {
            Random random = new Random();

            // Only pull from words that are fully unedited (neither hidden nor already hints)
            List<Word> fullyVisibleWords = _words.Where(w => !w.IsHidden() && !w.IsHint()).ToList();
            int actualToHint = Math.Min(numberToHint, fullyVisibleWords.Count);

            for (int i = 0; i < actualToHint; i++)
            {
                int randomIndex = random.Next(fullyVisibleWords.Count);
                fullyVisibleWords[randomIndex].ShowHint();
                fullyVisibleWords.RemoveAt(randomIndex);
            }
        }

        public string GetDisplayText()
        {
            List<string> displayedWords = new List<string>();
            foreach (Word word in _words)
            {
                displayedWords.Add(word.GetDisplayText());
            }

            return $"{_reference.GetDisplayText()} - {string.Join(" ", displayedWords)}";
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }

    // =========================================================================
    // 4. PROGRAM CLASS
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";

            Scripture scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SCRIPTURE MEMORIZER (WITH HINTS) ===");
                Console.WriteLine();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Great job! You've completely memorized the scripture.");
                    break;
                }

                Console.WriteLine("Controls:");
                Console.WriteLine("  [Press Enter]      -> Hide 3 random words");
                Console.WriteLine("  [Type 'h' + Enter] -> Reveal 3 first-letter hints");
                Console.WriteLine("  [Type 'quit']      -> Exit program");
                Console.Write("\nYour choice: ");

                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    break;
                }
                else if (input == "h")
                {
                    scripture.RevealRandomHints(3);
                }
                else
                {
                    scripture.HideRandomWords(3);
                }
            }
        }
    }
}