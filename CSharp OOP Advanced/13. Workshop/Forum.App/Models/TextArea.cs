namespace Forum.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
	using System.Threading;
	using Contracts;

    public class TextInputArea : ITextInputArea
    {
		private const int LineLength = 37;

		private const int PostMaxLength = 660;
		private const int PostAreaHeight = 18;

		private const int ReplyMaxLength = 220;
		private const int ReplyAreaHeight = 6;

        private static char[] forbiddenCharacters = { ';' };

        private int x;
        private int y;
        private int height;
		private int maxLength;

        private int textCursorPosition;
        private Position displayCursor;
		private IForumReader reader;

        private IEnumerable<string> lines = new List<string>();
        private string text = string.Empty;

		public TextInputArea(IForumReader reader, int x, int y, bool isPost = true)
		{
			this.reader = reader;

			this.x = x;
			this.y = y;
			this.displayCursor = new Position(x, y);

			this.height = isPost ? PostAreaHeight : ReplyAreaHeight;
			this.maxLength = isPost ? PostMaxLength : ReplyMaxLength;
		}

        public int Left { get => this.x; }

        public int Top { get => this.y; }

        public IEnumerable<string> Lines
        {
            get => this.lines;
        }

        public string Text
        {
            get => this.text;
            set
            {
                this.text = value;
                this.lines = this.Split(value);
            }
        }

        public Position DisplayCursor
        {
            get => this.displayCursor;
        }

        public void Write()
        {
			this.Render();
            this.reader.ShowCursor();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.Backspace)
                {
                    this.Delete();
                }
                else if (this.Text.Length == this.maxLength || forbiddenCharacters.Contains(keyInfo.KeyChar))
                {
					new Thread(() => Console.Beep(415, 260)).Start();
                    continue;
                }
                else if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    this.AddCharacter(keyInfo.KeyChar);
                }
            }

            this.reader.HideCursor();
        }

		public void Render()
		{
			int top = this.Top;

			Console.SetCursorPosition(this.Left, top);

			foreach (var item in this.Lines)
			{
				Console.SetCursorPosition(this.Left, top);
				Console.Write(new string(' ', 37));
				Console.SetCursorPosition(this.Left, top);
				foreach (var ch in item)
				{
					Console.Write(ch);
				}

				top++;
			}
		}

		public void Delete()
        {
            if (this.textCursorPosition > 0)
            {
                string stringBefore = this.Text.Substring(0, this.textCursorPosition);
                string stringAfter = this.Text.Substring(this.textCursorPosition, this.Text.Length - this.textCursorPosition);

                stringBefore = stringBefore.Substring(0, stringBefore.Length - 1);
                this.Text = stringBefore + stringAfter;
                this.textCursorPosition--;
				this.Render();
            }

            this.lines = this.Split(this.Text);
        }

        private bool AddCharacter(char character)
        {
            if (this.Text.Length < this.maxLength)
            {
                string stringBefore = this.Text.Substring(0, this.textCursorPosition);
                string stringAfter = this.Text.Substring(this.textCursorPosition, this.Text.Length - this.textCursorPosition);

                this.Text = stringBefore + character + stringAfter;

                this.textCursorPosition++;
                this.Render();
                return true;
            }

            return false;
        }

        private IEnumerable<string> Split(string text)
		{
			List<string> splitText = new List<string>();

			var lastSplit = 0;
			for (var i = 0; i < text.Length + 1; i++)
			{
				if (text.Length > i && text[i] == '\n')
				{
					splitText.Add(text.Substring(lastSplit, i - lastSplit + 1));
					lastSplit = i + 1;
				}
				else if (i - lastSplit == LineLength)
				{
					splitText.Add(text.Substring(lastSplit, i - lastSplit));
					lastSplit = i;
				}

                if (i == text.Length)
                {
                    splitText.Add(text.Substring(lastSplit, text.Length - lastSplit));
                }
			}

			return splitText.Select(x => x.Replace('\r', ' '));
		}
	}
}
