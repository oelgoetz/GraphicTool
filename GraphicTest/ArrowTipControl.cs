using GraphicShapes;
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
    public enum tipMode
    {
        Heads,
        Tails
    }

    public partial class ArrowTipControl : UserControl
    {
        GraphicObject _g;
        Display _caller;
        tipMode _mode;

        int defaultCenter = 15; //8;
        int defaultWidth = 20; //12;
        int defaultLength = 25; //16;
        private void updateButtonfaces()
        {
            switch (_mode)
            {
                case tipMode.Heads:
                    if (_g.arrowHeadAtHead != null)
                        btnAtHeads.BackgroundImage = imageList1.Images[0];
                    else
                        btnAtHeads.BackgroundImage = imageList1.Images[1];
                    if (_g.arrowHeadAtTail != null)
                        btnAtTails.BackgroundImage = imageList1.Images[2];
                    else
                        btnAtTails.BackgroundImage = imageList1.Images[3];
                    break;
                case tipMode.Tails:
                    if (_g.arrowTailAtTail != null)
                        btnAtTails.BackgroundImage = imageList1.Images[4];
                    else
                        btnAtTails.BackgroundImage = imageList1.Images[5];
                    if (_g.arrowTailAtHead != null)
                        btnAtHeads.BackgroundImage = imageList1.Images[6];
                    else
                        btnAtHeads.BackgroundImage = imageList1.Images[7];
                    break;
                default: break;
            }
        }

        public ArrowTipControl(GraphicObject g, Display caller, tipMode mode)
        {
            _g = g;
            _caller = caller;
            InitializeComponent();
            _mode = mode;

            switch (_mode)
            {
                case tipMode.Heads:
                    if (_g.arrowHeadAtHead != null)
                    {
                        UpDownWidth.Value = g.ArrowHeadWidth;
                        UpDownLength.Value = g.ArrowHeadLength;
                        UpDownCenter.Value = g.ArrowHeadCenter;
                    }
                    else
                    {
                        UpDownWidth.Value = 0;
                        UpDownLength.Value = 0;
                        UpDownCenter.Value = 0;
                    }
                    break;
                case tipMode.Tails:
                    if (_g.arrowTailAtHead != null)
                    {
                        UpDownWidth.Value = g.ArrowTailWidth;
                        UpDownLength.Value = g.ArrowTailLength;
                        UpDownCenter.Value = g.ArrowTailCenter;
                    }
                    else
                    {
                        UpDownWidth.Value = 0;
                        UpDownLength.Value = 0;
                        UpDownCenter.Value = 0;
                    }
                    break;
                default: break;
            }
            btnAtHeads.BackgroundImageLayout = ImageLayout.Stretch;
            btnAtTails.BackgroundImageLayout = ImageLayout.Stretch;
            updateButtonfaces();
            //sign event handler here, otherwise they'd update too early ...
            UpDownWidth.ValueChanged += ValueChanged;
            UpDownCenter.ValueChanged += ValueChanged;
            UpDownLength.ValueChanged += ValueChanged;
        }

        private void btnAtHeads_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case tipMode.Heads:
                    if (_g.arrowHeadAtHead != null)
                        _g.arrowHeadAtHead = null;
                    else
                    {
                        UpDownWidth.Value = defaultWidth; UpDownLength.Value = defaultLength; UpDownCenter.Value = defaultCenter;
                        _g.ArrowHeadLength = (int)UpDownLength.Value;
                        _g.ArrowHeadWidth = (int)UpDownWidth.Value;
                        _g.ArrowHeadCenter = (int)UpDownCenter.Value;
                        _g.arrowHeadAtHead = new ArrowHeadAtHead((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowHeadColor, _g);
                    }                    
                    break;
                case tipMode.Tails:
                    if (_g.arrowTailAtHead != null)
                        _g.arrowTailAtHead = null;
                    else
                    {
                        UpDownWidth.Value = defaultWidth; UpDownLength.Value = defaultLength; UpDownCenter.Value = defaultCenter;
                        _g.ArrowTailLength = (int)UpDownLength.Value;
                        _g.ArrowTailWidth = (int)UpDownWidth.Value;
                        _g.ArrowTailCenter = (int)UpDownCenter.Value;
                        _g.arrowTailAtHead = new ArrowTailAtHead((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowTailColor, _g);
                    }                                      
                    break;
                default: break;
            }
            updateButtonfaces();
            _caller.Invalidate();
        }

        private void btnAtTails_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case tipMode.Heads:
                    if (_g.arrowHeadAtTail != null)
                        _g.arrowHeadAtTail = null;
                    else
                    {
                        UpDownWidth.Value = defaultWidth; UpDownLength.Value = defaultLength; UpDownCenter.Value = defaultCenter;
                        _g.ArrowHeadLength = (int)UpDownLength.Value;
                        _g.ArrowHeadWidth = (int)UpDownWidth.Value;
                        _g.ArrowHeadCenter = (int)UpDownCenter.Value;
                        _g.arrowHeadAtTail = new ArrowHeadAtTail((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowHeadColor, _g);
                    }
                    break;
                case tipMode.Tails:
                    if (_g.arrowTailAtTail != null)
                        _g.arrowTailAtTail = null;
                    else
                    {
                        UpDownWidth.Value = defaultWidth; UpDownLength.Value = defaultLength; UpDownCenter.Value = defaultCenter;
                        _g.ArrowTailLength = (int)UpDownLength.Value;
                        _g.ArrowTailWidth = (int)UpDownWidth.Value;
                        _g.ArrowTailCenter = (int)UpDownCenter.Value;
                        _g.arrowTailAtTail = new ArrowTailAtTail((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowTailColor, _g);
                    }
                    break;
                default: break;
            }
            updateButtonfaces();
            _caller.Invalidate();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case tipMode.Heads:
                    if (_g.arrowHeadAtHead != null)
                    {
                        _g.ArrowHeadLength = (int)UpDownLength.Value;
                        _g.ArrowHeadWidth = (int)UpDownWidth.Value;
                        _g.ArrowHeadCenter = (int)UpDownCenter.Value;
                        _g.arrowHeadAtHead = new ArrowHeadAtHead((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowHeadColor, _g);
                    }
                    if (_g.arrowHeadAtTail != null)
                    {
                        _g.ArrowHeadLength = (int)UpDownLength.Value;
                        _g.ArrowHeadWidth = (int)UpDownWidth.Value;
                        _g.ArrowHeadCenter = (int)UpDownCenter.Value;
                        _g.arrowHeadAtTail = new ArrowHeadAtTail((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowHeadColor, _g);
                    }
                    break;
                case tipMode.Tails:
                    if (_g.arrowTailAtTail != null)
                    {
                        _g.ArrowTailLength = (int)UpDownLength.Value;
                        _g.ArrowTailWidth = (int)UpDownWidth.Value;
                        _g.ArrowTailCenter = (int)UpDownCenter.Value;
                        _g.arrowTailAtTail = new ArrowTailAtTail((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowHeadColor, _g);
                    }
                    if (_g.arrowTailAtHead != null)
                    {
                        _g.ArrowTailLength = (int)UpDownLength.Value;
                        _g.ArrowTailWidth = (int)UpDownWidth.Value;
                        _g.ArrowTailCenter = (int)UpDownCenter.Value;
                        _g.arrowTailAtHead = new ArrowTailAtHead((int)UpDownCenter.Value, (int)UpDownLength.Value, (int)UpDownWidth.Value, _g.ArrowHeadColor, _g);
                    }
                    break;
                default: break;
            }
            _caller.Invalidate();
        }
        
    }
}
