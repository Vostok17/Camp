using Task6.SimpleTextEditor;

string stream = new FileHandler("input.txt").Read();

TextEditor textEditor = new TextEditor(stream);

textEditor.SplitIntoSentences();

textEditor.DisplayShortestAndLongestWords();

Console.ReadLine();