namespace HCSAnalyzer.Forms.FormsForGraphsDisplay
{
    partial class FormForSingleCellsDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForSingleCellsDisplay));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartForPoints = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripForSingleCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mINEAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxAxeY = new System.Windows.Forms.ComboBox();
            this.comboBoxAxeX = new System.Windows.Forms.ComboBox();
            this.buttonStartCluster = new System.Windows.Forms.Button();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pointSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chartForPoints)).BeginInit();
            this.contextMenuStripForSingleCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(532, 594);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Axis Y";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 567);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Axis X";
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
            this.chartForPoints.ContextMenuStrip = this.contextMenuStripForSingleCell;
            this.chartForPoints.Location = new System.Drawing.Point(12, 3);
            this.chartForPoints.Name = "chartForPoints";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "SeriesPts";
            this.chartForPoints.Series.Add(series1);
            this.chartForPoints.Size = new System.Drawing.Size(696, 555);
            this.chartForPoints.TabIndex = 5;
            this.chartForPoints.Text = "chart1";
            // 
            // contextMenuStripForSingleCell
            // 
            this.contextMenuStripForSingleCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem,
            this.toolStripSeparator1,
            this.mINEAnalysisToolStripMenuItem});
            this.contextMenuStripForSingleCell.Name = "contextMenuStripForSingleCell";
            this.contextMenuStripForSingleCell.Size = new System.Drawing.Size(153, 76);
            // 
            // mINEAnalysisToolStripMenuItem
            // 
            this.mINEAnalysisToolStripMenuItem.Name = "mINEAnalysisToolStripMenuItem";
            this.mINEAnalysisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mINEAnalysisToolStripMenuItem.Text = "MINE analysis";
            this.mINEAnalysisToolStripMenuItem.Click += new System.EventHandler(this.mINEAnalysisToolStripMenuItem_Click);
            // 
            // comboBoxAxeY
            // 
            this.comboBoxAxeY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAxeY.FormattingEnabled = true;
            this.comboBoxAxeY.Location = new System.Drawing.Point(587, 591);
            this.comboBoxAxeY.Name = "comboBoxAxeY";
            this.comboBoxAxeY.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAxeY.TabIndex = 7;
            this.comboBoxAxeY.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxeY_SelectedIndexChanged);
            // 
            // comboBoxAxeX
            // 
            this.comboBoxAxeX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAxeX.FormattingEnabled = true;
            this.comboBoxAxeX.Location = new System.Drawing.Point(587, 564);
            this.comboBoxAxeX.Name = "comboBoxAxeX";
            this.comboBoxAxeX.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAxeX.TabIndex = 6;
            this.comboBoxAxeX.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxeX_SelectedIndexChanged);
            // 
            // buttonStartCluster
            // 
            this.buttonStartCluster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartCluster.Location = new System.Drawing.Point(12, 570);
            this.buttonStartCluster.Name = "buttonStartCluster";
            this.buttonStartCluster.Size = new System.Drawing.Size(79, 39);
            this.buttonStartCluster.TabIndex = 10;
            this.buttonStartCluster.Text = "Cluster";
            this.buttonStartCluster.UseVisualStyleBackColor = true;
            this.buttonStartCluster.Click += new System.EventHandler(this.buttonStartCluster_Click);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointSizeToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // pointSizeToolStripMenuItem
            // 
            this.pointSizeToolStripMenuItem.Name = "pointSizeToolStripMenuItem";
            this.pointSizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pointSizeToolStripMenuItem.Text = "Point Size";
            this.pointSizeToolStripMenuItem.Click += new System.EventHandler(this.pointSizeToolStripMenuItem_Click);
            // 
            // FormForSingleCellsDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 618);
            this.Controls.Add(this.buttonStartCluster);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartForPoints);
            this.Controls.Add(this.comboBoxAxeY);
            this.Controls.Add(this.comboBoxAxeX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForSingleCellsDisplay";
            this.Text = "FormForSingleCellsDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.chartForPoints)).EndInit();
            this.contextMenuStripForSingleCell.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartForPoints;
        public System.Windows.Forms.ComboBox comboBoxAxeY;
        public System.Windows.Forms.ComboBox comboBoxAxeX;
        private System.Windows.Forms.Button buttonStartCluster;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForSingleCell;
        private System.Windows.Forms.ToolStripMenuItem mINEAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}