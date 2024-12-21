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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GraphicTool
{
    public partial class DisplayModeControl : UserControl
    {
        private bool PROPS_FILE;
        private bool IMAGE_FILE;    

        public DisplayModeControl ()
        {
            InitializeComponent ();
            BorderStyle = BorderStyle.FixedSingle;
        }

        private int getBit(int target, int index) 
        {
            return (byte) target & (1 << index);
        }

        private void setBit(ref int target, byte bitValue, int index) 
        {
            byte mask = (byte) (bitValue << index);
            if (bitValue == 1)
                target |= mask; // set bit[bitIndex]
            else
                target &= (byte) ~mask; // drop bit[bitIndex]
            //target = target ^ (-bitValue ^ target) & (1 << n);
        }

        public void setDrawMode(int mode)
        {
            Properties.Settings.Default.DISPLAYMODE = mode;
            Properties.Settings.Default.Save();            
        }

        public void updateBackGroundMode(bool backGround)
        {
            cBBackGround.Checked = backGround;
            cBBackGround.Enabled = backGround;
            if (!backGround)
            {
                rbBackgroundXML.Enabled = false;
                rbBackgroundImage.Enabled = false;
            }
        }

        public void updatePropsFileMode(bool xml)
        {
            cBShapes.Enabled = xml;
            if (xml)
            {
                rbBackgroundXML.Enabled = true;
                rbBackgroundImage.Enabled = false;
                PROPS_FILE = true;
            }
            else
            {
                rbBackgroundXML.Enabled = false;
                rbBackgroundImage.Enabled = true;
                PROPS_FILE = false;
            }
        }

        public void updateImageFileMode(bool image)
        {
            cBBackGround.Enabled = image;
            if (image)
            {
                rbBackgroundXML.Enabled = false;
                rbBackgroundImage.Enabled = true;
                IMAGE_FILE = true;
            }
            else
            {
                rbBackgroundXML.Enabled = true;
                rbBackgroundImage.Enabled = false;
                IMAGE_FILE = false;
            }
        }

        public void update()
        {
            int drawMode = Properties.Settings.Default.DISPLAYMODE; 
            //cBBackGround.Checked = true;
            //Shapes anzeigen
            if ((drawMode & 1) == 1) cBShapes.Checked = true; else cBShapes.Checked = false;
            //Background aus Image file anzeigen
            if ((drawMode & 2) == 2)
            {
                rbBackgroundImage.Checked = true;               
                cBBackGround.Enabled = true;
            }
            //Background aus XML anzeigen
            if ((drawMode & 4) == 4)
            {
                rbBackgroundXML.Checked = true;
                cBBackGround.Checked = true;
                cBBackGround.Enabled = true;
            }
        }

        //public int getMode()
        //{
        //    int drawMode = Properties.Settings.Default.DISPLAYMODE;
        //    int result = 0;
        //    //Shapes anzeigen
        //    if ((drawMode & 1) == 1) result += 1;
        //    //Background aus Image file anzeigen
        //    if ((drawMode & 2) == 2) result += 2;
        //    //Background aus XML anzeigen
        //    if ((drawMode & 4) == 4) result += 4;            
        //    return result;
        //}

    }
}
