namespace GraphicTool
{
    partial class Display
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
            SuspendLayout();
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            DoubleBuffered = true;
            Name = "Display";
            Size = new Size(688, 646);
            Paint += Display_Paint;
            KeyDown += Display_KeyDown;
            KeyUp += Display_KeyUp;
            MouseDown += Display_MouseDown;
            MouseMove += Display_MouseMove;
            MouseUp += Display_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}
