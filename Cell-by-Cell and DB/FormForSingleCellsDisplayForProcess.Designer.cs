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
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markerBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mINEAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptorsAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correlationMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxAxeY = new System.Windows.Forms.ComboBox();
            this.comboBoxAxeX = new System.Windows.Forms.ComboBox();
            this.buttonStartCluster = new System.Windows.Forms.Button();
            this.splitContainerForCellByCellAnalysis = new System.Windows.Forms.SplitContainer();
            this.splitContainerHorizontal = new System.Windows.Forms.SplitContainer();
            this.splitContainerVertical = new System.Windows.Forms.SplitContainer();
            this.buttonCollapseHorizontal = new System.Windows.Forms.Button();
            this.buttonCollapseVertical = new System.Windows.Forms.Button();
            this.splitContainerForResults = new System.Windows.Forms.SplitContainer();
            this.richTextBoxForResults = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripForRichTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelForGraphicalResults = new System.Windows.Forms.Panel();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.toolTipForTraining = new System.Windows.Forms.ToolTip(this.components);
            this.buttonClassify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.classificationModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxIsVolumeConstant = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVolume = new System.Windows.Forms.ComboBox();
            this.splitContainerForParam = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.chartForPoints)).BeginInit();
            this.contextMenuStripForSingleCell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForCellByCellAnalysis)).BeginInit();
            this.splitContainerForCellByCellAnalysis.Panel1.SuspendLayout();
            this.splitContainerForCellByCellAnalysis.Panel2.SuspendLayout();
            this.splitContainerForCellByCellAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).BeginInit();
            this.splitContainerHorizontal.Panel2.SuspendLayout();
            this.splitContainerHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).BeginInit();
            this.splitContainerVertical.Panel1.SuspendLayout();
            this.splitContainerVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForResults)).BeginInit();
            this.splitContainerForResults.Panel1.SuspendLayout();
            this.splitContainerForResults.Panel2.SuspendLayout();
            this.splitContainerForResults.SuspendLayout();
            this.contextMenuStripForRichTextBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForParam)).BeginInit();
            this.splitContainerForParam.Panel1.SuspendLayout();
            this.splitContainerForParam.Panel2.SuspendLayout();
            this.splitContainerForParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Axis Y";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 5);
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
            this.chartForPoints.Location = new System.Drawing.Point(3, 3);
            this.chartForPoints.Name = "chartForPoints";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "SeriesPts";
            this.chartForPoints.Series.Add(series1);
            this.chartForPoints.Size = new System.Drawing.Size(361, 329);
            this.chartForPoints.TabIndex = 5;
            this.chartForPoints.Text = "chart1";
            this.chartForPoints.Resize += new System.EventHandler(this.chartForPoints_Resize);
            // 
            // contextMenuStripForSingleCell
            // 
            this.contextMenuStripForSingleCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem,
            this.toolStripSeparator1,
            this.mINEAnalysisToolStripMenuItem,
            this.descriptorsAnalysisToolStripMenuItem});
            this.contextMenuStripForSingleCell.Name = "contextMenuStripForSingleCell";
            this.contextMenuStripForSingleCell.Size = new System.Drawing.Size(180, 76);
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointSizeToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.markerBorderToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // pointSizeToolStripMenuItem
            // 
            this.pointSizeToolStripMenuItem.Name = "pointSizeToolStripMenuItem";
            this.pointSizeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.pointSizeToolStripMenuItem.Text = "Point Size";
            this.pointSizeToolStripMenuItem.Click += new System.EventHandler(this.pointSizeToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // markerBorderToolStripMenuItem
            // 
            this.markerBorderToolStripMenuItem.Checked = true;
            this.markerBorderToolStripMenuItem.CheckOnClick = true;
            this.markerBorderToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.markerBorderToolStripMenuItem.Name = "markerBorderToolStripMenuItem";
            this.markerBorderToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.markerBorderToolStripMenuItem.Text = "Marker Border";
            this.markerBorderToolStripMenuItem.Click += new System.EventHandler(this.markerBorderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // mINEAnalysisToolStripMenuItem
            // 
            this.mINEAnalysisToolStripMenuItem.Enabled = false;
            this.mINEAnalysisToolStripMenuItem.Name = "mINEAnalysisToolStripMenuItem";
            this.mINEAnalysisToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.mINEAnalysisToolStripMenuItem.Text = "MINE analysis";
            this.mINEAnalysisToolStripMenuItem.Click += new System.EventHandler(this.mINEAnalysisToolStripMenuItem_Click);
            // 
            // descriptorsAnalysisToolStripMenuItem
            // 
            this.descriptorsAnalysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correlationMatrixToolStripMenuItem});
            this.descriptorsAnalysisToolStripMenuItem.Name = "descriptorsAnalysisToolStripMenuItem";
            this.descriptorsAnalysisToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.descriptorsAnalysisToolStripMenuItem.Text = "Descriptors Analysis";
            // 
            // correlationMatrixToolStripMenuItem
            // 
            this.correlationMatrixToolStripMenuItem.Name = "correlationMatrixToolStripMenuItem";
            this.correlationMatrixToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.correlationMatrixToolStripMenuItem.Text = "Correlation Matrix";
            this.correlationMatrixToolStripMenuItem.Click += new System.EventHandler(this.correlationMatrixToolStripMenuItem_Click);
            // 
            // comboBoxAxeY
            // 
            this.comboBoxAxeY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAxeY.FormattingEnabled = true;
            this.comboBoxAxeY.Location = new System.Drawing.Point(95, 28);
            this.comboBoxAxeY.Name = "comboBoxAxeY";
            this.comboBoxAxeY.Size = new System.Drawing.Size(167, 21);
            this.comboBoxAxeY.TabIndex = 7;
            this.comboBoxAxeY.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxeY_SelectedIndexChanged);
            // 
            // comboBoxAxeX
            // 
            this.comboBoxAxeX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAxeX.FormattingEnabled = true;
            this.comboBoxAxeX.Location = new System.Drawing.Point(95, 2);
            this.comboBoxAxeX.Name = "comboBoxAxeX";
            this.comboBoxAxeX.Size = new System.Drawing.Size(167, 21);
            this.comboBoxAxeX.TabIndex = 6;
            this.comboBoxAxeX.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxeX_SelectedIndexChanged);
            // 
            // buttonStartCluster
            // 
            this.buttonStartCluster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartCluster.Location = new System.Drawing.Point(16, 32);
            this.buttonStartCluster.Name = "buttonStartCluster";
            this.buttonStartCluster.Size = new System.Drawing.Size(79, 39);
            this.buttonStartCluster.TabIndex = 10;
            this.buttonStartCluster.Text = "Cluster";
            this.toolTipForTraining.SetToolTip(this.buttonStartCluster, "Perform automated clustering of the data");
            this.buttonStartCluster.UseVisualStyleBackColor = true;
            this.buttonStartCluster.Click += new System.EventHandler(this.buttonStartCluster_Click);
            // 
            // splitContainerForCellByCellAnalysis
            // 
            this.splitContainerForCellByCellAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerForCellByCellAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerForCellByCellAnalysis.Location = new System.Drawing.Point(3, 27);
            this.splitContainerForCellByCellAnalysis.Name = "splitContainerForCellByCellAnalysis";
            // 
            // splitContainerForCellByCellAnalysis.Panel1
            // 
            this.splitContainerForCellByCellAnalysis.Panel1.Controls.Add(this.splitContainerHorizontal);
            // 
            // splitContainerForCellByCellAnalysis.Panel2
            // 
            this.splitContainerForCellByCellAnalysis.Panel2.Controls.Add(this.splitContainerForResults);
            this.splitContainerForCellByCellAnalysis.Size = new System.Drawing.Size(834, 385);
            this.splitContainerForCellByCellAnalysis.SplitterDistance = 564;
            this.splitContainerForCellByCellAnalysis.TabIndex = 11;
            // 
            // splitContainerHorizontal
            // 
            this.splitContainerHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerHorizontal.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerHorizontal.Location = new System.Drawing.Point(3, 1);
            this.splitContainerHorizontal.Name = "splitContainerHorizontal";
            // 
            // splitContainerHorizontal.Panel2
            // 
            this.splitContainerHorizontal.Panel2.Controls.Add(this.splitContainerVertical);
            this.splitContainerHorizontal.Size = new System.Drawing.Size(556, 381);
            this.splitContainerHorizontal.SplitterDistance = 185;
            this.splitContainerHorizontal.TabIndex = 8;
            // 
            // splitContainerVertical
            // 
            this.splitContainerVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVertical.Name = "splitContainerVertical";
            this.splitContainerVertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerVertical.Panel1
            // 
            this.splitContainerVertical.Panel1.Controls.Add(this.buttonCollapseHorizontal);
            this.splitContainerVertical.Panel1.Controls.Add(this.buttonCollapseVertical);
            this.splitContainerVertical.Panel1.Controls.Add(this.chartForPoints);
            this.splitContainerVertical.Size = new System.Drawing.Size(367, 381);
            this.splitContainerVertical.SplitterDistance = 335;
            this.splitContainerVertical.TabIndex = 0;
            // 
            // buttonCollapseHorizontal
            // 
            this.buttonCollapseHorizontal.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCollapseHorizontal.BackgroundImage = global::HCSAnalyzer.Properties.Resources.Arrow;
            this.buttonCollapseHorizontal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCollapseHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollapseHorizontal.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCollapseHorizontal.Location = new System.Drawing.Point(3, 3);
            this.buttonCollapseHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCollapseHorizontal.Name = "buttonCollapseHorizontal";
            this.buttonCollapseHorizontal.Size = new System.Drawing.Size(27, 23);
            this.buttonCollapseHorizontal.TabIndex = 6;
            this.buttonCollapseHorizontal.UseVisualStyleBackColor = false;
            this.buttonCollapseHorizontal.Click += new System.EventHandler(this.buttonCollapseHorizontal_Click);
            // 
            // buttonCollapseVertical
            // 
            this.buttonCollapseVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCollapseVertical.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCollapseVertical.BackgroundImage = global::HCSAnalyzer.Properties.Resources.Arrow;
            this.buttonCollapseVertical.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCollapseVertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollapseVertical.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCollapseVertical.Location = new System.Drawing.Point(337, 309);
            this.buttonCollapseVertical.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCollapseVertical.Name = "buttonCollapseVertical";
            this.buttonCollapseVertical.Size = new System.Drawing.Size(27, 23);
            this.buttonCollapseVertical.TabIndex = 7;
            this.buttonCollapseVertical.UseVisualStyleBackColor = false;
            this.buttonCollapseVertical.Click += new System.EventHandler(this.buttonCollapseVertical_Click);
            // 
            // splitContainerForResults
            // 
            this.splitContainerForResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerForResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerForResults.Location = new System.Drawing.Point(3, 3);
            this.splitContainerForResults.Name = "splitContainerForResults";
            this.splitContainerForResults.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerForResults.Panel1
            // 
            this.splitContainerForResults.Panel1.Controls.Add(this.richTextBoxForResults);
            // 
            // splitContainerForResults.Panel2
            // 
            this.splitContainerForResults.Panel2.Controls.Add(this.panelForGraphicalResults);
            this.splitContainerForResults.Size = new System.Drawing.Size(258, 377);
            this.splitContainerForResults.SplitterDistance = 185;
            this.splitContainerForResults.TabIndex = 2;
            // 
            // richTextBoxForResults
            // 
            this.richTextBoxForResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxForResults.ContextMenuStrip = this.contextMenuStripForRichTextBox;
            this.richTextBoxForResults.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxForResults.Name = "richTextBoxForResults";
            this.richTextBoxForResults.ReadOnly = true;
            this.richTextBoxForResults.Size = new System.Drawing.Size(250, 177);
            this.richTextBoxForResults.TabIndex = 0;
            this.richTextBoxForResults.Text = "";
            // 
            // contextMenuStripForRichTextBox
            // 
            this.contextMenuStripForRichTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanToolStripMenuItem});
            this.contextMenuStripForRichTextBox.Name = "contextMenuStripForRichTextBox";
            this.contextMenuStripForRichTextBox.Size = new System.Drawing.Size(102, 26);
            // 
            // cleanToolStripMenuItem
            // 
            this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
            this.cleanToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.cleanToolStripMenuItem.Text = "Clear";
            this.cleanToolStripMenuItem.Click += new System.EventHandler(this.cleanToolStripMenuItem_Click);
            // 
            // panelForGraphicalResults
            // 
            this.panelForGraphicalResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForGraphicalResults.AutoScroll = true;
            this.panelForGraphicalResults.Location = new System.Drawing.Point(3, 3);
            this.panelForGraphicalResults.Name = "panelForGraphicalResults";
            this.panelForGraphicalResults.Size = new System.Drawing.Size(250, 180);
            this.panelForGraphicalResults.TabIndex = 1;
            // 
            // buttonTraining
            // 
            this.buttonTraining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTraining.Location = new System.Drawing.Point(116, 33);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(79, 39);
            this.buttonTraining.TabIndex = 13;
            this.buttonTraining.Text = "Training";
            this.toolTipForTraining.SetToolTip(this.buttonTraining, "Generate a training model based on the clustering");
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // buttonClassify
            // 
            this.buttonClassify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClassify.Enabled = false;
            this.buttonClassify.Location = new System.Drawing.Point(218, 32);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(79, 39);
            this.buttonClassify.TabIndex = 14;
            this.buttonClassify.Text = "Classify";
            this.toolTipForTraining.SetToolTip(this.buttonClassify, "Classify every cell from the entire screening");
            this.buttonClassify.UseVisualStyleBackColor = true;
            this.buttonClassify.Click += new System.EventHandler(this.buttonClassify_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "2";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "3";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classificationModelsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(840, 24);
            this.menuStrip.TabIndex = 16;
            this.menuStrip.Text = "menuStrip1";
            // 
            // classificationModelsToolStripMenuItem
            // 
            this.classificationModelsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToolStripMenuItem});
            this.classificationModelsToolStripMenuItem.Name = "classificationModelsToolStripMenuItem";
            this.classificationModelsToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.classificationModelsToolStripMenuItem.Text = "Model Optimization";
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // checkBoxIsVolumeConstant
            // 
            this.checkBoxIsVolumeConstant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxIsVolumeConstant.AutoSize = true;
            this.checkBoxIsVolumeConstant.Checked = true;
            this.checkBoxIsVolumeConstant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsVolumeConstant.Location = new System.Drawing.Point(22, 56);
            this.checkBoxIsVolumeConstant.Name = "checkBoxIsVolumeConstant";
            this.checkBoxIsVolumeConstant.Size = new System.Drawing.Size(68, 17);
            this.checkBoxIsVolumeConstant.TabIndex = 19;
            this.checkBoxIsVolumeConstant.Text = "Constant";
            this.checkBoxIsVolumeConstant.UseVisualStyleBackColor = true;
            this.checkBoxIsVolumeConstant.CheckedChanged += new System.EventHandler(this.checkBoxIsVolumeConstant_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(599, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Area";
            // 
            // comboBoxVolume
            // 
            this.comboBoxVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVolume.Enabled = false;
            this.comboBoxVolume.FormattingEnabled = true;
            this.comboBoxVolume.Location = new System.Drawing.Point(96, 53);
            this.comboBoxVolume.Name = "comboBoxVolume";
            this.comboBoxVolume.Size = new System.Drawing.Size(166, 21);
            this.comboBoxVolume.TabIndex = 17;
            this.comboBoxVolume.SelectedIndexChanged += new System.EventHandler(this.comboBoxVolume_SelectedIndexChanged);
            // 
            // splitContainerForParam
            // 
            this.splitContainerForParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerForParam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerForParam.Location = new System.Drawing.Point(3, 416);
            this.splitContainerForParam.Name = "splitContainerForParam";
            // 
            // splitContainerForParam.Panel1
            // 
            this.splitContainerForParam.Panel1.Controls.Add(this.buttonClassify);
            this.splitContainerForParam.Panel1.Controls.Add(this.label5);
            this.splitContainerForParam.Panel1.Controls.Add(this.buttonTraining);
            this.splitContainerForParam.Panel1.Controls.Add(this.label4);
            this.splitContainerForParam.Panel1.Controls.Add(this.buttonStartCluster);
            this.splitContainerForParam.Panel1.Controls.Add(this.label3);
            this.splitContainerForParam.Panel1MinSize = 300;
            // 
            // splitContainerForParam.Panel2
            // 
            this.splitContainerForParam.Panel2.Controls.Add(this.comboBoxAxeX);
            this.splitContainerForParam.Panel2.Controls.Add(this.comboBoxAxeY);
            this.splitContainerForParam.Panel2.Controls.Add(this.label1);
            this.splitContainerForParam.Panel2.Controls.Add(this.checkBoxIsVolumeConstant);
            this.splitContainerForParam.Panel2.Controls.Add(this.label2);
            this.splitContainerForParam.Panel2.Controls.Add(this.comboBoxVolume);
            this.splitContainerForParam.Size = new System.Drawing.Size(834, 80);
            this.splitContainerForParam.SplitterDistance = 561;
            this.splitContainerForParam.TabIndex = 20;
            // 
            // FormForSingleCellsDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 498);
            this.Controls.Add(this.splitContainerForParam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.splitContainerForCellByCellAnalysis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForSingleCellsDisplay";
            this.Text = "Single cell analysis";
            ((System.ComponentModel.ISupportInitialize)(this.chartForPoints)).EndInit();
            this.contextMenuStripForSingleCell.ResumeLayout(false);
            this.splitContainerForCellByCellAnalysis.Panel1.ResumeLayout(false);
            this.splitContainerForCellByCellAnalysis.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForCellByCellAnalysis)).EndInit();
            this.splitContainerForCellByCellAnalysis.ResumeLayout(false);
            this.splitContainerHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).EndInit();
            this.splitContainerHorizontal.ResumeLayout(false);
            this.splitContainerVertical.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).EndInit();
            this.splitContainerVertical.ResumeLayout(false);
            this.splitContainerForResults.Panel1.ResumeLayout(false);
            this.splitContainerForResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForResults)).EndInit();
            this.splitContainerForResults.ResumeLayout(false);
            this.contextMenuStripForRichTextBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerForParam.Panel1.ResumeLayout(false);
            this.splitContainerForParam.Panel1.PerformLayout();
            this.splitContainerForParam.Panel2.ResumeLayout(false);
            this.splitContainerForParam.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerForParam)).EndInit();
            this.splitContainerForParam.ResumeLayout(false);
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
        public System.Windows.Forms.SplitContainer splitContainerForCellByCellAnalysis;
        public System.Windows.Forms.RichTextBox richTextBoxForResults;
        private System.Windows.Forms.SplitContainer splitContainerForResults;
        private System.Windows.Forms.Panel panelForGraphicalResults;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem cleanToolStripMenuItem;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.ToolTip toolTipForTraining;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.Button buttonClassify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem classificationModelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxIsVolumeConstant;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboBoxVolume;
        private System.Windows.Forms.Button buttonCollapseHorizontal;
        private System.Windows.Forms.Button buttonCollapseVertical;
        private System.Windows.Forms.SplitContainer splitContainerHorizontal;
        private System.Windows.Forms.SplitContainer splitContainerVertical;
        private System.Windows.Forms.ToolStripMenuItem markerBorderToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerForParam;
        private System.Windows.Forms.ToolStripMenuItem descriptorsAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correlationMatrixToolStripMenuItem;
    }
}