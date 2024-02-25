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
            LineTab = new TabPage();
            groupBox5 = new GroupBox();
            btnHeadAtHead = new Button();
            imageList1 = new ImageList(components);
            btnTailAtTail = new Button();
            btnTailAtHead = new Button();
            btnHeadAtTail = new Button();
            UpDownTailAtHeadWidth = new NumericUpDown();
            UpDownTailAtTailCenter = new NumericUpDown();
            UpDownTailAtTailLength = new NumericUpDown();
            UpDownTailAtTailWidth = new NumericUpDown();
            UpDownTailAtHeadCenter = new NumericUpDown();
            UpDownTailAtHeadLength = new NumericUpDown();
            UpDownHeadAtTailWidth = new NumericUpDown();
            UpDownHeadAtHeadWidth = new NumericUpDown();
            UpDownHeadAtTailCenter = new NumericUpDown();
            label5 = new Label();
            label3 = new Label();
            UpDownHeadAtTailLength = new NumericUpDown();
            UpDownHeadAtHeadCenter = new NumericUpDown();
            UpDownHeadAtHeadLength = new NumericUpDown();
            label4 = new Label();
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
            LineTab.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtHeadWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtTailCenter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtTailLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtTailWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtHeadCenter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtHeadLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtTailWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtHeadWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtTailCenter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtTailLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtHeadCenter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtHeadLength).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cBUnderline);
            groupBox2.Controls.Add(cBItalic);
            groupBox2.Controls.Add(cBBold);
            groupBox2.Location = new Point(3, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(116, 96);
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
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(401, 380);
            button1.Name = "button1";
            button1.Size = new Size(81, 29);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(UpDownLineWidth);
            groupBox1.Controls.Add(rBText);
            groupBox1.Controls.Add(rBBackground);
            groupBox1.Controls.Add(rbLine);
            groupBox1.Controls.Add(colorPalette1);
            groupBox1.Location = new Point(8, 192);
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
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(310, 380);
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
            groupBox4.Location = new Point(125, 48);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(259, 96);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Padding";
            // 
            // PdBottom
            // 
            PdBottom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdBottom.Location = new Point(145, 67);
            PdBottom.Name = "PdBottom";
            PdBottom.Size = new Size(43, 23);
            PdBottom.TabIndex = 24;
            PdBottom.ValueChanged += PdBottom_ValueChanged;
            // 
            // PdRight
            // 
            PdRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdRight.Location = new Point(194, 43);
            PdRight.Name = "PdRight";
            PdRight.Size = new Size(43, 23);
            PdRight.TabIndex = 23;
            PdRight.ValueChanged += PdRight_ValueChanged;
            // 
            // PdLeft
            // 
            PdLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdLeft.Location = new Point(96, 43);
            PdLeft.Name = "PdLeft";
            PdLeft.Size = new Size(43, 23);
            PdLeft.TabIndex = 22;
            PdLeft.ValueChanged += PdLeft_ValueChanged;
            // 
            // PdTop
            // 
            PdTop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PdTop.Location = new Point(145, 17);
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
            TabControl1.Controls.Add(TextTab);
            TabControl1.Controls.Add(LineTab);
            TabControl1.Location = new Point(7, 12);
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
            // LineTab
            // 
            LineTab.BackColor = SystemColors.Control;
            LineTab.Controls.Add(groupBox5);
            LineTab.Location = new Point(4, 24);
            LineTab.Name = "LineTab";
            LineTab.Padding = new Padding(3);
            LineTab.Size = new Size(489, 150);
            LineTab.TabIndex = 1;
            LineTab.Text = "Arrows";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnHeadAtHead);
            groupBox5.Controls.Add(btnTailAtTail);
            groupBox5.Controls.Add(btnTailAtHead);
            groupBox5.Controls.Add(btnHeadAtTail);
            groupBox5.Controls.Add(UpDownTailAtHeadWidth);
            groupBox5.Controls.Add(UpDownTailAtTailCenter);
            groupBox5.Controls.Add(UpDownTailAtTailLength);
            groupBox5.Controls.Add(UpDownTailAtTailWidth);
            groupBox5.Controls.Add(UpDownTailAtHeadCenter);
            groupBox5.Controls.Add(UpDownTailAtHeadLength);
            groupBox5.Controls.Add(UpDownHeadAtTailWidth);
            groupBox5.Controls.Add(UpDownHeadAtHeadWidth);
            groupBox5.Controls.Add(UpDownHeadAtTailCenter);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(UpDownHeadAtTailLength);
            groupBox5.Controls.Add(UpDownHeadAtHeadCenter);
            groupBox5.Controls.Add(UpDownHeadAtHeadLength);
            groupBox5.Controls.Add(label4);
            groupBox5.Location = new Point(6, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(309, 115);
            groupBox5.TabIndex = 22;
            groupBox5.TabStop = false;
            // 
            // btnHeadAtHead
            // 
            btnHeadAtHead.BackgroundImageLayout = ImageLayout.None;
            btnHeadAtHead.FlatStyle = FlatStyle.Popup;
            btnHeadAtHead.ImageList = imageList1;
            btnHeadAtHead.Location = new Point(115, 14);
            btnHeadAtHead.Name = "btnHeadAtHead";
            btnHeadAtHead.Size = new Size(58, 20);
            btnHeadAtHead.TabIndex = 32;
            btnHeadAtHead.UseVisualStyleBackColor = true;
            btnHeadAtHead.Click += btnHeadAtHead_Click;
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
            // 
            // btnTailAtTail
            // 
            btnTailAtTail.FlatStyle = FlatStyle.Popup;
            btnTailAtTail.ImageList = imageList1;
            btnTailAtTail.Location = new Point(179, 14);
            btnTailAtTail.Name = "btnTailAtTail";
            btnTailAtTail.Size = new Size(57, 20);
            btnTailAtTail.TabIndex = 31;
            btnTailAtTail.UseVisualStyleBackColor = true;
            btnTailAtTail.Click += btnTailAtTail_Click;
            // 
            // btnTailAtHead
            // 
            btnTailAtHead.FlatStyle = FlatStyle.Popup;
            btnTailAtHead.ImageList = imageList1;
            btnTailAtHead.Location = new Point(242, 14);
            btnTailAtHead.Name = "btnTailAtHead";
            btnTailAtHead.Size = new Size(57, 20);
            btnTailAtHead.TabIndex = 30;
            btnTailAtHead.UseVisualStyleBackColor = true;
            btnTailAtHead.Click += btnTailAtHead_Click;
            // 
            // btnHeadAtTail
            // 
            btnHeadAtTail.BackgroundImageLayout = ImageLayout.None;
            btnHeadAtTail.FlatStyle = FlatStyle.Popup;
            btnHeadAtTail.ImageList = imageList1;
            btnHeadAtTail.Location = new Point(52, 14);
            btnHeadAtTail.Name = "btnHeadAtTail";
            btnHeadAtTail.Size = new Size(57, 20);
            btnHeadAtTail.TabIndex = 29;
            btnHeadAtTail.UseVisualStyleBackColor = true;
            btnHeadAtTail.Click += btnHeadAtTail_Click;
            // 
            // UpDownTailAtHeadWidth
            // 
            UpDownTailAtHeadWidth.Location = new Point(241, 37);
            UpDownTailAtHeadWidth.Name = "UpDownTailAtHeadWidth";
            UpDownTailAtHeadWidth.Size = new Size(58, 23);
            UpDownTailAtHeadWidth.TabIndex = 25;
            // 
            // UpDownTailAtTailCenter
            // 
            UpDownTailAtTailCenter.Location = new Point(178, 85);
            UpDownTailAtTailCenter.Name = "UpDownTailAtTailCenter";
            UpDownTailAtTailCenter.Size = new Size(58, 23);
            UpDownTailAtTailCenter.TabIndex = 27;
            // 
            // UpDownTailAtTailLength
            // 
            UpDownTailAtTailLength.Location = new Point(178, 61);
            UpDownTailAtTailLength.Name = "UpDownTailAtTailLength";
            UpDownTailAtTailLength.Size = new Size(58, 23);
            UpDownTailAtTailLength.TabIndex = 26;
            // 
            // UpDownTailAtTailWidth
            // 
            UpDownTailAtTailWidth.Location = new Point(178, 37);
            UpDownTailAtTailWidth.Name = "UpDownTailAtTailWidth";
            UpDownTailAtTailWidth.Size = new Size(58, 23);
            UpDownTailAtTailWidth.TabIndex = 22;
            // 
            // UpDownTailAtHeadCenter
            // 
            UpDownTailAtHeadCenter.Location = new Point(241, 85);
            UpDownTailAtHeadCenter.Name = "UpDownTailAtHeadCenter";
            UpDownTailAtHeadCenter.Size = new Size(58, 23);
            UpDownTailAtHeadCenter.TabIndex = 24;
            // 
            // UpDownTailAtHeadLength
            // 
            UpDownTailAtHeadLength.Location = new Point(241, 61);
            UpDownTailAtHeadLength.Name = "UpDownTailAtHeadLength";
            UpDownTailAtHeadLength.Size = new Size(58, 23);
            UpDownTailAtHeadLength.TabIndex = 23;
            // 
            // UpDownHeadAtTailWidth
            // 
            UpDownHeadAtTailWidth.Location = new Point(51, 37);
            UpDownHeadAtTailWidth.Name = "UpDownHeadAtTailWidth";
            UpDownHeadAtTailWidth.Size = new Size(58, 23);
            UpDownHeadAtTailWidth.TabIndex = 17;
            UpDownHeadAtTailWidth.ValueChanged += UpDownHeadAtTailWidth_ValueChanged;
            // 
            // UpDownHeadAtHeadWidth
            // 
            UpDownHeadAtHeadWidth.Location = new Point(114, 37);
            UpDownHeadAtHeadWidth.Name = "UpDownHeadAtHeadWidth";
            UpDownHeadAtHeadWidth.Size = new Size(58, 23);
            UpDownHeadAtHeadWidth.TabIndex = 17;
            // 
            // UpDownHeadAtTailCenter
            // 
            UpDownHeadAtTailCenter.Location = new Point(51, 85);
            UpDownHeadAtTailCenter.Name = "UpDownHeadAtTailCenter";
            UpDownHeadAtTailCenter.Size = new Size(58, 23);
            UpDownHeadAtTailCenter.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 89);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 20;
            label5.Text = "Center";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 41);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 16;
            label3.Text = "Width";
            // 
            // UpDownHeadAtTailLength
            // 
            UpDownHeadAtTailLength.Location = new Point(51, 61);
            UpDownHeadAtTailLength.Name = "UpDownHeadAtTailLength";
            UpDownHeadAtTailLength.Size = new Size(58, 23);
            UpDownHeadAtTailLength.TabIndex = 19;
            // 
            // UpDownHeadAtHeadCenter
            // 
            UpDownHeadAtHeadCenter.Location = new Point(114, 85);
            UpDownHeadAtHeadCenter.Name = "UpDownHeadAtHeadCenter";
            UpDownHeadAtHeadCenter.Size = new Size(58, 23);
            UpDownHeadAtHeadCenter.TabIndex = 21;
            // 
            // UpDownHeadAtHeadLength
            // 
            UpDownHeadAtHeadLength.Location = new Point(114, 61);
            UpDownHeadAtHeadLength.Name = "UpDownHeadAtHeadLength";
            UpDownHeadAtHeadLength.Size = new Size(58, 23);
            UpDownHeadAtHeadLength.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 65);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 18;
            label4.Text = "Length";
            // 
            // GraphicShapeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 421);
            Controls.Add(TabControl1);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            MinimumSize = new Size(520, 460);
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
            LineTab.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtHeadWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtTailCenter).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtTailLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtTailWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtHeadCenter).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownTailAtHeadLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtTailWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtHeadWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtTailCenter).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtTailLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtHeadCenter).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownHeadAtHeadLength).EndInit();
            ResumeLayout(false);
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
        private TabPage LineTab;
        private Label label3;
        private NumericUpDown UpDownHeadAtHeadWidth;
        private Label label5;
        private NumericUpDown UpDownCenterLength;
        private Label label4;
        private NumericUpDown UpDownLength;
        private GroupBox groupBox5;
        private NumericUpDown UpDownHeadAtHeadCenter;
        private NumericUpDown UpDownHeadAtHeadLength;
        private NumericUpDown UpDownTailAtTailWidth;
        private NumericUpDown UpDownTailAtHeadCenter;
        private NumericUpDown UpDownTailAtHeadLength;
        private NumericUpDown UpDownHeadAtTailWidth;
        private NumericUpDown UpDownHeadAtTailCenter;
        private NumericUpDown UpDownHeadAtTailLength;
        private NumericUpDown UpDownTailAtHeadWidth;
        private NumericUpDown UpDownTailAtTailCenter;
        private NumericUpDown UpDownTailAtTailLength;
        private Button btnTailAtTail;
        private Button btnTailAtHead;
        private Button btnHeadAtTail;
        private ImageList imageList1;
        private Button btnHeadAtHead;
    }
}