// W03 Encapsulation — Scripture Memorizer
// Author: Yang Liao
// Date: 2025-09-20
//
// Encapsulation focus:
// - All state for words and reference is stored in private fields inside classes
// - Public methods/properties expose only what the outside world needs

using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorizer
{
    internal class Program
    {
        // How many words to hide per step (tune as you like)
        private const int HideCountPerStep = 3;

        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1) Choose a scripture to memorize:
            // Try to load from an optional "scriptures.txt" file;
            // if not found or invalid, fallback to hard-coded examples.
            Scripture scripture = TryLoadFromTextFile("scriptures.txt")
                                  ?? BuildFallbackScripture();

            RunLoop(scripture);
        }

        /// <summary>
        /// Main memorization loop: show -> prompt -> hide -> repeat.
        /// </summary>
        private static void RunLoop(Scripture scripture)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Reference.ToString());
                Console.WriteLine();
                Console.WriteLine(scripture.Render());
                Console.WriteLine();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("Great job! All words are now hidden. Press Enter to exit...");
                    Console.ReadLine();
                    break;
                }

                Console.Write("Press Enter to hide a few words, or type 'quit' to exit: ");
                string? input = Console.ReadLine();
                if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                    break;

                // Hide a few random *visible* words each step.
                scripture.HideRandomWords(HideCountPerStep);
            }
        }

        /// <summary>
        /// Attempt to load a scripture from "scriptures.txt".
        /// Format (two lines): 
        ///   First line: Reference, e.g. Proverbs 3:5-6
        ///   Second line: Text (full scripture content)
        /// Returns null if file missing or content invalid.
        /// </summary>
        private static Scripture? TryLoadFromTextFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return null;

                var lines = File.ReadAllLines(filePath);
                if (lines.Length < 2)
                    return null;

                string refLine = lines[0].Trim();
                string textLine = string.Join(" ", lines, 1, lines.Length - 1).Trim();

                if (string.IsNullOrWhiteSpace(refLine) || string.IsNullOrWhiteSpace(textLine))
                    return null;

                var reference = Reference.Parse(refLine);
                return new Scripture(reference, textLine);
            }
            catch
            {
                // Swallow and return null to fall back gracefully
                return null;
            }
        }

        /// <summary>
        /// Fallback scripture if file is not present.
        /// Demonstrates a *range* reference and a single verse.
        /// </summary>
        private static Scripture BuildFallbackScripture()
        {
            // Example 1: Range reference (multi-verse)
            var ref1 = new Reference("Proverbs", 3, 5, 6);
            string text1 =
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths.";

            // You can switch to a single-verse example if you prefer:
            // var ref2 = new Reference("James", 1, 5);
            // string text2 =
            //     "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, " +
            //     "and upbraideth not; and it shall be given him.";

            return new Scripture(ref1, text1);
        }
    }
}
