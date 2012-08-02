namespace HCSAnalyzer.Forms.IO
{
    partial class FormForCellByCellClusteringResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForCellByCellClusteringResults));
            this.buttonPerformLearning = new System.Windows.Forms.Button();
            this.richTextBoxResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonPerformLearning
            // 
            this.buttonPerformLearning.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonPerformLearning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPerformLearning.Location = new System.Drawing.Point(0, 475);
            this.buttonPerformLearning.Name = "buttonPerformLearning";
            this.buttonPerformLearning.Size = new System.Drawing.Size(365, 32);
            this.buttonPerformLearning.TabIndex = 0;
            this.buttonPerformLearning.Text = "Perform Learning !";
            this.buttonPerformLearning.UseVisualStyleBackColor = true;
            // 
            // richTextBoxResults
            // 
            this.richTextBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResults.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxResults.Name = "richTextBoxResults";
            this.richTextBoxResults.ReadOnly = true;
            this.richTextBoxResults.Size = new System.Drawing.Size(341, 457);
            this.richTextBoxResults.TabIndex = 1;
            this.richTextBoxResults.Text = "";
            // 
            // FormForCellByCellClusteringResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 507);
            this.Controls.Add(this.richTextBoxResults);
            this.Controls.Add(this.buttonPerformLearning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForCellByCellClusteringResults";
            this.Text = "Clustering Results";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBoxResults;
        public System.Windows.Forms.Button buttonPerformLearning;
    }
}