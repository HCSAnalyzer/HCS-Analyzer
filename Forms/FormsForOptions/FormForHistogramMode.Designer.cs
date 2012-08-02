namespace HCSAnalyzer.Forms
{
    partial class FormForHistogramMode
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForHistogramMode));
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOriginalClass = new System.Windows.Forms.ComboBox();
            this.buttonMetric = new System.Windows.Forms.Button();
            this.chartForReference = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDownBinNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartForReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBinNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(39, 580);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(163, 32);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Class of Interest";
            // 
            // comboBoxOriginalClass
            // 
            this.comboBoxOriginalClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxOriginalClass.FormattingEnabled = true;
            this.comboBoxOriginalClass.Items.AddRange(new object[] {
            "Unselected (-1)",
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
            this.comboBoxOriginalClass.Location = new System.Drawing.Point(110, 30);
            this.comboBoxOriginalClass.Name = "comboBoxOriginalClass";
            this.comboBoxOriginalClass.Size = new System.Drawing.Size(139, 21);
            this.comboBoxOriginalClass.TabIndex = 5;
            this.comboBoxOriginalClass.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBoxOriginalClass_DrawItem);
            // 
            // buttonMetric
            // 
            this.buttonMetric.Location = new System.Drawing.Point(39, 78);
            this.buttonMetric.Name = "buttonMetric";
            this.buttonMetric.Size = new System.Drawing.Size(177, 32);
            this.buttonMetric.TabIndex = 7;
            this.buttonMetric.Text = "Metric";
            this.buttonMetric.UseVisualStyleBackColor = true;
            this.buttonMetric.Click += new System.EventHandler(this.buttonMetric_Click);
            // 
            // chartForReference
            // 
            chartArea1.Name = "ChartArea1";
            this.chartForReference.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartForReference.Legends.Add(legend1);
            this.chartForReference.Location = new System.Drawing.Point(284, 12);
            this.chartForReference.Name = "chartForReference";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartForReference.Series.Add(series1);
            this.chartForReference.Size = new System.Drawing.Size(531, 328);
            this.chartForReference.TabIndex = 8;
            // 
            // numericUpDownBinNumber
            // 
            this.numericUpDownBinNumber.Location = new System.Drawing.Point(110, 143);
            this.numericUpDownBinNumber.Name = "numericUpDownBinNumber";
            this.numericUpDownBinNumber.Size = new System.Drawing.Size(139, 20);
            this.numericUpDownBinNumber.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bin Number";
            // 
            // FormForHistogramMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 624);
            this.Controls.Add(this.numericUpDownBinNumber);
            this.Controls.Add(this.chartForReference);
            this.Controls.Add(this.buttonMetric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOriginalClass);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForHistogramMode";
            this.Text = "Histogram Mode";
            ((System.ComponentModel.ISupportInitialize)(this.chartForReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBinNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxOriginalClass;
        private System.Windows.Forms.Button buttonMetric;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartForReference;
        public System.Windows.Forms.NumericUpDown numericUpDownBinNumber;
        private System.Windows.Forms.Label label2;
    }
}