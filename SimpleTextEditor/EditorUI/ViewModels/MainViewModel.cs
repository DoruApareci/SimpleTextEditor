using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _history = new History();
            _editor = new Editor();
        }

        public History _history { get; set; }
        public Editor _editor { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
