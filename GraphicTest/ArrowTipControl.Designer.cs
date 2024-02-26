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
            btnAtHeads = new Button();
            UpDownWidth = new NumericUpDown();
            UpDownCenter = new NumericUpDown();
            UpDownLength = new NumericUpDown();
            imageList1 = new ImageList(components);
            btnAtTails = new Button();
            ((System.ComponentModel.ISupportInitialize)UpDownWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownCenter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownLength).BeginInit();
            SuspendLayout();
            // 
            // btnAtHeads
            // 
            btnAtHeads.AccessibleDescription = "";
            btnAtHeads.BackgroundImageLayout = ImageLayout.None;
            btnAtHeads.FlatStyle = FlatStyle.Popup;
            btnAtHeads.Location = new Point(44, 3);
            btnAtHeads.Name = "btnAtHeads";
            btnAtHeads.Size = new Size(40, 20);
            btnAtHeads.TabIndex = 33;
            btnAtHeads.UseVisualStyleBackColor = true;
            btnAtHeads.Click += btnAtHeads_Click;
            // 
            // UpDownWidth
            // 
            UpDownWidth.Location = new Point(5, 26);
            UpDownWidth.Name = "UpDownWidth";
            UpDownWidth.Size = new Size(79, 23);
            UpDownWidth.TabIndex = 30;
            // 
            // UpDownCenter
            // 
            UpDownCenter.Location = new Point(5, 74);
            UpDownCenter.Name = "UpDownCenter";
            UpDownCenter.Size = new Size(79, 23);
            UpDownCenter.TabIndex = 32;
            // 
            // UpDownLength
            // 
            UpDownLength.Location = new Point(5, 50);
            UpDownLength.Name = "UpDownLength";
            UpDownLength.Size = new Size(79, 23);
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
            // btnAtTails
            // 
            btnAtTails.AccessibleDescription = "";
            btnAtTails.BackgroundImageLayout = ImageLayout.None;
            btnAtTails.FlatStyle = FlatStyle.Popup;
            btnAtTails.Location = new Point(5, 3);
            btnAtTails.Name = "btnAtTails";
            btnAtTails.Size = new Size(40, 20);
            btnAtTails.TabIndex = 34;
            btnAtTails.UseVisualStyleBackColor = true;
            btnAtTails.Click += btnAtTails_Click;
            // 
            // ArrowTipControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAtTails);
            Controls.Add(btnAtHeads);
            Controls.Add(UpDownWidth);
            Controls.Add(UpDownCenter);
            Controls.Add(UpDownLength);
            Name = "ArrowTipControl";
            Size = new Size(90, 100);
            ((System.ComponentModel.ISupportInitialize)UpDownWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownCenter).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownLength).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAtHeads;
        private NumericUpDown UpDownWidth;
        private NumericUpDown UpDownCenter;
        private NumericUpDown UpDownLength;
        private ImageList imageList1;
        private Button btnAtTails;
    }
}
