namespace HCSAnalyzer.Forms._3D
{
    partial class FormFor3DVizuOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFor3DVizuOptions));
            this.numericUpDownRadiusSphere = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadiusSphere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownRadiusSphere
            // 
            this.numericUpDownRadiusSphere.DecimalPlaces = 3;
            this.numericUpDownRadiusSphere.Location = new System.Drawing.Point(121, 49);
            this.numericUpDownRadiusSphere.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownRadiusSphere.Name = "numericUpDownRadiusSphere";
            this.numericUpDownRadiusSphere.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownRadiusSphere.TabIndex = 5;
            this.numericUpDownRadiusSphere.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(51, 96);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(146, 31);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sphere Radius";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.DecimalPlaces = 3;
            this.numericUpDownFontSize.Location = new System.Drawing.Point(121, 23);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownFontSize.TabIndex = 20;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Font Size";
            // 
            // FormFor3DVizuOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 137);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownRadiusSphere);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFor3DVizuOptions";
            this.Text = "Options Visualization 3D";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadiusSphere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numericUpDownRadiusSphere;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label label4;
    }
}