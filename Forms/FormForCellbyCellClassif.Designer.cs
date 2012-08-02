namespace HCSAnalyzer.Forms
{
    partial class FormForCellbyCellClassif
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForCellbyCellClassif));
            this.buttonClassify = new System.Windows.Forms.Button();
            this.checkBoxKeepOriginalDesc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonClassify
            // 
            this.buttonClassify.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClassify.Location = new System.Drawing.Point(196, 22);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(104, 30);
            this.buttonClassify.TabIndex = 0;
            this.buttonClassify.Text = "Classify";
            this.buttonClassify.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeepOriginalDesc
            // 
            this.checkBoxKeepOriginalDesc.AutoSize = true;
            this.checkBoxKeepOriginalDesc.Checked = true;
            this.checkBoxKeepOriginalDesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeepOriginalDesc.Location = new System.Drawing.Point(27, 29);
            this.checkBoxKeepOriginalDesc.Name = "checkBoxKeepOriginalDesc";
            this.checkBoxKeepOriginalDesc.Size = new System.Drawing.Size(145, 17);
            this.checkBoxKeepOriginalDesc.TabIndex = 1;
            this.checkBoxKeepOriginalDesc.Text = "Keep Original Descriptors";
            this.checkBoxKeepOriginalDesc.UseVisualStyleBackColor = true;
            // 
            // FormForCellbyCellClassif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 77);
            this.Controls.Add(this.checkBoxKeepOriginalDesc);
            this.Controls.Add(this.buttonClassify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForCellbyCellClassif";
            this.Text = "Cell by cell classification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClassify;
        public System.Windows.Forms.CheckBox checkBoxKeepOriginalDesc;
    }
}