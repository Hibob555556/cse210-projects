namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse;

        /// <summary>
        /// Constructor to build the a new reference. 
        /// </summary>
        /// <param name="book">string</param>
        /// <param name="chapter">int</param>
        /// <param name="verse">int</param>
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
        }

        /// <summary>
        /// Overflow constructor to allow for end verse for multiple verse scriptures. 
        /// </summary>
        /// <param name="book">string</param>
        /// <param name="chapter">int</param>
        /// <param name="verse">int</param>
        /// <param name="endVerse">int</param>
        public Reference(string book, int chapter, int verse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = endVerse;
        }

        public string GetDisplayString()
        {
            if (_endVerse == 0)
                return $"{_book} {_chapter}:{_verse}";
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}