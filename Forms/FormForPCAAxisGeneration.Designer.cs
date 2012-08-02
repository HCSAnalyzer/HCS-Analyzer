namespace HCSAnalyzer.Forms
{
    partial class FormForPCAAxisGeneration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForPCAAxisGeneration));
            this.comboBoxForNeutralClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClassification = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonFromFullScreening = new System.Windows.Forms.RadioButton();
            this.radioButtonFromCurrentPlate = new System.Windows.Forms.RadioButton();
            this.numericUpDownNumberOfAxis = new System.Windows.Forms.NumericUpDown();
            this.labelAxeNumber = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfAxis)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxForNeutralClass
            // 
            this.comboBoxForNeutralClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxForNeutralClass.FormattingEnabled = true;
            this.comboBoxForNeutralClass.Items.AddRange(new object[] {
            "Positive (0)",
            "Negative (1)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxForNeutralClass.Location = new System.Drawing.Point(128, 21);
            this.comboBoxForNeutralClass.Name = "comboBoxForNeutralClass";
            this.comboBoxForNeutralClass.Size = new System.Drawing.Size(112, 21);
            this.comboBoxForNeutralClass.TabIndex = 30;
            this.comboBoxForNeutralClass.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxForNeutralClass_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Neutral Class";
            // 
            // buttonClassification
            // 
            this.buttonClassification.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClassification.Location = new System.Drawing.Point(46, 202);
            this.buttonClassification.Name = "buttonClassification";
            this.buttonClassification.Size = new System.Drawing.Size(193, 29);
            this.buttonClassification.TabIndex = 28;
            this.buttonClassification.Text = "Ok";
            this.buttonClassification.UseVisualStyleBackColor = true;
            this.buttonClassification.Click += new System.EventHandler(this.buttonClassification_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFromFullScreening);
            this.groupBox1.Controls.Add(this.radioButtonFromCurrentPlate);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 59);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From";
            // 
            // radioButtonFromFullScreening
            // 
            this.radioButtonFromFullScreening.AutoSize = true;
            this.radioButtonFromFullScreening.Location = new System.Drawing.Point(142, 25);
            this.radioButtonFromFullScreening.Name = "radioButtonFromFullScreening";
            this.radioButtonFromFullScreening.Size = new System.Drawing.Size(78, 17);
            this.radioButtonFromFullScreening.TabIndex = 1;
            this.radioButtonFromFullScreening.Text = "Full Screen";
            this.radioButtonFromFullScreening.UseVisualStyleBackColor = true;
            // 
            // radioButtonFromCurrentPlate
            // 
            this.radioButtonFromCurrentPlate.AutoSize = true;
            this.radioButtonFromCurrentPlate.Checked = true;
            this.radioButtonFromCurrentPlate.Location = new System.Drawing.Point(32, 25);
            this.radioButtonFromCurrentPlate.Name = "radioButtonFromCurrentPlate";
            this.radioButtonFromCurrentPlate.Size = new System.Drawing.Size(86, 17);
            this.radioButtonFromCurrentPlate.TabIndex = 0;
            this.radioButtonFromCurrentPlate.TabStop = true;
            this.radioButtonFromCurrentPlate.Text = "Current Plate";
            this.radioButtonFromCurrentPlate.UseVisualStyleBackColor = true;
            // 
            // numericUpDownNumberOfAxis
            // 
            this.numericUpDownNumberOfAxis.Location = new System.Drawing.Point(128, 154);
            this.numericUpDownNumberOfAxis.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfAxis.Name = "numericUpDownNumberOfAxis";
            this.numericUpDownNumberOfAxis.Size = new System.Drawing.Size(111, 20);
            this.numericUpDownNumberOfAxis.TabIndex = 32;
            this.numericUpDownNumberOfAxis.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAxeNumber
            // 
            this.labelAxeNumber.AutoSize = true;
            this.labelAxeNumber.Location = new System.Drawing.Point(34, 156);
            this.labelAxeNumber.Name = "labelAxeNumber";
            this.labelAxeNumber.Size = new System.Drawing.Size(78, 13);
            this.labelAxeNumber.TabIndex = 33;
            this.labelAxeNumber.Text = "Number of Axis";
            // 
            // FormForPCAAxisGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 243);
            this.Controls.Add(this.labelAxeNumber);
            this.Controls.Add(this.numericUpDownNumberOfAxis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxForNeutralClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClassification);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormForPCAAxisGeneration";
            this.Text = "FormForPCAAxisGeneration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfAxis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxForNeutralClass;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonClassification;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioButtonFromFullScreening;
        public System.Windows.Forms.RadioButton radioButtonFromCurrentPlate;
        public System.Windows.Forms.NumericUpDown numericUpDownNumberOfAxis;
        public System.Windows.Forms.Label labelAxeNumber;
    }
}