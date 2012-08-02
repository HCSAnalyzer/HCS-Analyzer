namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    partial class FormSingleCellClusteringInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSingleCellClusteringInfo));
            this.buttonOk = new System.Windows.Forms.Button();
            this.radioButtonEM = new System.Windows.Forms.RadioButton();
            this.numericUpDownClassNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxEMAutomated = new System.Windows.Forms.CheckBox();
            this.groupBoxAutomated = new System.Windows.Forms.GroupBox();
            this.groupBoxDescriptorBased = new System.Windows.Forms.GroupBox();
            this.labelDescForClass = new System.Windows.Forms.Label();
            this.comboBoxDescriptorForClass = new System.Windows.Forms.ComboBox();
            this.radioButtonAutomated = new System.Windows.Forms.RadioButton();
            this.radioButtonDescriptorBased = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClassNumber)).BeginInit();
            this.groupBoxAutomated.SuspendLayout();
            this.groupBoxDescriptorBased.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(86, 212);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(130, 32);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // radioButtonEM
            // 
            this.radioButtonEM.AutoSize = true;
            this.radioButtonEM.Checked = true;
            this.radioButtonEM.Location = new System.Drawing.Point(123, 19);
            this.radioButtonEM.Name = "radioButtonEM";
            this.radioButtonEM.Size = new System.Drawing.Size(41, 17);
            this.radioButtonEM.TabIndex = 1;
            this.radioButtonEM.TabStop = true;
            this.radioButtonEM.Text = "EM";
            this.radioButtonEM.UseVisualStyleBackColor = true;
            // 
            // numericUpDownClassNumber
            // 
            this.numericUpDownClassNumber.Location = new System.Drawing.Point(108, 55);
            this.numericUpDownClassNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownClassNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownClassNumber.Name = "numericUpDownClassNumber";
            this.numericUpDownClassNumber.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownClassNumber.TabIndex = 2;
            this.numericUpDownClassNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of class";
            // 
            // checkBoxEMAutomated
            // 
            this.checkBoxEMAutomated.AutoSize = true;
            this.checkBoxEMAutomated.Location = new System.Drawing.Point(195, 57);
            this.checkBoxEMAutomated.Name = "checkBoxEMAutomated";
            this.checkBoxEMAutomated.Size = new System.Drawing.Size(77, 17);
            this.checkBoxEMAutomated.TabIndex = 4;
            this.checkBoxEMAutomated.Text = "Automated";
            this.checkBoxEMAutomated.UseVisualStyleBackColor = true;
            this.checkBoxEMAutomated.CheckedChanged += new System.EventHandler(this.checkBoxEMAutomated_CheckedChanged);
            // 
            // groupBoxAutomated
            // 
            this.groupBoxAutomated.Controls.Add(this.numericUpDownClassNumber);
            this.groupBoxAutomated.Controls.Add(this.checkBoxEMAutomated);
            this.groupBoxAutomated.Controls.Add(this.radioButtonEM);
            this.groupBoxAutomated.Controls.Add(this.label1);
            this.groupBoxAutomated.Location = new System.Drawing.Point(7, 12);
            this.groupBoxAutomated.Name = "groupBoxAutomated";
            this.groupBoxAutomated.Size = new System.Drawing.Size(287, 90);
            this.groupBoxAutomated.TabIndex = 5;
            this.groupBoxAutomated.TabStop = false;
            this.groupBoxAutomated.Text = "                               ";
            // 
            // groupBoxDescriptorBased
            // 
            this.groupBoxDescriptorBased.Controls.Add(this.labelDescForClass);
            this.groupBoxDescriptorBased.Controls.Add(this.comboBoxDescriptorForClass);
            this.groupBoxDescriptorBased.Enabled = false;
            this.groupBoxDescriptorBased.Location = new System.Drawing.Point(7, 106);
            this.groupBoxDescriptorBased.Name = "groupBoxDescriptorBased";
            this.groupBoxDescriptorBased.Size = new System.Drawing.Size(287, 85);
            this.groupBoxDescriptorBased.TabIndex = 6;
            this.groupBoxDescriptorBased.TabStop = false;
            this.groupBoxDescriptorBased.Text = "                         ";
            // 
            // labelDescForClass
            // 
            this.labelDescForClass.AutoSize = true;
            this.labelDescForClass.Location = new System.Drawing.Point(23, 38);
            this.labelDescForClass.Name = "labelDescForClass";
            this.labelDescForClass.Size = new System.Drawing.Size(97, 13);
            this.labelDescForClass.TabIndex = 15;
            this.labelDescForClass.Text = "Descriptor for class";
            // 
            // comboBoxDescriptorForClass
            // 
            this.comboBoxDescriptorForClass.FormattingEnabled = true;
            this.comboBoxDescriptorForClass.Location = new System.Drawing.Point(132, 35);
            this.comboBoxDescriptorForClass.Name = "comboBoxDescriptorForClass";
            this.comboBoxDescriptorForClass.Size = new System.Drawing.Size(140, 21);
            this.comboBoxDescriptorForClass.TabIndex = 14;
            // 
            // radioButtonAutomated
            // 
            this.radioButtonAutomated.AutoSize = true;
            this.radioButtonAutomated.Checked = true;
            this.radioButtonAutomated.Location = new System.Drawing.Point(22, 10);
            this.radioButtonAutomated.Name = "radioButtonAutomated";
            this.radioButtonAutomated.Size = new System.Drawing.Size(76, 17);
            this.radioButtonAutomated.TabIndex = 7;
            this.radioButtonAutomated.TabStop = true;
            this.radioButtonAutomated.Text = "Automated";
            this.radioButtonAutomated.UseVisualStyleBackColor = true;
            this.radioButtonAutomated.CheckedChanged += new System.EventHandler(this.radioButtonAutomated_CheckedChanged);
            // 
            // radioButtonDescriptorBased
            // 
            this.radioButtonDescriptorBased.AutoSize = true;
            this.radioButtonDescriptorBased.Location = new System.Drawing.Point(22, 105);
            this.radioButtonDescriptorBased.Name = "radioButtonDescriptorBased";
            this.radioButtonDescriptorBased.Size = new System.Drawing.Size(105, 17);
            this.radioButtonDescriptorBased.TabIndex = 8;
            this.radioButtonDescriptorBased.Text = "Descriptor based";
            this.radioButtonDescriptorBased.UseVisualStyleBackColor = true;
            this.radioButtonDescriptorBased.CheckedChanged += new System.EventHandler(this.radioButtonDescriptorBased_CheckedChanged);
            // 
            // FormSingleCellClusteringInfo
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 259);
            this.Controls.Add(this.radioButtonDescriptorBased);
            this.Controls.Add(this.radioButtonAutomated);
            this.Controls.Add(this.groupBoxDescriptorBased);
            this.Controls.Add(this.groupBoxAutomated);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSingleCellClusteringInfo";
            this.Text = "Clustering Properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClassNumber)).EndInit();
            this.groupBoxAutomated.ResumeLayout(false);
            this.groupBoxAutomated.PerformLayout();
            this.groupBoxDescriptorBased.ResumeLayout(false);
            this.groupBoxDescriptorBased.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.RadioButton radioButtonEM;
        public System.Windows.Forms.NumericUpDown numericUpDownClassNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxAutomated;
        private System.Windows.Forms.GroupBox groupBoxDescriptorBased;
        public System.Windows.Forms.RadioButton radioButtonAutomated;
        public System.Windows.Forms.RadioButton radioButtonDescriptorBased;
        public System.Windows.Forms.CheckBox checkBoxEMAutomated;
        private System.Windows.Forms.Label labelDescForClass;
        public System.Windows.Forms.ComboBox comboBoxDescriptorForClass;
    }
}