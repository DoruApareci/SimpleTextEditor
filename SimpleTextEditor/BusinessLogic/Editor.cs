using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Editor:INotifyPropertyChanged //Originator
    {
        private string _content="";

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Content { get { return _content; } set { _content = value;NotifyPropertyChanged("Content"); Trace.WriteLine(_content); } }//Trace.WriteLine(_content); //just making sure things work as they should

        public Editor()
        {
            Content = "";
        }

        public EditorState Save()
        {
            return new EditorState(_content);
        }
        public void Load(EditorState state)
        {
            Content = state.Content;
        }
    }
}
