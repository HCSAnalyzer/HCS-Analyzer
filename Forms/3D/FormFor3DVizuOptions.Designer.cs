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
            this.comboBoxDescriptorForScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCurrentScale = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadiusSphere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownRadiusSphere
            // 
            this.numericUpDownRadiusSphere.DecimalPlaces = 3;
            this.numericUpDownRadiusSphere.Location = new System.Drawing.Point(203, 111);
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
            this.buttonOK.Location = new System.Drawing.Point(133, 165);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(146, 31);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sphere Radius";
            // 
            // comboBoxDescriptorForScale
            // 
            this.comboBoxDescriptorForScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDescriptorForScale.FormattingEnabled = true;
            this.comboBoxDescriptorForScale.Location = new System.Drawing.Point(22, 43);
            this.comboBoxDescriptorForScale.Name = "comboBoxDescriptorForScale";
            this.comboBoxDescriptorForScale.Size = new System.Drawing.Size(213, 21);
            this.comboBoxDescriptorForScale.TabIndex = 17;
            this.comboBoxDescriptorForScale.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescriptorForScale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descriptor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Scale";
            // 
            // numericUpDownCurrentScale
            // 
            this.numericUpDownCurrentScale.DecimalPlaces = 1;
            this.numericUpDownCurrentScale.Location = new System.Drawing.Point(289, 44);
            this.numericUpDownCurrentScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownCurrentScale.Name = "numericUpDownCurrentScale";
            this.numericUpDownCurrentScale.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownCurrentScale.TabIndex = 18;
            this.numericUpDownCurrentScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCurrentScale.ValueChanged += new System.EventHandler(this.numericUpDownCurrentScale_ValueChanged);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.DecimalPlaces = 3;
            this.numericUpDownFontSize.Location = new System.Drawing.Point(203, 85);
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
            this.label4.Location = new System.Drawing.Point(111, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Font Size";
            // 
            // FormFor3DVizuOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 207);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownCurrentScale);
            this.Controls.Add(this.comboBoxDescriptorForScale);
            this.Controls.Add(this.numericUpDownRadiusSphere);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFor3DVizuOptions";
            this.Text = "Options Visualization 3D";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadiusSphere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numericUpDownRadiusSphere;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxDescriptorForScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericUpDownCurrentScale;
        public System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label label4;
    }
}