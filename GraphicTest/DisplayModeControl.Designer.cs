namespace GraphicTool
{
    partial class DisplayModeControl
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
            cBBackGround = new CheckBox();
            cBShapes = new CheckBox();
            rbBackgroundImage = new RadioButton();
            rbBackgroundXML = new RadioButton();
            lblMode = new Label();
            SuspendLayout();
            // 
            // cBBackGround
            // 
            cBBackGround.AutoSize = true;
            cBBackGround.Location = new Point(6, 6);
            cBBackGround.Name = "cBBackGround";
            cBBackGround.Size = new Size(90, 19);
            cBBackGround.TabIndex = 0;
            cBBackGround.Text = "Background";
            cBBackGround.UseVisualStyleBackColor = true;
            // 
            // cBShapes
            // 
            cBShapes.AutoSize = true;
            cBShapes.Location = new Point(6, 62);
            cBShapes.Name = "cBShapes";
            cBShapes.Size = new Size(63, 19);
            cBShapes.TabIndex = 1;
            cBShapes.Text = "Shapes";
            cBShapes.UseVisualStyleBackColor = true;
            // 
            // rbBackgroundImage
            // 
            rbBackgroundImage.AutoSize = true;
            rbBackgroundImage.Location = new Point(19, 24);
            rbBackgroundImage.Name = "rbBackgroundImage";
            rbBackgroundImage.Size = new Size(58, 19);
            rbBackgroundImage.TabIndex = 2;
            rbBackgroundImage.TabStop = true;
            rbBackgroundImage.Text = "Image";
            rbBackgroundImage.UseVisualStyleBackColor = true;
            // 
            // rbBackgroundXML
            // 
            rbBackgroundXML.AutoSize = true;
            rbBackgroundXML.Location = new Point(19, 43);
            rbBackgroundXML.Name = "rbBackgroundXML";
            rbBackgroundXML.Size = new Size(49, 19);
            rbBackgroundXML.TabIndex = 3;
            rbBackgroundXML.TabStop = true;
            rbBackgroundXML.Text = "XML";
            rbBackgroundXML.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(103, 65);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(10, 15);
            lblMode.TabIndex = 4;
            lblMode.Text = ".";
            // 
            // DisplayModeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMode);
            Controls.Add(rbBackgroundXML);
            Controls.Add(rbBackgroundImage);
            Controls.Add(cBShapes);
            Controls.Add(cBBackGround);
            Name = "DisplayModeControl";
            Size = new Size(133, 94);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cBBackGround;
        private CheckBox cBShapes;
        private RadioButton rbBackgroundImage;
        private RadioButton rbBackgroundXML;
        private Label lblMode;
    }
}
