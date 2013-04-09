namespace HCSAnalyzer.Forms.FormsForImages
{
    partial class FormForImageDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForImageDisplay));
            this.statusStripForImageViewer = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelForZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelForPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStartView = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripFor2DImageDisplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayScaleBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lUTManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelForImage = new System.Windows.Forms.Panel();
            this.statusStripForImageViewer.SuspendLayout();
            this.contextMenuStripFor2DImageDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripForImageViewer
            // 
            this.statusStripForImageViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelForZoom,
            this.toolStripStatusLabelForPosition,
            this.toolStripStatusLabelStartView});
            this.statusStripForImageViewer.Location = new System.Drawing.Point(0, 504);
            this.statusStripForImageViewer.Name = "statusStripForImageViewer";
            this.statusStripForImageViewer.ShowItemToolTips = true;
            this.statusStripForImageViewer.Size = new System.Drawing.Size(629, 22);
            this.statusStripForImageViewer.TabIndex = 5;
            this.statusStripForImageViewer.Text = "statusStrip1";
            // 
            // toolStripStatusLabelForZoom
            // 
            this.toolStripStatusLabelForZoom.Name = "toolStripStatusLabelForZoom";
            this.toolStripStatusLabelForZoom.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabelForZoom.Text = "Zoom: 100%";
            // 
            // toolStripStatusLabelForPosition
            // 
            this.toolStripStatusLabelForPosition.Name = "toolStripStatusLabelForPosition";
            this.toolStripStatusLabelForPosition.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabelForPosition.Text = "(0,0)";
            // 
            // toolStripStatusLabelStartView
            // 
            this.toolStripStatusLabelStartView.Name = "toolStripStatusLabelStartView";
            this.toolStripStatusLabelStartView.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabelStartView.Text = "Start View:";
            // 
            // contextMenuStripFor2DImageDisplay
            // 
            this.contextMenuStripFor2DImageDisplay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayScaleBarToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.lUTManagerToolStripMenuItem});
            this.contextMenuStripFor2DImageDisplay.Name = "contextMenuStripFor2DImageDisplay";
            this.contextMenuStripFor2DImageDisplay.Size = new System.Drawing.Size(175, 98);
            // 
            // displayScaleBarToolStripMenuItem
            // 
            this.displayScaleBarToolStripMenuItem.Name = "displayScaleBarToolStripMenuItem";
            this.displayScaleBarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.displayScaleBarToolStripMenuItem.Text = "Display Scale Bar";
            this.displayScaleBarToolStripMenuItem.Click += new System.EventHandler(this.displayScaleBarToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy To Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // lUTManagerToolStripMenuItem
            // 
            this.lUTManagerToolStripMenuItem.Name = "lUTManagerToolStripMenuItem";
            this.lUTManagerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.lUTManagerToolStripMenuItem.Text = "LUT manager";
            this.lUTManagerToolStripMenuItem.Click += new System.EventHandler(this.lUTManagerToolStripMenuItem_Click);
            // 
            // panelForImage
            // 
            this.panelForImage.AutoScroll = true;
            this.panelForImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForImage.ContextMenuStrip = this.contextMenuStripFor2DImageDisplay;
            this.panelForImage.Location = new System.Drawing.Point(12, 12);
            this.panelForImage.Name = "panelForImage";
            this.panelForImage.Size = new System.Drawing.Size(605, 476);
            this.panelForImage.TabIndex = 0;
            this.panelForImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForImage_Paint);
            this.panelForImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelForImage_MouseMove);
            // 
            // FormForImageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(629, 526);
            this.Controls.Add(this.statusStripForImageViewer);
            this.Controls.Add(this.panelForImage);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForImageDisplay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormForImageDisplay_FormClosed);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FormForImageDisplay_Scroll);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForImage_MouseWheel);
            this.Resize += new System.EventHandler(this.FormForImageDisplay_Resize);
            this.statusStripForImageViewer.ResumeLayout(false);
            this.statusStripForImageViewer.PerformLayout();
            this.contextMenuStripFor2DImageDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelForZoom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelForPosition;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFor2DImageDisplay;
        private System.Windows.Forms.ToolStripMenuItem displayScaleBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        protected System.Windows.Forms.Panel panelForImage;
        protected System.Windows.Forms.StatusStrip statusStripForImageViewer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStartView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lUTManagerToolStripMenuItem;
        //private System.Windows.Forms.MouseEventHandler panelForImage_MouseWheel;





      
    }
}