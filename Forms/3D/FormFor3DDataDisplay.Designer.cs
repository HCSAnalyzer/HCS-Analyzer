namespace HCSAnalyzer.Forms
{
    partial class FormFor3DDataDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFor3DDataDisplay));
            this.renderWindowControl1 = new Kitware.VTK.RenderWindowControl();
            this.comboBoxDescriptorX = new System.Windows.Forms.ComboBox();
            this.comboBoxDescriptorY = new System.Windows.Forms.ComboBox();
            this.comboBoxDescriptorZ = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderWindowControl1
            // 
            this.renderWindowControl1.AddTestActors = false;
            this.renderWindowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderWindowControl1.Location = new System.Drawing.Point(180, 69);
            this.renderWindowControl1.Name = "renderWindowControl1";
            this.renderWindowControl1.Size = new System.Drawing.Size(797, 574);
            this.renderWindowControl1.TabIndex = 0;
            this.renderWindowControl1.TestText = null;
            this.renderWindowControl1.Load += new System.EventHandler(this.renderWindowControl1_Load);
            // 
            // comboBoxDescriptorX
            // 
            this.comboBoxDescriptorX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxDescriptorX.FormattingEnabled = true;
            this.comboBoxDescriptorX.Location = new System.Drawing.Point(482, 652);
            this.comboBoxDescriptorX.Name = "comboBoxDescriptorX";
            this.comboBoxDescriptorX.Size = new System.Drawing.Size(195, 21);
            this.comboBoxDescriptorX.TabIndex = 14;
            this.comboBoxDescriptorX.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescriptorX_SelectedIndexChanged);
            // 
            // comboBoxDescriptorY
            // 
            this.comboBoxDescriptorY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxDescriptorY.FormattingEnabled = true;
            this.comboBoxDescriptorY.Location = new System.Drawing.Point(12, 279);
            this.comboBoxDescriptorY.Name = "comboBoxDescriptorY";
            this.comboBoxDescriptorY.Size = new System.Drawing.Size(162, 21);
            this.comboBoxDescriptorY.TabIndex = 15;
            this.comboBoxDescriptorY.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescriptorY_SelectedIndexChanged);
            // 
            // comboBoxDescriptorZ
            // 
            this.comboBoxDescriptorZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxDescriptorZ.FormattingEnabled = true;
            this.comboBoxDescriptorZ.Location = new System.Drawing.Point(482, 37);
            this.comboBoxDescriptorZ.Name = "comboBoxDescriptorZ";
            this.comboBoxDescriptorZ.Size = new System.Drawing.Size(195, 21);
            this.comboBoxDescriptorZ.TabIndex = 16;
            this.comboBoxDescriptorZ.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescriptorZ_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.axisToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Options";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // axisToolStripMenuItem
            // 
            this.axisToolStripMenuItem.CheckOnClick = true;
            this.axisToolStripMenuItem.Name = "axisToolStripMenuItem";
            this.axisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.axisToolStripMenuItem.Text = "Axis";
            this.axisToolStripMenuItem.Click += new System.EventHandler(this.axisToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 655);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Y";
            // 
            // FormFor3DDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 682);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDescriptorZ);
            this.Controls.Add(this.comboBoxDescriptorY);
            this.Controls.Add(this.comboBoxDescriptorX);
            this.Controls.Add(this.renderWindowControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormFor3DDataDisplay";
            this.Text = "3D Data Visualization";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kitware.VTK.RenderWindowControl renderWindowControl1;
        public System.Windows.Forms.ComboBox comboBoxDescriptorX;
        public System.Windows.Forms.ComboBox comboBoxDescriptorY;
        public System.Windows.Forms.ComboBox comboBoxDescriptorZ;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem axisToolStripMenuItem;
    }
}