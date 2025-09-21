// Scripture.cs encapsulates the scripture being memorized:
// - Holds a Reference and a list of Word objects
// - Can render the full text (joining all tokens with spaces)
// - Can hide a few random *visible* words per step
// - Can report whether all words are hidden
//
// Important encapsulation details:
// - The outside world cannot directly manipulate the internal word list
// - Only public methods like HideRandomWords(), Render(), AllWordsHidden() are exposed

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    public sealed class Scripture
    {
        private static readonly Random _rng = new Random();

        private readonly Reference _reference;
        private readonly List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            if (text == null) throw new ArgumentNullException(nameof(text));

            // Tokenization strategy:
            // Split on spaces to keep punctuation attached to tokens (simple & adequate for this assignment).
            // This ensures "paths." hides into "_____." keeping the period in place.
            _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                         .Select(tok => new Word(tok))
                         .ToList();
        }

        public Reference Reference => _reference;

        /// <summary>
        /// Render the entire scripture by joining the rendered tokens with spaces.
        /// </summary>
        public string Render()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _words.Count; i++)
            {
                if (i > 0) sb.Append(' ');
                sb.Append(_words[i].Render());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hide up to 'count' random words that are currently visible.
        /// If fewer than 'count' visible words remain, hides all of them.
        /// </summary>
        public void HideRandomWords(int count)
        {
            if (count <= 0) return;

            // Build a list of indices for words that are not yet hidden.
            List<int> visibleIndexes = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden)
                    visibleIndexes.Add(i);
            }

            if (visibleIndexes.Count == 0) return;

            int toHide = Math.Min(count, visibleIndexes.Count);

            // Shuffle the visible indices and take the first 'toHide' of them.
            Shuffle(visibleIndexes);
            for (int i = 0; i < toHide; i++)
            {
                int idx = visibleIndexes[i];
                _words[idx].Hide();
            }
        }

        /// <summary>
        /// True if every word is hidden.
        /// </summary>
        public bool AllWordsHidden()
        {
            // Early exit pattern for performance on long texts.
            foreach (var w in _words)
            {
                if (!w.IsHidden) return false;
            }
            return true;
        }

        /// <summary>
        /// Fisher–Yates shuffle (in-place) for a list of integers.
        /// </summary>
        private static void Shuffle(List<int> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
