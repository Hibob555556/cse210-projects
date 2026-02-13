namespace YouTubeVideos
{
    public class Video(string title, string author, int length)
    {
        public string Title { get; } = title;
        public int Length { get; } = length;
        public string Author { get; } = author;

        private readonly List<Comment> _comments = [];

        public IReadOnlyList<Comment> GetComments()
        {
            return _comments;
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}
