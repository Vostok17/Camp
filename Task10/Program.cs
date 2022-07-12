using Translater.FileHandlers;
using Translater.TextEditors;

string text = new FileReader("input.txt").Read();
Dictionary<string, string> dict = new DictionaryParser("dictionary.txt").Parse();

var editor = new TextEditor();
editor.Translate(text, dict);

Console.ReadLine();