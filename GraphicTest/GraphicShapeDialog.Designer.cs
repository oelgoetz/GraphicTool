namespace GraphicTool
{
    partial class GraphicShapeDialog
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicShapeDialog));
            groupBox2 = new GroupBox();
            cBUnderline = new CheckBox();
            cBItalic = new CheckBox();
            cBBold = new CheckBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            UpDownLineWidth = new NumericUpDown();
            rBText = new RadioButton();
            rBBackground = new RadioButton();
            rbLine = new RadioButton();
            colorPalette1 = new ColorPalette();
            button3 = new Button();
            groupBox3 = new GroupBox();
            a22 = new Button();
            a21 = new Button();
            a20 = new Button();
            a12 = new Button();
            a11 = new Button();
            a10 = new Button();
            a02 = new Button();
            a01 = new Button();
            a00 = new Button();
            groupBox4 = new GroupBox();
            PdBottom = new NumericUpDown();
            PdRight = new NumericUpDown();
            PdLeft = new NumericUpDown();
            PdTop = new NumericUpDown();
            label1 = new Label();
            lblFontName = new Label();
            UpDownFontSize = new NumericUpDown();
            CmbFontFamily = new ComboBox();
            fontPanel = new Panel();
            TabControl1 = new TabControl();
            TextTab = new TabPage();
            ArrowsTab = new TabPage();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            EffectsTab = new TabPage();
            UpDownBlur = new NumericUpDown();
            cBBlur = new CheckBox();
            groupBox5 = new GroupBox();
            UpDownZoom = new NumericUpDown();
            label9 = new Label();
            cBZoom = new CheckBox();
            label8 = new Label();
            UpDownMoveX = new NumericUpDown();
            UpDownMoveY = new NumericUpDown();
            imageList1 = new ImageList(components);
            menuStrip1 = new MenuStrip();
            topmost = new ToolStripMenuItem();
            Lift = new ToolStripMenuItem();
            Sink = new ToolStripMenuItem();
            Bottom = new ToolStripMenuItem();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownLineWidth).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PdBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PdRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PdLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PdTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownFontSize).BeginInit();
            fontPanel.SuspendLayout();
            TabControl1.SuspendLayout();
            TextTab.SuspendLayout();
            ArrowsTab.SuspendLayout();
            EffectsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownBlur).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownZoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownMoveX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownMoveY).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cBUnderline);
            groupBox2.Controls.Add(cBItalic);
            groupBox2.Controls.Add(cBBold);
            groupBox2.Location = new Point(3, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(110, 96);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Font Style";
            // 
            // cBUnderline
            // 
            cBUnderline.AutoSize = true;
            cBUnderline.Location = new Point(11, 72);
            cBUnderline.Name = "cBUnderline";
            cBUnderline.Size = new Size(77, 19);
            cBUnderline.TabIndex = 12;
            cBUnderline.Text = "Underline";
            cBUnderline.UseVisualStyleBackColor = true;
            cBUnderline.MouseUp += cBUnderline_MouseUp;
            // 
            // cBItalic
            // 
            cBItalic.AutoSize = true;
            cBItalic.Location = new Point(11, 55);
            cBItalic.Name = "cBItalic";
            cBItalic.Size = new Size(51, 19);
            cBItalic.TabIndex = 11;
            cBItalic.Text = "Italic";
            cBItalic.UseVisualStyleBackColor = true;
            cBItalic.MouseUp += cBItalic_MouseUp;
            // 
            // cBBold
            // 
            cBBold.AutoSize = true;
            cBBold.Location = new Point(11, 38);
            cBBold.Name = "cBBold";
            cBBold.Size = new Size(50, 19);
            cBBold.TabIndex = 10;
            cBBold.Text = "Bold";
            cBBold.UseVisualStyleBackColor = true;
            cBBold.MouseUp += cBBold_MouseUp;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Location = new Point(401, 410);
            button1.Name = "button1";
            button1.Size = new Size(81, 29);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(UpDownLineWidth);
            groupBox1.Controls.Add(rBText);
            groupBox1.Controls.Add(rBBackground);
            groupBox1.Controls.Add(rbLine);
            groupBox1.Controls.Add(colorPalette1);
            groupBox1.Location = new Point(8, 206);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(492, 148);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Color and Width";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 100);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 15;
            label2.Text = "Line Width";
            // 
            // UpDownLineWidth
            // 
            UpDownLineWidth.Location = new Point(14, 116);
            UpDownLineWidth.Name = "UpDownLineWidth";
            UpDownLineWidth.Size = new Size(81, 23);
            UpDownLineWidth.TabIndex = 15;
            UpDownLineWidth.ValueChanged += UpDownLineWidth_ValueChanged;
            // 
            // rBText
            // 
            rBText.AutoSize = true;
            rBText.Location = new Point(14, 56);
            rBText.Name = "rBText";
            rBText.Size = new Size(46, 19);
            rBText.TabIndex = 2;
            rBText.TabStop = true;
            rBText.Text = "Text";
            rBText.UseVisualStyleBackColor = true;
            rBText.MouseUp += rBText_MouseUp;
            // 
            // rBBackground
            // 
            rBBackground.AutoSize = true;
            rBBackground.Location = new Point(14, 38);
            rBBackground.Name = "rBBackground";
            rBBackground.Size = new Size(89, 19);
            rBBackground.TabIndex = 1;
            rBBackground.TabStop = true;
            rBBackground.Text = "Background";
            rBBackground.UseVisualStyleBackColor = true;
            rBBackground.MouseUp += rBBackground_MouseUp;
            // 
            // rbLine
            // 
            rbLine.AutoSize = true;
            rbLine.Location = new Point(14, 20);
            rbLine.Name = "rbLine";
            rbLine.Size = new Size(47, 19);
            rbLine.TabIndex = 0;
            rbLine.TabStop = true;
            rbLine.Text = "Line";
            rbLine.UseVisualStyleBackColor = true;
            rbLine.MouseUp += rbLine_MouseUp;
            // 
            // colorPalette1
            // 
            colorPalette1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            colorPalette1.Location = new Point(125, 14);
            colorPalette1.Name = "colorPalette1";
            colorPalette1.Size = new Size(357, 128);
            colorPalette1.TabIndex = 18;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom;
            button3.Location = new Point(310, 410);
            button3.Name = "button3";
            button3.Size = new Size(81, 29);
            button3.TabIndex = 16;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(a22);
            groupBox3.Controls.Add(a21);
            groupBox3.Controls.Add(a20);
            groupBox3.Controls.Add(a12);
            groupBox3.Controls.Add(a11);
            groupBox3.Controls.Add(a10);
            groupBox3.Controls.Add(a02);
            groupBox3.Controls.Add(a01);
            groupBox3.Controls.Add(a00);
            groupBox3.Location = new Point(390, 48);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(90, 96);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Alignment";
            // 
            // a22
            // 
            a22.BackColor = Color.White;
            a22.FlatAppearance.BorderColor = Color.Silver;
            a22.FlatStyle = FlatStyle.Flat;
            a22.Location = new Point(56, 67);
            a22.Margin = new Padding(1);
            a22.Name = "a22";
            a22.Size = new Size(26, 26);
            a22.TabIndex = 8;
            a22.Text = " ";
            a22.UseVisualStyleBackColor = false;
            a22.Click += TextAlignment_Changed;
            // 
            // a21
            // 
            a21.BackColor = Color.White;
            a21.FlatAppearance.BorderColor = Color.Silver;
            a21.FlatStyle = FlatStyle.Flat;
            a21.Location = new Point(31, 67);
            a21.Margin = new Padding(1);
            a21.Name = "a21";
            a21.Size = new Size(26, 26);
            a21.TabIndex = 7;
            a21.Text = " ";
            a21.UseVisualStyleBackColor = false;
            a21.Click += TextAlignment_Changed;
            // 
            // a20
            // 
            a20.BackColor = Color.White;
            a20.FlatAppearance.BorderColor = Color.Silver;
            a20.FlatStyle = FlatStyle.Flat;
            a20.Location = new Point(6, 67);
            a20.Margin = new Padding(1);
            a20.Name = "a20";
            a20.Size = new Size(26, 26);
            a20.TabIndex = 6;
            a20.Text = " ";
            a20.UseVisualStyleBackColor = false;
            a20.Click += TextAlignment_Changed;
            // 
            // a12
            // 
            a12.BackColor = Color.White;
            a12.FlatAppearance.BorderColor = Color.Silver;
            a12.FlatStyle = FlatStyle.Flat;
            a12.Location = new Point(56, 42);
            a12.Margin = new Padding(1);
            a12.Name = "a12";
            a12.Size = new Size(26, 26);
            a12.TabIndex = 5;
            a12.Text = " ";
            a12.UseVisualStyleBackColor = false;
            a12.Click += TextAlignment_Changed;
            // 
            // a11
            // 
            a11.BackColor = Color.White;
            a11.FlatAppearance.BorderColor = Color.Silver;
            a11.FlatStyle = FlatStyle.Flat;
            a11.Location = new Point(31, 42);
            a11.Margin = new Padding(1);
            a11.Name = "a11";
            a11.Size = new Size(26, 26);
            a11.TabIndex = 4;
            a11.Text = " ";
            a11.UseVisualStyleBackColor = false;
            a11.Click += TextAlignment_Changed;
            // 
            // a10
            // 
            a10.BackColor = Color.White;
            a10.FlatAppearance.BorderColor = Color.Silver;
            a10.FlatStyle = FlatStyle.Flat;
            a10.Location = new Point(6, 42);
            a10.Margin = new Padding(1);
            a10.Name = "a10";
            a10.Size = new Size(26, 26);
            a10.TabIndex = 3;
            a10.Text = " ";
            a10.UseVisualStyleBackColor = false;
            a10.Click += TextAlignment_Changed;
            // 
            // a02
            // 
            a02.BackColor = Color.White;
            a02.FlatAppearance.BorderColor = Color.Silver;
            a02.FlatStyle = FlatStyle.Flat;
            a02.Location = new Point(56, 17);
            a02.Margin = new Padding(1);
            a02.Name = "a02";
            a02.Size = new Size(26, 26);
            a02.TabIndex = 2;
            a02.Text = " ";
            a02.UseVisualStyleBackColor = false;
            a02.Click += TextAlignment_Changed;
            // 
            // a01
            // 
            a01.BackColor = Color.White;
            a01.FlatAppearance.BorderColor = Color.Silver;
            a01.FlatStyle = FlatStyle.Flat;
            a01.Location = new Point(31, 17);
            a01.Margin = new Padding(1);
            a01.Name = "a01";
            a01.Size = new Size(26, 26);
            a01.TabIndex = 1;
            a01.Text = " ";
            a01.UseVisualStyleBackColor = false;
            a01.Click += TextAlignment_Changed;
            // 
            // a00
            // 
            a00.BackColor = Color.White;
            a00.FlatAppearance.BorderColor = Color.Silver;
            a00.FlatStyle = FlatStyle.Flat;
            a00.Location = new Point(6, 17);
            a00.Margin = new Padding(1);
            a00.Name = "a00";
            a00.Size = new Size(26, 26);
            a00.TabIndex = 0;
            a00.Text = " ";
            a00.UseVisualStyleBackColor = false;
            a00.Click += TextAlignment_Changed;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(PdBottom);
            groupBox4.Controls.Add(PdRight);
            groupBox4.Controls.Add(PdLeft);
            groupBox4.Controls.Add(PdTop);
            groupBox4.Location = new Point(119, 48);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(265, 96);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Padding";
            // 
            // PdBottom
            // 
            PdBottom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdBottom.Location = new Point(151, 67);
            PdBottom.Name = "PdBottom";
            PdBottom.Size = new Size(43, 23);
            PdBottom.TabIndex = 24;
            PdBottom.ValueChanged += PdBottom_ValueChanged;
            // 
            // PdRight
            // 
            PdRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdRight.Location = new Point(200, 43);
            PdRight.Name = "PdRight";
            PdRight.Size = new Size(43, 23);
            PdRight.TabIndex = 23;
            PdRight.ValueChanged += PdRight_ValueChanged;
            // 
            // PdLeft
            // 
            PdLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdLeft.Location = new Point(102, 43);
            PdLeft.Name = "PdLeft";
            PdLeft.Size = new Size(43, 23);
            PdLeft.TabIndex = 22;
            PdLeft.ValueChanged += PdLeft_ValueChanged;
            // 
            // PdTop
            // 
            PdTop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdTop.Location = new Point(151, 17);
            PdTop.Name = "PdTop";
            PdTop.Size = new Size(43, 23);
            PdTop.TabIndex = 21;
            PdTop.ValueChanged += PdTop_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(390, 5);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 20;
            label1.Text = "Font Size";
            // 
            // lblFontName
            // 
            lblFontName.AutoSize = true;
            lblFontName.Location = new Point(3, 5);
            lblFontName.Name = "lblFontName";
            lblFontName.Size = new Size(69, 15);
            lblFontName.TabIndex = 19;
            lblFontName.Text = "Font Family";
            // 
            // UpDownFontSize
            // 
            UpDownFontSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpDownFontSize.Location = new Point(390, 24);
            UpDownFontSize.Name = "UpDownFontSize";
            UpDownFontSize.Size = new Size(81, 23);
            UpDownFontSize.TabIndex = 18;
            UpDownFontSize.ValueChanged += UpDownFontSize_ValueChanged;
            // 
            // CmbFontFamily
            // 
            CmbFontFamily.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CmbFontFamily.FormattingEnabled = true;
            CmbFontFamily.Location = new Point(5, 23);
            CmbFontFamily.Name = "CmbFontFamily";
            CmbFontFamily.Size = new Size(379, 23);
            CmbFontFamily.TabIndex = 17;
            CmbFontFamily.TextChanged += CmbFontFamily_TextChanged;
            // 
            // fontPanel
            // 
            fontPanel.Controls.Add(lblFontName);
            fontPanel.Controls.Add(groupBox3);
            fontPanel.Controls.Add(groupBox2);
            fontPanel.Controls.Add(groupBox4);
            fontPanel.Controls.Add(CmbFontFamily);
            fontPanel.Controls.Add(label1);
            fontPanel.Controls.Add(UpDownFontSize);
            fontPanel.Dock = DockStyle.Fill;
            fontPanel.Location = new Point(3, 3);
            fontPanel.Name = "fontPanel";
            fontPanel.Size = new Size(483, 144);
            fontPanel.TabIndex = 21;
            // 
            // TabControl1
            // 
            TabControl1.Anchor = AnchorStyles.Bottom;
            TabControl1.Controls.Add(TextTab);
            TabControl1.Controls.Add(ArrowsTab);
            TabControl1.Controls.Add(EffectsTab);
            TabControl1.Location = new Point(7, 26);
            TabControl1.Name = "TabControl1";
            TabControl1.SelectedIndex = 0;
            TabControl1.Size = new Size(497, 178);
            TabControl1.TabIndex = 22;
            // 
            // TextTab
            // 
            TextTab.BackColor = SystemColors.Control;
            TextTab.Controls.Add(fontPanel);
            TextTab.Location = new Point(4, 24);
            TextTab.Name = "TextTab";
            TextTab.Padding = new Padding(3);
            TextTab.Size = new Size(489, 150);
            TextTab.TabIndex = 0;
            TextTab.Text = "Text";
            // 
            // ArrowsTab
            // 
            ArrowsTab.BackColor = SystemColors.Control;
            ArrowsTab.Controls.Add(label7);
            ArrowsTab.Controls.Add(label6);
            ArrowsTab.Controls.Add(label5);
            ArrowsTab.Controls.Add(label3);
            ArrowsTab.Controls.Add(label4);
            ArrowsTab.Location = new Point(4, 24);
            ArrowsTab.Name = "ArrowsTab";
            ArrowsTab.Padding = new Padding(3);
            ArrowsTab.Size = new Size(489, 150);
            ArrowsTab.TabIndex = 1;
            ArrowsTab.Text = "Arrows";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(175, 9);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 22;
            label7.Text = "Tails";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(82, 9);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 21;
            label6.Text = "Heads";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 107);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 20;
            label5.Text = "Center";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 59);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 16;
            label3.Text = "Width";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 83);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 18;
            label4.Text = "Length";
            // 
            // EffectsTab
            // 
            EffectsTab.Controls.Add(UpDownBlur);
            EffectsTab.Controls.Add(cBBlur);
            EffectsTab.Controls.Add(groupBox5);
            EffectsTab.Location = new Point(4, 24);
            EffectsTab.Name = "EffectsTab";
            EffectsTab.Size = new Size(489, 150);
            EffectsTab.TabIndex = 2;
            EffectsTab.Text = "Effects";
            EffectsTab.UseVisualStyleBackColor = true;
            // 
            // UpDownBlur
            // 
            UpDownBlur.Location = new Point(80, 12);
            UpDownBlur.Name = "UpDownBlur";
            UpDownBlur.Size = new Size(48, 23);
            UpDownBlur.TabIndex = 2;
            UpDownBlur.ValueChanged += UpDownBlur_ValueChanged;
            // 
            // cBBlur
            // 
            cBBlur.AutoSize = true;
            cBBlur.Location = new Point(19, 13);
            cBBlur.Name = "cBBlur";
            cBBlur.Size = new Size(47, 19);
            cBBlur.TabIndex = 0;
            cBBlur.Text = "Blur";
            cBBlur.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(UpDownZoom);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(cBZoom);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(UpDownMoveX);
            groupBox5.Controls.Add(UpDownMoveY);
            groupBox5.Location = new Point(13, 31);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(140, 99);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            // 
            // UpDownZoom
            // 
            UpDownZoom.DecimalPlaces = 1;
            UpDownZoom.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            UpDownZoom.Location = new Point(67, 12);
            UpDownZoom.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownZoom.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            UpDownZoom.Name = "UpDownZoom";
            UpDownZoom.Size = new Size(66, 23);
            UpDownZoom.TabIndex = 8;
            UpDownZoom.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 68);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 7;
            label9.Text = "Move Y";
            // 
            // cBZoom
            // 
            cBZoom.AutoSize = true;
            cBZoom.Location = new Point(5, 13);
            cBZoom.Name = "cBZoom";
            cBZoom.Size = new Size(58, 19);
            cBZoom.TabIndex = 1;
            cBZoom.Text = "Zoom";
            cBZoom.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 43);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 6;
            label8.Text = "Move X";
            // 
            // UpDownMoveX
            // 
            UpDownMoveX.DecimalPlaces = 1;
            UpDownMoveX.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            UpDownMoveX.Location = new Point(67, 41);
            UpDownMoveX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownMoveX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            UpDownMoveX.Name = "UpDownMoveX";
            UpDownMoveX.Size = new Size(66, 23);
            UpDownMoveX.TabIndex = 4;
            UpDownMoveX.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // UpDownMoveY
            // 
            UpDownMoveY.DecimalPlaces = 1;
            UpDownMoveY.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            UpDownMoveY.Location = new Point(67, 66);
            UpDownMoveY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            UpDownMoveY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            UpDownMoveY.Name = "UpDownMoveY";
            UpDownMoveY.Size = new Size(66, 23);
            UpDownMoveY.TabIndex = 5;
            UpDownMoveY.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "1HeadAtHead.png");
            imageList1.Images.SetKeyName(1, "0HeadAtHead.png");
            imageList1.Images.SetKeyName(2, "1HeadAtTail.png");
            imageList1.Images.SetKeyName(3, "0HeadAtTail.png");
            imageList1.Images.SetKeyName(4, "1TailAtHead.png");
            imageList1.Images.SetKeyName(5, "0TailAtHead.png");
            imageList1.Images.SetKeyName(6, "1TailAtTail.png");
            imageList1.Images.SetKeyName(7, "0TailAtTail.png");
            imageList1.Images.SetKeyName(8, "LiftTopmost.png");
            imageList1.Images.SetKeyName(9, "liftUp.png");
            imageList1.Images.SetKeyName(10, "sinkDown.png");
            imageList1.Images.SetKeyName(11, "sinkLowest.png");
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { topmost, Lift, Sink, Bottom });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(504, 24);
            menuStrip1.TabIndex = 23;
            menuStrip1.Text = "menuStrip1";
            // 
            // topmost
            // 
            topmost.Image = Properties.Resources.LiftTopmost;
            topmost.Name = "topmost";
            topmost.Size = new Size(28, 20);
            topmost.Click += topmost_Click;
            // 
            // Lift
            // 
            Lift.Image = Properties.Resources.liftUp;
            Lift.Name = "Lift";
            Lift.Size = new Size(28, 20);
            Lift.Click += Lift_Click;
            // 
            // Sink
            // 
            Sink.Image = Properties.Resources.sinkDown;
            Sink.Name = "Sink";
            Sink.Size = new Size(28, 20);
            Sink.Click += Sink_Click;
            // 
            // Bottom
            // 
            Bottom.Image = Properties.Resources.sinkLowest;
            Bottom.Name = "Bottom";
            Bottom.Size = new Size(28, 20);
            Bottom.Click += bottom_Click;
            // 
            // GraphicShapeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 451);
            Controls.Add(TabControl1);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MaximumSize = new Size(520, 490);
            MinimumSize = new Size(520, 490);
            Name = "GraphicShapeDialog";
            Text = "GraphicShapeDialog";
            Load += GraphicShapeDialog_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownLineWidth).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PdBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)PdRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)PdLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)PdTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownFontSize).EndInit();
            fontPanel.ResumeLayout(false);
            fontPanel.PerformLayout();
            TabControl1.ResumeLayout(false);
            TextTab.ResumeLayout(false);
            ArrowsTab.ResumeLayout(false);
            ArrowsTab.PerformLayout();
            EffectsTab.ResumeLayout(false);
            EffectsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownBlur).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownZoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownMoveX).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownMoveY).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox2;
        private CheckBox cBUnderline;
        private CheckBox cBItalic;
        private CheckBox cBBold;
        private Button button1;
        private GroupBox groupBox1;
        private RadioButton rBText;
        private RadioButton rBBackground;
        private RadioButton rbLine;
        private Label label2;
        private NumericUpDown UpDownLineWidth;
        private Button button3;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private Button a22;
        private Button a21;
        private Button a20;
        private Button a12;
        private Button a11;
        private Button a10;
        private Button a02;
        private Button a01;
        private Button a00;
        private Label label1;
        private Label lblFontName;
        private NumericUpDown UpDownFontSize;
        private ComboBox CmbFontFamily;
        private Panel panel1;
        private Panel fontPanel;
        private ColorPalette colorPalette1;
        private NumericUpDown PdBottom;
        private NumericUpDown PdRight;
        private NumericUpDown PdLeft;
        private NumericUpDown PdTop;
        private TabControl TabControl1;
        private TabPage TextTab;
        private TabPage ArrowsTab;
        private Label label3;
        private Label label5;
        private NumericUpDown UpDownCenterLength;
        private Label label4;
        private NumericUpDown UpDownLength;
        private ImageList imageList1;
        private Label label7;
        private Label label6;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem topmost;
        private ToolStripMenuItem Lift;
        private ToolStripMenuItem Sink;
        private ToolStripMenuItem Bottom;
        private TabPage EffectsTab;
        private CheckBox cBZoom;
        private CheckBox cBBlur;
        private NumericUpDown UpDownBlur;
        private Label label9;
        private Label label8;
        private NumericUpDown UpDownMoveY;
        private NumericUpDown UpDownMoveX;
        private GroupBox groupBox5;
        private NumericUpDown UpDownZoom;
    }
}