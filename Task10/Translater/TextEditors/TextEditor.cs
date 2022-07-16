using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Translater.FileHandlers;
using Translater.Logs;
using Translater.UserInfo;

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

        public string Translate(string text, Dictionary<string, string> dict, Func<string, string>? Fix = null)
        {
            var words = Regex.Matches(text, @"((\b[^\s]+\b)((?<=\.\w).)?)");

            foreach (var word in words)
            {
                try
                {
                    text = text.Replace(word.ToString(), dict[word.ToString()]);
                }
                catch (KeyNotFoundException ex)
                {
                    Logger.Log(ex.Message);
                    if (Fix is null)
                        throw;
                    else text = text.Replace(word.ToString(), Fix.Invoke($"Not in dictionary: {word}."));
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    throw;
                }
            }
            return text;
        }
        public void Translate(Dictionary<string, string> dict) => Translate(_stream, dict);
    }
}
