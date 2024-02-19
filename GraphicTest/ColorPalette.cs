﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GraphicTool
{
    public partial class ColorPalette : UserControl
    {
        GraphicShapeDialog _callingDialog;
        string _property;
        string[] colors;
        public ColorPalette()
        {
            InitializeComponent();

        }

        public void showCbTransparent(bool check, bool show, bool enabled)
        {
            cbTransparent.Checked = check;
            cbTransparent.Visible = show;
            cbTransparent.Enabled = enabled;
        }

        public void setCurrentColor(Color col)
        {
            currentColor.Visible = true;
            cbTransparent.Checked = false;
            currentColor.SetColor(col);
        }

        public void hideCurrentColor()
        {
            currentColor.Visible = false;
        }

        public void colorControlMouseDown(object sender, MouseEventArgs e)
        {
            foreach (Control x in groupBox1.Controls)
            {
                if (x.GetType() == typeof(ColorControl))
                {
                    if (x.ContainsFocus)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                
                            Color color = x.BackColor;
                            cbTransparent.Checked = false;
                            _callingDialog.ApplyColor(color);
                            continue;
                        }
                        else
                        {
                            ContextMenuStrip contextMenu = new ContextMenuStrip();
                            ToolStripMenuItem ColorContextMenu = new ToolStripMenuItem();
                            ColorContextMenu.Text = "Set Color";
                            //ColorContextMenu.Click += SetColorControl_Click;
                            contextMenu.Items.AddRange(new ToolStripItem[] { ColorContextMenu });
                            contextMenu.Show(Cursor.Position);
                        }
                    }
                }
            }            
        }

        private void sendColorToParentControl(Color s)
        {

        }

        private void Notify(object sender, EventArgs e)
        {
            MessageBox.Show("Button wurde geklickt!");
        }

        private void ColorPalette_EnabledChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Enabled.ToString(), "Enabled");
            if (this.Enabled)
            {
                string[] colors = Properties.Settings.Default.COLORS.Split(';');
                int i = 0;
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(ColorControl))
                    {
                        ColorConverter converter = new ColorConverter();
                        Color col1 = (Color)converter.ConvertFromString(colors[i]);
                        c.BackColor = col1;
                        c.Enabled = true;
                        i += 2;
                    }
                }
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(ColorControl))
                    {
                        Color s = c.BackColor;
                        //int avg = (int) (s.R + s.G + s.B) / 3;

                        Color oc = c.BackColor;
                        int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                        Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);

                        c.BackColor = nc;
                        c.Enabled = false;
                    }

                }
            }
        }

        private void ColorPalette_Load(object sender, EventArgs e)
        {
            _callingDialog = (GraphicShapeDialog)ParentForm;
            update(Properties.Settings.Default.COLORS, _callingDialog);

        }

        public void update(string p, GraphicShapeDialog EditForm)
        {
            colors = p.Split(';');
            int deltax = 5;
            int deltay = 15;
            int x = deltax;
            int y = deltay;
            for (int i = 0; i < colors.Length - 1; i += 2)
            {
                ColorControl c = new ColorControl();
                c.MouseDown += new MouseEventHandler(colorControlMouseDown);

                ColorConverter converter = new ColorConverter();
                Color col1 = (Color)converter.ConvertFromString(colors[i]);
                c.SetColor(col1);
                Color col2 = (Color)converter.ConvertFromString(colors[i + 1]);
                c.SetBorder(col2);
                //8x8 Matrix 
                if (i > 0 && i % 8 == 0)
                {
                    y += c.Height + 1;
                    x = deltax;
                }
                c.SetPosition(x, y);
                x += c.Width + 1;

                this.groupBox1.Controls.Add(c);
            }
            _callingDialog = EditForm;
        }

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            ColorPicker picker = new ColorPicker(_callingDialog);
            picker.Show();
        }

        private void cbTransparent_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(cbTransparent.Checked.ToString());
            if(cbTransparent.Checked)
            {
                _callingDialog.ApplyTransparency();
            }
        }
    }
}