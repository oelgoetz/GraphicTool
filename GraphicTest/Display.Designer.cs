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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
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
            DoubleClick += Display_DoubleClick;
            KeyDown += Display_KeyDown;
            KeyUp += Display_KeyUp;
            MouseDown += Display_MouseDown;
            MouseMove += Display_MouseMove;
            MouseUp += Display_MouseUp;
            PreviewKeyDown += Display_PreviewKeyDown;
            Resize += Display_Resize;
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
    }
}
