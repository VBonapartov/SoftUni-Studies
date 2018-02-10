namespace _05.SemanticHTML
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> html = new List<string>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                html.Add(input);
            }

            List<string> semanticHTML = ConvertToSemanticHTML(html);
            Console.WriteLine(string.Join(Environment.NewLine, semanticHTML));
        }

        private static List<string> ConvertToSemanticHTML(List<string> html)
        {
            List<string> semanticHTML = new List<string>();

            string patternOpenTag = @"<div\s+(?<first>[^>]*?)(?:id|class)\s*=(?<attrValue>\s*.*?)(?<last>\s+.*?)?>";
            string patternCloseTag = @"<\/div>\s*<!--\s*(?<attrValue>[a-z]+)\s*-->";

            foreach (string row in html)
            {
                Match whiteSpaces = Regex.Match(row, @"(?<whiteSpaces>\s*)<");
                Match matchOpenTag = Regex.Match(row, patternOpenTag);
                Match matchCloseTag = Regex.Match(row, patternCloseTag);

                if (matchOpenTag.Success)
                {
                    string newRow = whiteSpaces.Groups["whiteSpaces"].Value + CreateNewOpenTag(matchOpenTag);
                    semanticHTML.Add(newRow);
                }
                else if (matchCloseTag.Success)
                {
                    string newRow = whiteSpaces.Groups["whiteSpaces"].Value + CreateNewCloseTag(matchCloseTag);
                    semanticHTML.Add(newRow);
                }
                else
                {
                    semanticHTML.Add(row);
                }
            }

            return semanticHTML;
        }

        private static string CreateNewOpenTag(Match matchOpenTag)
        {
            //get row parts - first part(before id|class); last part(after id|class) and attribute value(id|class value)
            string firstPart = matchOpenTag.Groups["first"].Value.Trim();
            string lastPart = matchOpenTag.Groups["last"].Value.Trim();
            string attrValue = matchOpenTag.Groups["attrValue"].Value.Trim().Trim('\"');

            //replace multiple spaces
            firstPart = Regex.Replace(firstPart, @"\s+", " ");
            lastPart = Regex.Replace(lastPart, @"\s+", " ");

            //create new open tag
            string newRow = $"<{attrValue} {firstPart}";
            newRow = newRow.Trim() + $" {lastPart}";
            newRow = newRow.Trim() + ">";

            return newRow;
        }

        private static string CreateNewCloseTag(Match matchCloseTag)
        {
            //create new close tag
            string attrValue = matchCloseTag.Groups["attrValue"].Value.Trim();
            string newRow = $"</{attrValue}>";

            return newRow;
        }
    }
}
