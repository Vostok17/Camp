using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Translater.FileHandlers;

namespace Translater.TextEditors
{
    internal class TextEditor
    {
        private string _stream;

        public TextEditor() { }
        public TextEditor(string stream)
        {
            _stream = stream;
        }

        public void Translate(string text, Dictionary<string, string> dict)
        {
            var words = Regex.Matches(text, @"((\b[^\s]+\b)((?<=\.\w).)?)");

            foreach (var word in words)
            {
                try
                {
                    text = text.Replace(word.ToString(), dict[word.ToString()]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(text);
        }
        public void Translate(Dictionary<string, string> dict) => Translate(_stream, dict);
    }
}
