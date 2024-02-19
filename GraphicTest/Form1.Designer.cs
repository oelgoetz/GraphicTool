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
            statusStrip1 = new StatusStrip();
            currentFileLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            recentFilesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            ShowInfoToolStripMenuItem = new ToolStripMenuItem();
            ConfirmSaveToToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            devToolsToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            button6 = new Button();
            button5 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button1 = new Button();
            btnxml = new Button();
            btnExplorer = new Button();
            zoomLabel = new Label();
            zoomSelector = new NumericUpDown();
            groupBox1 = new GroupBox();
            ShapesCheckBox = new CheckBox();
            BackGroundCheckBox = new CheckBox();
            BackgroundXMLRadioButton = new RadioButton();
            BackgroundImageRadioButton = new RadioButton();
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
            currentFileLabel.Click += currentFileLabel_Click;
            currentFileLabel.DoubleClick += currentFileLabel_DoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolStripMenuItem1, settingsToolStripMenuItem, toolsToolStripMenuItem });
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
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(180, 22);
            quitToolStripMenuItem.Text = "Quit";
            // 
            // recentFilesToolStripMenuItem
            // 
            recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            recentFilesToolStripMenuItem.Size = new Size(180, 22);
            recentFilesToolStripMenuItem.Text = "Recent files";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 20);
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
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // devToolsToolStripMenuItem
            // 
            devToolsToolStripMenuItem.Name = "devToolsToolStripMenuItem";
            devToolsToolStripMenuItem.Size = new Size(121, 22);
            devToolsToolStripMenuItem.Text = "DevTools";
            devToolsToolStripMenuItem.Click += devToolsToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button6);
            splitContainer1.Panel1.Controls.Add(button5);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(btnxml);
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
            splitContainer1.SplitterDistance = 140;
            splitContainer1.TabIndex = 2;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderColor = Color.Silver;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Image = Properties.Resources._newArrow;
            button6.Location = new Point(85, 98);
            button6.Name = "button6";
            button6.Size = new Size(34, 34);
            button6.TabIndex = 10;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderColor = Color.Silver;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Image = Properties.Resources._newOval;
            button5.Location = new Point(47, 98);
            button5.Name = "button5";
            button5.Size = new Size(34, 34);
            button5.TabIndex = 9;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources._newRectangle;
            button2.Location = new Point(10, 98);
            button2.Name = "button2";
            button2.Size = new Size(34, 34);
            button2.TabIndex = 8;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.Silver;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = Properties.Resources._capture;
            button3.Location = new Point(47, 60);
            button3.Name = "button3";
            button3.Size = new Size(34, 34);
            button3.TabIndex = 7;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.Silver;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ControlText;
            button4.Image = Properties.Resources._mspaint;
            button4.Location = new Point(10, 60);
            button4.Name = "button4";
            button4.Size = new Size(34, 34);
            button4.TabIndex = 6;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.resume;
            button1.Location = new Point(84, 22);
            button1.Name = "button1";
            button1.Size = new Size(34, 34);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnxml
            // 
            btnxml.FlatAppearance.BorderColor = Color.Silver;
            btnxml.FlatStyle = FlatStyle.Flat;
            btnxml.Image = Properties.Resources.xml;
            btnxml.Location = new Point(47, 22);
            btnxml.Name = "btnxml";
            btnxml.Size = new Size(34, 34);
            btnxml.TabIndex = 4;
            btnxml.UseVisualStyleBackColor = true;
            btnxml.Click += btnxml_Click;
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
            btnExplorer.Click += button1_Click;
            // 
            // zoomLabel
            // 
            zoomLabel.AutoSize = true;
            zoomLabel.Location = new Point(3, 147);
            zoomLabel.Name = "zoomLabel";
            zoomLabel.Size = new Size(39, 15);
            zoomLabel.TabIndex = 2;
            zoomLabel.Text = "Zoom";
            zoomLabel.DoubleClick += label1_DoubleClick;
            // 
            // zoomSelector
            // 
            zoomSelector.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            zoomSelector.Location = new Point(81, 145);
            zoomSelector.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            zoomSelector.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            zoomSelector.Name = "zoomSelector";
            zoomSelector.Size = new Size(56, 23);
            zoomSelector.TabIndex = 1;
            zoomSelector.TabStop = false;
            zoomSelector.Value = new decimal(new int[] { 100, 0, 0, 0 });
            zoomSelector.ValueChanged += zoomSelector_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ShapesCheckBox);
            groupBox1.Controls.Add(BackGroundCheckBox);
            groupBox1.Controls.Add(BackgroundXMLRadioButton);
            groupBox1.Controls.Add(BackgroundImageRadioButton);
            groupBox1.Location = new Point(3, 165);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(135, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // ShapesCheckBox
            // 
            ShapesCheckBox.AutoSize = true;
            ShapesCheckBox.Location = new Point(9, 69);
            ShapesCheckBox.Name = "ShapesCheckBox";
            ShapesCheckBox.Size = new Size(63, 19);
            ShapesCheckBox.TabIndex = 6;
            ShapesCheckBox.Text = "Shapes";
            ShapesCheckBox.UseVisualStyleBackColor = true;
            ShapesCheckBox.MouseUp += ShapesCheckBox_MouseUp;
            // 
            // BackGroundCheckBox
            // 
            BackGroundCheckBox.AutoSize = true;
            BackGroundCheckBox.Location = new Point(7, 19);
            BackGroundCheckBox.Name = "BackGroundCheckBox";
            BackGroundCheckBox.Size = new Size(90, 19);
            BackGroundCheckBox.TabIndex = 5;
            BackGroundCheckBox.Text = "Background";
            BackGroundCheckBox.UseVisualStyleBackColor = true;
            BackGroundCheckBox.MouseUp += cBBackground_MouseUp;
            // 
            // BackgroundXMLRadioButton
            // 
            BackgroundXMLRadioButton.AutoSize = true;
            BackgroundXMLRadioButton.Location = new Point(21, 52);
            BackgroundXMLRadioButton.Name = "BackgroundXMLRadioButton";
            BackgroundXMLRadioButton.Size = new Size(49, 19);
            BackgroundXMLRadioButton.TabIndex = 4;
            BackgroundXMLRadioButton.TabStop = true;
            BackgroundXMLRadioButton.Text = "XML";
            BackgroundXMLRadioButton.UseVisualStyleBackColor = true;
            BackgroundXMLRadioButton.MouseUp += rbBgXml_MouseUp;
            // 
            // BackgroundImageRadioButton
            // 
            BackgroundImageRadioButton.AutoSize = true;
            BackgroundImageRadioButton.Location = new Point(21, 35);
            BackgroundImageRadioButton.Name = "BackgroundImageRadioButton";
            BackgroundImageRadioButton.Size = new Size(58, 19);
            BackgroundImageRadioButton.TabIndex = 3;
            BackgroundImageRadioButton.TabStop = true;
            BackgroundImageRadioButton.Text = "Image";
            BackgroundImageRadioButton.UseVisualStyleBackColor = true;
            BackgroundImageRadioButton.MouseUp += rBBgImage_MouseUp;
            // 
            // display
            // 
            display.BackColor = Color.MistyRose;
            display.Dock = DockStyle.Fill;
            display.Location = new Point(0, 0);
            display.Name = "display";
            display.Size = new Size(951, 663);
            display.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
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
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox1;
        private RadioButton BackgroundXMLRadioButton;
        private RadioButton BackgroundImageRadioButton;
        private CheckBox ShapesCheckBox;
        private CheckBox BackGroundCheckBox;
        private ToolStripMenuItem recentFilesToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem ShowInfoToolStripMenuItem;
        private ToolStripMenuItem ConfirmSaveToToolStripMenuItem;
        private NumericUpDown zoomSelector;
        private Label zoomLabel;
        private SaveFileDialog saveFileDialog1;
        private Button btnExplorer;
        private Button btnxml;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem devToolsToolStripMenuItem;
        private Button button6;
        private Button button5;
    }
}