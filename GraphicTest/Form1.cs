using GraphicShapes;
using GraphicTool;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GraphicTool
{
    public partial class Form1 : Form
    {
        int NUMBEROFRECENTFILES = 10;
        string[] _args = null; //https://stackoverflow.com/questions/1179532/#37457463 (alternativ: string[] args = Environment.GetCommandLineArgs();)


        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0) _args = args;
            display.Saved += () => CheckPropsFile();
            display.ShapeCount += () => getShapesCount();
            //DEBUG argument: C:\temp\test\test.png
            this.display.Value_Change += this.Form1_GetDisplayStatus;
        }

        // EventHandler
        public void Form1_GetDisplayStatus(Display sender, DisplayChangesEventArgs e)
        {
            //The following could replace these "Saved & ShapeCount - Actions":
            //label1.Text = "Count: " + e.Count.ToString();
        }


        private void getShapesCount()
        {
            int z = display.getShapeCount();
            if (z > 0)
                label1.Text = "(" + z.ToString() + ")";
            else
                label1.Text = "";
        }

        private bool CheckPropsFile()
        {
            if (File.Exists(currentFileLabel.Text + ".props"))
            {
                lblShapes.Visible = true;
                return true;
            }
            else
            {
                lblShapes.Visible = false;
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string loc = Properties.Settings.Default.DESKTOPBOUNDS;
            string[] temp = loc.Split(';');
            this.SetDesktopBounds(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[2]), Convert.ToInt32(temp[3]));

            ShowInfoToolStripMenuItem.Checked = Properties.Settings.Default.SHOWDISPLAYINFO;
            ConfirmSaveToToolStripMenuItem.Checked = Properties.Settings.Default.SHOWSAVEIMAGETOBACKGROUNDWARNING;
            GetDisplayModeProperty();
            InitRecentFileList();

            if (_args != null && _args.Length > 0)
            {
                LoadFile(_args[0], true);  //Some test cases - false
                if (!File.Exists(_args[0])) MessageBox.Show(_args[0], "Invalid file argument");
            }

            // --- TEST CASE for Images where props file is created during the session:
            if (File.Exists(@"C:\temp\test\testNoProps.png.props"))  //testNoPropsBAK.png
                File.Delete(@"C:\temp\test\testNoProps.png.props");
            if (File.Exists(@"C:\temp\test\testNoPropsBAK.png"))
                File.Copy(@"C:\temp\test\testNoPropsBAK.png", @"C:\temp\test\testNoProps.png", true);

            //Other Test cases:
            //("deleteme");
            //("FontStyleTest");
            //("texttest01");
            //("texttest02");
            //("textsizetest");
            //("texttest05");
            //("blurTest00");
            //("complexShapes1");
            //Properties.Settings.Default.COLORS = "#308784;#1d5251;#59d396;#2fa567;#88b720;#628406;#208220;#0b540b;#5ec1e9;#359cbc;#5d8cc2;#306191;#3661a3;#1e457c;#7c67a3;#584877;#f4b425;#c68709;#ef890f;#c66a05;#e56469;#ba363f;#e56493;#b7376c;#8c8c8c;#666666;#636363;#4d4d4d;#ffffff;#dddddd;#000000;#555555";
            //Properties.Settings.Default.Save();
        }

        public void LoadFile(string fileName, bool doc)
        {
            if (fileName.EndsWith(".props")) fileName = fileName.Substring(0, fileName.Length - 6);
            if (!File.Exists(fileName)) return;
            display.LoadImageFile(fileName);
            lblBgImg.Visible = true;
            if (currentFileLabel.Text != fileName) currentFileLabel.Text = fileName;

            if (CheckPropsFile())
            {
                display.loadPropsFile(fileName + ".props");
                if (doc) UpdateRecentFiles(fileName);
            }
        }

        // -------------------- FILE HISTORY -------------------- 

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = DialogResult.OK;
            if (display.changed)
            {
                d = MessageBox.Show("Save changes before opening the new file?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (d == DialogResult.Yes)
                {
                    display.Save2File(currentFileLabel.Text);
                }
                else
                {
                    if (d == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                LoadFile(openFileDialog1.FileName, true);
            }
        }

        private void UpdateRecentFiles(string fileName)
        {
            int index = -1;
            int i = 0;
            while (i < recentFilesToolStripMenuItem.DropDownItems.Count)
            {
                if (recentFilesToolStripMenuItem.DropDownItems[i].ToolTipText.ToLower() == fileName.ToLower())
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (index > -1)
            {
                for (int j = index; j > 0; j--)
                {
                    recentFilesToolStripMenuItem.DropDownItems[j].ToolTipText = recentFilesToolStripMenuItem.DropDownItems[j - 1].ToolTipText;
                    recentFilesToolStripMenuItem.DropDownItems[j].Text = recentFilesToolStripMenuItem.DropDownItems[j - 1].Text;
                }
                recentFilesToolStripMenuItem.DropDownItems[0].ToolTipText = fileName;
                recentFilesToolStripMenuItem.DropDownItems[0].Text = Path.GetFileName(fileName);
            }
            else
            {
                if (recentFilesToolStripMenuItem.DropDownItems.Count < NUMBEROFRECENTFILES)
                {
                    AddRecentFileMenuItem(fileName);
                }
                else
                {
                    for (int j = NUMBEROFRECENTFILES - 1; j >= 1; j--)
                    {
                        recentFilesToolStripMenuItem.DropDownItems[j].ToolTipText = recentFilesToolStripMenuItem.DropDownItems[j - 1].ToolTipText;
                        recentFilesToolStripMenuItem.DropDownItems[j].Text = recentFilesToolStripMenuItem.DropDownItems[j - 1].Text;
                    }
                    recentFilesToolStripMenuItem.DropDownItems[0].ToolTipText = fileName;
                    recentFilesToolStripMenuItem.DropDownItems[0].Text = Path.GetFileName(fileName);
                }
            }

            string t = "";
            foreach (ToolStripItem item in recentFilesToolStripMenuItem.DropDownItems)
                t = item.ToolTipText + ";" + t;
            Properties.Settings.Default.RECENTFILES = t;
            Properties.Settings.Default.Save();
        }

        public void AddRecentFileMenuItem(string fileName)
        {
            ToolStripItem newItem = recentFilesToolStripMenuItem.DropDownItems.Add(Path.GetFileName(fileName));
            recentFilesToolStripMenuItem.DropDownItems.Insert(0, newItem);
            newItem.ToolTipText = fileName;
            newItem.Click += new EventHandler(RecentFileMenuItem_Load);
        }

        private void RecentFileMenuItem_Load(object sender, EventArgs e)
        {
            string fileName = (sender as ToolStripMenuItem).ToolTipText;
            if (fileName.EndsWith(".props")) fileName = fileName.Substring(0, fileName.Length - 6);
            if (!File.Exists(fileName)) return;

            DialogResult d = DialogResult.OK;
            if (display.changed)
            {
                d = MessageBox.Show("Save changes before opening the new file?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (d == DialogResult.Yes)
                {
                    display.Save2File(currentFileLabel.Text);
                }
                else
                {
                    if (d == DialogResult.Cancel)
                    {
                        //LoadFile(currentFileLabel.Text, false);
                        return;
                    }
                }
            }
            LoadFile(fileName, true);
            currentFileLabel.Text = fileName;
            UpdateRecentFiles(fileName);
        }

        private void InitRecentFileList()
        {
            if (Properties.Settings.Default.RECENTFILES.Length > 0)
            {
                string[] temp = Properties.Settings.Default.RECENTFILES.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    string fileName = temp[i];
                    if (File.Exists(fileName))
                        AddRecentFileMenuItem(fileName);
                }
            }
        }

        // -------------------- DISPLAY MODE --------------------

        private void cBBackground_MouseUp(object sender, MouseEventArgs e)
        {
            setDisplayMode();
        }

        private void rBBackgroundImage_MouseUp(object sender, MouseEventArgs e)
        {
            setDisplayMode();
        }

        private void rbBackgroundXml_MouseUp(object sender, MouseEventArgs e)
        {
            setDisplayMode();
        }

        private void cBShapes_MouseUp(object sender, MouseEventArgs e)
        {
            setDisplayMode();
        }

        private void setDisplayMode()
        {
            int temp = 0;
            if (cBBackGround.Checked)
            {
                rBBackgroundXML.Enabled = true;
                rBBackgroundImage.Enabled = true;
                if (rBBackgroundXML.Checked) temp += 4;
                if (rBBackgroundImage.Checked) temp += 2;
            }
            else
            {
                rBBackgroundXML.Enabled = false;
                rBBackgroundImage.Enabled = false;
            }
            if (cBShapes.Checked) temp += 1;
            Properties.Settings.Default.DISPLAYMODE = temp;
            Properties.Settings.Default.Save();
            display.setDrawMode(Properties.Settings.Default.DISPLAYMODE);
            //display.Invalidate();
        }

        private void GetDisplayModeProperty()
        {
            int b = (byte)Properties.Settings.Default.DISPLAYMODE;

            if ((b & (1 << 0)) > 0) cBShapes.Checked = true; else cBShapes.Checked = false;
            if ((b & (1 << 1)) > 0) rBBackgroundImage.Checked = true;
            if ((b & (1 << 2)) > 0) rBBackgroundXML.Checked = true;
            if (b > 1) cBBackGround.Checked = true;

            display.setDrawMode(Properties.Settings.Default.DISPLAYMODE);
        }

        private void ConfirmSaveToToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfirmSaveToToolStripMenuItem.Checked)
                Properties.Settings.Default.SHOWSAVEIMAGETOBACKGROUNDWARNING = true;
            else
                Properties.Settings.Default.SHOWSAVEIMAGETOBACKGROUNDWARNING = false;
            Properties.Settings.Default.Save();
        }

        private void ShowInfoToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SHOWDISPLAYINFO = ShowInfoToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            display.setInfo(ShowInfoToolStripMenuItem.Checked);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DESKTOPBOUNDS = this.DesktopBounds.X.ToString() + ";" + this.DesktopBounds.Y.ToString() + ";" + this.DesktopBounds.Width.ToString() + ";" + this.DesktopBounds.Height.ToString();
            Properties.Settings.Default.Save();
            //https://stackoverflow.com/questions/1873658/net-windows-forms-remember-windows-size-and-location
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DESKTOPBOUNDS = this.DesktopBounds.X.ToString() + ";" + this.DesktopBounds.Y.ToString() + ";" + this.DesktopBounds.Width.ToString() + ";" + this.DesktopBounds.Height.ToString();
            Properties.Settings.Default.Save();
        }

        private void ZoomSelector_ValueChanged(object sender, EventArgs e)
        {
            int f = (int)zoomSelector.Value;
            if (f <= 10) return;
            int step = (int)zoomSelector.Increment;
            display.setZoomFactor(f);
        }

        private void ZoomSelector_DoubleClick(object sender, EventArgs e)
        {
            zoomSelector.Value = 100;
        }

        private void CurrentFileLabel_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(currentFileLabel.Text);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Save2File(currentFileLabel.Text);
            if (File.Exists(currentFileLabel.Text + ".props"))
                rBBackgroundXML.Enabled = true;
            else rBBackgroundXML.Enabled = false;
        }

        private bool CheckBgBeforeSaving()
        {
            ////TODO: Offer options to save:
            ////1. to save current view in Image file, but in XML only background without shapes
            ////2. to save current view in Image, as well as in XML
            ////3. Save only view to Image file, skip props file if available.
            ////4. Cancel
            //if (Properties.Settings.Default.SHOWSAVEIMAGETOBACKGROUNDWARNING && ((Properties.Settings.Default.DISPLAYMODE & 4) == 4))
            //{
            //    string Message = "This will save the current view as OriginalImage in the \".props\" File.\nContinue ?";
            //    if (MessageBox.Show(Message, "TODO: CheckBgBeforeSaving", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(currentFileLabel.Text);
            saveFileDialog1.FileName = Path.GetFileName(currentFileLabel.Text);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                AddRecentFileMenuItem(fileName);
                currentFileLabel.Text = fileName;
                //UNDER CONSTRUCTION!!! saveToolStripMenuItem.Enabled = true;
                if (fileName.EndsWith(".props")) fileName = fileName.Substring(0, fileName.Length - 6);
                display.Save2File(currentFileLabel.Text);
            }
            if (File.Exists(currentFileLabel.Text + ".props")) rBBackgroundXML.Enabled = true; else rBBackgroundXML.Enabled = false;
        }

        private void BtnExplorer_Click(object sender, EventArgs e)
        {
            string argument = "/select, \"" + currentFileLabel.Text + "\"";
            Process.Start("explorer.exe", argument);
        }

        private void BtnXml_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFileLabel.Text + ".props"))
            {
                try
                {
                    if (File.Exists("C:\\Program Files\\Notepad++\\notepad++.exe"))
                        Process.Start("C:\\Program Files\\Notepad++\\notepad++.exe", currentFileLabel.Text + ".props");
                    else
                    if (File.Exists("C:\\Program Files (x86)\\Notepad++\\notepad++.exe"))
                        Process.Start("C:\\Program Files (x86)\\Notepad++\\notepad++.exe", currentFileLabel.Text + ".props");
                    else
                        Process.Start("notepad.exe", currentFileLabel.Text + ".props");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnReloadClick(object sender, EventArgs e)
        {
            string fileName = currentFileLabel.Text;
            LoadFile(fileName, false);
        }

        private void BtnSendToPaint_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFileLabel.Text))
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.FileName = ("mspaint.exe");
                procInfo.Arguments = currentFileLabel.Text;

                Process.Start(procInfo);
            }
        }

        private void BtnSendToCapture_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFileLabel.Text))
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.FileName = (@"C:\Program Files (x86)\MadCap Software\MadCap Capture 7\Capture.app\Capture.exe");
                procInfo.Arguments = currentFileLabel.Text;

                System.Diagnostics.Process.Start(procInfo);
            }
        }

        private void CurrentFileLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(currentFileLabel.Text);
        }

        private void DevToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevTool01 Devtool = new DevTool01(this);
            Devtool.Top = 0; ;
            Devtool.Left = 0;
            Devtool.Show();
            return;
        }

        private void BtnAddRectangle_Click(object sender, EventArgs e)
        {
            if (!cBShapes.Checked) cBShapes.Checked = true;
            display.AddShape(Properties.Settings.Default.RECTANGLE);
            //rBBackgroundXML.Checked = true;
            setDisplayMode();
        }

        private void BtnAddEllipse_Click(object sender, EventArgs e)
        {
            if (!cBShapes.Checked) cBShapes.Checked = true;
            display.AddShape(Properties.Settings.Default.OVAL);
            //rBBackgroundXML.Checked = true;
            setDisplayMode();
        }

        private void BtnAddArrow_Click(object sender, EventArgs e)
        {
            if (!cBShapes.Checked) cBShapes.Checked = true;
            display.AddShape(Properties.Settings.Default.POLYLINE);
            //rBBackgroundXML.Checked = true;
            setDisplayMode();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCancel();
        }

        /// <summary>
        /// wird für das beenden über "x" gebraucht.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseCancel();
        }

        public void CloseCancel()
        {
            if (display.changed)
            {
                DialogResult d = MessageBox.Show("There are unsaved changes. Save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if ( d == DialogResult.No)
                {
                    display.changed = false;
                    this.Close();
                }
                else
                {
                    if (d == DialogResult.Cancel)
                        return;
                    else
                        display.Save2File(currentFileLabel.Text);
                }
            }
            else
                Environment.Exit(0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void lblShapes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save the current view into the image file and delete the .props file?",
                     "Delete XML Properties", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                display.SaveCurrentView2File(currentFileLabel.Text);
            }
        }

        private void butnAddTextBox_Click(object sender, EventArgs e)
        {
            if (!cBShapes.Checked) cBShapes.Checked = true;
            int index = display.AddShape(Properties.Settings.Default.TEXTBOX);
            display.setFocus(index);
            setDisplayMode();
        }
    }
}
