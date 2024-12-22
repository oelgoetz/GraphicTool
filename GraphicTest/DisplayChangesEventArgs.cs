using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicTool
{
    public class DisplayChangesEventArgs : EventArgs
    {
        private int _Count;

        public int Count
        {
            get { return _Count; }
        }
        public DisplayChangesEventArgs(int count)
        {
            _Count = count;
        }
    }
}
