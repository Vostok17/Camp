using Translater.FileHandlers;
using Translater.TextEditors;
using Translater.Behavior;

string text = new FileReader("input.txt").Read();
Dictionary<string, string> dict = new DictionaryParser("dictionary.txt").Parse();

var editor = new TextEditor();
text = editor.Translate(text, dict, UnknownKeyHandler.Fix);

var resultFile = new FileWriter("result.txt");
resultFile.Write(text);

Console.ReadLine();