using GraphicShapes;
using GraphicTool;
using System.Diagnostics;
using System.Windows.Forms;

namespace GraphicTool
{
    public partial class Form1 : Form
    {
        int NUMBEROFRECENTFILES = 10;
        string[] _args = null; //https://stackoverflow.com/questions/1179532/#37457463 (alternativ: string[] args = Environment.GetCommandLineArgs();)
        public Form1(string[] args)
        {
            if (args.Length > 0)
                _args = args;
            InitializeComponent();
            string loc = Properties.Settings.Default.DESKTOPBOUNDS;
            string[] temp = loc.Split(';');
            this.SetDesktopBounds(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[2]), Convert.ToInt32(temp[3]));
            //display.PreviewKeyDown += new PreviewKeyDownEventHandler(Display_PreviewKeyDown);
            display.setPaintMode(5);
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

        public void LoadImageFile(string fileName, bool doc)
        {
            if (!File.Exists(fileName)) return;
            display.LoadImageFile(fileName); //, Properties.Settings.Default.DISPLAYMODE, Properties.Settings.Default.SHOWDISPLAYINFO);        
            currentFileLabel.Text = fileName;
            //UNDER CONSTRUCTION!!! saveToolStripMenuItem.Enabled = true;
            if (doc) updateRecentFiles(fileName);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //display.LoadImageFile(@"C:\temp\deleteme.png");
            string fileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                if (fileName.EndsWith(".props")) fileName = fileName.Substring(0, fileName.Length - 6);
                //if (oldD) LoadImageFile(fileName, true);

                if (File.Exists(fileName + ".props")) BackgroundXMLRadioButton.Enabled = true; else BackgroundXMLRadioButton.Enabled = false;
                if (!File.Exists(fileName + ".props")) BackGroundCheckBox.Checked = true;
                display.LoadImageFile(fileName); //, Properties.Settings.Default.DISPLAYMODE, Properties.Settings.Default.SHOWDISPLAYINFO);
            }

            currentFileLabel.Text = fileName;
            //UNDER CONSTRUCTION!!! saveToolStripMenuItem.Enabled = true;

            updateRecentFiles(fileName);
        }

        private void updateRecentFiles(string fileName)
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
            //if(oldD) LoadImageFile((sender as ToolStripMenuItem).ToolTipText, true);
            string fileName = (sender as ToolStripMenuItem).ToolTipText;
            if (!File.Exists(fileName)) return;
            if (fileName.EndsWith(".props")) fileName = fileName.Substring(0, fileName.Length - 6);
            if (File.Exists(fileName + ".props")) BackgroundXMLRadioButton.Enabled = true; else BackgroundXMLRadioButton.Enabled = false;
            if (!File.Exists(fileName + ".props")) BackGroundCheckBox.Checked = true;
            display.LoadImageFile(fileName); //, Properties.Settings.Default.DISPLAYMODE, Properties.Settings.Default.SHOWDISPLAYINFO);
            currentFileLabel.Text = fileName;
            //UNDER CONSTRUCTION!!! saveToolStripMenuItem.Enabled = true;
            updateRecentFiles(fileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowInfoToolStripMenuItem.Checked = Properties.Settings.Default.SHOWDISPLAYINFO;
            ConfirmSaveToToolStripMenuItem.Checked = Properties.Settings.Default.SHOWSAVEIMAGETOBACKGROUNDWARNING;
            applyFileOpenMode();
            applyRecentFileList();
            if (_args != null && _args.Length > 0)
            {
                if (File.Exists(_args[0]))
                {
                    display.LoadImageFile(_args[0]);
                    currentFileLabel.Text = _args[0];
                    //UNDER CONSTRUCTION!!! saveToolStripMenuItem.Enabled = true;
                    updateRecentFiles(_args[0]);
                }
                else
                    MessageBox.Show(_args[0]);
            }
            splitContainer1.SplitterDistance = 142;
            //LoadTestCase("deleteme");
            //LoadTestCase("FontStyleTest");
            //LoadTestCase("texttest01");
            //LoadTestCase("texttest02");
            //LoadTestCase("textsizetest");
            //LoadTestCase("texttest05");
            //LoadTestCase("AutoStockPlaceIndexNumbersEx00");
            LoadTestCase("blurTest00");
            //LoadTestCase("iCMGIBBS15exampleT0702RVQ3");
            //LoadTestCase("complexShapes1");
            //LoadTestCase("tdmCompactToolAssemblyBOMPos");
            //Properties.Settings.Default.COLORS = "#308784;#1d5251;#59d396;#2fa567;#88b720;#628406;#208220;#0b540b;#5ec1e9;#359cbc;#5d8cc2;#306191;#3661a3;#1e457c;#7c67a3;#584877;#f4b425;#c68709;#ef890f;#c66a05;#e56469;#ba363f;#e56493;#b7376c;#8c8c8c;#666666;#636363;#4d4d4d;#ffffff;#dddddd;#000000;#555555";
            //Properties.Settings.Default.Save();
        }

        private void LoadTestCase(string testfile)
        {
            if (File.Exists("C:\\temp\\Backup\\" + testfile + ".png"))
                File.Copy("C:\\temp\\Backup\\" + testfile + ".png", "C:\\temp\\" + testfile + ".png", true);
            if (File.Exists("C:\\temp\\Backup\\" + testfile + ".png.props"))
            {
                File.Copy("C:\\temp\\Backup\\" + testfile + ".png.props", "C:\\temp\\" + testfile + ".png.props", true);
            }
            //else if (File.Exists("C:\\temp\\" + testfile + ".png.props"))
            //    File.Delete("C:\\temp\\" + testfile + ".png.props");


            if (File.Exists("C:\\temp\\" + testfile + ".png.props")) BackgroundXMLRadioButton.Enabled = true; else BackgroundXMLRadioButton.Enabled = false;
            if (!File.Exists("C:\\temp\\" + testfile + ".png.props")) BackgroundImageRadioButton.Checked = true;
            applyDisplayMode();
            display.LoadImageFile("C:\\temp\\" + testfile + ".png");//, Properties.Settings.Default.DISPLAYMODE, Properties.Settings.Default.SHOWDISPLAYINFO);
            currentFileLabel.Text = "C:\\temp\\" + testfile + ".png";
        }

        private void applyFileOpenMode()
        {
            int t = (int)Properties.Settings.Default.DISPLAYMODE;
            int temp = (t & 1);
            if (temp >= 1) ShapesCheckBox.Checked = true; else ShapesCheckBox.Checked = false;
            temp = (t & 2);
            if (temp >= 1) BackgroundImageRadioButton.Checked = true;
            temp = t & 4;
            if (temp >= 1) BackgroundXMLRadioButton.Checked = true;
            if (t > 1) BackGroundCheckBox.Checked = true;
            //if (oldD) display.setPaintMode(Properties.Settings.Default.DISPLAYMODE);
            display.setPaintMode(Properties.Settings.Default.DISPLAYMODE);
        }

        private void applyRecentFileList()
        {
            if (Properties.Settings.Default.RECENTFILES.Length > 0)
            {
                string[] temp = Properties.Settings.Default.RECENTFILES.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (File.Exists(temp[i]))
                        AddRecentFileMenuItem(temp[i]);
                }
            }

        }

        private void cBBackground_MouseUp(object sender, MouseEventArgs e)
        {
            applyDisplayMode();
        }

        private void rBBgImage_MouseUp(object sender, MouseEventArgs e)
        {
            applyDisplayMode();
        }

        private void rbBgXml_MouseUp(object sender, MouseEventArgs e)
        {
            applyDisplayMode();
        }

        private void ShapesCheckBox_MouseUp(object sender, MouseEventArgs e)
        {
            applyDisplayMode();
        }

        private void applyDisplayMode()
        {
            int temp = 0;
            if (BackGroundCheckBox.Checked)
            {
                BackgroundXMLRadioButton.Enabled = true;
                BackgroundImageRadioButton.Enabled = true;
                if (BackgroundXMLRadioButton.Checked) temp += 4;
                if (BackgroundImageRadioButton.Checked) temp += 2;
            }
            else
            {
                BackgroundXMLRadioButton.Enabled = false;
                BackgroundImageRadioButton.Enabled = false;
            }
            if (ShapesCheckBox.Checked) temp += 1;
            Properties.Settings.Default.DISPLAYMODE = temp;
            Properties.Settings.Default.Save();
            display.setPaintMode(Properties.Settings.Default.DISPLAYMODE);
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

        private void zoomSelector_ValueChanged(object sender, EventArgs e)
        {
            int f = (int)zoomSelector.Value;
            if (f <= 10) return;
            int step = (int)zoomSelector.Increment;
            display.setZoomFactor(f);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            zoomSelector.Value = 100;
        }

        private void currentFileLabel_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(currentFileLabel.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkbeforeSaving())
            {
                display.Save2File(currentFileLabel.Text);
            }
            if (File.Exists(currentFileLabel.Text + ".props")) BackgroundXMLRadioButton.Enabled = true; else BackgroundXMLRadioButton.Enabled = false;
        }

        private bool checkbeforeSaving()
        {
            if (Properties.Settings.Default.SHOWSAVEIMAGETOBACKGROUNDWARNING && ((Properties.Settings.Default.DISPLAYMODE & 2) == 2))
            {
                string Message = "This will save the current view as OriginalImage in the \".props\" File.\nContinue ?";
                if (MessageBox.Show(Message, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkbeforeSaving())
            {
                saveFileDialog1.DefaultExt = "png";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.InitialDirectory = Path.GetDirectoryName(currentFileLabel.Text);
                saveFileDialog1.FileName = Path.GetFileName(currentFileLabel.Text);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    //display01.Save2File(fileName);
                    AddRecentFileMenuItem(fileName);
                    //UNDER CONSTRUCTION!!! saveToolStripMenuItem.Enabled = true;
                    if (fileName.EndsWith(".props")) fileName = fileName.Substring(0, fileName.Length - 6);
                    currentFileLabel.Text = fileName;
                }
            }
            if (File.Exists(currentFileLabel.Text + ".props")) BackgroundXMLRadioButton.Enabled = true; else BackgroundXMLRadioButton.Enabled = false;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string argument = "/select, \"" + currentFileLabel.Text + "\"";
            Process.Start("explorer.exe", argument);
        }

        private void btnxml_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(currentFileLabel.Text + ".props")) BackgroundXMLRadioButton.Enabled = true; else BackgroundXMLRadioButton.Enabled = false;
            if (!File.Exists(currentFileLabel.Text + ".props")) BackgroundImageRadioButton.Checked = true;
            display.LoadImageFile(currentFileLabel.Text); //, Properties.Settings.Default.DISPLAYMODE, Properties.Settings.Default.SHOWDISPLAYINFO);
            //if(oldD) LoadImageFile(currentFileLabel.Text, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFileLabel.Text))
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.FileName = ("mspaint.exe");
                procInfo.Arguments = currentFileLabel.Text;

                System.Diagnostics.Process.Start(procInfo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFileLabel.Text))
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.FileName = (@"C:\Program Files (x86)\MadCap Software\MadCap Capture 7\Capture.app\Capture.exe");
                procInfo.Arguments = currentFileLabel.Text;

                System.Diagnostics.Process.Start(procInfo);
            }
        }



        private void currentFileLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(currentFileLabel.Text);
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DevTool01 Devtool = new DevTool01(this);
            Devtool.Top = 0; ;
            Devtool.Left = 0;
            Devtool.Show();
            return;
        }

        private void ShowInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ShapesCheckBox.Checked) ShapesCheckBox.Checked = true;
            display.AddShape(Properties.Settings.Default.RECTANGLE);
            BackgroundXMLRadioButton.Checked = true;
            applyDisplayMode();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!ShapesCheckBox.Checked) ShapesCheckBox.Checked = true;
            display.AddShape(Properties.Settings.Default.OVAL);
            BackgroundXMLRadioButton.Checked = true;
            applyDisplayMode();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!ShapesCheckBox.Checked) ShapesCheckBox.Checked = true;
            display.AddShape(Properties.Settings.Default.POLYLINE);
            BackgroundXMLRadioButton.Checked = true;
            applyDisplayMode();
        }

        private void btnLiftTopmost_Click(object sender, EventArgs e)
        {
            
        }
    }
}
