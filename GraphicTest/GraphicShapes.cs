using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GraphicShapes
{
    public abstract class GraphicObject
    {
        internal static float _PI = Convert.ToSingle(Math.PI);
        internal static Pen DarkMarkerPen = new Pen(Color.Gray, 1);
        internal static Pen LightMarkerPen = new Pen(Color.LightGray, 1);
        internal static Brush MarkerBrush = new SolidBrush(Color.Gray);
        internal static Pen SpecialMarkerPen = new Pen(Color.Red, 2);
        internal static Brush SpecialMarkerBrush = new SolidBrush(Color.Red);
        internal static Font defaultFont = new Font("Arial", 10);

        public GraphicObject Parent;
        public List<GraphicObject> Children = new List<GraphicObject>();

        //(Type)
        //PaddingLeft
        //PaddingBottom
        //PaddingRight
        //PaddingTop
        //X
        //Y
        //Width
        //Height
        //BackgroundColor
        //Color
        //CornerRadius
        //FontWeight
        //FontStyle
        //FontFamily
        //FontSize
        //Underline
        //LineWidth
        //Transparency
        //EnableShadow
        //ShapeTimeSpan
        //Right
        //Bottom
        //BackgroundColorAlt
        //Left
        //Top
        //Rotation

        ////Polyine:
        //(Type)
        //Coordinates
        //ArrowHeadColor
        //LineColor
        //LineWidth
        //PaddingLeft
        //PaddingRight
        //PaddingTop
        //PaddingBottom
        //ShapeTimeSpan
        //Rotation

        public Rectangle Box = new Rectangle();
        public string _text = "";
        public StringFormat? _stringFormat;
        public Rectangle _textBox;
        public Padding _padding = new Padding(0, 0, 0, 0);
        public Font? _font;
        public Pen? _pen;
        public Color _fontColor;
        public FontStyle _fontStyle;
        public Brush? _fontBrush;
        public Brush? _fillBrush = null;
        public int _flags;
        public int SelectedMarker = -1;

        public Single ArrowHeadCenterLength = 15;
        public Single ArrowHeadLength = 25;
        public Single ArrowHeadWidth = 20;
        public Single ArrowTailCenterLength = 15;
        public Single ArrowTailLength = 25;
        public Single ArrowTailWidth = 20;

        public Point[] MarkerPoints;

        public bool IsSelected = false;

        public abstract void Draw(Graphics g, int extd);

        public abstract void Move(Point d);

        public abstract void Reshape(Point d);

        public virtual void Ungroup(GraphicObject parent)
        {
            foreach (GraphicObject obj in Children)
            {
                parent.Children.Add(obj);
                obj.Move(new Point(this.Box.X, this.Box.Y));
            }
            this.Children.Clear();
            parent.Children.Remove(this);
        }

        public virtual void Add(XmlNode shape, GraphicObject Parent)
        {
            if (shape.NodeType != XmlNodeType.Element)
                return;
            GraphicObject newGraphicObject = null;
            switch (shape.Attributes["Type"].Value)
            {
                case "Rectangle":
                    newGraphicObject = new MyRectangle(shape, Parent);
                    break;
                case "Oval":
                    newGraphicObject = new MyOval(shape, Parent);
                    break;
                case "Group":
                    newGraphicObject = new MyGroup(shape, Parent);
                    break;
                case "Polygon":
                    newGraphicObject = new MyPolygon(shape, Parent);
                    break;
                case "Polyline":
                    newGraphicObject = new MyPolyline(shape, Parent);
                    break;
                case "Image":
                    newGraphicObject = new MyImage(shape, Parent);
                    break;
                case "Bubble": break;
                case "Cursor": break;
                default: break;
            }
            if (newGraphicObject != null)
            {
                this.Children.Add(newGraphicObject);
            }

        }

        public virtual void Select()
        {
            IsSelected = true;
        }

        public virtual void UnSelect()
        {
            IsSelected = false;
        }

        public Point getOffset(GraphicObject Parent)
        {
            Point result = Point.Empty;
            while (Parent != null && Parent.GetType().Name != "Root")
            {
                result.X += Parent.Box.Location.X;
                result.Y += Parent.Box.Location.Y;
                Parent = Parent.Parent;
            }
            return result;
        }

        //--------------------------------------------------

        public virtual void setStringAlignment()
        {
            _stringFormat = StringFormat.GenericTypographic;
            _stringFormat.Alignment = StringAlignment.Near;
            _stringFormat.LineAlignment = StringAlignment.Near;

            if ((_flags & 1) == 1) _stringFormat.Alignment |= StringAlignment.Center;
            if ((_flags & 2) == 2) _stringFormat.Alignment |= StringAlignment.Far;
            if ((_flags & 4) == 4) _stringFormat.LineAlignment |= StringAlignment.Center;
            if ((_flags & 8) == 8) _stringFormat.LineAlignment |= StringAlignment.Far;
        }

        public virtual void getTextAttributes(XmlNode node)
        {
            //VERTICAL ALIGNMENT
            if (node.Attributes["VerticalAlign"] == null)
                _flags += 4;      //Default in MadCap Capture is "center"
            else
            {
                switch (node.Attributes["VerticalAlign"].Value)
                {
                    case "top": _flags += 0; break;
                    case "center": _flags += 4; break;
                    case "bottom": _flags += 8; break;
                    default: break;
                }
            }
            //HORIZONTAL ALIGNMENT
            if (node.Attributes["TextAlign"] == null)
                _flags += 1;      //Default in MadCap Capture is "center"
            else
            {
                switch (node.Attributes["TextAlign"].Value)
                {
                    case "left": _flags += 0; break;
                    case "center": _flags += 1; break;
                    case "right": _flags += 2; break;
                    default: break;
                }
            }
            
            //DEFAULT FONT PATCHING
            if (_text != "" && _font == null)
                _font = new Font("Segoe UI", 12, _fontStyle, GraphicsUnit.Point);

            //PADDING
            if (node.Attributes["PaddingLeft"] != null) 
                _padding.Left= Convert.ToInt32(node.Attributes["PaddingLeft"].Value);
            if (node.Attributes["PaddingTop"] != null)
                _padding.Top = Convert.ToInt32(node.Attributes["PaddingTop"].Value);
            if (node.Attributes["PaddingRight"] != null)
                _padding.Right = Convert.ToInt32(node.Attributes["PaddingRight"].Value);
            if (node.Attributes["PaddingBottom"] != null)
                _padding.Bottom = Convert.ToInt32(node.Attributes["PaddingBottom"].Value);

            updateTextBox();

            //FONT COLOR
            if (node.Attributes["Color"] != null)
                _fontBrush = new SolidBrush(ColorTranslator.FromHtml(node.Attributes["Color"].Value));
            else
                _fontBrush = Brushes.Black;
            //FONT WEIGHT
            //FONT STYLE
            if (node.Attributes["FontWeight"] != null)
            {
                if (node.Attributes["FontWeight"].Value.ToLower() == "bold")
                    _fontStyle |= FontStyle.Bold;
            }

            if (node.Attributes["FontStyle"] != null)
            {
                if (node.Attributes["FontStyle"].Value.ToLower() == "italic")
                    _fontStyle |= FontStyle.Italic;
            }

            if (node.Attributes["Underline"] != null)
            {
                if (node.Attributes["Underline"].Value.ToLower() == "true")
                    _fontStyle |= FontStyle.Underline;
            }

            if (node.Attributes["Strikeout"] != null)
            {
                if (node.Attributes["Strikeout"].Value.ToLower() == "true")
                    _fontStyle |= FontStyle.Strikeout;
            }

            //FONT FAMILY
            if ((node.Attributes["FontFamily"] != null) && (node.Attributes["FontSize"] != null))
            {
                string fs = node.Attributes["FontSize"].Value;
                if (fs.EndsWith("pt"))
                {
                    fs = fs.Substring(0, fs.Length - 2);
                    int ptsize = Convert.ToInt32(fs);
                    int pxsize = point2pixels(ptsize);
                    _font = new Font(node.Attributes["FontFamily"].Value, (int)pxsize, _fontStyle, GraphicsUnit.Point);
                }
                else
                {
                    _font = new Font(node.Attributes["FontFamily"].Value, Convert.ToInt32(fs), _fontStyle, GraphicsUnit.Point);
                }
            }
        }

        public virtual double Orientation(PointF p1, PointF p2)
        {
            //double radius = Math.Sqrt((x * x) + (y * y));
            double angle = -Math.Atan2(p1.X - p2.X, p1.Y - p2.Y);
            //MessageBox.Show(angle.ToString() + "\n" + ((angle * 180) / Math.PI).ToString());//DEBUG
            return angle;
        }

        public virtual PointF[] Rotate(PointF[] Pcord, double angle)
        {
            PointF[] newPcord = new PointF[Pcord.Length];
            for (int i = 0; i < Pcord.Length; i++)
            {

                double sin = Math.Cos(angle);
                double cos = Math.Sin(angle);
                newPcord[i].X = Convert.ToSingle(cos * Pcord[i].X + sin * Pcord[i].Y);
                newPcord[i].Y = Convert.ToSingle(-sin * Pcord[i].X + cos * Pcord[i].Y);
            }
            return newPcord;
        }

        public virtual Point[] Rotate(Point[] Pcord, double angle)
        {
            Point[] newPcord = new Point[Pcord.Length];
            for (int i = 0; i < Pcord.Length; i++)
            {

                double sin = Math.Cos(angle);
                double cos = Math.Sin(angle);
                newPcord[i].X = (int)Math.Round(cos * Pcord[i].X + sin * Pcord[i].Y);
                newPcord[i].Y = (int)Math.Round(-sin * Pcord[i].X + cos * Pcord[i].Y);
            }
            return newPcord;
        }

        public virtual PointF[] Translate(PointF[] Pcord, PointF t)
        {
            PointF[] newPcord = new PointF[Pcord.Length];
            for (int i = 0; i < Pcord.Length; i++)
            {
                newPcord[i].X = Pcord[i].X + t.X;
                newPcord[i].Y = Pcord[i].Y + t.Y;
            }

            return newPcord;

        }

        public virtual Point[] Translate(Point[] Pcord, Point t)
        {
            Point[] newPcord = new Point[Pcord.Length];
            for (int i = 0; i < Pcord.Length; i++)
            {
                newPcord[i].X = Pcord[i].X + t.X;
                newPcord[i].Y = Pcord[i].Y + t.Y;
            }

            return newPcord;

        }

        public virtual int point2pixels(double ptsize)
        {
            return (int) Math.Round(ptsize, 1, MidpointRounding.AwayFromZero);
        }

        public virtual Point[] Coordinates2Array(string c)
        {
            string[] Scords = c.Split(',');
            Point[] Pcords = new Point[Scords.Length / 2];
            for (int i = 0; i < Scords.Length - 1; i += 2)
            {
                if (Scords[i].Contains("."))
                    Scords[i] = Scords[i].Substring(0, Scords[i].IndexOf("."));
                if (Scords[i + 1].Contains("."))
                    Scords[i + 1] = Scords[i + 1].Substring(0, Scords[i].IndexOf("."));
                Pcords[i / 2].X = Convert.ToInt32(Convert.ToDouble(Scords[i]));
                Pcords[i / 2].Y = Convert.ToInt32(Convert.ToDouble(Scords[i + 1]));
            }
            return Pcords;
        }

        public virtual string CoordinateString(Point BGOffset)
        {
            string c = "";
            foreach(Point p in MarkerPoints)
            {
                c += (p.X - BGOffset.X).ToString() + ',' + (p.Y- BGOffset.Y).ToString() + ','; 
            }
            if(c.EndsWith(',')) c = c.Substring(0, c.Length - 1);
            return c;
        }

        public virtual Point[] Rectangle2Array(Rectangle rect)
        {
            Point[] MarkerPoints = new Point[4];
            MarkerPoints[0] = new Point(Box.Width / 2, 0);
            MarkerPoints[1] = new Point(Box.Width / 2, Box.Height);
            MarkerPoints[2] = new Point(0, Box.Height / 2);
            MarkerPoints[3] = new Point(Box.Width, Box.Height / 2);

            return MarkerPoints;
        }

        public virtual List<Point> Coordinates2List(string c)
        {
            string[] Scords = c.Split(',');
            List<Point> Pcords = new List<Point>();
            for (int i = 0; i < Scords.Length - 1; i += 2)
            {
                if (Scords[i].Contains("."))
                    Scords[i] = Scords[i].Substring(0, Scords[i].IndexOf("."));
                if (Scords[i + 1].Contains("."))
                    Scords[i + 1] = Scords[i + 1].Substring(0, Scords[i].IndexOf("."));
                Pcords.Add(new Point(Convert.ToInt32(Convert.ToDouble(Scords[i])), Convert.ToInt32(Convert.ToDouble(Scords[i + 1]))));
            }
            return Pcords;
        }

        public virtual string ConvertColor2HexString(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public virtual void markClipping(Graphics g, string text, Font font, Rectangle TextBox, StringFormat _stringFormat)
        {           
            int charactersFitted;
            int linesFilled;
            g.MeasureString(text, font, _textBox.Size, _stringFormat, out charactersFitted, out linesFilled);
            if(charactersFitted < text.Length)
            {
                int marker_pos = 6;
                int merker_siz = 14;
                g.FillRectangle(Brushes.Red, new Rectangle(new Point(_textBox.Right + marker_pos, _textBox.Bottom + 1), new Size(1, merker_siz - 3)));
                g.FillRectangle(Brushes.Red, new Rectangle(new Point(_textBox.Right + 1, _textBox.Bottom + marker_pos), new Size(merker_siz - 3, 1)));
                g.DrawRectangle(Pens.Red, new Rectangle(new Point(_textBox.Right - 1, _textBox.Bottom - 1), new Size(merker_siz, merker_siz)));
            }
        }

        internal void updatePolyBox()
        {
            int minX = MarkerPoints[0].X; int maxX = MarkerPoints[0].X;
            int minY = MarkerPoints[0].Y; int maxY = MarkerPoints[0].Y;

            for (int i = 1; i < MarkerPoints.Length; i++)
            {
                if (MarkerPoints[i].X > maxX) maxX = MarkerPoints[i].X;
                if (MarkerPoints[i].Y > maxY) maxY = MarkerPoints[i].Y;
                if (MarkerPoints[i].X < minX) minX = MarkerPoints[i].X;
                if (MarkerPoints[i].Y < minY) minY = MarkerPoints[i].Y;
            }

            Box.X = minX;
            Box.Y = minY;
            Box.Width = maxX - minX;
            Box.Height = maxY - minY;

            //if Size too small for Mouse Actions
            if (Box.Width < 2)
            {
                Box.X -= 2;
                Box.Width = 4;
            }
            if (Box.Height < 2)
            {
                Box.Y -= 2;
                Box.Height = 4;
            }
        }

        internal void updateTextBox()
        {
            _textBox = new Rectangle(0, 0, Box.Width, Box.Height);
            _textBox.X += _padding.Left;
            _textBox.Y += _padding.Top;
            _textBox.Width -= _padding.Right + _padding.Left;
            _textBox.Height -= _padding.Bottom + _padding.Top;
        }

        internal int getMarkerPoint(Point MousePosition)
        {
            if(MarkerPoints != null)
            {
                for (int i = 0; i < MarkerPoints.Length; i++)
                {
                    if(this.GetType().Name.Contains("Rectangle") || this.GetType().Name.Contains("Oval"))
                    {
                        //Funktioniert mit Rectangular Objects, nit mit Polyline Objects
                        if (Math.Abs(Box.X + MarkerPoints[i].X - MousePosition.X) < 4)
                        {
                            if (Math.Abs(Box.Y + MarkerPoints[i].Y - MousePosition.Y) < 4)
                            {
                                SelectedMarker = i;
                                return i;
                            }
                        }
                    }
                    if (this.GetType().Name.Contains("Polyline") || this.GetType().Name.Contains("Polygon"))
                    {
                        //Funktioniert mit Rectangular Objects, nit mit Polyline Objects
                        if (Math.Abs(MarkerPoints[i].X - MousePosition.X) < 4)
                        {
                            if (Math.Abs(MarkerPoints[i].Y - MousePosition.Y) < 4)
                            {
                                SelectedMarker = i;
                                return i;
                            }
                        }
                    }
                }
            }
            SelectedMarker = -1;
            return -1;
        }

        internal Image Base642Image(string base64String)
        {
            if (base64String == "")
            {
                return null;
            }
            try
            {
                byte[] buffer = Convert.FromBase64String(base64String);
                if (buffer != null)
                {
                    ImageConverter ic = new ImageConverter();
                    return ic.ConvertFrom(buffer) as Image;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //-----------------------------------------------------------------------------
    }

    //-----------------------------------------------
    class Root : GraphicObject
    {
        public Root()
        {
        }

        public override void Draw(Graphics g, int extd) //Root
        {
            throw new NotImplementedException();
        }

        public override void Move(Point d) //Root
        {
            throw new NotImplementedException();
        }

        public override void Reshape(Point d) //Root
        {
            throw new NotImplementedException();
        }
    }

    class MyImage : GraphicObject
    {
        private Bitmap _image;

        public MyImage(XmlNode shape, GraphicObject parent) //MyImage
        {
            Parent = parent;

            Box.X = Convert.ToInt32(shape.Attributes["X"].Value);
            Box.Y = Convert.ToInt32(shape.Attributes["Y"].Value);
            Box.Width = Convert.ToInt32(shape.Attributes["Width"].Value);
            Box.Height = Convert.ToInt32(shape.Attributes["Height"].Value);

            //wenn das Objekt zu klein zum selektieren wird
            if (Box.Width < 2)
            {
                Box.X -= 2;
                Box.Width = 4;
            }
            if (Box.Height < 2)
            {
                Box.Y -= 2;
                Box.Height = 4;
            }

            string base64String = shape.InnerText;
            _image = (Bitmap)Base642Image(base64String);
            if (_image != null && (_image.Size.Width != Box.Width || _image.Size.Height != Box.Height))
                _image = new Bitmap(_image, new Size(Box.Width, Box.Height));

            MarkerPoints = new Point[]
            {               
                new Point(Box.Width / 2, 0),
                new Point(Box.Width / 2, Box.Height),
                new Point(0, Box.Height / 2),
                new Point(Box.Width, Box.Height/2)
           };
        }

        public override void Draw(Graphics g, int extd) //MyImage
        {
            g.TranslateTransform(Box.X, Box.Y);

            if (this._image != null)
                g.DrawImage(_image, Point.Empty);
            if (extd > 0 && this.IsSelected)
            {
                Brush solidBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
                g.FillRectangle(solidBrush, 0, 0, Box.Width, Box.Height);
                for (int i = 0; i < MarkerPoints.Length; i++)
                {
                    if (SelectedMarker == i)
                        g.FillRectangle(Brushes.Black, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    else
                    {
                        g.DrawRectangle(DarkMarkerPen, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    }
                }
            }
            g.TranslateTransform(-Box.X, -Box.Y);
        }

        public override void Move(Point d)  //MyImage
        {
            Box.X += d.X;
            Box.Y += d.Y;
        }

        public override void Reshape(Point d) //MyImage
        {
            switch (SelectedMarker)
            {
                case 0: //Top
                    Box.Y += d.Y;
                    Box.Height -= d.Y;
                    break;
                case 1: //Bottom
                    Box.Height += d.Y;
                    break;
                case 2: //Left
                    Box.Width -= d.X;
                    Box.X += d.X;
                    break;
                case 3: //Right
                    Box.Width += d.X;
                    break;
            }
            MarkerPoints = Rectangle2Array(Box);
            updateTextBox();
        }
    }

    class MyRectangle : GraphicObject
    {        
        public MyRectangle(XmlNode shape, GraphicObject parent) //Rectangle
        {
            Parent = parent;

            Box.X = Convert.ToInt32(shape.Attributes["X"].Value);
            Box.Y = Convert.ToInt32(shape.Attributes["Y"].Value);
            Box.Width = Convert.ToInt32(shape.Attributes["Width"].Value);
            Box.Height = Convert.ToInt32(shape.Attributes["Height"].Value);
            //if Size too small for Mouse Actions
            if (Box.Width < 2)
            {
                Box.X -= 2;
                Box.Width = 4;
            }
            if (Box.Height < 2)
            {
                Box.Y -= 2;
                Box.Height = 4;
            }

            MarkerPoints = Rectangle2Array(Box);

            Color _penColor = Color.Black;
            if (shape.Attributes["LineColor"] != null) _penColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

            int _penWidth = 0;
            if (shape.Attributes["LineWidth"] != null) _penWidth = Convert.ToInt32(shape.Attributes["LineWidth"].Value);

            _pen = new Pen(_penColor, _penWidth);

            if (shape.Attributes["BackgroundColor"] != null)
            {
                string sBackGroundColor = shape.Attributes["BackgroundColor"].Value;
                //Box zeichnen (außer bei "transparent");
                if (sBackGroundColor != "transparent")
                {
                    Color brushColor = ColorTranslator.FromHtml(sBackGroundColor);
                    _fillBrush = new SolidBrush(brushColor);
                }
            }

            if (shape.InnerText != null && shape.InnerText != "")
            {
                _text = shape.InnerText;
                getTextAttributes(shape);
            }
        }

        public override void Draw(Graphics g, int extd) //Rectangle
        {

            g.TranslateTransform(Box.X, Box.Y);
            if (_fillBrush != null) g.FillRectangle(_fillBrush, 0, 0, Box.Width, Box.Height);
            if(_pen.Width > 0) g.DrawRectangle(_pen, 0, 0, Box.Width, Box.Height);
            if (_text != "")
            {
                setStringAlignment();
                g.DrawString(_text, _font, _fontBrush, _textBox, _stringFormat);
                if (extd > 0)
                {
                    markClipping(g, _text, _font, _textBox, _stringFormat);
                }

            }
            if (extd > 0 && this.IsSelected)
            {
                Brush solidBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
                g.FillRectangle(solidBrush, 0, 0, Box.Width, Box.Height);
                for (int i = 0; i < MarkerPoints.Length; i++)
                {
                    if (SelectedMarker == i)
                        g.FillRectangle(Brushes.Black, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    else
                    {
                        g.DrawRectangle(DarkMarkerPen, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    }
                }
            }            
            g.TranslateTransform(-Box.X, -Box.Y);
        }

        public override void Move(Point d)  //Rectangle
        {
            Box.X += d.X;
            Box.Y += d.Y;
        }

        public override void Reshape(Point d) //Rectangle
        {
            switch (SelectedMarker)
            {
                case 0: //Top
                    Box.Y += d.Y; 
                    Box.Height -= d.Y;
                    break;
                case 1: //Bottom
                    Box.Height += d.Y;
                    break;
                case 2: //Left
                    Box.Width -= d.X; 
                    Box.X += d.X;
                     break;                                
                case 3: //Right
                    Box.Width += d.X;
                    break;
            }
            MarkerPoints = Rectangle2Array(Box);
            updateTextBox();
        } 
    }

    class MyGroup : GraphicObject
    {
        public MyGroup(XmlNode shape, GraphicObject parent) //Group
        {
            Parent = parent;

            Box.X = Convert.ToInt32(shape.Attributes["X"].Value);
            Box.Y = Convert.ToInt32(shape.Attributes["Y"].Value);
            Box.Width = Convert.ToInt32(shape.Attributes["Width"].Value);
            Box.Height = Convert.ToInt32(shape.Attributes["Height"].Value);

            foreach (XmlNode child in shape.ChildNodes)
            {
                Add(child, this);
            }
        }

        public MyGroup(List<GraphicObject> objects, GraphicObject parent)
        {
            Children = new List<GraphicObject>();
            Parent = parent;
            Point Offset = getOffset(Parent);

            int minX = objects[0].Box.X;
            int minY = objects[0].Box.Y;
            int maxX = objects[0].Box.X + objects[0].Box.Width;
            int maxY = objects[0].Box.Y + objects[0].Box.Height;

            foreach (GraphicObject g in objects)
            {
                if (g.Box.X < minX) minX = g.Box.X;
                if (g.Box.Y < minY) minY = g.Box.Y;
                if (g.Box.X + g.Box.Width > maxX) maxX = g.Box.X + g.Box.Width;
                if (g.Box.Y + g.Box.Height > maxY) maxY = g.Box.Y + g.Box.Height;
                g.UnSelect();
            }

            Box = new System.Drawing.Rectangle(minX + Offset.X, minY + Offset.Y, maxX - minX, maxY - minY);

            foreach (GraphicObject g in objects)
            {
                this.Children.Add(g);
                Parent.Children.Remove(g);

                g.Move(new Point(-this.Box.X, -this.Box.Y));
            }
            Parent.Children.Add(this);
        }

        public MyGroup() 
        { 
        }

        public override void Draw(Graphics g, int extd) //Group
        {
            g.TranslateTransform(Box.X, Box.Y);
            
            if (extd > 0)
            {
                g.DrawRectangle(LightMarkerPen, 0, 0, Box.Width, Box.Height);
                if (this.IsSelected)
                {
                    g.DrawRectangle(DarkMarkerPen, 0, 0, Box.Width, Box.Height);
                    Brush solidBrush = new SolidBrush(Color.FromArgb(64, 0, 255, 0));
                    g.FillRectangle(solidBrush, 0, 0, Box.Width, Box.Height);
                }                              
            }
            foreach (GraphicObject child in Children)
            {
                child.Draw(g, extd);
            }
            g.TranslateTransform(-Box.X, -Box.Y);
        }

        public override void Move(Point d) //Group
        {
            Box.X += d.X;
            Box.Y += d.Y;
        }

        public override void Reshape(Point d) //Group
        {
            throw new NotImplementedException();
        }
    }

    class MyOval : GraphicObject
    {
        public MyOval(XmlNode shape, GraphicObject parent) //Oval
        {
            Parent = parent;

            Box.X = Convert.ToInt32(shape.Attributes["X"].Value);
            Box.Y = Convert.ToInt32(shape.Attributes["Y"].Value);
            Box.Width = Convert.ToInt32(shape.Attributes["Width"].Value);
            Box.Height = Convert.ToInt32(shape.Attributes["Height"].Value);

            //if Size too small for Mouse Actions
            if (Box.Width < 2)
            {
                Box.X -= 2;
                Box.Width = 4;
            }
            if (Box.Height < 2)
            {
                Box.Y -= 2;
                Box.Height = 4;
            }

            MarkerPoints = Rectangle2Array(Box);

            Color penColor = Color.Black;
            if (shape.Attributes["LineColor"] != null) penColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

            int penWidth = 0;
            if (shape.Attributes["LineWidth"] != null) penWidth = Convert.ToInt32(shape.Attributes["LineWidth"].Value);

            _pen = new Pen(penColor, penWidth);

            if (shape.Attributes["BackgroundColor"] != null)
            {
                string sBackGroundColor = shape.Attributes["BackgroundColor"].Value;
                //Box zeichnen (außer bei "transparent");
                if (sBackGroundColor != "transparent")
                {
                    Color brushColor = ColorTranslator.FromHtml(sBackGroundColor);
                    _fillBrush = new SolidBrush(brushColor);
                }
            }

            if (shape.InnerText != null && shape.InnerText != "")
            {
                _text = shape.InnerText;
                getTextAttributes(shape);
            }
        }

        public override void Draw(Graphics g, int extd) //Oval
        {
            g.TranslateTransform(Box.X, Box.Y);
            if (_fillBrush != null) g.FillEllipse(_fillBrush, 0, 0, Box.Width, Box.Height);
            if (_pen.Width > 0) g.DrawEllipse(_pen, 0, 0, Box.Width, Box.Height);
            if (_text != "")
            {
                setStringAlignment();
                g.DrawString(_text, _font, _fontBrush, _textBox, _stringFormat);
                if (extd > 0)
                {
                    markClipping(g, _text, _font, _textBox, _stringFormat);
                }
            }
            if (extd > 0 && this.IsSelected)
            {
                Brush solidBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
                g.FillEllipse(solidBrush, 0, 0, Box.Width, Box.Height);
                for (int i = 0; i < MarkerPoints.Length; i++)
                {
                    if (SelectedMarker == i)
                        g.FillRectangle(Brushes.Black, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    else
                    {
                        g.DrawRectangle(DarkMarkerPen, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    }
                }
            }
            g.TranslateTransform(-Box.X, -Box.Y);
        }

        public override void Move(Point d)  //Ellipse
        {
            Box.X += d.X;
            Box.Y += d.Y;
        }

        public override void Reshape(Point d) //Ellipse
        {
            switch (SelectedMarker)
            {
                case 0: //Top
                    Box.Y += d.Y;
                    Box.Height -= d.Y;
                    break;
                case 1: //Bottom
                    Box.Height += d.Y;
                    break;
                case 2: //Left
                    Box.Width -= d.X;
                    Box.X += d.X;
                    break;
                case 3: //Right
                    Box.Width += d.X;
                    break;
            }
            MarkerPoints = Rectangle2Array(Box);
            updateTextBox();
            //throw new NotImplementedException();
        }
    }    

    class MyPolyline : GraphicObject
    {
        ArrowTip tipEnd = null;
        ArrowTip tailEnd = null;
        public MyPolyline(XmlNode shape, GraphicObject parent) //Polyline
        {
            Parent = parent;

            MarkerPoints = Coordinates2Array(shape.Attributes["Coordinates"].Value);
            updatePolyBox();

            Color penColor = Color.Black;
            if (shape.Attributes["LineColor"] != null) penColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

            int penWidth = 1;
            if (shape.Attributes["LineWidth"] != null) penWidth = Convert.ToInt32(shape.Attributes["LineWidth"].Value);

            _pen = new Pen(penColor, penWidth);

            if (shape.Attributes["ArrowHeadCenterLength"] != null)
                ArrowHeadCenterLength = Convert.ToSingle(shape.Attributes["ArrowHeadCenterLength"].Value);
            if (shape.Attributes["ArrowHeadLength"] != null)
                ArrowHeadLength = Convert.ToSingle(shape.Attributes["ArrowHeadLength"].Value);
            if (shape.Attributes["ArrowHeadWidth"] != null)
                ArrowHeadWidth = Convert.ToSingle(shape.Attributes["ArrowHeadWidth"].Value);


            if (shape.Attributes["ArrowTailCenterLength"] != null)
                ArrowTailCenterLength = Convert.ToSingle(shape.Attributes["ArrowTailCenterLength"].Value);
            if (shape.Attributes["ArrowTailLength"] != null)
                ArrowTailLength = Convert.ToSingle(shape.Attributes["ArrowTailLength"].Value);
            if (shape.Attributes["ArrowTailWidth"] != null)
                ArrowTailWidth = Convert.ToSingle(shape.Attributes["ArrowTailWidth"].Value);

            //ArrowHeads="none","ends","tail","head"
            //ArrowHeads="head" same as ArrowHeads==null
            int n = MarkerPoints.Length;
            if (shape.Attributes["ArrowHeads"] == null)
            {
                tipEnd = new ArrowTip(MarkerPoints[n - 1], MarkerPoints[n - 2], _pen, ArrowHeadWidth, ArrowHeadLength, ArrowHeadCenterLength, 0);
            }
            else
            {
                switch (shape.Attributes["ArrowHeads"].Value)
                {
                    case "head":
                        tipEnd = new ArrowTip(MarkerPoints[n - 1], MarkerPoints[n - 2], _pen, ArrowHeadWidth, ArrowHeadLength, ArrowHeadCenterLength, 0);
                        break;
                    case "tail":
                        tipEnd = new ArrowTip(MarkerPoints[0], MarkerPoints[1], _pen, ArrowHeadWidth, ArrowHeadLength, ArrowHeadCenterLength, 0);
                        break;
                    //case "center": break;
                    case "ends":
                        tipEnd = new ArrowTip(MarkerPoints[n - 1], MarkerPoints[n - 2], _pen, ArrowHeadWidth, ArrowHeadLength, ArrowHeadCenterLength, 0);
                        tailEnd = new ArrowTip(MarkerPoints[0], MarkerPoints[1], _pen, ArrowHeadWidth, ArrowHeadLength, ArrowHeadCenterLength, 0);
                        break;
                    case "none": break;
                    //case "everywhere": break;
                    default: break;
                }

                if (shape.Attributes["ArrowTails"] != null)
                {
                    switch (shape.Attributes["ArrowTails"].Value)
                    {
                        case "head":
                            tailEnd = new ArrowTip(MarkerPoints[n - 1], MarkerPoints[n - 2], _pen, ArrowTailWidth, ArrowTailLength, ArrowTailCenterLength, _PI);
                            break;
                        case "tail":
                            tailEnd = new ArrowTip(MarkerPoints[0], MarkerPoints[1], _pen, ArrowTailWidth, ArrowTailLength, ArrowTailCenterLength, _PI);
                            break;
                        case "center": break;
                        case "ends":
                            tailEnd = new ArrowTip(MarkerPoints[n - 1], MarkerPoints[n - 2], _pen, ArrowTailWidth, ArrowTailLength, ArrowTailCenterLength, _PI);
                            tipEnd = new ArrowTip(MarkerPoints[0], MarkerPoints[1], _pen, ArrowTailWidth, ArrowTailLength, ArrowTailCenterLength, _PI);
                            break;
                        case "none": break;
                        case "everywhere": break;
                        default: break;
                    }
                }

            }
        }

        public override void Draw(Graphics g, int extd) //Polyline
        {
            g.DrawLines(_pen, MarkerPoints);

            if (tipEnd != null)
            {
                tipEnd.Draw(g, extd);
            }
            if (tailEnd != null)
            {
                tailEnd.Draw(g, extd);
            }

            if (extd > 0 && this.IsSelected)
            {
                Brush solidBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
                g.FillRectangle(solidBrush, Box.X, Box.Y, Box.Width, Box.Height);
                for (int i = 0; i < MarkerPoints.Length; i++)
                {
                    if (SelectedMarker == i)
                        g.FillRectangle(Brushes.Black, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    else
                    {
                        g.DrawRectangle(DarkMarkerPen, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    }
                }
            }
        }

        public override void Move(Point d)  //Polyline
        {
            Box.X += d.X;
            Box.Y += d.Y;

            for (int i = 0; i < MarkerPoints.Length; i++)
            {
                MarkerPoints[i].X += d.X;
                MarkerPoints[i].Y += d.Y;
            }

            if (tipEnd != null)
            {
                tipEnd.Move(d);
            }
            if (tailEnd != null)
            {
                tailEnd.Move(d);
            }
        }

        public override void Reshape(Point d) //Polyline
        {
            double oldTailAngle = Orientation(MarkerPoints[0], MarkerPoints[1]);
            double oldTipAngle = Orientation(MarkerPoints[MarkerPoints.Length - 1], MarkerPoints[MarkerPoints.Length - 2]);

            MarkerPoints[SelectedMarker].X += d.X;
            MarkerPoints[SelectedMarker].Y += d.Y;

            updatePolyBox();

            if (tipEnd != null)
            {
                if (SelectedMarker == MarkerPoints.Length - 1) tipEnd.Move(d);
                tipEnd.AdjustDirection((float)Orientation(MarkerPoints[MarkerPoints.Length - 1], MarkerPoints[MarkerPoints.Length - 2]) - (float)oldTipAngle);
            }
            if (tailEnd != null)
            {
                if (SelectedMarker == 0) tailEnd.Move(d);
                tailEnd.AdjustDirection((float)Orientation(MarkerPoints[0], MarkerPoints[1]) - (float)oldTailAngle);
            }
        }
    }

    class MyPolygon : GraphicObject
    {
        public MyPolygon(XmlNode shape, GraphicObject parent) //Polygon
        {
            Parent = parent;

            MarkerPoints = Coordinates2Array(shape.Attributes["Coordinates"].Value);
            int n = MarkerPoints.Length;

            {
                int minX = MarkerPoints[0].X; int maxX = MarkerPoints[0].X;
                int minY = MarkerPoints[0].Y; int maxY = MarkerPoints[0].Y;

                for (int i = 1; i < MarkerPoints.Length; i++)
                {
                    if (MarkerPoints[i].X > maxX) maxX = MarkerPoints[i].X;
                    if (MarkerPoints[i].Y > maxY) maxY = MarkerPoints[i].Y;
                    if (MarkerPoints[i].X < minX) minX = MarkerPoints[i].X;
                    if (MarkerPoints[i].Y < minY) minY = MarkerPoints[i].Y;
                }

                Box.X = minX;
                Box.Y = minY;
                Box.Width = maxX - minX;
                Box.Height = maxY - minY;

                //if Size too small for Mouse Actions
                if (Box.Width < 2)
                {
                    Box.X -= 2;
                    Box.Width = 4;
                }
                if (Box.Height < 2)
                {
                    Box.Y -= 2;
                    Box.Height = 4;
                }


                Color _penColor = Color.Black;
                if (shape.Attributes["LineColor"] != null) 
                    _penColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

                int _penWidth = 0;
                if (shape.Attributes["LineWidth"] != null) 
                    _penWidth = Convert.ToInt32(shape.Attributes["LineWidth"].Value);

                _pen = new Pen(_penColor, _penWidth);

                if (shape.Attributes["BackgroundColor"] != null)
                {
                    string sBackGroundColor = shape.Attributes["BackgroundColor"].Value;
                    //Draw box - except "transparent";
                    if (sBackGroundColor != "transparent")
                    {
                        Color brushColor = ColorTranslator.FromHtml(sBackGroundColor);
                        _fillBrush = new SolidBrush(brushColor);
                    }
                }
            }

            Color penColor = Color.Black;
            if (shape.Attributes["LineColor"] != null) penColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

            int penWidth = 1;
            if (shape.Attributes["LineWidth"] != null) penWidth = Convert.ToInt32(shape.Attributes["LineWidth"].Value);

            _pen = new Pen(penColor, penWidth);
        }

        public override void Draw(Graphics g, int extd) //Polygon
        {
            if (_fillBrush != null) g.FillPolygon(_fillBrush, MarkerPoints);
            if (_pen.Width > 0) g.DrawPolygon(_pen, MarkerPoints);

            if (extd > 0 && this.IsSelected)
            {
                Brush solidBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
                g.FillRectangle(solidBrush, Box.X, Box.Y, Box.Width, Box.Height);
                for (int i = 0; i < MarkerPoints.Length; i++)
                {
                    if (SelectedMarker == i)
                        g.FillRectangle(Brushes.Black, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    else
                    {
                        g.DrawRectangle(DarkMarkerPen, new Rectangle(new Point(MarkerPoints[i].X - 4, MarkerPoints[i].Y - 4), new Size(8, 8)));
                    }
                }
            }
        }

        public override void Move(Point d)  //Polygon
        {
            Box.X += d.X;
            Box.Y += d.Y;

            for (int i = 0; i < MarkerPoints.Length; i++)
            {
                MarkerPoints[i].X += d.X;
                MarkerPoints[i].Y += d.Y;
            }
        }

        public override void Reshape(Point d) //Polygon
        {
            MarkerPoints[SelectedMarker].X += d.X;
            MarkerPoints[SelectedMarker].Y += d.Y;

            updatePolyBox();
        }
    }

    class ArrowTip : GraphicObject
    {
        public PointF _tip;
        double _orientation;
        Pen _pen;
        Brush _brush;
        PointF[] Points = new PointF[4];
        Point Position = new Point(0, 0);

        public ArrowTip(PointF p1, PointF p2, Pen pen, float Width, float Length, float CenterLength, float rot)
        {
            _tip.X = p1.X;
            _tip.Y = p1.Y;
            _orientation = Orientation(p1, p2);
            _pen = pen;
            _brush = new SolidBrush(pen.Color);

            Points[0].Y = 0;
            Points[0].X = 0;
            Points[1].Y = -Width / 2;
            Points[1].X = Length;
            Points[2].Y = 0;
            Points[2].X = CenterLength;
            Points[3].Y = Width / 2;
            Points[3].X = Length;

            Points = Rotate(Points, _orientation + rot);
            Points = Translate(Points, p1);
        }

        public void AdjustDirection(float angle)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].X = (float)(_tip.X + (Points[i].X - _tip.X) * Math.Cos(angle) - (Points[i].Y - _tip.Y) * Math.Sin(angle));
                Points[i].Y = (float)(_tip.Y + (Points[i].X - _tip.X) * Math.Sin(angle) + (Points[i].Y - _tip.Y) * Math.Cos(angle));
            }
        }

        public override void Move(Point d)
        {
            for (int i = 0; i < Points.Length; i++)
            //foreach(PointF p in _points) 
            {
                Points[i].X += d.X;
                Points[i].Y += d.Y;
            }
            _tip.X += d.X;
            _tip.Y += d.Y;
            Position.X = Position.X + d.X;
            Position.Y = Position.Y + d.Y;
        }

        public override void Reshape(Point d) //ArrowTip
        {
            //--> Polyline.reshape
        }

        public override void Draw(Graphics g, int extd) //ArrowTip
        {
            g.FillPolygon(_brush, Points);
        }

    }

}
