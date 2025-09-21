// Reference.cs encapsulates a scripture reference.
// Supports both single verse and a range, e.g. "Proverbs 3:5-6".
// Parsing logic is included to support loading from text file.
// All fields are private; consumers use properties and ToString() for display.

using System;
using System.Globalization;

namespace ScriptureMemorizer
{
    public sealed class Reference
    {
        // Private fields enforce encapsulation
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _verseStart;
        private readonly int? _verseEnd; // null for single verse

        /// <summary>
        /// Single-verse constructor, e.g., "James 1:5".
        /// </summary>
        public Reference(string book, int chapter, int verse)
        {
            _book = book ?? throw new ArgumentNullException(nameof(book));
            _chapter = chapter;
            _verseStart = verse;
            _verseEnd = null;
        }

        /// <summary>
        /// Range constructor, e.g., "Proverbs 3:5-6".
        /// </summary>
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book ?? throw new ArgumentNullException(nameof(book));
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd >= verseStart ? verseEnd : verseStart;
        }

        // Public, read-only accessors
        public string Book => _book;
        public int Chapter => _chapter;
        public int VerseStart => _verseStart;
        public int VerseEnd => _verseEnd ?? _verseStart;

        public bool IsRange => _verseEnd.HasValue && _verseEnd.Value != _verseStart;

        /// <summary>
        /// Friendly format: "Proverbs 3:5-6" or "James 1:5".
        /// </summary>
        public override string ToString()
        {
            return IsRange
                ? $"{_book} {_chapter}:{_verseStart}-{_verseEnd}"
                : $"{_book} {_chapter}:{_verseStart}";
        }

        /// <summary>
        /// Parse a reference string, e.g., "Proverbs 3:5-6" or "James 1:5".
        /// </summary>
        public static Reference Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Reference string cannot be empty.", nameof(s));

            // Split into "Book Name ...", "Chapter:Verses"
            // Book can contain spaces (e.g., "1 Nephi").
            s = s.Trim();
            int spaceIndex = s.LastIndexOf(' ');
            if (spaceIndex < 0)
                throw new FormatException("Invalid reference format.");

            string book = s.Substring(0, spaceIndex).Trim();
            string chapterVerse = s.Substring(spaceIndex + 1).Trim();

            // Chapter:Verse or Chapter:Start-End
            string[] parts = chapterVerse.Split(':');
            if (parts.Length != 2)
                throw new FormatException("Invalid chapter/verse format.");

            if (!int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int chapter))
                throw new FormatException("Invalid chapter number.");

            string versePart = parts[1];
            if (versePart.Contains("-"))
            {
                string[] v = versePart.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (v.Length != 2) throw new FormatException("Invalid verse range.");
                if (!int.TryParse(v[0], out int vs) || !int.TryParse(v[1], out int ve))
                    throw new FormatException("Invalid verse numbers.");
                return new Reference(book, chapter, vs, ve);
            }
            else
            {
                if (!int.TryParse(versePart, out int v1))
                    throw new FormatException("Invalid verse number.");
                return new Reference(book, chapter, v1);
            }
        }
    }
}
