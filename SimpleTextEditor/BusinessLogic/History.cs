using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class History: INotifyPropertyChanged //Caretaker
    {
        private readonly Stack<EditorState> Undo = new Stack<EditorState>();
        private readonly Stack<EditorState> Redo = new Stack<EditorState>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool CanUndo { get { return Undo.Count != 0; } }
        public bool CanRedo { get { return Redo.Count != 0; } }

        public void Save(Editor editor)
        {
            Undo.Push(editor.Save());
            Redo.Clear();
        }
        //Undo
        public EditorState UndoAction()
        {
            if (CanUndo)
            {
                EditorState state = Undo.Pop();
                Redo.Push(state);
                return state;
            }
            return new EditorState("");
        }
        //Redo
        public EditorState RedoAction()
        {
            if (CanRedo)
            {
                EditorState state = Redo.Pop();
                Undo.Push(state);
                return state;
            }
            return new EditorState("");
        }
    }
}
