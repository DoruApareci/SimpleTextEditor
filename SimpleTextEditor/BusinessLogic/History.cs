using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class History //Caretaker
    {
        private readonly Stack<EditorState> Undo = new Stack<EditorState>();
        private readonly Stack<EditorState> Redo = new Stack<EditorState>();

        public bool CanUndo(object? param) { return Undo.Count != 0; } 
        public bool CanRedo(object? param) { return Redo.Count != 0; }
        private EditorState lastState { get; set; } = new EditorState("");
        
        //Save state method
        public void Save(Editor editor)
        {
            if (editor.Content == lastState.Content)
                return;
            Undo.Push(editor.Save());
            lastState = undoPeek();
            Redo.Clear();
        }
        //peek methods
        
        public EditorState undoPeek()
        {
            EditorState state;
            if (Undo.TryPeek(out state))
                return state;
            return new EditorState("");
        }
        public EditorState redoPeek()
        {
            EditorState state;
            if (Redo.TryPeek(out state))
                return state;
            return new EditorState("");
        }
        //Undo
        public EditorState UndoAction()
        {
            if (CanUndo(null))
            {
                EditorState state = undoPeek();
                Undo.Pop();
                Redo.Push(state);
                lastState = state;
                return state;
            }
            return new EditorState("");
        }
        //Redo
        public EditorState RedoAction()
        {
            if (CanRedo(null))
            {
                EditorState state = Redo.Pop();
                Undo.Push(state);
                lastState = state;
                return state;
            }
            return new EditorState("");
        }
    }
}
