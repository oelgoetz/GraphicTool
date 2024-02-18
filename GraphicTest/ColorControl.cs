using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicTool
{
    public partial class ColorControl : UserControl
    {
        public ColorControl()
        {
            InitializeComponent();
            
        }

        public void SetColor(Color color)
        {
            this.BackColor = color;
        }

        public void SetBorder(Color color)
        {
            //this.BorderStyle = BorderStyle.FixedSingle;
            //this.SetBorder(color);
        }

        public void SetPosition(int x, int y)
        {
            this.Left = x;
            this.Top = y;
        }

        public Color GetColor()
        {
            return this.BackColor;
        }
    }
}
