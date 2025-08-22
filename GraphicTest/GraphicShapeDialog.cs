using GraphicShapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Reflection.Metadata;

namespace GraphicTool
{
    public partial class GraphicShapeDialog : Form
    {
        private InstalledFontCollection systemFonts = new InstalledFontCollection();
        private Display _callingDisplay;

        public static string theText;
        public static Font theFont;
        public static Color theFontColor;

        bool isFontColorSet;
        decimal fontSize;
        string fontFamily;
        private Color TextColor;
        private Color BackColor;
        private Color LineColor;
        FontStyle style;
        GraphicObject _g;
        HorizontalAlignment tbHor = HorizontalAlignment.Center;
        string oldText = "";
        Color cact = Color.Gray;
        Color cdef = Color.White;

        bool borderVisible = false;
        bool transparent = false;

        ArrowTipControl Heads;
        ArrowTipControl HeadAtTail;
        ArrowTipControl Tails;
        ArrowTipControl TailAtTail;

        public GraphicShapeDialog(Display caller, GraphicObject g, Point Location)
        {
            InitializeComponent();

            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _callingDisplay = caller;
            //_g = g;

            //SHAPE PROPERTIES - BODIES
            if (g._type == "Rectangle" || g._type == "Oval" || g._type == "Polygon")
            {
                rBBackground.Checked = true;
                //SpinButton-Defultwerte extra behandeln. Das muss passieren, so lange _g noch nicht zugewiesen ist,
                //damit die OnChange Events vorzeitig verlassen werden können.
                UpDownLineWidth.Value = (decimal) g._pen.Width;
                PdLeft.Value = g._padding.Left;
                PdTop.Value = g._padding.Top;
                PdRight.Value = g._padding.Right;
                PdBottom.Value = g._padding.Bottom;

                if (g.zoom != null || g.blur != null)
                {
                    rbLine.Checked = true;
                    colorPalette1.showCbTransparent(g._fillBrush == null, false, false); //Muss die colorPalette von zoom und blur abhängen?
                    if (g.zoom != null)
                    {
                        UpDownZoomFactor.Value = new decimal((float)g.zoom._zoomFactor);
                        UpDownZoomX.Value = new decimal((float)g.zoom._zoomMoveXfactor);
                        UpDownZoomY.Value = new decimal((float)g.zoom._zoomMoveYfactor);
                        cBZoom.Checked = true;
                    }
                    else
                        cBZoom.Checked = false;

                    if (g.blur != null)
                    {
                        UpDownBlur.Value = (decimal)g.blur.blurFactor;
                        cBBlur.Checked = true;
                    }
                    else
                        cBBlur.Checked = false;
                }
                else
                    colorPalette1.showCbTransparent(g._fillBrush == null, true, true);
                if (g._fillBrush != null)
                    colorPalette1.setCurrentColor(((SolidBrush)g._fillBrush).Color);
                else
                    colorPalette1.hideCurrentColor();
                //TabControl1.TabIndex = 0;
                TabControl1.SelectedTab = TabControl1.TabPages[0];
            }
            else
            {
                colorPalette1.showCbTransparent(false, false, false);
                rbLine.Checked = true;
                if (g._pen != null)
                    colorPalette1.setCurrentColor(g._pen.Color);
                else
                    colorPalette1.hideCurrentColor();
                //TabControl1.TabIndex = 1;
                TabControl1.SelectedTab = TabControl1.TabPages[1];
            }

            //SHAPE PROPERTIES - LINES
            if (g._type == "Polyline")
            {
                rBBackground.Enabled = false;
                UpDownLineWidth.Value = (decimal)g._pen.Width;
                Heads = new ArrowTipControl(g, caller, tipMode.Heads);
                ArrowsTab.Controls.Add(Heads);
                Heads.Location = new Point(56, 28);
                Heads.Visible = true;

                Tails = new ArrowTipControl(g, caller, tipMode.Tails);
                ArrowsTab.Controls.Add(Tails);
                Tails.Location = new Point(146, 28);
                Tails.Visible = true;
                ArrowsTab.Enabled = true;
            }
            else
            {
                rBBackground.Enabled = true;
                ArrowsTab.Enabled = false;
            }

            //TEXT PROPERTIES
            if (g._text != null && g._text.Length > 0)
            {
                FontFamily[] fonts = systemFonts.Families.ToArray();
                for (int i = 0; i < fonts.Length; i++) CmbFontFamily.Items.Add(fonts[i].Name);

                //cBBold.Checked = _g._fontStyle == FontStyle.Bold;
                //cBItalic.Checked = _g._fontStyle == FontStyle.Italic;
                //cBUnderline.Checked = _g._fontStyle == FontStyle.Underline;
                //rbRegular.Checked = (_g._fontStyle != FontStyle.Bold && _g._fontStyle != FontStyle.Italic && _g._fontStyle != FontStyle.Underline);

                fontPanel.Enabled = true;
                rBText.Enabled = true;
                //SET ALIGNMENT SWITCHES
                switch (g._flags)
                {
                    case 0: a00.BackColor = cact; break;
                    case 1: a01.BackColor = cact; break;
                    case 2: a02.BackColor = cact; break;

                    case 4: a10.BackColor = cact; break;
                    case 5: a11.BackColor = cact; break;
                    case 6: a12.BackColor = cact; break;

                    case 8: a20.BackColor = cact; break;
                    case 9: a21.BackColor = cact; break;
                    case 10: a22.BackColor = cact; break;
                }
                PdTop.Value = g._padding.Top;
                PdLeft.Value = g._padding.Left;
                PdRight.Value = g._padding.Right;
                PdBottom.Value = g._padding.Bottom;
            }
            else
            {
                fontPanel.Enabled = false;
                rBText.Enabled = false;
            }

            //TODO: MyImages haben keine Definition für pen. Sollen sie das haben?
            if (g._pen == null) g._pen = new Pen(Color.Black,0);
            //try
            //{
            //    UpDownLineWidth.Value = (decimal)_g._pen.Width;
            //}
            //catch (Exception ex)
            //{ 
                
            //}
            //finally
            //{
                
            //}
            

            if (g._font != null)
            {
                //FONT_FAMILY
                CmbFontFamily.Text = g._font.Name;
                //FONT_SIZE
                UpDownFontSize.Value = Convert.ToInt32(g._font.Size);
                //FONT_STYLE
                if (g._fontStyle.HasFlag(FontStyle.Bold))
                {
                    //rbRegular.Checked = false;
                    cBBold.Checked = true;
                }
                if (g._fontStyle.HasFlag(FontStyle.Italic))
                {
                    //rbRegular.Checked = false;
                    cBItalic.Checked = true;
                }
                if (g._fontStyle.HasFlag(FontStyle.Underline))
                {
                    //rbRegular.Checked = false;
                    cBUnderline.Checked = true;
                }
            }
            this.Location = Location;

            //Jetzt _g auf g zuweisen.
            _g = g;

            updateMenuButtons();


            UpDownZoomX.ValueChanged += UpDownMoveX_ValueChanged;
            UpDownZoomY.ValueChanged += UpDownMoveY_ValueChanged;
            UpDownZoomFactor.ValueChanged += UpDownZoom_ValueChanged;
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GraphicShapeDialog_Load(object sender, EventArgs e)
        {
            var _point = new System.Drawing.Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
            Top = _point.Y;
            Left = _point.X;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ApplyColor(Color c)
        {
            if (_g == null) return;
            if (rbLine.Checked)
            {
                _g.SetLineColor(c);
            }
            if (rBBackground.Checked)
            {
                _g._fillBrush = new SolidBrush(c);
                colorPalette1.showCbTransparent(false, true, true);
            }
            if (rBText.Checked)
            {
                _g._fontBrush = new SolidBrush(c);
            }
            colorPalette1.setCurrentColor(c);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();

        }

        public void ApplyTransparency()
        {
            if (_g == null) return;
            if (rBBackground.Checked)
                _g._fillBrush = null;
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void UpDownLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_g == null) return;
            _g.SetLineWidth((int)UpDownLineWidth.Value);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void rbLine_MouseUp(object sender, MouseEventArgs e)
        {
            updateColorMode();
        }

        private void rBBackground_MouseUp(object sender, MouseEventArgs e)
        {
            updateColorMode();
        }

        private void rBText_MouseUp(object sender, MouseEventArgs e)
        {
            updateColorMode();
        }

        private void TextAlignment_Changed(object sender, EventArgs e)
        {
            if (_g == null) return;
            _g._flags = 0;
            if (a00.ContainsFocus) { _g._flags =  0; a00.BackColor = cact; } else a00.BackColor = cdef;
            if (a01.ContainsFocus) { _g._flags =  1; a01.BackColor = cact; } else a01.BackColor = cdef;
            if (a02.ContainsFocus) { _g._flags =  2; a02.BackColor = cact; } else a02.BackColor = cdef;
            if (a10.ContainsFocus) { _g._flags =  4; a10.BackColor = cact; } else a10.BackColor = cdef;
            if (a11.ContainsFocus) { _g._flags =  5; a11.BackColor = cact; } else a11.BackColor = cdef;
            if (a12.ContainsFocus) { _g._flags =  6; a12.BackColor = cact; } else a12.BackColor = cdef;
            if (a20.ContainsFocus) { _g._flags =  8; a20.BackColor = cact; } else a20.BackColor = cdef;
            if (a21.ContainsFocus) { _g._flags =  9; a21.BackColor = cact; } else a21.BackColor = cdef;
            if (a22.ContainsFocus) { _g._flags = 10; a22.BackColor = cact; } else a22.BackColor = cdef;
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void updateColorMode()
        {
            if (rBBackground.Checked)
            {
                colorPalette1.showCbTransparent(_g._fillBrush == null, true, true);
                if (_g._fillBrush != null)
                    colorPalette1.setCurrentColor(((SolidBrush)_g._fillBrush).Color);
                else
                    colorPalette1.hideCurrentColor();
            }
            if (rbLine.Checked)
            {
                colorPalette1.showCbTransparent(false, false, false);
                if (_g._pen != null)
                    colorPalette1.setCurrentColor(_g._pen.Color);
                else
                    colorPalette1.hideCurrentColor();
            }
            if (rBText.Checked)
            {
                colorPalette1.showCbTransparent(false, false, false);
                colorPalette1.setCurrentColor(((SolidBrush)_g._fontBrush).Color);
            }
        }

        private void UpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            if(_g == null) return;
            _g.SetFontSize((int)UpDownFontSize.Value);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void CmbFontFamily_TextChanged(object sender, EventArgs e)
        {
            if (_g == null) return;
            _g.SetFontFamily(CmbFontFamily.Text);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void cBRegular_MouseUp(object sender, MouseEventArgs e)
        {
            updateFontStyle();
        }

        private void cBBold_MouseUp(object sender, MouseEventArgs e)
        {
            updateFontStyle();
        }

        private void cBItalic_MouseUp(object sender, MouseEventArgs e)
        {
            updateFontStyle();
        }

        private void cBUnderline_MouseUp(object sender, MouseEventArgs e)
        {
            updateFontStyle();
        }

        private void updateFontStyle()
        {
            if (_g == null) return;
            FontStyle f = FontStyle.Regular;
            if (cBBold.Checked) f |= FontStyle.Bold;
            if (cBItalic.Checked) f |= FontStyle.Italic;
            if (cBUnderline.Checked) f |= FontStyle.Underline;
            _g.SetFontStyle(f);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void PdTop_ValueChanged(object sender, EventArgs e)
        {
            if(_g != null) updatePadding();
        }

        private void PdRight_ValueChanged(object sender, EventArgs e)
        {
            if (_g != null) updatePadding();
        }

        private void PdBottom_ValueChanged(object sender, EventArgs e)
        {
            if (_g != null) updatePadding();
        }

        private void PdLeft_ValueChanged(object sender, EventArgs e)
        {
            if (_g != null) updatePadding();
        }

        private void updatePadding()
        {
            if (_g == null)
                return;
            Padding padding = new Padding((int)PdLeft.Value, (int)PdTop.Value, (int)PdRight.Value, (int)PdBottom.Value);
            _g.SetPadding(padding);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void updateMenuButtons()
        {
            //if (_g == null) return; 
            if (_g.Parent.Children.Count == 1)
            {
                menuStrip1.Items[0].Enabled = false; //topmost
                menuStrip1.Items[1].Enabled = false; //lift
                menuStrip1.Items[2].Enabled = false; //sink
                menuStrip1.Items[3].Enabled = false; //lowest
            }
            else
            {
                if (_g.Parent.Children.IndexOf(_g) == 0)
                {
                    menuStrip1.Items[0].Enabled = true; //topmost
                    menuStrip1.Items[1].Enabled = true; //lift
                    menuStrip1.Items[2].Enabled = false; //sink
                    menuStrip1.Items[3].Enabled = false; //lowest
                }
                else
                {
                    if (_g.Parent.Children.IndexOf(_g) < _g.Parent.Children.Count - 1)
                    {
                        menuStrip1.Items[0].Enabled = true; //topmost
                        menuStrip1.Items[1].Enabled = true; //lift
                        menuStrip1.Items[2].Enabled = true; //sink
                        menuStrip1.Items[3].Enabled = true; //lowest
                    }
                }
                if (_g.Parent.Children.IndexOf(_g) == _g.Parent.Children.Count - 1)
                {
                    menuStrip1.Items[0].Enabled = false; //topmost
                    menuStrip1.Items[1].Enabled = false; //lift
                    menuStrip1.Items[2].Enabled = true; //sink
                    menuStrip1.Items[3].Enabled = true; //lowest
                }
            }
        }
        private void topmost_Click(object sender, EventArgs e)
        {
            GraphicObject r = _g.Parent;
            GraphicObject g = r.Children[r.Children.IndexOf(_g)];
            r.Children.RemoveAt(r.Children.IndexOf(_g));
            r.Children.Add(g);

            updateMenuButtons();
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void bottom_Click(object sender, EventArgs e)
        {
            GraphicObject r = _g.Parent;
            GraphicObject g = r.Children[r.Children.IndexOf(_g)];
            r.Children.RemoveAt(r.Children.IndexOf(_g));
            r.Children.Insert(0, g);

            updateMenuButtons();
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void Lift_Click(object sender, EventArgs e)
        {
            GraphicObject r = _g.Parent;
            int i = r.Children.IndexOf(_g);
            GraphicObject g = r.Children[i];
            r.Children.RemoveAt(i);
            r.Children.Insert(i + 1, g);

            updateMenuButtons();
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void Sink_Click(object sender, EventArgs e)
        {
            GraphicObject r = _g.Parent;
            int i = r.Children.IndexOf(_g);
            GraphicObject g = r.Children[i];
            r.Children.RemoveAt(i);
            r.Children.Insert(i - 1, g);

            updateMenuButtons();
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void UpDownBlur_ValueChanged(object sender, EventArgs e)
        {
            _g.blur.blurFactor = ((int)UpDownBlur.Value);
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void UpDownZoom_ValueChanged(object sender, EventArgs e)
        {
            _g.zoom._zoomFactor = (float)UpDownZoomFactor.Value;
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void UpDownMoveX_ValueChanged(object sender, EventArgs e)
        {
            _g.zoom._zoomMoveXfactor = (float)UpDownZoomX.Value;
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }

        private void UpDownMoveY_ValueChanged(object sender, EventArgs e)
        {
            _g.zoom._zoomMoveYfactor = (float)UpDownZoomY.Value;
            _callingDisplay.changed = true;
            _callingDisplay.Invalidate();
        }
    }
}
