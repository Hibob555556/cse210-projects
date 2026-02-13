namespace YouTubeVideos
{
    public class Comment(string name, string text)
    {
        public string Text { get; } = text;
        public string Name { get; } = name;
    }
}
