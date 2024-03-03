namespace GraphicTool
{
    partial class DevTool01
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            cBValues = new CheckBox();
            comboBox1 = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            lBActionFiles = new ListBox();
            tabPage2 = new TabPage();
            cLBLanguages = new CheckedListBox();
            clBBuildTypes = new CheckedListBox();
            clBBranches = new CheckedListBox();
            label1 = new Label();
            button2 = new Button();
            lBHitFiles = new ListBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            getAllpropsAttributesToolStripMenuItem = new ToolStripMenuItem();
            getAttributes049ValuesToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            saveListToClipboardToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(6, 38);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(773, 165);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cBValues);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(lBActionFiles);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(765, 137);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cBValues
            // 
            cBValues.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cBValues.AutoSize = true;
            cBValues.Location = new Point(710, 112);
            cBValues.Name = "cBValues";
            cBValues.Size = new Size(46, 19);
            cBValues.TabIndex = 21;
            cBValues.Text = "Vals";
            cBValues.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.ContextMenuStrip = contextMenuStrip1;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "//Shape[@Type='Oval' and contains(text(),'')]", "//Shape[@Type='Rectangle' and contains(text(),'Werkzeug')]" });
            comboBox1.Location = new Point(6, 110);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(638, 23);
            comboBox1.TabIndex = 20;
            comboBox1.Text = "//Shape[@Type='Polyline' and @ArrowHeadCenterLength and @ArrowHeads]";
            comboBox1.KeyDown += comboBox1_KeyDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(118, 26);
            contextMenuStrip1.Text = "Remove";
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(117, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(650, 109);
            button1.Name = "button1";
            button1.Size = new Size(54, 23);
            button1.TabIndex = 19;
            button1.Text = "search !";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lBActionFiles
            // 
            lBActionFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lBActionFiles.FormattingEnabled = true;
            lBActionFiles.ItemHeight = 15;
            lBActionFiles.Items.AddRange(new object[] { "C:\\docuR2024\\00\\ActionsGLHelp.xml", "C:\\docuR2024\\00\\ActionsV4Help.xml" });
            lBActionFiles.Location = new Point(6, 40);
            lBActionFiles.Name = "lBActionFiles";
            lBActionFiles.Size = new Size(753, 64);
            lBActionFiles.TabIndex = 17;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cLBLanguages);
            tabPage2.Controls.Add(clBBuildTypes);
            tabPage2.Controls.Add(clBBranches);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(765, 137);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cLBLanguages
            // 
            cLBLanguages.FormattingEnabled = true;
            cLBLanguages.Items.AddRange(new object[] { "00", "01", "02", "03", "17" });
            cLBLanguages.Location = new Point(132, 6);
            cLBLanguages.Name = "cLBLanguages";
            cLBLanguages.Size = new Size(120, 94);
            cLBLanguages.TabIndex = 24;
            // 
            // clBBuildTypes
            // 
            clBBuildTypes.FormattingEnabled = true;
            clBBuildTypes.Items.AddRange(new object[] { "GLHelp", "V4Help" });
            clBBuildTypes.Location = new Point(258, 6);
            clBBuildTypes.Name = "clBBuildTypes";
            clBBuildTypes.Size = new Size(120, 94);
            clBBuildTypes.TabIndex = 23;
            // 
            // clBBranches
            // 
            clBBranches.FormattingEnabled = true;
            clBBranches.Items.AddRange(new object[] { "C:\\docuR2401", "C:\\docuR2302", "C:\\docuR2301" });
            clBBranches.Location = new Point(6, 6);
            clBBranches.Name = "clBBranches";
            clBBranches.Size = new Size(120, 94);
            clBBranches.TabIndex = 22;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(640, 10);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 21;
            label1.Text = "label1";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(684, 6);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 20;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lBHitFiles
            // 
            lBHitFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lBHitFiles.ContextMenuStrip = contextMenuStrip2;
            lBHitFiles.FormattingEnabled = true;
            lBHitFiles.ItemHeight = 15;
            lBHitFiles.Location = new Point(6, 209);
            lBHitFiles.Name = "lBHitFiles";
            lBHitFiles.Size = new Size(768, 769);
            lBHitFiles.TabIndex = 16;
            lBHitFiles.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 984);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(786, 22);
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { actionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(786, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { getAllpropsAttributesToolStripMenuItem, getAttributes049ValuesToolStripMenuItem });
            actionsToolStripMenuItem.Enabled = false;
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(59, 20);
            actionsToolStripMenuItem.Text = "Actions";
            // 
            // getAllpropsAttributesToolStripMenuItem
            // 
            getAllpropsAttributesToolStripMenuItem.Enabled = false;
            getAllpropsAttributesToolStripMenuItem.Name = "getAllpropsAttributesToolStripMenuItem";
            getAllpropsAttributesToolStripMenuItem.Size = new Size(209, 22);
            getAllpropsAttributesToolStripMenuItem.Text = "Get all .props Attributes";
            getAllpropsAttributesToolStripMenuItem.Click += getAllpropsAttributesToolStripMenuItem_Click;
            // 
            // getAttributes049ValuesToolStripMenuItem
            // 
            getAttributes049ValuesToolStripMenuItem.Enabled = false;
            getAttributes049ValuesToolStripMenuItem.Name = "getAttributes049ValuesToolStripMenuItem";
            getAttributes049ValuesToolStripMenuItem.Size = new Size(209, 22);
            getAttributes049ValuesToolStripMenuItem.Text = "Get Attributes 0-49 values";
            getAttributes049ValuesToolStripMenuItem.Click += getAttributes049ValuesToolStripMenuItem_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { saveListToClipboardToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(184, 48);
            // 
            // saveListToClipboardToolStripMenuItem
            // 
            saveListToClipboardToolStripMenuItem.Name = "saveListToClipboardToolStripMenuItem";
            saveListToClipboardToolStripMenuItem.Size = new Size(183, 22);
            saveListToClipboardToolStripMenuItem.Text = "Save list to clipboard";
            saveListToClipboardToolStripMenuItem.Click += saveListToClipboardToolStripMenuItem_Click;
            // 
            // DevTool01
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 1006);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            Controls.Add(lBHitFiles);
            MainMenuStrip = menuStrip1;
            Name = "DevTool01";
            Text = "DevTool01";
            Load += DevTool01_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private TextBox textBox1;
        private ListBox lBActionFiles;
        private Label label1;
        private Button button2;
        private ListBox lBHitFiles;
        private CheckedListBox clBBranches;
        private CheckedListBox cLBLanguages;
        private CheckedListBox clBBuildTypes;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ComboBox comboBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem removeToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem getAllpropsAttributesToolStripMenuItem;
        private ToolStripMenuItem getAttributes049ValuesToolStripMenuItem;
        private CheckBox cBValues;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem saveListToClipboardToolStripMenuItem;
    }
}