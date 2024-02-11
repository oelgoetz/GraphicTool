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

namespace GraphicTool
{
    public partial class GraphicShapeDialog : Form
    {
        private InstalledFontCollection systemFonts = new InstalledFontCollection();
        private GraphicObject G;
        private Display Caller;

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
        int _textAlignmentFlags = 0;
        HorizontalAlignment tbHor = HorizontalAlignment.Center;
        string oldText = "";
        Color cact = Color.Gray;
        Color cdef = Color.White;

        bool borderVisible = false;
        bool transparent = false;

        public GraphicShapeDialog(Display caller, GraphicObject g)
        {
            InitializeComponent();
            Caller = caller;
            G = g;

            FontFamily[] fonts = systemFonts.Families.ToArray();
            for (int i = 0; i < fonts.Length; i++) CmbFontFamily.Items.Add(fonts[i].Name);

            if (G._font != null)
            {
                //FONT_FAMILY
                CmbFontFamily.Text = G._font.Name;
                //FONT_SIZE
                NuFontSize.Value = Convert.ToInt32(G._font.Size);
                //FONT_STYLE
                style = G._fontStyle; //G._font.Style;
                if (style.HasFlag(FontStyle.Bold))
                {
                    cBRegular.Checked = false;
                    cBBold.Checked = true;
                }
                if (style.HasFlag(FontStyle.Italic))
                {
                    cBRegular.Checked = false;
                    cBItalic.Checked = true;
                }
                if (style.HasFlag(FontStyle.Underline))
                {
                    cBRegular.Checked = false;
                    cBUnderline.Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (oldText != theText)
            {
                G._text = theText;
            }
            this.Close();
        }
    }
}
