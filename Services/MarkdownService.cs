using BlogMarkDown.Models;
using Markdig;

namespace BlogMarkDown.Services
{
    public class MarkdownService
    {
        public static BlogPost LoadPost(string filePath)
        {
            var markdown = File.ReadAllText(filePath);
            var html = Markdown.ToHtml(markdown);

            return new BlogPost
            {
                Title = Path.GetFileNameWithoutExtension(filePath),
                Slug = Path.GetFileNameWithoutExtension(filePath).ToLower(),
                ContentHtml = html,
                LastModified = File.GetLastWriteTime(filePath)
            };
        }
    }
}