using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Editor //Originator
    {
        private string _content="";

        public string Content { get { return _content; } set { _content = value; } }//Trace.WriteLine(_content); //just making sure things work as they should

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
