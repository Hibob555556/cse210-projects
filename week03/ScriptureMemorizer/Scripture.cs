namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words = [];
        private readonly int _wordCount;
        private int _hiddenCount;

        public Scripture(Reference reference, string scripture)
        {
            _reference = reference;
            List<String> words = [.. scripture.Split(" ")];
            foreach (string word in words)
            {
                Word w = new(word);
                _words.Add(w);
            }
            _wordCount = _words.Count;
        }

        public string GetDisplayText()
        {
            string refDisplayString = _reference.GetDisplayString();
            List<string> words = [];
            foreach (Word word in _words)
                words.Add(word.GetDisplayText());
            string text = string.Join(" ", words);
            string output = $"{refDisplayString}\n{text}";
            return output;
        }

        public void HideRandomWords()
        {
            int wordCount = _wordCount;
            Random random = new();
            bool hiding = true;
            int i = 0;
            while (hiding)
            {
                if (_hiddenCount < _wordCount - 3)
                {
                    int toHide = random.Next(0, wordCount);
                    if (!_words[toHide].IsHidden())
                    {
                        _words[toHide].Hide();
                        _hiddenCount++;
                        i++;
                    }
                    if (i > 2)
                        hiding = false;
                }
                else
                {
                    foreach (Word word in _words)
                    {
                        if (!word.IsHidden())
                            word.Hide();
                    }
                    hiding = false;
                }
            }
        }

        public bool IsCompletelyHidden()
        {
            bool completelyHidden = true;
            foreach (Word word in _words)
                if (!word.IsHidden())
                {
                    completelyHidden = false;
                    break;
                }
            return completelyHidden;
        }

        public void ResetWords()
        {
            List<Word> hiddenWords = [.. _words.Where(w => w.IsHidden())];
            foreach (Word word in hiddenWords)
            {
                word.Show();
            }
            _hiddenCount = 0;
        }
    }
}