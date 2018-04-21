namespace Forum.App.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class ContentViewModel
    {
        private const int LineLength = 37;

        public ContentViewModel(string content)
        {
            this.Content = this.GetLines(content);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LineLength)
            {
                char[] row = contentChars.Skip(i).Take(LineLength).ToArray();
                string rowString = string.Join(string.Empty, row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
