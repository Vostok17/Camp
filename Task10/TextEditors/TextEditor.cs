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

        private TextEditor() { }
        public TextEditor(string stream)
        {
            _stream = stream;
        }

        public void SplitIntoSentences()
        {
            string[] sentences = Regex.Split(_stream, @"(?<=[\.!\?])\s+");

            var file = new FileHandler("Result.txt");
            file.Write(sentences);
        }
    }
}
