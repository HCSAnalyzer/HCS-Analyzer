namespace HCSAnalyzer.Forms.FormsForImages
{
    partial class UserControlSingleLUT
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
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.numericUpDownMaxValue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinValue = new System.Windows.Forms.NumericUpDown();
            this.comboBoxForLUT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinValue)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Checked = true;
            this.checkBoxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsActive.Location = new System.Drawing.Point(9, 9);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxIsActive.TabIndex = 0;
            this.checkBoxIsActive.Text = "Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            this.checkBoxIsActive.CheckedChanged += new System.EventHandler(this.checkBoxIsActive_CheckedChanged);
            // 
            // numericUpDownMaxValue
            // 
            this.numericUpDownMaxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownMaxValue.DecimalPlaces = 1;
            this.numericUpDownMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMaxValue.Location = new System.Drawing.Point(163, 32);
            this.numericUpDownMaxValue.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDownMaxValue.Minimum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            -2147483648});
            this.numericUpDownMaxValue.Name = "numericUpDownMaxValue";
            this.numericUpDownMaxValue.Size = new System.Drawing.Size(62, 14);
            this.numericUpDownMaxValue.TabIndex = 6;
            this.numericUpDownMaxValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownMaxValue.ValueChanged += new System.EventHandler(this.numericUpDownMaxValue_ValueChanged);
            // 
            // numericUpDownMinValue
            // 
            this.numericUpDownMinValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownMinValue.DecimalPlaces = 1;
            this.numericUpDownMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownMinValue.Location = new System.Drawing.Point(9, 32);
            this.numericUpDownMinValue.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDownMinValue.Minimum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            -2147483648});
            this.numericUpDownMinValue.Name = "numericUpDownMinValue";
            this.numericUpDownMinValue.Size = new System.Drawing.Size(62, 14);
            this.numericUpDownMinValue.TabIndex = 7;
            this.numericUpDownMinValue.ValueChanged += new System.EventHandler(this.numericUpDownMinValue_ValueChanged);
            // 
            // comboBoxForLUT
            // 
            this.comboBoxForLUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxForLUT.FormattingEnabled = true;
            this.comboBoxForLUT.Items.AddRange(new object[] {
            "Linear",
            "HSV",
            "Fire",
            "Green to Red",
            "Jet",
            "Hot",
            "Cool",
            "Spring",
            "Summer",
            "Automn",
            "Winter",
            "Bone",
            "Copper"});
            this.comboBoxForLUT.Location = new System.Drawing.Point(119, 56);
            this.comboBoxForLUT.Name = "comboBoxForLUT";
            this.comboBoxForLUT.Size = new System.Drawing.Size(106, 20);
            this.comboBoxForLUT.TabIndex = 8;
            this.comboBoxForLUT.SelectedIndexChanged += new System.EventHandler(this.comboBoxForLUT_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "LUT";
            // 
            // UserControlSingleLUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxForLUT);
            this.Controls.Add(this.numericUpDownMinValue);
            this.Controls.Add(this.numericUpDownMaxValue);
            this.Controls.Add(this.checkBoxIsActive);
            this.Name = "UserControlSingleLUT";
            this.Size = new System.Drawing.Size(236, 86);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBoxIsActive;
        public System.Windows.Forms.NumericUpDown numericUpDownMaxValue;
        public System.Windows.Forms.NumericUpDown numericUpDownMinValue;
        private System.Windows.Forms.ComboBox comboBoxForLUT;
        private System.Windows.Forms.Label label1;
    }
}
