using GraphicShapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicTool
{
    public partial class ColorPicker : Form
    {
        Color m_CurrentColor = Color.Empty;
        GraphicObject _g;
        GraphicShapeDialog _caller;
        string _prop;
        public Color CursorEllipseColor { get; set; } = Color.Orange;

        public ColorPicker(GraphicShapeDialog caller)
        {
            InitializeComponent();
            _caller = caller;
            // TEST !! //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // TEST !! //WindowState = FormWindowState.Maximized;
            ResizeRedraw = true;
            DoubleBuffered = true;
            TopMost = true;
            BackColor = Color.Navy;
            TransparencyKey = Color.Navy;
        }

        public void setProperty(string newProperty)
        {
            _prop = newProperty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GetColorUnderCursor();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = GetCursorEllipse();
            using (var pen = new Pen(CursorEllipseColor, 5))
            {
                e.Graphics.DrawEllipse(pen, rect);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //if (e.Button == MouseButtons.Right)
            //{
            //    m_SavedColors.Add(m_CurrentColor);
            //    //picPalette.Invalidate();
            //}
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        private Rectangle GetCursorEllipse()
        {
            var cursorEllipse = new Rectangle(PointToClient(Cursor.Position), Cursor.Size);
            cursorEllipse.Offset(-cursorEllipse.Width / 2, -cursorEllipse.Height / 2);
            return cursorEllipse;
        }

        private void GetColorUnderCursor()
        {
            using (var bmp = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(Cursor.Position, Point.Empty, new Size(1, 1));
                m_CurrentColor = bmp.GetPixel(0, 0);
                //picColor.BackColor = m_CurrentColor;
                CursorEllipseColor = m_CurrentColor;
            }
        }

        private void ColorPicker_MouseDown(object sender, MouseEventArgs e)
        {
            _caller.ApplyColor(m_CurrentColor);
            this.Close();
        }
    }
}
