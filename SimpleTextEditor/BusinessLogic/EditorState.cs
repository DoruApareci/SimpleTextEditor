using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EditorState //Memento
    {
        private readonly string content;
        public string Content { get { return content; } }

        public EditorState(string content)
        {
            this.content = content;
        }
    }
}
