using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GraphicTool
{
    public class DisplayChangesEventArgs : EventArgs
    {
        private int _Count;
        private bool _Changed;
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }

        public bool Changed
        {
            get { return _Changed; }
            set { _Changed = value; }
        }
        public DisplayChangesEventArgs(int count, bool changed)
        {
            _Count = count;
            _Changed = changed;
        }
    }
}
