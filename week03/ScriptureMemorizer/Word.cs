// Word.cs models a single token in the scripture text.
// It stores the original token and whether it's hidden.
// Rendering rule when hidden: replace letters/digits with '_' but keep punctuation.
// Example: "paths." -> "_____." (period preserved)

using System;
using System.Text;

namespace ScriptureMemorizer
{
    public sealed class Word
    {
        private readonly string _token;
        private bool _isHidden;

        public Word(string token)
        {
            _token = token ?? "";
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        /// <summary>
        /// Hide this word (idempotent).
        /// </summary>
        public void Hide() => _isHidden = true;

        /// <summary>
        /// Show this word again (not used in this assignment, but encapsulation-friendly).
        /// </summary>
        public void Show() => _isHidden = false;

        /// <summary>
        /// Render this word depending on hidden state.
        /// Letters/digits become underscores when hidden; punctuation/spaces remain.
        /// </summary>
        public string Render()
        {
            if (!_isHidden) return _token;

            var sb = new StringBuilder(_token.Length);
            foreach (char c in _token)
            {
                if (char.IsLetterOrDigit(c))
                    sb.Append('_');
                else
                    sb.Append(c); // keep punctuation like ',', '.', ';', etc.
            }
            return sb.ToString();
        }
    }
}
