using BusinessLogic;
using EditorUI.Comands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditorUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _history = new History();
            _editor = new Editor();
            UndoComand = new BaseComand(UndoComand_Execute, _history.CanUndo);
            RedoComand = new BaseComand(RedoComand_Execute, _history.CanRedo);
            SaveComand = new BaseComand(SaveComand_Execute);
        }

        public History _history { get; set; }

        public Editor _editor { get; set; }

        //comands
        public ICommand UndoComand { get; }
        void UndoComand_Execute(object param)
        {
            if (_history.CanUndo(param))
            {
                _editor.Load(_history.UndoAction());
            }
        }
        public ICommand RedoComand { get; }
        void RedoComand_Execute(object param)
        {
            if (_history.CanRedo(param))
            {
                _editor.Load(_history.RedoAction());
            }
        }
        private string previousContent = "";
        public ICommand SaveComand { get; }
        void SaveComand_Execute(object param)
        {
            if (previousContent!=_editor.Content)
            {
                _history.Save(_editor);
            }
            previousContent = _editor.Content;
        }
    }
}
