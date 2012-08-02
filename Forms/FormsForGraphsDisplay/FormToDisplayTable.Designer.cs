namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    partial class FormToDisplayTable
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToDisplayTable));
            this.dataGridViewForTable = new System.Windows.Forms.DataGridView();
            this.chartForPoints = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripForGraph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applyClassificationModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClassificationTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxAxeX = new System.Windows.Forms.ComboBox();
            this.comboBoxAxeY = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxVolume = new System.Windows.Forms.ComboBox();
            this.checkBoxIsVolumeConstant = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartForPoints)).BeginInit();
            this.contextMenuStripForGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewForTable
            // 
            this.dataGridViewForTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewForTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForTable.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewForTable.Name = "dataGridViewForTable";
            this.dataGridViewForTable.Size = new System.Drawing.Size(457, 568);
            this.dataGridViewForTable.TabIndex = 0;
            // 
            // chartForPoints
            // 
            this.chartForPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartForPoints.ChartAreas.Add(chartArea1);
            this.chartForPoints.ContextMenuStrip = this.contextMenuStripForGraph;
            this.chartForPoints.Location = new System.Drawing.Point(3, 3);
            this.chartForPoints.Name = "chartForPoints";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.MarkerSize = 7;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "SeriesPts";
            this.chartForPoints.Series.Add(series1);
            this.chartForPoints.Size = new System.Drawing.Size(470, 489);
            this.chartForPoints.TabIndex = 1;
            this.chartForPoints.Text = "chart1";
            // 
            // contextMenuStripForGraph
            // 
            this.contextMenuStripForGraph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyClassificationModelToolStripMenuItem,
            this.showClassificationTreeToolStripMenuItem});
            this.contextMenuStripForGraph.Name = "contextMenuStripForGraph";
            this.contextMenuStripForGraph.Size = new System.Drawing.Size(216, 48);
            // 
            // applyClassificationModelToolStripMenuItem
            // 
            this.applyClassificationModelToolStripMenuItem.Name = "applyClassificationModelToolStripMenuItem";
            this.applyClassificationModelToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.applyClassificationModelToolStripMenuItem.Text = "Apply Classification Model";
            this.applyClassificationModelToolStripMenuItem.Click += new System.EventHandler(this.applyClassificationModelToolStripMenuItem_Click);
            // 
            // showClassificationTreeToolStripMenuItem
            // 
            this.showClassificationTreeToolStripMenuItem.Name = "showClassificationTreeToolStripMenuItem";
            this.showClassificationTreeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showClassificationTreeToolStripMenuItem.Text = "Show Classification Tree";
            this.showClassificationTreeToolStripMenuItem.Click += new System.EventHandler(this.showClassificationTreeToolStripMenuItem_Click);
            // 
            // comboBoxAxeX
            // 
            this.comboBoxAxeX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAxeX.FormattingEnabled = true;
            this.comboBoxAxeX.Location = new System.Drawing.Point(351, 498);
            this.comboBoxAxeX.Name = "comboBoxAxeX";
            this.comboBoxAxeX.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAxeX.TabIndex = 2;
            this.comboBoxAxeX.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxeX_SelectedIndexChanged);
            // 
            // comboBoxAxeY
            // 
            this.comboBoxAxeY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAxeY.FormattingEnabled = true;
            this.comboBoxAxeY.Location = new System.Drawing.Point(351, 525);
            this.comboBoxAxeY.Name = "comboBoxAxeY";
            this.comboBoxAxeY.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAxeY.TabIndex = 3;
            this.comboBoxAxeY.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxeY_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewForTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxIsVolumeConstant);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxVolume);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.chartForPoints);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxAxeY);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxAxeX);
            this.splitContainer1.Size = new System.Drawing.Size(943, 574);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Axis Y";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Axis X";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 555);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Volume";
            // 
            // comboBoxVolume
            // 
            this.comboBoxVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVolume.Enabled = false;
            this.comboBoxVolume.FormattingEnabled = true;
            this.comboBoxVolume.Location = new System.Drawing.Point(351, 552);
            this.comboBoxVolume.Name = "comboBoxVolume";
            this.comboBoxVolume.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVolume.TabIndex = 5;
            this.comboBoxVolume.SelectedIndexChanged += new System.EventHandler(this.comboBoxVolume_SelectedIndexChanged);
            // 
            // checkBoxIsVolumeConstant
            // 
            this.checkBoxIsVolumeConstant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIsVolumeConstant.AutoSize = true;
            this.checkBoxIsVolumeConstant.Checked = true;
            this.checkBoxIsVolumeConstant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsVolumeConstant.Location = new System.Drawing.Point(281, 554);
            this.checkBoxIsVolumeConstant.Name = "checkBoxIsVolumeConstant";
            this.checkBoxIsVolumeConstant.Size = new System.Drawing.Size(68, 17);
            this.checkBoxIsVolumeConstant.TabIndex = 7;
            this.checkBoxIsVolumeConstant.Text = "Constant";
            this.checkBoxIsVolumeConstant.UseVisualStyleBackColor = true;
            this.checkBoxIsVolumeConstant.CheckedChanged += new System.EventHandler(this.checkBoxIsVolumeConstant_CheckedChanged);
            // 
            // FormToDisplayTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 598);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToDisplayTable";
            this.Text = "FormToDisplayTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartForPoints)).EndInit();
            this.contextMenuStripForGraph.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewForTable;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartForPoints;
        public System.Windows.Forms.ComboBox comboBoxAxeX;
        public System.Windows.Forms.ComboBox comboBoxAxeY;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForGraph;
        private System.Windows.Forms.ToolStripMenuItem applyClassificationModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClassificationTreeToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxVolume;
        private System.Windows.Forms.CheckBox checkBoxIsVolumeConstant;


    }
}