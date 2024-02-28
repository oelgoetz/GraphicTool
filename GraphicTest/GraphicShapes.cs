using GraphicTool;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
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
        public string _type;
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

        internal ArrowHeadAtHead arrowHeadAtHead = null;
        internal ArrowTailAtHead arrowTailAtHead = null;
        internal ArrowHeadAtTail arrowHeadAtTail = null;
        internal ArrowTailAtTail arrowTailAtTail = null;

        int defaultCenter = 8;
        int defaultWidth = 12;
        int defaultLength = 16;

        public int ArrowHeadCenter = 15;
        public int ArrowHeadLength = 25;
        public int ArrowHeadWidth = 20;
        public int ArrowTailCenter = 15;
        public int ArrowTailLength = 25;
        public int ArrowTailWidth = 20;
        public Color ArrowHeadColor = Color.Black;
        public Color ArrowTailColor = Color.Black;

        public Point[] MarkerPoints;

        public bool IsSelected = false;

        public abstract void Draw(Graphics g, int extd);

        public abstract void Move(Point d);

        public abstract void Reshape(Point d);

        internal void Ungroup(GraphicObject parent)
        {
            foreach (GraphicObject obj in Children)
            {
                parent.Children.Add(obj);
                obj.Move(new Point(this.Box.X, this.Box.Y));
            }
            this.Children.Clear();
            parent.Children.Remove(this);
        }

        internal void Add(XmlNode shape, GraphicObject Parent)
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

        internal void Select()
        {
            IsSelected = true;
        }

        internal void UnSelect()
        {
            IsSelected = false;
        }

        public Point getOffset(GraphicObject Parent)
        {
            Point result = Point.Empty;
            while (Parent != null && Parent._type == "Root") //GetType().Name != "Root")
            {
                result.X += Parent.Box.Location.X;
                result.Y += Parent.Box.Location.Y;
                Parent = Parent.Parent;
            }
            return result;
        }

        //--------------------------------------------------

        internal void setStringAlignment()
        {
            _stringFormat = StringFormat.GenericTypographic;
            _stringFormat.Alignment = StringAlignment.Near;
            _stringFormat.LineAlignment = StringAlignment.Near;

            if ((_flags & 1) == 1) _stringFormat.Alignment |= StringAlignment.Center;
            if ((_flags & 2) == 2) _stringFormat.Alignment |= StringAlignment.Far;
            if ((_flags & 4) == 4) _stringFormat.LineAlignment |= StringAlignment.Center;
            if ((_flags & 8) == 8) _stringFormat.LineAlignment |= StringAlignment.Far;
        }

        internal void getTextAttributes(XmlNode node)
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

        internal double Orientation(PointF p1, PointF p2)
        {
            //double radius = Math.Sqrt((x * x) + (y * y));
            double angle = -Math.Atan2(p1.X - p2.X, p1.Y - p2.Y);
            //MessageBox.Show(angle.ToString() + "\n" + ((angle * 180) / Math.PI).ToString());//DEBUG
            return angle;
        }

        internal PointF[] Rotate(PointF[] Pcord, double angle)
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

        internal Point[] Rotate(Point[] Pcord, double angle)
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

        internal PointF[] Translate(PointF[] Pcord, PointF t)
        {
            PointF[] newPcord = new PointF[Pcord.Length];
            for (int i = 0; i < Pcord.Length; i++)
            {
                newPcord[i].X = Pcord[i].X + t.X;
                newPcord[i].Y = Pcord[i].Y + t.Y;
            }

            return newPcord;

        }

        internal Point[] Translate(Point[] Pcord, Point t)
        {
            Point[] newPcord = new Point[Pcord.Length];
            for (int i = 0; i < Pcord.Length; i++)
            {
                newPcord[i].X = Pcord[i].X + t.X;
                newPcord[i].Y = Pcord[i].Y + t.Y;
            }

            return newPcord;

        }

        internal int point2pixels(double ptsize)
        {
            return (int) Math.Round(ptsize, 1, MidpointRounding.AwayFromZero);
        }

        internal Point[] Coordinates2Array(string c)
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

        internal string CoordinateString(Point BGOffset)
        {
            string c = "";
            foreach(Point p in MarkerPoints)
            {
                c += (p.X - BGOffset.X).ToString() + ',' + (p.Y- BGOffset.Y).ToString() + ','; 
            }
            if(c.EndsWith(',')) c = c.Substring(0, c.Length - 1);
            return c;
        }

        internal Point[] Rectangle2Array(Rectangle rect)
        {
            Point[] MarkerPoints = new Point[4];
            MarkerPoints[0] = new Point(Box.Width / 2, 0);
            MarkerPoints[1] = new Point(Box.Width / 2, Box.Height);
            MarkerPoints[2] = new Point(0, Box.Height / 2);
            MarkerPoints[3] = new Point(Box.Width, Box.Height / 2);

            return MarkerPoints;
        }

        internal List<Point> Coordinates2List(string c)
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

        internal string ConvertColor2HexString(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        internal void markClipping(Graphics g, string text, Font font, Rectangle TextBox, StringFormat _stringFormat)
        {           
            if (text == null || text.Length == 0) return;
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
                    if (this._type == "Rectangle" || this._type == "Oval")
                    {
                        //Funktioniert mit Rectangular Objects, nicht mit Polyline Objects
                        if (Math.Abs(Box.X + MarkerPoints[i].X - MousePosition.X) < 4)
                        {
                            if (Math.Abs(Box.Y + MarkerPoints[i].Y - MousePosition.Y) < 4)
                            {
                                SelectedMarker = i;
                                return i;
                            }
                        }
                    }
                    if (this._type == "Polyline" || this._type == "Polygon")                        
                    {
                        //Funktioniert mit Rectangular Objects, nicht mit Polyline Objects
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

        internal void SetLineColor(Color color)
        {
            _pen.Color = color;
            if (this._type == "Polyline")
            {
                if (arrowHeadAtHead != null) arrowHeadAtHead.SetBrushColor(color);
                if (arrowHeadAtTail != null) arrowHeadAtTail.SetBrushColor(color);
                if (arrowTailAtTail != null) arrowTailAtTail.SetBrushColor(color);
                if (arrowTailAtHead != null) arrowTailAtHead.SetBrushColor(color);
                //_g.ArrowHeadColor

            }
        }

        internal void SetLineWidth(int width)
        {
            _pen.Width = width;
        }

        internal void SetFontSize(int size)
        {
            _font = new Font(_font.FontFamily, Convert.ToInt32(size), _fontStyle, GraphicsUnit.Point);
        }

        internal void SetFontFamily(string f)
        {
            try
            {
                _font = new Font(f, _font.Size, _fontStyle, GraphicsUnit.Point);
            }
            catch
            {
                MessageBox.Show(f + " is no valid Font family!");
            }
        }

        internal void SetFontStyle(FontStyle f)
        {
            _font = new Font(_font.FontFamily, _font.Size, f, GraphicsUnit.Point);
        }

        internal void SetPadding(Padding padding)
        {
            _padding = padding;
            updateTextBox();

        }

        internal void deserialize(XmlNode Node, Point BGOffset)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                GraphicObject g = Children[i];
                XmlElement Shape = Node.OwnerDocument.CreateElement("Shape");
                Node.AppendChild(Shape);
                string type = g._type;
                Attribute(Shape, "Type", type);
                
                if (type == "Polyline" || type == "Polygon")
                {
                    Attribute(Shape, "Coordinates", g.CoordinateString(BGOffset));                    
                }
                else
                {
                    Attribute(Shape, "X", (g.Box.X - BGOffset.X).ToString());
                    Attribute(Shape, "Y", (g.Box.Y - BGOffset.Y).ToString());
                    Attribute(Shape, "Width", g.Box.Width.ToString());
                    Attribute(Shape, "Height", g.Box.Height.ToString());
                }

                if (type == "Polyline")
                {
                    //ArrowHeads="none","ends","tail","head"
                    //ArrowHeads="head" same as ArrowHeads==null

                    if (g.arrowHeadAtHead != null && g.arrowHeadAtTail != null) Attribute(Shape, "ArrowHeads", "ends");
                    if (g.arrowHeadAtHead == null && g.arrowHeadAtTail != null) Attribute(Shape, "ArrowHeads", "tail");
                    //if (g.arrowHeadAtHead != null && g.arrowHeadAtTail == null) Attribute(Shape, "ArrowHeads", "head");
                    if (g.arrowHeadAtHead == null && g.arrowHeadAtTail == null) Attribute(Shape, "ArrowHeads", "none");
                    
                    if (g.arrowHeadAtHead != null || g.arrowHeadAtHead != null)
                    {
                        Attribute(Shape, "ArrowHeadCenterLength", g.ArrowHeadCenter.ToString());
                        Attribute(Shape, "ArrowHeadLength", g.ArrowHeadLength.ToString());
                        Attribute(Shape, "ArrowHeadWidth", g.ArrowHeadWidth.ToString());
                        Attribute(Shape, "ArrowHeadColor", ColorTranslator.ToHtml(g.ArrowHeadColor));
                    }

                    if (g.arrowTailAtTail != null && g.arrowTailAtHead != null) Attribute(Shape, "ArrowTails", "ends");
                    if (g.arrowTailAtTail == null && g.arrowTailAtHead != null) Attribute(Shape, "ArrowTails", "head");
                    if (g.arrowTailAtTail != null && g.arrowTailAtHead == null) Attribute(Shape, "ArrowTails", "tail");
                    if (g.arrowTailAtTail == null && g.arrowTailAtHead == null) Attribute(Shape, "ArrowTails", "none");

                    if (g.arrowTailAtHead != null || g.arrowTailAtTail != null)
                    {
                        Attribute(Shape, "ArrowTailCenterLength", g.ArrowTailCenter.ToString());
                        Attribute(Shape, "ArrowTailLength", g.ArrowTailLength.ToString());
                        Attribute(Shape, "ArrowTailWidth", g.ArrowTailWidth.ToString());
                        Attribute(Shape, "ArrowTailColor", ColorTranslator.ToHtml(g.ArrowTailColor));
                    }
                }

                if (g._pen != null && g._pen.Width > 0)
                {
                    Attribute(Shape, "LineWidth", g._pen.Width.ToString());
                    Attribute(Shape, "LineColor", ColorTranslator.ToHtml(g._pen.Color));
                }

                if (g._fillBrush != null)
                {
                    Color BackColor = ((SolidBrush)g._fillBrush).Color;
                    Attribute(Shape, "BackgroundColor", ColorTranslator.ToHtml(BackColor));
                }

                if (g._text != "")
                {
                    Shape.InnerText = g._text;
                }

                if (g._padding != null)
                {
                    Attribute(Shape, "PaddingLeft", g._padding.Left.ToString());
                    Attribute(Shape, "PaddingTop", g._padding.Top.ToString());
                    Attribute(Shape, "PaddingRight", g._padding.Right.ToString());
                    Attribute(Shape, "PaddingBottom", g._padding.Bottom.ToString());
                }

                if (g._flags < 4)
                {
                    Attribute(Shape, "VerticalAlign", "top");
                    if (g._flags == 0) Attribute(Shape, "TextAlign", "left");
                    if ((g._flags & 1) == 1) Attribute(Shape, "TextAlign", "center");
                    if ((g._flags & 2) == 2) Attribute(Shape, "TextAlign", "right");
                }
                else
                {
                    if ((g._flags & 1) == 1)
                        Attribute(Shape, "TextAlign", "center");
                    else
                        if ((g._flags & 2) == 2)
                        Attribute(Shape, "TextAlign", "right");
                    else
                        Attribute(Shape, "TextAlign", "left");
                    if ((g._flags & 4) == 4) Attribute(Shape, "VerticalAlign", "center");
                    if ((g._flags & 8) == 8) Attribute(Shape, "VerticalAlign", "bottom");

                }

                if (g._font != null)
                {
                    Attribute(Shape, "FontFamily", g._font.Name.ToString());
                    Attribute(Shape, "FontSize", g._font.Size.ToString());
                    Attribute(Shape, "FontStyle", g._font.Style.ToString());
                    string colorstring = ColorTranslator.ToHtml(((SolidBrush) g._fontBrush).Color);
                    Attribute(Shape, "Color", colorstring);

                    if (g._font.Bold)
                        Attribute(Shape, "FontWeight", "bold");
                    else
                        Attribute(Shape, "FontWeight", "normal");

                    if (g._font.Underline)
                        Attribute(Shape, "Underline", "true");
                    else
                        Attribute(Shape, "Underline", "false");

                    if (g._font.Italic)
                        Attribute(Shape, "FontStyle", "italic");
                    else
                        Attribute(Shape, "FontStyle", "normal");

                    if (g._font.Strikeout)
                        Attribute(Shape, "Strikeout", "true");
                    else
                        Attribute(Shape, "Strikeout", "false");

                }                

                    //Recursive call for Groups
                    if (g._type == "Group")
                        g.deserialize(Shape, BGOffset);
            }

            //----------//OK:
            //Type
            //Coordinates
            //Width   ?Coordinates?
            //Height  ?Coordinates?
            //X
            //Y
            //LineWidth
            //LineColor
            //BackgroundColor

            //TEXT: InnerText!
            //PaddingLeft
            //PaddingBottom
            //PaddingRight
            //PaddingTop
            //FontStyle
            //FontFamily
            //FontSize
            //FontWeight
            //Underline                        
            //TextAlign
            //VerticalAlign

            //NOT SUPPORTED:
            //CornerRadius
            //Rotation
            //ShapeTimeSpan
            //Transparency
            //EnableShadow
            //Right
            //Bottom
            //BackgroundColorAlt
            //Left
            //Top

            ////Polyine:
            //ArrowHeadColor
        }

        private void Attribute(XmlNode node, string name, string value)
        {
            if (node.Attributes[name] == null)
            {
                XmlAttribute newAtt = node.OwnerDocument.CreateAttribute(name);
                node.Attributes.Append(newAtt);
            }
            node.Attributes[name].Value = value.ToString();
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

        public void liftUp(GraphicObject g)
        {

        }

        public void sinkDown(GraphicObject g)
        {

        }

        public void liftUpMost(GraphicObject g)
        {

        }

        public void sinkLowest(GraphicObject g)
        {

        }
    }

    class MyImage : GraphicObject
    {
        private Bitmap _image;

        public MyImage(XmlNode shape, GraphicObject parent) //MyImage
        {
            Parent = parent;
            _type = "Image";
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
            _type = "Rectangle";
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

            getTextAttributes(shape);
            _text = shape.InnerText;
            if (_text != "" && _font == null) _font = defaultFont;

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
            _type = "Group";
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
            _type = "Group";
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
            _type = "Group";
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
            _type = "Oval";
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

            getTextAttributes(shape);
            _text = shape.InnerText;
            if(_text != "" && _font == null) _font = defaultFont;
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
        }
    }    

    class MyPolyline : GraphicObject
    {
        public MyPolyline(XmlNode shape, GraphicObject parent) //Polyline
        {
            Parent = parent;
            _type = "Polyline";
            MarkerPoints = Coordinates2Array(shape.Attributes["Coordinates"].Value);
            updatePolyBox();

            Color penColor = Color.Black;
            if (shape.Attributes["LineColor"] != null) penColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

            int penWidth = 1;
            if (shape.Attributes["LineWidth"] != null) penWidth = Convert.ToInt32(shape.Attributes["LineWidth"].Value);

            _pen = new Pen(penColor, penWidth);

            if (shape.Attributes["ArrowHeadCenterLength"] != null)
                ArrowHeadCenter = Convert.ToInt16(shape.Attributes["ArrowHeadCenterLength"].Value);
            if (shape.Attributes["ArrowHeadLength"] != null)
                ArrowHeadLength = Convert.ToInt16(shape.Attributes["ArrowHeadLength"].Value);
            if (shape.Attributes["ArrowHeadWidth"] != null)
                ArrowHeadWidth = Convert.ToInt16(shape.Attributes["ArrowHeadWidth"].Value);

            if (shape.Attributes["ArrowTailCenterLength"] != null)
                ArrowTailCenter = Convert.ToInt16(shape.Attributes["ArrowTailCenterLength"].Value);
            if (shape.Attributes["ArrowTailLength"] != null)
                ArrowTailLength = Convert.ToInt16(shape.Attributes["ArrowTailLength"].Value);
            if (shape.Attributes["ArrowTailWidth"] != null)
                ArrowTailWidth = Convert.ToInt16(shape.Attributes["ArrowTailWidth"].Value);

            if(shape.Attributes["ArrowTailColor"] != null)
                ArrowTailColor = ColorTranslator.FromHtml(shape.Attributes["ArrowTailColor"].Value);
            else
                if(shape.Attributes["LineColor"] != null)
                    ArrowTailColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);
            
            if (shape.Attributes["ArrowHeadColor"] != null)
                ArrowHeadColor = ColorTranslator.FromHtml(shape.Attributes["ArrowHeadColor"].Value);
            else
                if (shape.Attributes["LineColor"] != null)
                ArrowHeadColor = ColorTranslator.FromHtml(shape.Attributes["LineColor"].Value);

            //ArrowHeads = "none","ends","tail","head" eq ArrowHeads == null
            int n = MarkerPoints.Length;
            if (shape.Attributes["ArrowHeads"] == null)
            {
                arrowHeadAtHead = new ArrowHeadAtHead(ArrowHeadCenter, ArrowHeadLength, ArrowHeadWidth, ArrowHeadColor, this);               
            }
            else
            {
                switch (shape.Attributes["ArrowHeads"].Value)
                {
                    case "head":
                        arrowHeadAtHead = new ArrowHeadAtHead(ArrowHeadCenter, ArrowHeadLength, ArrowHeadWidth, ArrowHeadColor, this);
                        break;
                    case "tail":
                        arrowHeadAtTail = new ArrowHeadAtTail(ArrowHeadCenter, ArrowHeadLength, ArrowHeadWidth, ArrowHeadColor, this);
                        break;
                    //case "center": break;
                    case "ends":
                        arrowHeadAtHead = new ArrowHeadAtHead(ArrowHeadCenter, ArrowHeadLength, ArrowHeadWidth, ArrowHeadColor, this);
                        arrowHeadAtTail = new ArrowHeadAtTail(ArrowHeadCenter, ArrowHeadLength, ArrowHeadWidth, ArrowHeadColor, this);
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
                            arrowTailAtHead = new ArrowTailAtHead(ArrowTailCenter, ArrowTailLength, ArrowTailWidth, ArrowTailColor, this);
                            break;
                        case "tail":
                            arrowTailAtTail = new ArrowTailAtTail(ArrowTailCenter, ArrowTailLength, ArrowTailWidth, ArrowTailColor, this);
                            break;
                        case "center": break;
                        case "ends":
                            arrowTailAtHead = new ArrowTailAtHead(ArrowTailCenter, ArrowTailLength, ArrowTailWidth, ArrowTailColor, this);
                            arrowTailAtTail = new ArrowTailAtTail(ArrowTailCenter, ArrowTailLength, ArrowTailWidth, ArrowTailColor, this);
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

            if (arrowHeadAtHead != null) arrowHeadAtHead.Draw(g, extd);
            if (arrowTailAtHead != null) arrowTailAtHead.Draw(g, extd);
            if (arrowHeadAtTail != null) arrowHeadAtTail.Draw(g, extd);
            if (arrowTailAtTail != null) arrowTailAtTail.Draw(g, extd);

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

        }

        public override void Reshape(Point d) //Polyline
        {
            double oldTailAngle = Orientation(MarkerPoints[0], MarkerPoints[1]);
            double oldTipAngle = Orientation(MarkerPoints[MarkerPoints.Length - 1], MarkerPoints[MarkerPoints.Length - 2]);

            MarkerPoints[SelectedMarker].X += d.X;
            MarkerPoints[SelectedMarker].Y += d.Y;

            updatePolyBox();

            if(arrowHeadAtHead != null && SelectedMarker == MarkerPoints.Length - 1)
            {
                arrowHeadAtHead.Move(d);
            }

            if (arrowTailAtHead != null && SelectedMarker == 0)
            {
                arrowTailAtHead.Move(d);
            }
        }

    }

    class MyPolygon : GraphicObject
    {
        //TODO: LineDashPattern="5 10" LineStyleName="Dashed Line"
        public MyPolygon(XmlNode shape, GraphicObject parent) //Polygon
        {
            Parent = parent;
            _type = "Polygon";
            MarkerPoints = Coordinates2Array(shape.Attributes["Coordinates"].Value);

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

                int _penWidth = 1;
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

            getTextAttributes(shape);
            _text = shape.InnerText;
            if (_text != "" && _font == null) _font = defaultFont;
        }

        public override void Draw(Graphics g, int extd) //Polygon
        {
            if (_fillBrush != null) g.FillPolygon(_fillBrush, MarkerPoints);
            if (_pen.Width > 0) g.DrawPolygon(_pen, MarkerPoints);
            g.TranslateTransform(Box.X, Box.Y);
            if (_text != "")
            {
                setStringAlignment();
                g.DrawString(_text, _font, _fontBrush, _textBox, _stringFormat);
                if (extd > 0)
                {
                    markClipping(g, _text, _font, _textBox, _stringFormat);
                }

            }
            g.TranslateTransform(-Box.X, -Box.Y);

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

    class ArrowHeadAtHead : GraphicObject
    {
        public PointF _tip;
        PointF[] Points = new PointF[4];
        Brush brush;

        public ArrowHeadAtHead(int Center, int Length, int Width, Color c, GraphicObject parent)
        {
            Parent = parent;
            _type = "ArrowHeadAtHead";
            brush = new SolidBrush(c);// Color.Black);

            Points[0].Y = 0;                Points[0].X = 0;
            Points[1].Y = -Length;          Points[1].X = - Width / 2;
            Points[2].Y = -Center;          Points[2].X = 0;
            Points[3].Y = -Length;          Points[3].X = Width / 2;

        }

        public override void Draw(Graphics g, int extd)
        {
            PointF p1 = Parent.MarkerPoints[Parent.MarkerPoints.Length - 1];
            PointF p2 = Parent.MarkerPoints[Parent.MarkerPoints.Length - 2];
            float _orientation = (float)((Orientation(p1 , p2) * 180) / Math.PI);
            g.TranslateTransform(p1.X, p1.Y);
            g.RotateTransform(_orientation);
            g.FillPolygon(brush, Points);
            g.RotateTransform(-_orientation);
            g.TranslateTransform(-p1.X, -p1.Y);
            //g.TranslateTransform(0, 0);
            //g.DrawPolygon(DarkMarkerPen, Points);
            //g.TranslateTransform(0, 0);
        }

        public void SetBrushColor(Color c)
        {
            brush = new SolidBrush(c);
            Parent.ArrowHeadColor = c;
            Parent.ArrowTailColor = c;
        }

        public override void Move(Point d) { }

        public override void Reshape(Point d) { }
    }

    class ArrowTailAtHead : GraphicObject
    {
        public PointF _tip;
        PointF[] Points = new PointF[4];
        Brush brush;

        public ArrowTailAtHead(int Center, int Length, int Width, Color c, GraphicObject parent)
        {
            Parent = parent;
            _type = "ArrowTailAtHead";
            brush = new SolidBrush(c);//Color.Green);

            Points[0].Y = Center; Points[0].X = 0;
            Points[1].Y = Center - Length; Points[1].X = -Width / 2;
            Points[2].Y = 0; Points[2].X = 0;
            Points[3].Y = Center - Length; Points[3].X = Width / 2;
        }

        public override void Draw(Graphics g, int extd)
        {
            PointF p1 = Parent.MarkerPoints[1];
            PointF p2 = Parent.MarkerPoints[0];
            float _orientation = (float)((Orientation(p2, p1) * 180) / Math.PI);
            g.TranslateTransform(p1.X, p1.Y);
            g.RotateTransform(_orientation);
            g.FillPolygon(brush, Points);
            g.RotateTransform(-_orientation);
            g.TranslateTransform(-p1.X, -p1.Y);
            //g.TranslateTransform(80, 0);
            //g.DrawPolygon(DarkMarkerPen, Points);
            //g.TranslateTransform(-80, 0);
        }

        public void SetBrushColor(Color c)
        {
            brush = new SolidBrush(c);
            Parent.ArrowTailColor = c;
            Parent.ArrowHeadColor = c;
        }

        public override void Move(Point d) { }

        public override void Reshape(Point d) { }
    }

    internal class ArrowTailAtTail: GraphicObject
    {
        public PointF _tip;
        PointF[] Points = new PointF[4];
        Brush brush;

        public ArrowTailAtTail(int Center, int Length, int Width, Color c, GraphicObject parent) 
        {
            Parent = parent;
            _type = "ArrowTailAtTail";
            brush = new SolidBrush(c);//Color.Red);

            Points[0].Y = -Center; Points[0].X = 0;
            Points[1].Y = Length - Center; Points[1].X = -Width / 2;
            Points[2].Y = 0; Points[2].X = 0;
            Points[3].Y = Length - Center; Points[3].X = Width / 2;
        }

        public void SetBrushColor(Color c)
        {
            brush = new SolidBrush(c);
            Parent.ArrowTailColor = c;
            Parent.ArrowHeadColor = c;
        }

        public override void Draw(Graphics g, int extd)
        {
            PointF p1 = Parent.MarkerPoints[0];
            PointF p2 = Parent.MarkerPoints[1];
            float _orientation = (float)((Orientation(p1, p2) * 180) / Math.PI);
            g.TranslateTransform(p1.X, p1.Y);
            g.RotateTransform(_orientation);
            g.FillPolygon(brush, Points);
            g.RotateTransform(-_orientation);
            g.TranslateTransform(-p1.X, -p1.Y);
            //g.TranslateTransform(160, 0);
            //g.DrawPolygon(DarkMarkerPen, Points);
            //g.TranslateTransform(-160, 0);
        }

        public override void Move(Point d) { }

        public override void Reshape(Point d) { }
    }

    internal class ArrowHeadAtTail: GraphicObject
    {
        public PointF _tip;
        PointF[] Points = new PointF[4];
        Brush brush;
        public ArrowHeadAtTail(int Center, int Length, int Width, Color c, GraphicObject parent) 
        {
            Parent = parent;
            _type = "ArrowHeadAtTail";
            brush = new SolidBrush(c); //Color.Orange);

            Points[0].Y = 0; Points[0].X = 0;
            Points[1].Y = Length; Points[1].X = -Width / 2;
            Points[2].Y = Center; Points[2].X = 0;
            Points[3].Y = Length; Points[3].X = Width / 2;
        }

        public void SetBrushColor(Color c)
        {
            brush = new SolidBrush(c);
            Parent.ArrowHeadColor = c;
            Parent.ArrowTailColor = c;
        }

        public override void Draw(Graphics g, int extd)
        {
            PointF p1 = Parent.MarkerPoints[0];
            PointF p2 = Parent.MarkerPoints[1];
            float _orientation = (float)((Orientation(p2, p1) * 180) / Math.PI);
            g.TranslateTransform(p1.X, p1.Y);
            g.RotateTransform(_orientation);
            g.FillPolygon(brush, Points);
            g.RotateTransform(-_orientation);
            g.TranslateTransform(-p1.X, -p1.Y);
            //g.TranslateTransform(240, 0);
            //g.DrawPolygon(DarkMarkerPen, Points);
            //g.TranslateTransform(-240, 0);
        }

        public override void Move(Point d) { }

        public override void Reshape(Point d) { }
    }
}
