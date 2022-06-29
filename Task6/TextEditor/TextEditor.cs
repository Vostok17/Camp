using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6.SimpleTextEditor
{
    internal class TextEditor
    {
        private string _stream;

        private TextEditor() { }
        public TextEditor(string stream)
        {
            _stream = stream;
        }

        public string Read(string filename)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string path = Path.Combine(projectFolder, "assets", filename);

            return File.ReadAllText(path);
        }
        public void SplitIntoSentences()
        {
            string[] sentences = Regex.Split(_stream, @"(?<=[\.!\?])\s+");

            var file = new FileHandler("Result.txt");
            file.Write(sentences);
        }       
        public void DisplayShortestAndLongestWords()
        {
            string[] sentences = Regex.Split(_stream, @"(?<=[\.!\?])\s+");

            var res = new List<(int num, string shortest, string longest)>();

            int num = 0;
            foreach (string sentence in sentences)
            {
                var matches = Regex.Matches(sentence, @"((\b[^\s]+\b)((?<=\.\w).)?)");

                string[] words = matches.Select(x => x.ToString()).OrderBy(x => x.Length).ToArray();
                res.Add((++num, words[0], words[words.Length - 1]));
            }

            var tableData = res.Select(x => new
            {
                Sentence = x.num,
                ShortestWord = x.shortest,
                LongestWord = x.longest
            }).ToArray();

            Table table = new Table(tableData);
            Console.WriteLine(table);
        }
    }
}
