namespace GraphicTool
{
    partial class ArrowTipControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrowTipControl));
            btn = new Button();
            UpDownWidth = new NumericUpDown();
            UpDownCenter = new NumericUpDown();
            UpDownLength = new NumericUpDown();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)UpDownWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownCenter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownLength).BeginInit();
            SuspendLayout();
            // 
            // btn
            // 
            btn.BackgroundImageLayout = ImageLayout.None;
            btn.FlatStyle = FlatStyle.Popup;
            btn.Location = new Point(3, 3);
            btn.Name = "btn";
            btn.Size = new Size(57, 20);
            btn.TabIndex = 33;
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // UpDownWidth
            // 
            UpDownWidth.Location = new Point(2, 26);
            UpDownWidth.Name = "UpDownWidth";
            UpDownWidth.Size = new Size(58, 23);
            UpDownWidth.TabIndex = 30;            
            // 
            // UpDownCenter
            // 
            UpDownCenter.Location = new Point(2, 74);
            UpDownCenter.Name = "UpDownCenter";
            UpDownCenter.Size = new Size(58, 23);
            UpDownCenter.TabIndex = 32;
            // 
            // UpDownLength
            // 
            UpDownLength.Location = new Point(2, 50);
            UpDownLength.Name = "UpDownLength";
            UpDownLength.Size = new Size(58, 23);
            UpDownLength.TabIndex = 31;
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
            // ArrowTipControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn);
            Controls.Add(UpDownWidth);
            Controls.Add(UpDownCenter);
            Controls.Add(UpDownLength);
            Name = "ArrowTipControl";
            Size = new Size(62, 98);
            ((System.ComponentModel.ISupportInitialize)UpDownWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownCenter).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownLength).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn;
        private NumericUpDown UpDownWidth;
        private NumericUpDown UpDownCenter;
        private NumericUpDown UpDownLength;
        private ImageList imageList1;
    }
}
