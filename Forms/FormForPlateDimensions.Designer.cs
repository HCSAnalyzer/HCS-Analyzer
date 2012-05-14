namespace HCSAnalyzer.Forms
{
    partial class FormForPlateDimensions
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHistoSize = new System.Windows.Forms.NumericUpDown();
            this.labelHisto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistoSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(39, 124);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(124, 32);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rows";
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(96, 15);
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
            this.numericUpDownColumns.TabIndex = 1;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(96, 41);
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
            this.numericUpDownRows.TabIndex = 2;
            this.numericUpDownRows.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numericUpDownHistoSize
            // 
            this.numericUpDownHistoSize.Location = new System.Drawing.Point(96, 86);
            this.numericUpDownHistoSize.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownHistoSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHistoSize.Name = "numericUpDownHistoSize";
            this.numericUpDownHistoSize.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownHistoSize.TabIndex = 5;
            this.numericUpDownHistoSize.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownHistoSize.Visible = false;
            // 
            // labelHisto
            // 
            this.labelHisto.AutoSize = true;
            this.labelHisto.Location = new System.Drawing.Point(21, 88);
            this.labelHisto.Name = "labelHisto";
            this.labelHisto.Size = new System.Drawing.Size(57, 13);
            this.labelHisto.TabIndex = 4;
            this.labelHisto.Text = "Histo. Size";
            this.labelHisto.Visible = false;
            // 
            // FormForPlateDimensions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 168);
            this.Controls.Add(this.numericUpDownHistoSize);
            this.Controls.Add(this.labelHisto);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.numericUpDownColumns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormForPlateDimensions";
            this.Text = "Plate Dimensions";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistoSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericUpDownColumns;
        public System.Windows.Forms.NumericUpDown numericUpDownRows;
        public System.Windows.Forms.NumericUpDown numericUpDownHistoSize;
        public System.Windows.Forms.Label labelHisto;
    }
}