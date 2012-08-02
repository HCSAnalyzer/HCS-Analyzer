namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    partial class FormForPointSize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForPointSize));
            this.buttonApply = new System.Windows.Forms.Button();
            this.trackBarPointSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPointSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonApply.Location = new System.Drawing.Point(69, 107);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(102, 28);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // trackBarPointSize
            // 
            this.trackBarPointSize.Location = new System.Drawing.Point(12, 47);
            this.trackBarPointSize.Maximum = 100;
            this.trackBarPointSize.Minimum = 1;
            this.trackBarPointSize.Name = "trackBarPointSize";
            this.trackBarPointSize.Size = new System.Drawing.Size(216, 45);
            this.trackBarPointSize.TabIndex = 1;
            this.trackBarPointSize.Value = 4;
            this.trackBarPointSize.ValueChanged += new System.EventHandler(this.trackBarPointSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // FormForPointSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 154);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarPointSize);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForPointSize";
            this.Text = "Marker Size";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPointSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TrackBar trackBarPointSize;
    }
}