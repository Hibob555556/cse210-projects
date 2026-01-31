namespace ScriptureMemorizer
{
    public class Word
    {
        private string _originalText;
        private string _hiddenWord;
        private bool _hidden;

        public Word(string text)
        {
            _originalText = text;
        }

        /// <summary>
        /// Generate the hidden text and set the word as hidden.
        /// </summary>
        public void Hide()
        {
            int textLen = _originalText.Length;
            string placeholder = string.Empty;
            for (int i = textLen; i > 0; i--)
                placeholder += "_";
            _hiddenWord = placeholder;
            _hidden = true;
        }

        public void Show() { _hidden = false; }
        public bool IsHidden() { return _hidden; }

        /// <summary>
        /// Get the display text. This will return _'s if hidden and the word if visible.
        /// </summary>    
        /// <returns>
        /// string
        /// </returns>
        public string GetDisplayText()
        {
            if (_hidden)
                return _hiddenWord;
            return _originalText;
        }
    }
}