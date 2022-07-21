using BusinessLogic;

Editor _editor = new Editor();
History _history = new History();

_editor.Content = "Hello World!";
_history.Save(_editor);
_editor.Content = "Hello World! 2";
_history.Save(_editor);
_editor.Content = "Hello World! 3";
_history.Save(_editor);
Console.WriteLine("Content: " + _editor.Content);
Console.WriteLine("History: " + _history.CanUndo);
Console.WriteLine("History: " + _history.CanRedo);
//_editor.Load(_history.UndoAction());