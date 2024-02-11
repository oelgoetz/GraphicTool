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
            CmbFontFamily = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            NuFontSize = new NumericUpDown();
            groupBox2 = new GroupBox();
            cBUnderline = new CheckBox();
            cBItalic = new CheckBox();
            cBBold = new CheckBox();
            cBRegular = new CheckBox();
            tabPage2 = new TabPage();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NuFontSize).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CmbFontFamily
            // 
            CmbFontFamily.FormattingEnabled = true;
            CmbFontFamily.Location = new Point(6, 7);
            CmbFontFamily.Name = "CmbFontFamily";
            CmbFontFamily.Size = new Size(268, 23);
            CmbFontFamily.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 116);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(375, 330);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(NuFontSize);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(CmbFontFamily);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(367, 302);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // NuFontSize
            // 
            NuFontSize.Location = new Point(280, 7);
            NuFontSize.Name = "NuFontSize";
            NuFontSize.Size = new Size(81, 23);
            NuFontSize.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cBUnderline);
            groupBox2.Controls.Add(cBItalic);
            groupBox2.Controls.Add(cBBold);
            groupBox2.Controls.Add(cBRegular);
            groupBox2.Location = new Point(6, 35);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(98, 100);
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
            // 
            // cBRegular
            // 
            cBRegular.AutoSize = true;
            cBRegular.Location = new Point(11, 21);
            cBRegular.Name = "cBRegular";
            cBRegular.Size = new Size(66, 19);
            cBRegular.TabIndex = 9;
            cBRegular.Text = "Regular";
            cBRegular.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(367, 302);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(308, 482);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(16, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(367, 98);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // GraphicShapeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 523);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Name = "GraphicShapeDialog";
            Text = "GraphicShapeDialog";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NuFontSize).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CmbFontFamily;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox2;
        private CheckBox cBUnderline;
        private CheckBox cBItalic;
        private CheckBox cBBold;
        private CheckBox cBRegular;
        private NumericUpDown NuFontSize;
        private Button button1;
        private PictureBox pictureBox1;
    }
}