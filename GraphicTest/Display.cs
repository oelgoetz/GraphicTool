﻿using GraphicShapes;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GraphicTool
{
    public partial class Display : UserControl
    {
        private Bitmap? BackGroundBmp;
        private Bitmap? PropsFileBmp;
        private Bitmap? ImageFileBmp;
        private Graphics graph;
        private Point displayOffset = Point.Empty;
        private float zoomFactor = 1.0f;
        private int drawMode = 5;
        private GraphicObject root;
        private Point delta;
        private Point lastPoint;
        private mode Mode = mode.Default;
        private bool showInfo = false;
        private Size infoBox;

        private enum mode
        {
            Default,
            Paste,
            Borders,
            Move,
            ResizeThis,
            ResizeObject,
            SelectColor,
            EditText,
            DisplayProperties,
            SelectImg,
            ViewOnly,
            ContextMenu
        }

        private Point XY;

        private Point deltaXY = Point.Empty;
        private int mouseOverObject;
        private int focusedGraphicObject;
        private int nSelected;
        private bool multiSelect;
        private bool backGroundSelected;
        private Point BackgroundOffset = Point.Empty;



        public Display()
        {
            InitializeComponent();
            BackGroundBmp = new Bitmap(this.Width, this.Height);
            PropsFileBmp = new Bitmap(this.Width, this.Height);
            ImageFileBmp = new Bitmap(this.Width, this.Height);
            root = new Root();
            //PreviewKeyDown += new PreviewKeyDownEventHandler(Display_PreviewKeyDown);

        }

        //public void Display_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Right:
        //        case Keys.Left:
        //        case Keys.Down:
        //        case Keys.Up:
        //            e.IsInputKey = true;
        //            break;
        //    }
        //}

        public void DrawOnGraphics(Graphics g)
        {
            g = this.CreateGraphics();
            Point Offset = new Point(50, 50);
            g.TranslateTransform(Offset.X, Offset.Y);
            g.DrawEllipse(new Pen(Color.Black), 0, 0, 100, 100);
            Offset = new Point(50, 50);
            g.TranslateTransform(Offset.X, Offset.Y);
            g.DrawEllipse(new Pen(Color.Black), 0, 0, 100, 100);
        }

        public void LoadImageFile(string fileName)
        {
            BackGroundBmp = null; PropsFileBmp = null; ImageFileBmp = null;
            displayOffset = Point.Empty;
            BackgroundOffset = Point.Empty;
            backGroundSelected = false;
            root = new Root();

            if (fileName.EndsWith(".props"))
                fileName = fileName.Substring(0, fileName.Length - 6);

            if (File.Exists(fileName))
                this.LoadBackGroundImageFromFile(fileName, false);

            if (File.Exists(fileName + ".props"))
            {
                XmlDocument propsFile = new XmlDocument();
                propsFile.Load(fileName + ".props");

                XmlNode OriginalImageNode = propsFile.SelectSingleNode("//OriginalImage");
                this.LoadBackgroundImageFromPropsFile(propsFile.SelectSingleNode("//OriginalImage"));

                XmlNode ShapesNode = propsFile.SelectSingleNode("//fileProperties/ImageOverlay/Shapes");
                this.LoadOverlays(ShapesNode);
            }

            Center();
            this.Invalidate();
        }

        private void Center()
        {
            if ((drawMode & 2) == 2 && ImageFileBmp != null)
                BackGroundBmp = (Bitmap)ImageFileBmp.Clone();
            if ((drawMode & 4) == 4 && PropsFileBmp != null)
                BackGroundBmp = (Bitmap)PropsFileBmp.Clone();
            if (BackGroundBmp != null)
            {
                displayOffset.X = this.Width / 2 - BackGroundBmp.Width / 2;
                displayOffset.Y = this.Height / 2 - (BackGroundBmp.Height + infoBox.Height) / 2;
            }
            if(BackGroundBmp != null)
            {
                if (displayOffset.X + BackGroundBmp.Width > this.Width) displayOffset.X = 0;
                if (displayOffset.Y + BackGroundBmp.Height + infoBox.Height > this.Height) displayOffset.Y = 0;
            }
            Invalidate();
        }

        public void LoadBackGroundImageFromFile(string filename, bool scale = true)
        {
            if (filename == null) return;
            //https://mycsharp.de/forum/threads/62769/geloest-allgemeiner-fehler-in-gdi-beim-speichern-einer-bitmap

            if (File.Exists(filename))
            {
                ImageFileBmp = UnlinkedBitmap.FromFile(filename);
            }
        }

        public void LoadBackgroundImageFromPropsFile(XmlNode OriginalImage)
        {
            string base64String = OriginalImage.InnerText;
            PropsFileBmp = (Bitmap)Base642Image(base64String);
        }

        public void LoadOverlays(XmlNode Shapes)
        {
            foreach (XmlNode shape in Shapes)
            {
                if (shape.NodeType != XmlNodeType.Element) continue;
                try
                {
                    root.Add(shape, root);
                }
                catch (Exception ex)
                {
                    string s = " ";
                    if (shape.Attributes["Type"] != null) s += shape.Attributes["Type"].Value;
                    if (shape.ParentNode.Attributes["Type"] != null) s += shape.ParentNode.Attributes["Type"].Value;
                    MessageBox.Show(ex.Message + "\n" + shape.Name + "\n" + s + "\n" + shape.BaseURI, "Display02.addShape");
                }
            }
            this.Invalidate();
        }

        private Point getOffset(GraphicObject Parent)
        {
            Point result = Point.Empty;
            while (Parent != null && Parent.GetType().Name != "Root")
            {
                result.X += Parent.Box.X;
                result.Y += Parent.Box.Y;
                Parent = Parent.Parent;
            }
            return result;

        }

        //------------------------------------------------------------------
        private void deserialize(XmlNode ShapesNode, GraphicObject Object, Point BGOffset)
        {
            MyGroup dummy = new MyGroup();
            string grouptype = dummy.GetType().Name.ToString();
            for (int i = 0; i < Object.Children.Count; i++)
            {
                GraphicObject g = Object.Children[i];
                XmlElement Shape = ShapesNode.OwnerDocument.CreateElement("Shape");
                ShapesNode.AppendChild(Shape);
                string type = g.GetType().Name.ToString();
                string writetype = type;
                if (writetype.StartsWith("My"))
                    writetype = writetype.Replace("My", "");
                Attribute(Shape, "Type", writetype);

                if (writetype == "Polyline" || writetype == "Polygon")
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
                if (type == grouptype)
                    deserialize(Shape, g, BGOffset);
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

        public void Save2File(string fileName)
        {
            if (fileName == null) return;
            //if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            //    tools1.createPath(Path.GetDirectoryName(fileName));

            XmlNode OriginalImageNode;
            XmlDocument propsFile = PreparePropsFile();

            OriginalImageNode = propsFile.SelectSingleNode("//OriginalImage");
            OriginalImageNode.InnerText = Image2Base64((Image)PropsFileBmp); //BackGroundBmp); // 

            Attribute(OriginalImageNode, "ComputedWidth", BackGroundBmp.Width.ToString());
            Attribute(OriginalImageNode, "ComputedHeight", BackGroundBmp.Height.ToString());
            Attribute(OriginalImageNode, "Type", "Image");
            Attribute(OriginalImageNode, "Format", "png");
            Attribute(OriginalImageNode, "DPI", "96");

            XmlNode ShapesNode = propsFile.SelectSingleNode("//Shapes");
            //Save Shapes as Xml
            deserialize(ShapesNode, root, BackgroundOffset);
            //Draw Shapes on Graphic
            PaintOnGraphicInstance(graph, 0, Color.White);
            //Save Graphic
            BackGroundBmp.Save(fileName);
            //Update Image File in memory
            //ImageFileBmp = (Bitmap)BackGroundBmp.Clone();
            propsFile.Save(fileName + ".props");
            //tools1.BeautifyXml(fileName + ".props", fileName + ".props");
        }

        private XmlDocument PreparePropsFile()
        {
            XmlDocument propsFile = new XmlDocument();
            propsFile.LoadXml(
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "	<fileProperties>" +
            "		<ImageOverlay>" +
            "		    <OriginalImage/>" +
            "		<Shapes/>" +
            "		<Shapes IsResourceLayer=\"true\" Name=\"Resources\"/>" +
            "		<Variables/>" +
            "		<ConditionTagSet/>" +
            "	</ImageOverlay>" +
            "</fileProperties>");
            return propsFile;
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

        private static Image Base642Image(string base64String)
        {
            if (base64String == "") return null;
            try
            {
                byte[] buffer = Convert.FromBase64String(base64String);
                if (buffer != null)
                {
                    ImageConverter ic = new ImageConverter();
                    return ic.ConvertFrom(buffer) as Image;
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public string Image2Base64(Image bImage)
        {
            System.IO.MemoryStream ms = new MemoryStream();
            bImage.Save(ms, ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            return Convert.ToBase64String(byteImage);
        }

        public void setPaintMode(int mode)
        {
            drawMode = mode;
            BackGroundBmp = new Bitmap(this.Width, this.Height);
            if ((drawMode & 2) == 2 && ImageFileBmp != null)
                BackGroundBmp = (Bitmap)ImageFileBmp.Clone();
            if ((drawMode & 4) == 4 && PropsFileBmp != null)
                BackGroundBmp = (Bitmap)PropsFileBmp.Clone();
            this.Invalidate();
        }

        public void setInfo(bool Info)
        {
            showInfo = Info;
            Invalidate();
        }

        public void setZoomFactor(int f)
        {
            zoomFactor = (float)f / 100;
            //Center();
            this.Invalidate();
        }

        private void PaintOnGraphicInstance(Graphics graphic, int marker, Color ClearColor)
        {
            //if ((drawMode & 2) == 2 && ImageFileBmp != null)
            //    BackGroundBmp = (Bitmap)ImageFileBmp.Clone();
            //if ((drawMode & 4) == 4 && PropsFileBmp != null)
            if (BackGroundBmp != null)
                BackGroundBmp = (Bitmap)PropsFileBmp.Clone();
            else
                BackGroundBmp = new Bitmap(this.Width, this.Height);

            //if (graphic == null) 
            
            graphic = Graphics.FromImage(BackGroundBmp);
            //graphic.TextRenderingHint = TextRenderingHint.AntiAlias;
            if ((drawMode & 6) > 1)
            {
                graphic.DrawImage(BackGroundBmp, BackgroundOffset.X, BackgroundOffset.Y, BackGroundBmp.Width, BackGroundBmp.Height);
            }
            else
            {
                graphic.Clear(ClearColor);
            }

            if ((drawMode & 1) == 1)
            {
                Point Offset = new Point(0, 0);
                if ((drawMode & 1) == 1)
                {
                    foreach (GraphicObject g in root.Children)
                    {
                        g.Draw(graphic, marker);
                    }
                }
            }
        }

        private void Display_Paint(object sender, PaintEventArgs e)
        {
            if ((drawMode & 2) == 2 && ImageFileBmp != null)
                BackGroundBmp = (Bitmap)ImageFileBmp.Clone();
            if ((drawMode & 4) == 4 && PropsFileBmp != null)
                BackGroundBmp = (Bitmap)PropsFileBmp.Clone();

            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);
            e.Graphics.TranslateTransform(displayOffset.X / zoomFactor, displayOffset.Y / zoomFactor);
            //e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            if (BackGroundBmp != null)
            {
                e.Graphics.DrawImage((Bitmap)BackGroundBmp, new Rectangle(BackgroundOffset.X, BackgroundOffset.Y, BackGroundBmp.Width, BackGroundBmp.Height));
            }
            if ((drawMode & 1) == 1)
            {
                foreach (GraphicObject g in root.Children)
                {
                    g.Draw(e.Graphics, 1);
                }
            }
            if (backGroundSelected)
            {
                Brush solidBrush = new SolidBrush(Color.FromArgb(64, 0, 0, 255));
                e.Graphics.FillRectangle(solidBrush, new Rectangle(BackgroundOffset.X, BackgroundOffset.Y, BackGroundBmp.Width, BackGroundBmp.Height));
            }

            if (showInfo)
            {
                if (BackGroundBmp != null || root != null)
                {
                    string msg = "";
                    {
                        msg += "Test";
                        msg += "mode :  " + Mode.ToString() + " ";
                        string m = ""; if (multiSelect) m += "m"; else m += " ";
                        msg += "\nDmode:  " + drawMode.ToString() + " " + m;
                        msg += "\nn obj:  " + root.Children.Count.ToString();
                        msg += "\nn Sel:  " + nSelected.ToString();
                        msg += "\nfocus:  " + focusedGraphicObject.ToString();

                        //msg += "\nview mode: " + drawMode.ToString();
                        //msg += "\nview: " + ViewBox.X.ToString() + " " + ViewBox.Y.ToString() + " " + ViewBox.Width.ToString() + " " + ViewBox.Height.ToString();
                        //msg += "\nPOS : " + Convert.ToInt16((lastPoint.X/* - centerOfView.X*/) * 100 / zoomFactor).ToString() + " " + Convert.ToInt16((lastPoint.Y/* - centerOfView.Y*/) * 100 / zoomFactor).ToString() + " ";
                        msg += "\nXY: " + XY.X.ToString() + " " + XY.Y.ToString();
                        msg += "\nmouse over: " + mouseOverObject.ToString();
                        //msg += "\nx:" + origin.X.ToString() + " y:" + origin.Y.ToString();
                        //msg += "\nSEL: x:" + Selection.X.ToString() + " y:" + Selection.Y.ToString() + " w:" + Selection.Width.ToString() + " h:" + Selection.Height.ToString();
                        //msg += "\nBG : x:" + BackgroundBox.X.ToString() + " y:" + BackgroundBox.Y.ToString() + " w:" + BackgroundBox.Width.ToString() + " h:" + BackgroundBox.Height.ToString();
                        //if(SelectedImage != null) msg += " SI: x:" + SelectedImage.Position.X.ToString() + " y:" + SelectedImage.Position.Y.ToString() + " w:" + SelectedImage.Position.Width.ToString() + " h:" + SelectedImage.Position.Height.ToString();
                    }

                    int h;
                    if (BackGroundBmp != null) h = BackGroundBmp.Height; else h = 10;
                    int newlines = msg.Split("\n").Length;
                    int x = 5;
                    int y = 10 + h;//displayOffset.Y + h; // - newlines * 25;
                    infoBox.Height = y;
                    infoBox.Width = x;
                    Font stringFont = new Font("Courier New", 10);
                    float size = getTextSize(msg, stringFont);
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 1), x, y, size, newlines * 15 + 2);
                    Brush solidBrush = new SolidBrush(Color.FromArgb(196, 255, 255, 255));
                    e.Graphics.FillRectangle(solidBrush, new System.Drawing.Rectangle(x + 1, y + 1, (int)size - 1, newlines * 15));
                    e.Graphics.DrawString(msg, stringFont, Brushes.Black, new Point(x, y));
                }
            }
            else
                infoBox = Size.Empty;
        }

        private float getTextSize(string text, Font font)
        {
            Image dummy = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(dummy);
            SizeF size = graphics.MeasureString(text, font);
            return size.Width;
        }

        private void selectObjects(bool add)
        {
            if (!add)
            {
                foreach (GraphicObject g in root.Children)
                    g.UnSelect();
                focusedGraphicObject = -1;
            }
            switch (mouseOverObject)
            {
                case -3:
                    //BackGroundSelected = false;
                    break;
                case -2:
                    //BackGroundSelected = true;
                    break;
                case -1:
                    backGroundSelected = true;
                    break;
                default:
                    //if (SelectedImage != null)
                    //    SelectedImage.UnSelect();
                    if (root.Children.Count > 0 && mouseOverObject < root.Children.Count)
                    {
                        root.Children[mouseOverObject].Select();
                        focusedGraphicObject = mouseOverObject;
                    }
                    break;
            }
            nSelected = 0;
            foreach (GraphicObject g in root.Children)
            {
                if (g.IsSelected)
                {
                    Mode = mode.Move;
                    nSelected++;
                    if (!add)
                        break;
                }
            }
            this.Invalidate();
        }

        private void replaceBackgroundFromClipboard()
        {
            //MessageBox.Show("Ctrl & V = Loop.");  
            //return;
            if (Clipboard.ContainsImage())
            {
                Bitmap _ImgBufferBmp = (Bitmap)
                    Clipboard.GetImage();
                if ((drawMode & 2) == 2)
                    ImageFileBmp = (Bitmap)_ImgBufferBmp.Clone();
                if ((drawMode & 4) == 4)
                    PropsFileBmp = (Bitmap)_ImgBufferBmp.Clone();
                BackGroundBmp = _ImgBufferBmp;
                //Background.Size = .Size;
                //this.Size = Background.Size;
                //drawOriginalImage = true;
                backGroundSelected = true;
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Clipboard is empty. Please Copy Image.");
            }
        }


        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            delta.X = e.X - lastPoint.X;// - Offset.X;
            delta.Y = e.Y - lastPoint.Y;// - Offset.Y;
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            XY.X = Convert.ToInt32((e.X - displayOffset.X) / zoomFactor);
            XY.Y = Convert.ToInt32((e.Y - displayOffset.Y) / zoomFactor);
            deltaXY.X = Convert.ToInt32(delta.X / zoomFactor);
            deltaXY.Y = Convert.ToInt32(delta.Y / zoomFactor);

            mouseOverObject = -2;
            for (int j = root.Children.Count - 1; j >= 0; j--)
            {
                GraphicObject g = root.Children[j];
                if (XY.X > g.Box.X)
                    if (XY.X < g.Box.X + g.Box.Width)
                        if (XY.Y > g.Box.Y)
                            if (XY.Y < g.Box.Y + g.Box.Height)
                            {
                                mouseOverObject = j;
                                break;
                            }
            }
            if (mouseOverObject == -2)
            {
                if (BackGroundBmp != null &&
                    XY.X < BackgroundOffset.X + BackGroundBmp.Width &&
                    XY.Y < BackgroundOffset.Y + BackGroundBmp.Height &&
                    XY.X > BackgroundOffset.X &&
                    XY.Y > BackgroundOffset.Y)
                    mouseOverObject = -1;
            }
            if (e.Button == MouseButtons.Left)
            {
                switch (Mode)
                {
                    case mode.Move:
                        {
                            foreach (GraphicObject g in root.Children)
                            {
                                if (g.IsSelected) // && (XY.X >= 0) && (XY.Y >= 0))
                                    g.Move(new Point(deltaXY.X, deltaXY.Y));
                            }
                        }
                        break;
                    case mode.ResizeObject:
                        {
                            foreach (GraphicObject g in root.Children)
                            {
                                if (g.IsSelected)
                                {
                                    g.Reshape(deltaXY);
                                }
                            }

                        }
                        break;
                }
                if (backGroundSelected)
                {
                    BackgroundOffset.X += deltaXY.X;
                    BackgroundOffset.Y += deltaXY.Y;
                }
            }
            Invalidate();
        }

        private void Display_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                multiSelect = true;
                //AVOIDS UNWANTED MOVING OF SHAPES DURING MULTI-SELECT:
                delta.X = 0;
                delta.Y = 0;
                Invalidate();
                return;
            }
            //Objekt(e) mit Pfeiltasten bewegen
            if (e.KeyCode == Keys.Left)
            {
                deltaXY.X = -1;
                deltaXY.Y = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                deltaXY.X = 1;
                deltaXY.Y = 0;
            }
            if (e.KeyCode == Keys.Up)
            {
                deltaXY.X = 0;
                deltaXY.Y = -1;
            }
            if (e.KeyCode == Keys.Down)
            {
                deltaXY.X = 0;
                deltaXY.Y = 1;
            }
            if (deltaXY.X != 0 || deltaXY.Y != 0)
            {
                //CAUTION! _mode = mode.Move; is not working here!
                if (Mode == mode.Default)
                {
                    foreach (GraphicObject g in root.Children)
                    {
                        if (g.IsSelected) // && (XY.X >= 0) && (XY.Y >= 0) && (XY.X < this.Width - displayOffset.X) && (XY.Y < this.Height - displayOffset.Y))
                        {
                            g.Move(deltaXY);
                        }
                    }
                    if (backGroundSelected)
                    {
                        BackgroundOffset.X += deltaXY.X;
                        BackgroundOffset.Y += deltaXY.Y;
                    }
                    deltaXY.X = 0;
                    deltaXY.Y = 0;
                    delta.X = 0;
                    delta.Y = 0;

                }
            }
            //Neues Hintergrundbild einfügen.
            if (e.Control)
            {
                if (e.KeyCode == Keys.V)
                    replaceBackgroundFromClipboard();
            }
            if (e.KeyCode == Keys.Escape)
            {
                multiSelect = false;
                foreach (GraphicObject g in root.Children)
                    g.UnSelect();
                backGroundSelected = false;
                focusedGraphicObject = -1;
                Mode = mode.Default;
            }
            Invalidate();
        }

        private void Display_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Display_KeyUp(object sender, KeyEventArgs e)
        {
            if (multiSelect) multiSelect = false;
        }

        private void Display_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (Mode)
                {
                    case mode.Default:
                        if (mouseOverObject > -1)
                        {
                            GraphicObject g;
                            if (focusedGraphicObject > 0)
                                g = root.Children[focusedGraphicObject];
                            else
                                g = root.Children[mouseOverObject];
                            if (g != null)
                            {
                                if ((nSelected == 1 && g.GetType() == typeof(MyGroup)) || nSelected > 1)
                                {
                                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                                    //string type = g.GetType().Name.ToString();
                                    //MessageBox.Show(child.GetType().Name.ToString());
                                    if (nSelected == 1 && g.GetType() == typeof(MyGroup))
                                    {
                                        ToolStripMenuItem ungroupToolStripMenuItem = new ToolStripMenuItem();
                                        ungroupToolStripMenuItem.Text = "ungroup";
                                        ungroupToolStripMenuItem.Click += ungroupToolStripMenuItem_Click;
                                        contextMenu.Items.AddRange(new ToolStripItem[] { ungroupToolStripMenuItem });
                                    }
                                    if (nSelected > 1)
                                    {
                                        ToolStripMenuItem groupToolStripMenuItem = new ToolStripMenuItem();
                                        groupToolStripMenuItem.Text = "group";
                                        groupToolStripMenuItem.Click += groupToolStripMenuItem_Click;
                                        contextMenu.Items.AddRange(new ToolStripItem[] { groupToolStripMenuItem });
                                    }
                                    
                                    contextMenu.Show(Cursor.Position);
                                    Mode = mode.ContextMenu;
                                    this.Invalidate();
                                }
                                else
                                {
                                    if (g != null)
                                    {
                                        GraphicShapeDialog textForm = new GraphicShapeDialog(this, g);

                                        if (textForm.ShowDialog() == DialogResult.OK)
                                        {

                                        }

                                        textForm.Dispose();
                                        this.Invalidate();
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            else //MouseButtons.Left
            {
                if (mouseOverObject == -2) backGroundSelected = false;
                int index = -1;
                foreach (GraphicObject g in root.Children)
                {
                    if (g.IsSelected)
                    {
                        index = g.getMarkerPoint(XY);
                        if (index >= 0)
                        {
                            Mode = mode.ResizeObject;
                            return;
                        }
                    }
                }
                //if(MarkerPointSelected < 0)
                selectObjects(multiSelect);
            }
            this.Invalidate();
        }

        private void Display_MouseUp(object sender, MouseEventArgs e)
        {
            if (Mode == mode.Move)
            {
                Mode = mode.Default;
            }
            if (Mode == mode.ContextMenu)
            {
                Mode = mode.Default;
            }
        }

        private void groupToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            List<GraphicObject> objects = new List<GraphicObject>();
            foreach (GraphicObject g in root.Children)
                if (g.IsSelected)
                    objects.Add(g);
            GraphicObject newGroup = new MyGroup(objects, root);
            newGroup.Select();
            Invalidate();
        }

        private void ungroupToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            int i = 0;
            while (i < root.Children.Count)
            {
                GraphicObject g = root.Children[i];
                if (g.IsSelected)
                {
                    g.Ungroup(root);
                    break;
                }
                i++;
            }
            Invalidate();
        }

        private void Display_Resize(object sender, EventArgs e)
        {
            Center();
        }
    }

    public static class UnlinkedBitmap
    {
        public static Bitmap FromFile(string filename)
        {
            Byte[] buffer = File.ReadAllBytes(filename);
            MemoryStream memstream = new MemoryStream(buffer);
            return new Bitmap(memstream);
        }
    }

}
