namespace GraphicTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip1 = new StatusStrip();
            currentFileLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            recentFilesToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            ShowInfoToolStripMenuItem = new ToolStripMenuItem();
            ConfirmSaveToToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            devToolsToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            butnAddTextBox = new Button();
            dmc1 = new DisplayModeControl();
            btnAddArrow = new Button();
            btnAddEllipse = new Button();
            btnAddRectangle = new Button();
            btnSendToCapture = new Button();
            btnSendToPaint = new Button();
            btnReload = new Button();
            btnXml = new Button();
            btnExplorer = new Button();
            zoomLabel = new Label();
            zoomSelector = new NumericUpDown();
            groupBox1 = new GroupBox();
            label1 = new Label();
            lblShapes = new Button();
            lblBgImg = new Button();
            cBShapes = new CheckBox();
            cBBackGround = new CheckBox();
            rBBackgroundXML = new RadioButton();
            rBBackgroundImage = new RadioButton();
            display = new Display();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)zoomSelector).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { currentFileLabel });
            statusStrip1.Location = new Point(0, 687);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1095, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // currentFileLabel
            // 
            currentFileLabel.Name = "currentFileLabel";
            currentFileLabel.Size = new Size(10, 17);
            currentFileLabel.Text = ".";
            currentFileLabel.Click += CurrentFileLabel_Click;
            currentFileLabel.DoubleClick += CurrentFileLabel_DoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1095, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, quitToolStripMenuItem, recentFilesToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(134, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(134, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(134, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(134, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += QuitToolStripMenuItem_Click;
            // 
            // recentFilesToolStripMenuItem
            // 
            recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            recentFilesToolStripMenuItem.Size = new Size(134, 22);
            recentFilesToolStripMenuItem.Text = "Recent files";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ShowInfoToolStripMenuItem, ConfirmSaveToToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // ShowInfoToolStripMenuItem
            // 
            ShowInfoToolStripMenuItem.CheckOnClick = true;
            ShowInfoToolStripMenuItem.Name = "ShowInfoToolStripMenuItem";
            ShowInfoToolStripMenuItem.Size = new Size(229, 22);
            ShowInfoToolStripMenuItem.Text = "Show Info";
            ShowInfoToolStripMenuItem.CheckedChanged += ShowInfoToolStripMenuItem_CheckedChanged;
            // 
            // ConfirmSaveToToolStripMenuItem
            // 
            ConfirmSaveToToolStripMenuItem.CheckOnClick = true;
            ConfirmSaveToToolStripMenuItem.Name = "ConfirmSaveToToolStripMenuItem";
            ConfirmSaveToToolStripMenuItem.Size = new Size(229, 22);
            ConfirmSaveToToolStripMenuItem.Text = "Confirm Save Image into Xml";
            ConfirmSaveToToolStripMenuItem.CheckedChanged += ConfirmSaveToToolStripMenuItem_CheckedChanged;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devToolsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // devToolsToolStripMenuItem
            // 
            devToolsToolStripMenuItem.Name = "devToolsToolStripMenuItem";
            devToolsToolStripMenuItem.Size = new Size(122, 22);
            devToolsToolStripMenuItem.Text = "DevTools";
            devToolsToolStripMenuItem.Click += DevToolsToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(butnAddTextBox);
            splitContainer1.Panel1.Controls.Add(dmc1);
            splitContainer1.Panel1.Controls.Add(btnAddArrow);
            splitContainer1.Panel1.Controls.Add(btnAddEllipse);
            splitContainer1.Panel1.Controls.Add(btnAddRectangle);
            splitContainer1.Panel1.Controls.Add(btnSendToCapture);
            splitContainer1.Panel1.Controls.Add(btnSendToPaint);
            splitContainer1.Panel1.Controls.Add(btnReload);
            splitContainer1.Panel1.Controls.Add(btnXml);
            splitContainer1.Panel1.Controls.Add(btnExplorer);
            splitContainer1.Panel1.Controls.Add(zoomLabel);
            splitContainer1.Panel1.Controls.Add(zoomSelector);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1MinSize = 140;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(display);
            splitContainer1.Size = new Size(1095, 663);
            splitContainer1.SplitterDistance = 166;
            splitContainer1.TabIndex = 2;
            // 
            // butnAddTextBox
            // 
            butnAddTextBox.FlatAppearance.BorderColor = Color.Silver;
            butnAddTextBox.FlatStyle = FlatStyle.Flat;
            butnAddTextBox.Image = (Image)resources.GetObject("butnAddTextBox.Image");
            butnAddTextBox.Location = new Point(10, 97);
            butnAddTextBox.Name = "butnAddTextBox";
            butnAddTextBox.Size = new Size(34, 34);
            butnAddTextBox.TabIndex = 12;
            butnAddTextBox.UseVisualStyleBackColor = true;
            butnAddTextBox.Click += butnAddTextBox_Click;
            // 
            // dmc1
            // 
            dmc1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dmc1.BorderStyle = BorderStyle.FixedSingle;
            dmc1.Location = new Point(3, 502);
            dmc1.Name = "dmc1";
            dmc1.Size = new Size(158, 85);
            dmc1.TabIndex = 11;
            dmc1.Visible = false;
            // 
            // btnAddArrow
            // 
            btnAddArrow.FlatAppearance.BorderColor = Color.Silver;
            btnAddArrow.FlatStyle = FlatStyle.Flat;
            btnAddArrow.Image = Properties.Resources._newArrow;
            btnAddArrow.Location = new Point(122, 97);
            btnAddArrow.Name = "btnAddArrow";
            btnAddArrow.Size = new Size(34, 34);
            btnAddArrow.TabIndex = 10;
            btnAddArrow.UseVisualStyleBackColor = true;
            btnAddArrow.Click += BtnAddArrow_Click;
            // 
            // btnAddEllipse
            // 
            btnAddEllipse.FlatAppearance.BorderColor = Color.Silver;
            btnAddEllipse.FlatStyle = FlatStyle.Flat;
            btnAddEllipse.Image = Properties.Resources._newOval;
            btnAddEllipse.Location = new Point(84, 97);
            btnAddEllipse.Name = "btnAddEllipse";
            btnAddEllipse.Size = new Size(34, 34);
            btnAddEllipse.TabIndex = 9;
            btnAddEllipse.UseVisualStyleBackColor = true;
            btnAddEllipse.Click += BtnAddEllipse_Click;
            // 
            // btnAddRectangle
            // 
            btnAddRectangle.FlatAppearance.BorderColor = Color.Silver;
            btnAddRectangle.FlatStyle = FlatStyle.Flat;
            btnAddRectangle.Image = Properties.Resources._newRectangle;
            btnAddRectangle.Location = new Point(47, 97);
            btnAddRectangle.Name = "btnAddRectangle";
            btnAddRectangle.Size = new Size(34, 34);
            btnAddRectangle.TabIndex = 8;
            btnAddRectangle.UseVisualStyleBackColor = true;
            btnAddRectangle.Click += BtnAddRectangle_Click;
            // 
            // btnSendToCapture
            // 
            btnSendToCapture.FlatAppearance.BorderColor = Color.Silver;
            btnSendToCapture.FlatStyle = FlatStyle.Flat;
            btnSendToCapture.Image = Properties.Resources._capture;
            btnSendToCapture.Location = new Point(47, 60);
            btnSendToCapture.Name = "btnSendToCapture";
            btnSendToCapture.Size = new Size(34, 34);
            btnSendToCapture.TabIndex = 7;
            btnSendToCapture.UseVisualStyleBackColor = true;
            btnSendToCapture.Click += BtnSendToCapture_Click;
            // 
            // btnSendToPaint
            // 
            btnSendToPaint.FlatAppearance.BorderColor = Color.Silver;
            btnSendToPaint.FlatStyle = FlatStyle.Flat;
            btnSendToPaint.ForeColor = SystemColors.ControlText;
            btnSendToPaint.Image = Properties.Resources._mspaint;
            btnSendToPaint.Location = new Point(10, 60);
            btnSendToPaint.Name = "btnSendToPaint";
            btnSendToPaint.Size = new Size(34, 34);
            btnSendToPaint.TabIndex = 6;
            btnSendToPaint.UseVisualStyleBackColor = true;
            btnSendToPaint.Click += BtnSendToPaint_Click;
            // 
            // btnReload
            // 
            btnReload.FlatAppearance.BorderColor = Color.Silver;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Image = Properties.Resources.resume;
            btnReload.Location = new Point(84, 22);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(34, 34);
            btnReload.TabIndex = 5;
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += BtnReloadClick;
            // 
            // btnXml
            // 
            btnXml.FlatAppearance.BorderColor = Color.Silver;
            btnXml.FlatStyle = FlatStyle.Flat;
            btnXml.Image = Properties.Resources.xml;
            btnXml.Location = new Point(47, 22);
            btnXml.Name = "btnXml";
            btnXml.Size = new Size(34, 34);
            btnXml.TabIndex = 4;
            btnXml.UseVisualStyleBackColor = true;
            btnXml.Click += BtnXml_Click;
            // 
            // btnExplorer
            // 
            btnExplorer.FlatAppearance.BorderColor = Color.Silver;
            btnExplorer.FlatStyle = FlatStyle.Flat;
            btnExplorer.ForeColor = SystemColors.ControlText;
            btnExplorer.Image = Properties.Resources.opendir;
            btnExplorer.Location = new Point(10, 22);
            btnExplorer.Name = "btnExplorer";
            btnExplorer.Size = new Size(34, 34);
            btnExplorer.TabIndex = 3;
            btnExplorer.UseVisualStyleBackColor = true;
            btnExplorer.Click += BtnExplorer_Click;
            // 
            // zoomLabel
            // 
            zoomLabel.AutoSize = true;
            zoomLabel.Location = new Point(3, 147);
            zoomLabel.Name = "zoomLabel";
            zoomLabel.Size = new Size(39, 15);
            zoomLabel.TabIndex = 2;
            zoomLabel.Text = "Zoom";
            zoomLabel.DoubleClick += ZoomSelector_DoubleClick;
            // 
            // zoomSelector
            // 
            zoomSelector.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            zoomSelector.Location = new Point(103, 145);
            zoomSelector.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            zoomSelector.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            zoomSelector.Name = "zoomSelector";
            zoomSelector.Size = new Size(56, 23);
            zoomSelector.TabIndex = 1;
            zoomSelector.TabStop = false;
            zoomSelector.Value = new decimal(new int[] { 100, 0, 0, 0 });
            zoomSelector.ValueChanged += ZoomSelector_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblShapes);
            groupBox1.Controls.Add(lblBgImg);
            groupBox1.Controls.Add(cBShapes);
            groupBox1.Controls.Add(cBBackGround);
            groupBox1.Controls.Add(rBBackgroundXML);
            groupBox1.Controls.Add(rBBackgroundImage);
            groupBox1.Location = new Point(3, 165);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 70);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 15;
            label1.Text = ".";
            // 
            // lblShapes
            // 
            lblShapes.BackColor = Color.White;
            lblShapes.FlatAppearance.BorderColor = Color.Silver;
            lblShapes.FlatAppearance.MouseDownBackColor = Color.White;
            lblShapes.FlatAppearance.MouseOverBackColor = Color.White;
            lblShapes.FlatStyle = FlatStyle.Flat;
            lblShapes.ForeColor = SystemColors.ControlText;
            lblShapes.Image = (Image)resources.GetObject("lblShapes.Image");
            lblShapes.Location = new Point(119, 55);
            lblShapes.Name = "lblShapes";
            lblShapes.Size = new Size(17, 32);
            lblShapes.TabIndex = 14;
            lblShapes.UseVisualStyleBackColor = false;
            lblShapes.Visible = false;
            lblShapes.Click += lblShapes_Click;
            // 
            // lblBgImg
            // 
            lblBgImg.FlatAppearance.BorderColor = Color.Silver;
            lblBgImg.FlatStyle = FlatStyle.Flat;
            lblBgImg.ForeColor = SystemColors.ControlText;
            lblBgImg.Image = (Image)resources.GetObject("lblBgImg.Image");
            lblBgImg.Location = new Point(120, 37);
            lblBgImg.Name = "lblBgImg";
            lblBgImg.Size = new Size(16, 16);
            lblBgImg.TabIndex = 12;
            lblBgImg.UseVisualStyleBackColor = true;
            lblBgImg.Visible = false;
            // 
            // cBShapes
            // 
            cBShapes.AutoSize = true;
            cBShapes.Location = new Point(9, 69);
            cBShapes.Name = "cBShapes";
            cBShapes.Size = new Size(63, 19);
            cBShapes.TabIndex = 6;
            cBShapes.Text = "Shapes";
            cBShapes.UseVisualStyleBackColor = true;
            cBShapes.MouseUp += cBShapes_MouseUp;
            // 
            // cBBackGround
            // 
            cBBackGround.AutoSize = true;
            cBBackGround.Location = new Point(7, 19);
            cBBackGround.Name = "cBBackGround";
            cBBackGround.Size = new Size(90, 19);
            cBBackGround.TabIndex = 5;
            cBBackGround.Text = "Background";
            cBBackGround.UseVisualStyleBackColor = true;
            cBBackGround.MouseUp += cBBackground_MouseUp;
            // 
            // rBBackgroundXML
            // 
            rBBackgroundXML.AutoSize = true;
            rBBackgroundXML.Location = new Point(21, 52);
            rBBackgroundXML.Name = "rBBackgroundXML";
            rBBackgroundXML.Size = new Size(49, 19);
            rBBackgroundXML.TabIndex = 4;
            rBBackgroundXML.TabStop = true;
            rBBackgroundXML.Text = "XML";
            rBBackgroundXML.UseVisualStyleBackColor = true;
            rBBackgroundXML.MouseUp += rbBackgroundXml_MouseUp;
            // 
            // rBBackgroundImage
            // 
            rBBackgroundImage.AutoSize = true;
            rBBackgroundImage.Location = new Point(21, 35);
            rBBackgroundImage.Name = "rBBackgroundImage";
            rBBackgroundImage.Size = new Size(58, 19);
            rBBackgroundImage.TabIndex = 3;
            rBBackgroundImage.TabStop = true;
            rBBackgroundImage.Text = "Image";
            rBBackgroundImage.UseVisualStyleBackColor = true;
            rBBackgroundImage.MouseUp += rBBackgroundImage_MouseUp;
            // 
            // display
            // 
            display.BackColor = Color.MistyRose;
            display.Dock = DockStyle.Fill;
            display.Location = new Point(0, 0);
            display.Name = "display";
            display.Size = new Size(925, 663);
            display.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 709);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form2";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            LocationChanged += Form1_LocationChanged;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)zoomSelector).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel currentFileLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Display display;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox1;
        private RadioButton rBBackgroundXML;
        private RadioButton rBBackgroundImage;
        private CheckBox cBShapes;
        private CheckBox cBBackGround;
        private ToolStripMenuItem recentFilesToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem ShowInfoToolStripMenuItem;
        private ToolStripMenuItem ConfirmSaveToToolStripMenuItem;
        private NumericUpDown zoomSelector;
        private Label zoomLabel;
        private SaveFileDialog saveFileDialog1;
        private Button btnExplorer;
        private Button btnXml;
        private Button btnReload;
        private Button btnAddRectangle;
        private Button btnSendToCapture;
        private Button btnSendToPaint;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem devToolsToolStripMenuItem;
        private Button btnAddArrow;
        private Button btnAddEllipse;
        private DisplayModeControl dmc1;
        private Button lblBgImg;
        private Button lblShapes;
        private Label label1;
        private Button butnAddTextBox;
    }
}