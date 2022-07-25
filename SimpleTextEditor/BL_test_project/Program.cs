using BusinessLogic;

Editor _editor = new Editor();
History _history = new History();
EditorState _state;

_editor.Content = "Hello World! 1";
_history.Save(_editor);
Console.WriteLine("load data 1");
ShowData();
_editor.Content = "Hello World! 2";
_history.Save(_editor);
Console.WriteLine("load data 2");
ShowData();
Console.WriteLine("data changed");
_editor.Content = "Hello World! 3";


ShowData();
_editor.Load(_history.UndoAction());
ShowData();
_editor.Load(_history.UndoAction());
ShowData();
_editor.Load(_history.UndoAction());
ShowData();
_editor.Load(_history.RedoAction());
ShowData();
_editor.Load(_history.RedoAction());
ShowData();
_editor.Load(_history.RedoAction());
ShowData();
_editor.Load(_history.RedoAction());
ShowData();



void ShowData()
{
    Console.WriteLine("===============================");
    Console.WriteLine("Content: " + _editor.Content);
    Console.WriteLine("CanUndo: " + _history.CanUndo(null));
    Console.WriteLine("CanRedo: " + _history.CanRedo(null));
}