namespace GraphicTool
{
    partial class ColorPalette
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPalette));
            groupBox1 = new GroupBox();
            currentColor = new ColorControl();
            cbTransparent = new CheckBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(currentColor);
            groupBox1.Controls.Add(cbTransparent);
            groupBox1.Controls.Add(button2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 150);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Color";
            // 
            // currentColor
            // 
            currentColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            currentColor.BorderStyle = BorderStyle.FixedSingle;
            currentColor.Location = new Point(248, 72);
            currentColor.Name = "currentColor";
            currentColor.Size = new Size(34, 34);
            currentColor.TabIndex = 20;
            // 
            // cbTransparent
            // 
            cbTransparent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbTransparent.AutoSize = true;
            cbTransparent.Location = new Point(6, 119);
            cbTransparent.Name = "cbTransparent";
            cbTransparent.Size = new Size(86, 19);
            cbTransparent.TabIndex = 19;
            cbTransparent.Text = "transparent";
            cbTransparent.UseVisualStyleBackColor = true;
            cbTransparent.MouseUp += cbTransparent_MouseUp;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.FlatAppearance.BorderColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(248, 110);
            button2.Name = "button2";
            button2.Size = new Size(34, 34);
            button2.TabIndex = 18;
            button2.UseVisualStyleBackColor = true;
            button2.Click += ColorPicker_Click;
            // 
            // ColorPalette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ColorPalette";
            Size = new Size(285, 150);
            Load += ColorPalette_Load;
            EnabledChanged += ColorPalette_EnabledChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button button2;
        private CheckBox cbTransparent;
        private ColorControl currentColor;
    }
}
