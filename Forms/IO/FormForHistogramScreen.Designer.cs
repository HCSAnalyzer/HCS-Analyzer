namespace HCSAnalyzer.Forms.IO
{
    partial class FormForHistogramScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForHistogramScreen));
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownHistogramSize = new System.Windows.Forms.NumericUpDown();
            this.groupBoxGeneralInfo = new System.Windows.Forms.GroupBox();
            this.numericUpDownPlateNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAddAsDescriptor = new System.Windows.Forms.CheckBox();
            this.numericUpDownPopulation1NumberOfEvents = new System.Windows.Forms.NumericUpDown();
            this.labelEventsPop1 = new System.Windows.Forms.Label();
            this.numericUpDownPopulation1Stdev = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPopulation1Mean = new System.Windows.Forms.NumericUpDown();
            this.labelMeanPop1 = new System.Windows.Forms.Label();
            this.labelStdevPop1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownPopulation2Mean = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPopulation2NumberOfEvents = new System.Windows.Forms.NumericUpDown();
            this.labelEventsPop2 = new System.Windows.Forms.Label();
            this.labelStdevPop2 = new System.Windows.Forms.Label();
            this.labelMeanPop2 = new System.Windows.Forms.Label();
            this.numericUpDownPopulation2Stdev = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistogramSize)).BeginInit();
            this.groupBoxGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlateNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation1NumberOfEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation1Stdev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation1Mean)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation2Mean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation2NumberOfEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation2Stdev)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGenerate.Location = new System.Drawing.Point(63, 576);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(185, 34);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Histogram Size";
            // 
            // numericUpDownHistogramSize
            // 
            this.numericUpDownHistogramSize.Location = new System.Drawing.Point(152, 184);
            this.numericUpDownHistogramSize.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownHistogramSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHistogramSize.Name = "numericUpDownHistogramSize";
            this.numericUpDownHistogramSize.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownHistogramSize.TabIndex = 2;
            this.numericUpDownHistogramSize.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // groupBoxGeneralInfo
            // 
            this.groupBoxGeneralInfo.Controls.Add(this.numericUpDownPlateNumber);
            this.groupBoxGeneralInfo.Controls.Add(this.label2);
            this.groupBoxGeneralInfo.Controls.Add(this.label3);
            this.groupBoxGeneralInfo.Controls.Add(this.numericUpDownRows);
            this.groupBoxGeneralInfo.Controls.Add(this.label4);
            this.groupBoxGeneralInfo.Controls.Add(this.numericUpDownColumns);
            this.groupBoxGeneralInfo.Location = new System.Drawing.Point(27, 50);
            this.groupBoxGeneralInfo.Name = "groupBoxGeneralInfo";
            this.groupBoxGeneralInfo.Size = new System.Drawing.Size(243, 119);
            this.groupBoxGeneralInfo.TabIndex = 21;
            this.groupBoxGeneralInfo.TabStop = false;
            this.groupBoxGeneralInfo.Text = "General";
            // 
            // numericUpDownPlateNumber
            // 
            this.numericUpDownPlateNumber.Location = new System.Drawing.Point(125, 27);
            this.numericUpDownPlateNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPlateNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPlateNumber.Name = "numericUpDownPlateNumber";
            this.numericUpDownPlateNumber.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPlateNumber.TabIndex = 2;
            this.numericUpDownPlateNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of Plates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Columns";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(125, 84);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownRows.TabIndex = 6;
            this.numericUpDownRows.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rows";
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(125, 58);
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownColumns.TabIndex = 5;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // checkBoxAddAsDescriptor
            // 
            this.checkBoxAddAsDescriptor.AutoSize = true;
            this.checkBoxAddAsDescriptor.Location = new System.Drawing.Point(92, 24);
            this.checkBoxAddAsDescriptor.Name = "checkBoxAddAsDescriptor";
            this.checkBoxAddAsDescriptor.Size = new System.Drawing.Size(110, 17);
            this.checkBoxAddAsDescriptor.TabIndex = 20;
            this.checkBoxAddAsDescriptor.Text = "As new descriptor";
            this.checkBoxAddAsDescriptor.UseVisualStyleBackColor = true;
            this.checkBoxAddAsDescriptor.CheckedChanged += new System.EventHandler(this.checkBoxAddAsDescriptor_CheckedChanged);
            // 
            // numericUpDownPopulation1NumberOfEvents
            // 
            this.numericUpDownPopulation1NumberOfEvents.Location = new System.Drawing.Point(125, 109);
            this.numericUpDownPopulation1NumberOfEvents.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownPopulation1NumberOfEvents.Name = "numericUpDownPopulation1NumberOfEvents";
            this.numericUpDownPopulation1NumberOfEvents.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPopulation1NumberOfEvents.TabIndex = 23;
            this.numericUpDownPopulation1NumberOfEvents.ThousandsSeparator = true;
            this.numericUpDownPopulation1NumberOfEvents.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // labelEventsPop1
            // 
            this.labelEventsPop1.AutoSize = true;
            this.labelEventsPop1.Location = new System.Drawing.Point(16, 111);
            this.labelEventsPop1.Name = "labelEventsPop1";
            this.labelEventsPop1.Size = new System.Drawing.Size(91, 13);
            this.labelEventsPop1.TabIndex = 22;
            this.labelEventsPop1.Text = "Number of events";
            this.labelEventsPop1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelEventsPop1_MouseClick);
            // 
            // numericUpDownPopulation1Stdev
            // 
            this.numericUpDownPopulation1Stdev.DecimalPlaces = 1;
            this.numericUpDownPopulation1Stdev.Location = new System.Drawing.Point(125, 69);
            this.numericUpDownPopulation1Stdev.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownPopulation1Stdev.Name = "numericUpDownPopulation1Stdev";
            this.numericUpDownPopulation1Stdev.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPopulation1Stdev.TabIndex = 24;
            this.numericUpDownPopulation1Stdev.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDownPopulation1Mean
            // 
            this.numericUpDownPopulation1Mean.DecimalPlaces = 1;
            this.numericUpDownPopulation1Mean.Location = new System.Drawing.Point(125, 36);
            this.numericUpDownPopulation1Mean.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownPopulation1Mean.Name = "numericUpDownPopulation1Mean";
            this.numericUpDownPopulation1Mean.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPopulation1Mean.TabIndex = 26;
            this.numericUpDownPopulation1Mean.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // labelMeanPop1
            // 
            this.labelMeanPop1.AutoSize = true;
            this.labelMeanPop1.Location = new System.Drawing.Point(44, 38);
            this.labelMeanPop1.Name = "labelMeanPop1";
            this.labelMeanPop1.Size = new System.Drawing.Size(34, 13);
            this.labelMeanPop1.TabIndex = 25;
            this.labelMeanPop1.Text = "Mean";
            this.labelMeanPop1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMeanPop1_MouseClick);
            // 
            // labelStdevPop1
            // 
            this.labelStdevPop1.AutoSize = true;
            this.labelStdevPop1.Location = new System.Drawing.Point(12, 71);
            this.labelStdevPop1.Name = "labelStdevPop1";
            this.labelStdevPop1.Size = new System.Drawing.Size(98, 13);
            this.labelStdevPop1.TabIndex = 27;
            this.labelStdevPop1.Text = "Standard Deviation";
            this.labelStdevPop1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelStdevPop1_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownPopulation1Mean);
            this.groupBox1.Controls.Add(this.numericUpDownPopulation1NumberOfEvents);
            this.groupBox1.Controls.Add(this.labelEventsPop1);
            this.groupBox1.Controls.Add(this.labelStdevPop1);
            this.groupBox1.Controls.Add(this.labelMeanPop1);
            this.groupBox1.Controls.Add(this.numericUpDownPopulation1Stdev);
            this.groupBox1.Location = new System.Drawing.Point(27, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 157);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Population 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownPopulation2Mean);
            this.groupBox2.Controls.Add(this.numericUpDownPopulation2NumberOfEvents);
            this.groupBox2.Controls.Add(this.labelEventsPop2);
            this.groupBox2.Controls.Add(this.labelStdevPop2);
            this.groupBox2.Controls.Add(this.labelMeanPop2);
            this.groupBox2.Controls.Add(this.numericUpDownPopulation2Stdev);
            this.groupBox2.Location = new System.Drawing.Point(29, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 157);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Population 2";
            // 
            // numericUpDownPopulation2Mean
            // 
            this.numericUpDownPopulation2Mean.DecimalPlaces = 1;
            this.numericUpDownPopulation2Mean.Location = new System.Drawing.Point(125, 36);
            this.numericUpDownPopulation2Mean.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownPopulation2Mean.Name = "numericUpDownPopulation2Mean";
            this.numericUpDownPopulation2Mean.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPopulation2Mean.TabIndex = 26;
            this.numericUpDownPopulation2Mean.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // numericUpDownPopulation2NumberOfEvents
            // 
            this.numericUpDownPopulation2NumberOfEvents.Location = new System.Drawing.Point(125, 109);
            this.numericUpDownPopulation2NumberOfEvents.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numericUpDownPopulation2NumberOfEvents.Name = "numericUpDownPopulation2NumberOfEvents";
            this.numericUpDownPopulation2NumberOfEvents.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPopulation2NumberOfEvents.TabIndex = 23;
            this.numericUpDownPopulation2NumberOfEvents.ThousandsSeparator = true;
            this.numericUpDownPopulation2NumberOfEvents.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // labelEventsPop2
            // 
            this.labelEventsPop2.AutoSize = true;
            this.labelEventsPop2.Location = new System.Drawing.Point(16, 111);
            this.labelEventsPop2.Name = "labelEventsPop2";
            this.labelEventsPop2.Size = new System.Drawing.Size(91, 13);
            this.labelEventsPop2.TabIndex = 22;
            this.labelEventsPop2.Text = "Number of events";
            this.labelEventsPop2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelEventsPop2_MouseClick);
            // 
            // labelStdevPop2
            // 
            this.labelStdevPop2.AutoSize = true;
            this.labelStdevPop2.Location = new System.Drawing.Point(12, 71);
            this.labelStdevPop2.Name = "labelStdevPop2";
            this.labelStdevPop2.Size = new System.Drawing.Size(98, 13);
            this.labelStdevPop2.TabIndex = 27;
            this.labelStdevPop2.Text = "Standard Deviation";
            this.labelStdevPop2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelStdevPop2_MouseClick);
            // 
            // labelMeanPop2
            // 
            this.labelMeanPop2.AutoSize = true;
            this.labelMeanPop2.Location = new System.Drawing.Point(44, 38);
            this.labelMeanPop2.Name = "labelMeanPop2";
            this.labelMeanPop2.Size = new System.Drawing.Size(34, 13);
            this.labelMeanPop2.TabIndex = 25;
            this.labelMeanPop2.Text = "Mean";
            this.labelMeanPop2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelMeanPop2_MouseClick);
            // 
            // numericUpDownPopulation2Stdev
            // 
            this.numericUpDownPopulation2Stdev.DecimalPlaces = 1;
            this.numericUpDownPopulation2Stdev.Location = new System.Drawing.Point(125, 69);
            this.numericUpDownPopulation2Stdev.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownPopulation2Stdev.Name = "numericUpDownPopulation2Stdev";
            this.numericUpDownPopulation2Stdev.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownPopulation2Stdev.TabIndex = 24;
            this.numericUpDownPopulation2Stdev.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // FormForHistogramScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 622);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxGeneralInfo);
            this.Controls.Add(this.checkBoxAddAsDescriptor);
            this.Controls.Add(this.numericUpDownHistogramSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForHistogramScreen";
            this.Text = "Histogram based Screening";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistogramSize)).EndInit();
            this.groupBoxGeneralInfo.ResumeLayout(false);
            this.groupBoxGeneralInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlateNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation1NumberOfEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation1Stdev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation1Mean)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation2Mean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation2NumberOfEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation2Stdev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericUpDownHistogramSize;
        private System.Windows.Forms.GroupBox groupBoxGeneralInfo;
        public System.Windows.Forms.NumericUpDown numericUpDownPlateNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown numericUpDownColumns;
        public System.Windows.Forms.CheckBox checkBoxAddAsDescriptor;
        public System.Windows.Forms.NumericUpDown numericUpDownPopulation1NumberOfEvents;
        private System.Windows.Forms.Label labelEventsPop1;
        public System.Windows.Forms.NumericUpDown numericUpDownPopulation1Stdev;
        public System.Windows.Forms.NumericUpDown numericUpDownPopulation1Mean;
        private System.Windows.Forms.Label labelMeanPop1;
        private System.Windows.Forms.Label labelStdevPop1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.NumericUpDown numericUpDownPopulation2Mean;
        public System.Windows.Forms.NumericUpDown numericUpDownPopulation2NumberOfEvents;
        private System.Windows.Forms.Label labelEventsPop2;
        private System.Windows.Forms.Label labelStdevPop2;
        private System.Windows.Forms.Label labelMeanPop2;
        public System.Windows.Forms.NumericUpDown numericUpDownPopulation2Stdev;
    }
}