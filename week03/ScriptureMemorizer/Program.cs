using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // =========================================================================
    // 1. WORD CLASS
    // =========================================================================
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                // Replaces each letter with an underscore, keeping the length identical
                return new string('_', _text.Length);
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

        // Constructor for a single verse
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = verse; // If single verse, endVerse is the same
        }

        // Constructor for a verse range
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

            // Split the text by spaces and populate our List of Word objects
            string[] splitWords = text.Split(' ');
            foreach (string wordText in splitWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();

            // STRETCH CHALLENGE: Filter to find only words that are NOT already hidden
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            // If there are fewer visible words left than numberToHide, adjust down
            int actualToHide = Math.Min(numberToHide, visibleWords.Count);

            for (int i = 0; i < actualToHide; i++)
            {
                int randomIndex = random.Next(visibleWords.Count);
                visibleWords[randomIndex].Hide();
                visibleWords.RemoveAt(randomIndex); // Prevent picking the same word in this pass
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
            // Returns true if ALL words return true for IsHidden()
            return _words.All(w => w.IsHidden());
        }
    }

    // =========================================================================
    // 4. PROGRAM CLASS
    // =========================================================================
    class Program
    {
        static void Main(string[] sender)
        {
            // Setup a scripture with a verse range
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";

            Scripture scripture = new Scripture(reference, text);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                // If everything is hidden, break immediately so the final layout is displayed
                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Great job! You've completely memorized the scripture.");
                    break;
                }

                Console.WriteLine("Press Enter to hide words, or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                // Hide 3 words at a time
                scripture.HideRandomWords(3);
            }
        }
    }
}